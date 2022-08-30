using ECommercePlateform.Data;
using ECommercePlateform.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
	.AddRoles<IdentityRole>()
	.AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
	var services = scope.ServiceProvider;
	var loggerFactory = services.GetRequiredService<ILoggerFactory>();
	var context = services.GetRequiredService<ApplicationDbContext>();
	context.Database.Migrate();
	var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
	var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
	var testUserPw = builder.Configuration.GetValue<string>("SeedUserPW");
	await ContextSeed.SeedRolesAsync(userManager, roleManager);
	await ContextSeed.SeedAdminAsync(userManager, roleManager, testUserPw);
	await ContextSeed.SeedClientAsync(userManager, roleManager, testUserPw);
	await ContextSeed.SeedDBAsync(context);

}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseMigrationsEndPoint();
}
else
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
