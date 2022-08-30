using ECommercePlateform.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace ECommercePlateform.Data
{
    public class ContextSeed
    {
        public static async Task SeedRolesAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Roles
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Client.ToString()));
        }

        public static byte[] GetImage(string path)
        {
            byte[] image = null;
            FileInfo fileInfo = new FileInfo(path);
            long numBytes = fileInfo.Length;

            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            image = br.ReadBytes((int)numBytes);
            return image;
        }

        public static async Task SeedAdminAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, string defaultPw)
        {
            //Seed Default Admin
            var defaultAdmin = new ApplicationUser
            {
                UserName = "Administrator",
                Email = "admin@gmail.com",
                FirstName = "Joe",
                LastName = "Blow",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != defaultAdmin.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultAdmin.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultAdmin, defaultPw);
                    await userManager.AddToRoleAsync(defaultAdmin, Enums.Roles.Admin.ToString());
                }

            }
        }

        public static async Task SeedClientAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, string defaultPw)
        {
            //Seed Default Client
            var defaultClient = new ApplicationUser
            {
                UserName = "Client1",
                Email = "default_client@gmail.com",
                FirstName = "Joe",
                LastName = "Louis",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };

            var user = await userManager.FindByNameAsync(defaultClient.UserName);
            if (user == null)
            {
                await userManager.CreateAsync(defaultClient, defaultPw);
                await userManager.AddToRoleAsync(defaultClient, Enums.Roles.Client.ToString());
            }
            
            else
            {
                throw new Exception("The user already exists");
            }
            
 
        }

        public static async Task SeedDBAsync(ApplicationDbContext context)
        {

            if (!context.Categories.Any())
            {
            context.Categories.AddRange(
                new Category
                {
                    CategoryName = "Headphones",
                    Description = "",
                    Picture = GetImage("media/Headphones/CategoryImage.jpg")
                },
                new Category
                {
                    CategoryName = "Keyboards",
                    Description = "",
                    Picture = GetImage("media/Keyboards/CategoryImage.jpg")
                },
                new Category
                {
                    CategoryName = "Monitors",
                    Description = "",
                    Picture = GetImage("media/Monitors/CategoryImage.jpg")
                }
            );
            context.SaveChanges();
        }

        if (!context.Products.Any())
        {
            //Headphones
            byte[] image1 = GetImage("media/Headphones/Apple_AirPods_Pro.jpeg");
            byte[] image2 = GetImage("media/Headphones/Bose_700.jpg");
            byte[] image3 = GetImage("media/Headphones/Bose_QuietComfort_45.jpg");
            byte[] image4 = GetImage("media/Headphones/Bowers_&_Wilkins_Px7_S2.jpg");
            byte[] image5 = GetImage("media/Headphones/Grado_GT220.jpg");
            byte[] image6 = GetImage("media/Headphones/Master_&_Dynamic_MW08.jpg");
            byte[] image7 = GetImage("media/Headphones/Sennheiser_Momentum_4_Wireless.jpg");
            byte[] image8 = GetImage("media/Headphones/Technics_EAH-A800.jpg");
            byte[] image9 = GetImage("media/Headphones/Technics_EAH-AZ60.jpg");
            byte[] image10 = GetImage("media/Headphones/Sony_WH-1000XM5.jpg");

            /*
            Collection<byte[]> airpodsPro = new Collection<byte[]>();
            Collection<byte[]> bose700 = new Collection<byte[]>();
            Collection<byte[]> boseQuiet = new Collection<byte[]>();
            Collection<byte[]> px7 = new Collection<byte[]>();
            Collection<byte[]> gt220 = new Collection<byte[]>();
            Collection<byte[]> mw08 = new Collection<byte[]>();
            Collection<byte[]> momentum4 = new Collection<byte[]>();
            Collection<byte[]> eahA800 = new Collection<byte[]>();
            Collection<byte[]> eahAz60 = new Collection<byte[]>();
            Collection<byte[]> wh1000 = new Collection<byte[]>();
            airpodsPro.Add(image1);
            bose700.Add(image2);
            boseQuiet.Add(image3);
            px7.Add(image4);
            gt220.Add(image5);
            mw08.Add(image6);
            momentum4.Add(image7);
            eahA800.Add(image8);
            eahAz60.Add(image9);
            wh1000.Add(image10);
            */

            //Keyboards
            byte[] image1k = GetImage("media/Keyboards/Apple_Magic_Keyboard.jpg");
            byte[] image2k = GetImage("media/Keyboards/Cherry_Stream_Desktop_Keyboard.jpg");
            byte[] image3k = GetImage("media/Keyboards/Das_Keyboard_4_Professional.jpg");
            byte[] image4k = GetImage("media/Keyboards/Logitech_Craft.jpg");
            byte[] image5k = GetImage("media/Keyboards/Logitech_MX_Keys_Mini.jpg");
            byte[] image6k = GetImage("media/Keyboards/Logitech_Mx_Mechanical.jpg");
            byte[] image7k = GetImage("media/Keyboards/Razer_Deathstalker_V2_Pro.jpg");
            byte[] image8k = GetImage("media/Keyboards/Razer_Huntsman_V2_Analog.jpg");
            byte[] image9k = GetImage("media/Keyboards/Razer_Pro_Type_Ultra.jpg");
            byte[] image10k = GetImage("media/Keyboards/Unicomp_New_Model_M.jpg");

            /*
            Collection<byte[]> appleMagic = new Collection<byte[]>();
            Collection<byte[]> cherryStream = new Collection<byte[]>();
            Collection<byte[]> das4 = new Collection<byte[]>();
            Collection<byte[]> craft = new Collection<byte[]>();
            Collection<byte[]> keysMini = new Collection<byte[]>();
            Collection<byte[]> mxMechanical = new Collection<byte[]>();
            Collection<byte[]> deathStalker = new Collection<byte[]>();
            Collection<byte[]> huntman = new Collection<byte[]>();
            Collection<byte[]> razerPro = new Collection<byte[]>();
            Collection<byte[]> unicomp = new Collection<byte[]>();
            appleMagic.Add(image1k);
            cherryStream.Add(image2k);
            das4.Add(image3k);
            craft.Add(image4k);
            keysMini.Add(image5k);
            mxMechanical.Add(image6k);
            deathStalker.Add(image7k);
            huntman.Add(image8k);
            razerPro.Add(image9k);
            unicomp.Add(image10k);
            */

            //Monitors
            byte[] image1m = GetImage("media/Monitors/Acer_Predator_X38.jpg");
            byte[] image2m = GetImage("media/Monitors/Alienware_34_QD-OLED_(AW3423DW).jpg");
            byte[] image3m = GetImage("media/Monitors/Dell_S2722DGM.jpg");
            byte[] image4m = GetImage("media/Monitors/Dell_S3222DGM.jpg");
            byte[] image5m = GetImage("media/Monitors/Gigabyte_M28U.png");
            byte[] image6m = GetImage("media/Monitors/GigabyteG27Q.jpg");
            byte[] image7m = GetImage("media/Monitors/LG_27GN950-B.jpg");
            byte[] image8m = GetImage("media/Monitors/MSI_Oculux_NXG253R.jpg");
            byte[] image9m = GetImage("media/Monitors/Samsung_Odyssey_Neo_G9.jpg");
            byte[] image10m = GetImage("media/Monitors/Pixio_PX277_Prime.png");

            /*
            Collection<byte[]> predator = new Collection<byte[]>();
            Collection<byte[]> alienware = new Collection<byte[]>();
            Collection<byte[]> dellS3 = new Collection<byte[]>();
            Collection<byte[]> dellS2 = new Collection<byte[]>();
            Collection<byte[]> m28u = new Collection<byte[]>();
            Collection<byte[]> g27q = new Collection<byte[]>();
            Collection<byte[]> lg = new Collection<byte[]>();
            Collection<byte[]> msi = new Collection<byte[]>();
            Collection<byte[]> odyssey = new Collection<byte[]>();
            Collection<byte[]> pixio = new Collection<byte[]>();
            predator.Add(image1m);
            alienware.Add(image2m);
            dellS3.Add(image3m);
            dellS2.Add(image4m);
            m28u.Add(image5m);
            g27q.Add(image6m);
            lg.Add(image7m);
            msi.Add(image8m);
            odyssey.Add(image9m);
            pixio.Add(image10m);
            */

            context.Products.AddRange(
                new Product
                {
                    Name = "Apple AirPods Pro",
                    Price = 249,
                    Color = "White",
                    Quantity = 10,
                    Pictures = image1,
                    Description = "AirPods Pro have been designed to deliver Active Noise Cancellation for immersive sound, Transparency mode so you can hear your surroundings and a customizable fit for all-day comfort. Just like AirPods, AirPods Pro connect like magic to your iPhone or Apple Watch. And they're ready to use straight out of the case.",
                    Category = context.Categories.FirstOrDefault(c => c.CategoryName == "Headphones")
                },
                new Product
                {
                    Name = "Bose 700",
                    Price = 500,
                    Color = "Grey",
                    Quantity = 9,
                    Pictures = image2,
                    Description = "Bose Noise Cancelling Headphones 700 deliver everything you expect - and things you never imagined possible. Think of them as smart headphones that let you keep your head up to the world with easy access to voice assistants. Or confidently take a call with the most powerful microphone system for voice pickup. And then there's Bose AR, a first-of-its-kind audio augmented reality platform that makes astonishing new audio experiences possible.",
                    Category = context.Categories.FirstOrDefault(c => c.CategoryName == "Headphones")
                },
                new Product
                {
                    Name = "Bose QuietComfort 45",
                    Price = 450,
                    Color = "Black",
                    Quantity = 12,
                    Pictures = image3,
                    Description = "The original noise canceling headphones are back, with world-class quiet, shockingly light materials, and proprietary technology for deep, clear sound. QuietComfort 45 headphones. It's an icon reborn. Proprietary Acoustic Noise Canceling technology produces the true quiet you need to hear every detail of your music in high fidelity. Or choose Aware Mode to hear your music and your environment at the same time.",
                    Category = context.Categories.FirstOrDefault(c => c.CategoryName == "Headphones")
                },
                new Product
                {
                    Name = "Bowers & Wilkins Px7 S2",
                    Price = 249,
                    Color = "Black",
                    Quantity = 10,
                    Pictures = image4,
                    Description = "A premium upgrade to the award winning Px7, the Bowers & Wilkins Px7 S2 Wireless Headphones, featuring a completely redesigned and optimized acoustic system, an all-new angled drive unit design, and a more powerful motor system, deliver detailed, rich audio performance with incredible clarity. With its proprietary, all-new active noise cancellation, the headphones are designed to block out unwanted external noise, ensuring clear, crisp playback of your favorite tracks.",
                    Category = context.Categories.FirstOrDefault(c => c.CategoryName == "Headphones")
                },
                new Product
                {
                    Name = "Grado GT220",
                    Price = 500,
                    Color = "Black",
                    Quantity = 10,
                    Pictures = image5,
                    Description = "GT220 marks a milestone in Grado's seven decades of audio. Years in the making, Grado didn't want to rush the process of creating a compact and versatile wireless Grado headphone with such vocality and depth. Control music, calls, and more with just a tap, or your voice with the built-in microphone. Easy to always have around, they're ready when you are.",
                    Category = context.Categories.FirstOrDefault(c => c.CategoryName == "Headphones")
                },
                new Product
                {
                    Name = "Master & Dynamic MW08",
                    Price = 235,
                    Color = "Black",
                    Quantity = 5,
                    Pictures = image6,
                    Description = "Crafted from ceramic and stainless steel, MW08 features hybrid Active Noise-Cancellation, a streamlined form designed for comfort, and a new wind-reducing talk solution with six microphones. Active Noise-Cancelling True Wireless Earphones Let you listen to your favorite tracks, so you won't be held back by wires. Rechargeable battery Offers up to 10 hours of use on a charge and 8 hours with ANC Water-resistant Wireless earphones feature an IPX5 water resistance rating.",
                    Category = context.Categories.FirstOrDefault(c => c.CategoryName == "Headphones")
                },
                new Product
                {
                    Name = "Sennheiser Momentum 4 Wireless",
                    Price = 359,
                    Color = "Black",
                    Quantity = 2,
                    Pictures = image7,
                    Description = "Get the next generation MOMENTUM 4 Wireless that is inspired by music.",
                    Category = context.Categories.FirstOrDefault(c => c.CategoryName == "Headphones")
                },
                new Product
                {
                    Name = "Sony WH-1000XM5",
                    Price = 450,
                    Color = "White",
                    Quantity = 30,
                    Pictures = image8,
                    Description = "The WH-1000XM5 headphones rewrite the rules for distraction-free listening. 2 processors control 8 microphones for unprecedented noise cancellation and exceptional call quality. With a newly developed driver, DSEE - Extreme technology and Hi-Res audio support the WH-1000XM5 headphones provide awe-inspiring audio quality.",
                    Category = context.Categories.FirstOrDefault(c => c.CategoryName == "Headphones")
                },
                new Product
                {
                    Name = "Technics EAH-A800",
                    Price = 429.97M,
                    Color = "Silver",
                    Quantity = 10,
                    Pictures = image9,
                    Description = "Backed by Technics' legendary sound quality, EAH-A800 headphones feature superior audio, exceptional over-the-ear comfort, and sparkling call clarity for home, work, and travel. Unleash a true high-fidelity sound experience in comfortable headphones. The legendary sound quality of Technics with true wireless freedom.",
                    Category = context.Categories.FirstOrDefault(c => c.CategoryName == "Headphones")
                },
                new Product
                {
                    Name = "Technics EAH-AZ60",
                    Price = 200,
                    Color = "Grey",
                    Quantity = 4,
                    Pictures = image10,
                    Description = "Backed by Technics' legendary sound quality, EAH-AZ60 earbuds feature industry-leading noise cancelling, exceptional comfort, and sparkling call clarity for home, work, and travel. Unleash a true high-fidelity sound experience in comfortable earbuds.",
                    Category = context.Categories.FirstOrDefault(c => c.CategoryName == "Headphones")
                },

                //KEYBOARDS


                new Product
                {
                    Name = "Apple Magic Keyboard",
                    Price = 400,
                    Color = "White",
                    Quantity = 1,
                    Pictures = image1k,
                    Description = "Magic Keyboard combines a sleek design with a built-in rechargeable battery and enhanced key features. With a stable scissor mechanism beneath each key, as well as optimized key travel and a low profile, Magic Keyboard provides a remarkably comfortable and precise typing experience. It pairs automatically with your Mac, so you can get to work right away. And the battery is incredibly long-lasting - it will power your keyboard for about a month or more between charges.",
                    Category = context.Categories.FirstOrDefault(c => c.CategoryName == "Keyboards")
                },
                new Product
                {
                    Name = "Cherry Stream Desktop Keyboard",
                    Price = 96.99M,
                    Color = "Black",
                    Quantity = 3,
                    Pictures = image2k,
                    Description = "The best STREAM ever - wireless and with charging capability. The CHERRY STREAM desktop recharge is a high-quality new addition to the STREAM Family with many valuable features for both professional and home-office use. As with all products in the STREAM family, it has the proprietary CHERRY SX scissor mechanism at its heart. A charging function and AES encryption round off the 2.4 GHz wireless keyboard and accompanying wireless mouse perfectly.",
                    Category = context.Categories.FirstOrDefault(c => c.CategoryName == "Keyboards")
                },
                new Product
                {
                    Name = "Das Keyboard 4 Professional",
                    Price = 268.03M,
                    Color = "Black",
                    Quantity = 10,
                    Pictures = image3k,
                    Description = "Das Keyboard 4 Professional for Mac mechanical keyboard is designed to take your Mac experience to the next level. It's made of the highest-quality materials and has a robust construction you can feel. All of the keyboards are designed with high-performance, gold-plated mechanical key switches lasting up to 50 million keystrokes.",
                    Category = context.Categories.FirstOrDefault(c => c.CategoryName == "Keyboards")
                },
                new Product
                {
                    Name = "Logitech Craft",
                    Price = 239.99M,
                    Color = "Black",
                    Quantity = 10,
                    Pictures = image4k,
                    Description = "Craft is a wireless keyboard with a premium typing experience and a versatile input dial that adapts to what you're making - keeping you focused and in your creative flow.",
                    Category = context.Categories.FirstOrDefault(c => c.CategoryName == "Keyboards")
                },
                new Product
                {
                    Name = "Logitech MX Keys Mini",
                    Price = 129.99M,
                    Color = "White",
                    Quantity = 10,
                    Pictures = image5k,
                    Description = "Crafted for creators, it features Perfect Stroke keys, shaped for optimal key stability and tactile responsiveness. Its minimalist form factor provides improved ergonomics by aligning your shoulders and allowing you to place your mouse closer to your keyboard for less arm reaching and better body posture.",
                    Category = context.Categories.FirstOrDefault(c => c.CategoryName == "Keyboards")
                },
                new Product
                {
                    Name = "Logitech MX Mechanical",
                    Price = 219.99M,
                    Color = "Black",
                    Quantity = 5,
                    Pictures = image6k,
                    Description = "Introducing Logitech MX Mechanical - a full-size keyboard with extraordinary feel, precision, and performance. Low-profile mechanical keys in your choice of 3 switch types deliver satisfying feedback with every keystroke. Your fingers glide effortlessly across the matte surface of the keys - and dual color keycaps guide peripheral vision to make it easy to orient your fingers and stay in your flow.",
                    Category = context.Categories.FirstOrDefault(c => c.CategoryName == "Keyboards")
                },
                new Product
                {
                    Name = "Razer DeathStalker V2 Pro",
                    Price = 329.99M,
                    Color = "Black",
                    Quantity = 8,
                    Pictures = image7k,
                    Description = "Meet the Razer DeathStalker V2 Pro—a wireless ultra-slim optical keyboard optimized for top-tier performance and durability. Featuring new low-profile switches and Razer HyperSpeed Wireless for ultra-responsive gaming, all housed within a durable, ultra-slim casing for long-lasting ergonomic use.",
                    Category = context.Categories.FirstOrDefault(c => c.CategoryName == "Keyboards")
                },
                new Product
                {
                    Name = "Razer Huntsman V2",
                    Price = 239.99M,
                    Color = "Black",
                    Quantity = 6,
                    Pictures = image8k,
                    Description = "Actuation at the speed of light now comes with the finest degree of control. Meet the Razer Huntsman V2 Analog—our first gaming keyboard featuring Razer Analog Optical Switches. With keys that give you as much granular precision as analog sticks, you’ll have no trouble moving into a winning position.",
                    Category = context.Categories.FirstOrDefault(c => c.CategoryName == "Keyboards")
                },
                new Product
                {
                    Name = "Razer Pro Type Ultra Wireless Mechanical Keyboard",
                    Price = 201.99M,
                    Color = "White",
                    Quantity = 10,
                    Pictures = image9k,
                    Description = "The Razer Pro Type returns in top form to revolutionize your workstation. Back by popular demand and greatly refined through community feedback, this resilient ergonomic keyboard promises a quieter, more luxurious experience with every keystroke. Take your productivity to new heights with the Razer Pro Type Ultra.",
                    Category = context.Categories.FirstOrDefault(c => c.CategoryName == "Keyboards")
                },
                new Product
                {
                    Name = "Unicomp New Model M",
                    Price = 104,
                    Color = "Black",
                    Quantity = 4,
                    Pictures = image10k,
                    Description = "The New Model M buckling spring keyboard has the same mechanism, feel and layout as the original IBM Model M keyboard, but with a slightly smaller footprint. With the much-loved buckling spring key design these keyboards have been prized by computer enthusiasts and robust typists because of the tactile and auditory feedback of each keystroke.",
                    Category = context.Categories.FirstOrDefault(c => c.CategoryName == "Keyboards")
                },

                //Monitors
                new Product
                {
                    Name = "Acer Predator X38",
                    Price = 1399.99M,
                    Color = "Black",
                    Quantity = 4,
                    Pictures = image1m,
                    Description = "Infused with Agile-splendor IPS and its 0.31ms GtG response, 175Hz refresh2 and a 2300R curve – the Predator X38 transports you to a realm of 21:9 immersion. And with NVIDIA® G-SYNC® at the helm, expect smooth, tear-free gaming as the new norm.",
                    Category = context.Categories.FirstOrDefault(c => c.CategoryName == "Monitors")
                },
                new Product
                {
                    Name = "Alienware 34 QD-OLED (AW3423DW)",
                    Price = 1649.99M,
                    Color = "Black",
                    Quantity = 9,
                    Pictures = image2m,
                    Description = "The world's first QD-OLED gaming monitor. Featuring infinite contrast ratio and VESA DisplayHDR TrueBlack 400 for remarkably vivid colors and visuals bursting to life.",
                    Category = context.Categories.FirstOrDefault(c => c.CategoryName == "Monitors")
                },
                new Product
                {
                    Name = "Dell 27 Curved Gaming Monitor",
                    Price = 349.99M,
                    Color = "Black",
                    Quantity = 10,
                    Pictures = image3m,
                    Description = "27\" QHD Curved Gaming Monitor with 1ms (MPRT)/ 2ms (gray to gray) response time, 165Hz refresh rate and 99% sRGB color for sharp gaming visuals and immersive gameplay.",
                    Category = context.Categories.FirstOrDefault(c => c.CategoryName == "Monitors")
                },
                new Product
                {
                    Name = "Dell 32 Curved Gaming Monitor",
                    Price = 670.91M,
                    Color = "Black",
                    Quantity = 15,
                    Pictures = image4m,
                    Description = "31.5\" QHD Curved Gaming Monitor with 1ms (MPRT)/ 2ms (gray to gray) response time, 165Hz refresh rate and 99% sRGB color for sharp gaming visuals and immersive gameplay.",
                    Category = context.Categories.FirstOrDefault(c => c.CategoryName == "Monitors")
                },
                new Product
                {
                    Name = "GIGABYTE M-U Gaming Monitor",
                    Price = 650.31M,
                    Color = "Black",
                    Quantity = 10,
                    Pictures = image5m,
                    Description = "Compete like a pro with the crisp and unbeatable performance of the GIGABYTE M28U Gaming Monitor. Featuring a 28-inch screen monitor with an IPS panel and Ultra-HD 3840p x 2160p maximum resolution, experience your games in a stunning display. Powered by AMD FreeSync™ Premium Pro, experience smooth HDR performance with 2ms response time and 144Hz refresh rate. With its 8-bit color depth, convenient KVM switch, and various gaming features, enjoy your favorite games in high detail.",
                    Category = context.Categories.FirstOrDefault(c => c.CategoryName == "Monitors")
                },
                new Product
                {
                    Name = "G27Q Gaming Monitor",
                    Price = 219.99M,
                    Color = "Black",
                    Quantity = 5,
                    Pictures = image6m,
                    Description = "Fearlessly charge into battle with the stunning visuals of the GIGABYTE G27Q Gaming Monitor, a 27-inch screen monitor with an IPS panel that features Quad HD 2560p x 1440p maximum resolution for a stunning display. Powered by AMD FreeSync™ Premium, experience detailed display quality with 1ms response time and 144Hz refresh rate. With its 8-bit color depth, 90% DCI-P3 super wide-gamut color, and various gaming features, secure your victory in every game.",
                    Category = context.Categories.FirstOrDefault(c => c.CategoryName == "Monitors")
                },
                new Product
                {
                    Name = "RLG UltraGear GN950",
                    Price = 599.99M,
                    Color = "Black",
                    Quantity = 8,
                    Pictures = image7m,
                    Description = "High-performance, pro-level gaming. Even if you’re not a pro gamer, you’ll feel like one with LG’s 27” UltraGear monitor. The 1ms Nano IPS with UHD 4K resolution and VESA DisplayHDR 600, it combines color intensity and purity with ultra-fast 1ms response rates time and 144Hz refresh rate. Featuring custom gaming control, RGB sphere lighting, and NVIDIA G-SYNC compatibility with AMD FreeSync Premium Pro to minimize tearing and stutter — it's cutting-edge tech to give you the edge.\r\n",
                    Category = context.Categories.FirstOrDefault(c => c.CategoryName == "Monitors")
                },
                new Product
                {
                    Name = "MSI Oculux NXG-3R",
                    Price = 525.76M,
                    Color = "Black",
                    Quantity = 6,
                    Pictures = image8m,
                    Description = "NVIDIA G-SYNC displays deliver unparalleled 360 Hz gameplay, making them the choice for esports enthusiasts everywhere. Experience low system latency for faster reaction times, practically no ghosting, and smooth motion to help stay on target. Add in zero tearing with G-SYNC, and it's clear why these displays are designed to win.",
                    Category = context.Categories.FirstOrDefault(c => c.CategoryName == "Monitors")
                },
                new Product
                {
                    Name = "Pixio PX-7",
                    Price = 339.99M,
                    Color = "Black",
                    Quantity = 10,
                    Pictures = image9m,
                    Description = "The PX277 monitor is a 27inch monitor with tons of features. The immersive 2560 x 1440p WQHD (Wide Quad High Definition, 2k) display will provide you with stunning and crisp visuals. Super slim bezel-less design is finished in completely matte black color. The fast 144Hz refresh rate enables liquid smooth seamless images.",
                    Category = context.Categories.FirstOrDefault(c => c.CategoryName == "Monitors")
                },
                new Product
                {
                    Name = "Samsung Odyssey Neo G9",
                    Price = 2019.99M,
                    Color = "Black",
                    Quantity = 4,
                    Pictures = image10m,
                    Description = "Built with all the needed features to match your gaming beast, the Samsung Odyssey Neo G9 WQHD curved gaming monitor certainly does not disappoint. It boasts a 49\" curved VA panel in WQHD resolution for hypnotic visuals. It also includes a 240Hz refresh rate, Quantum HDR 2000, Quantum Matrix technology, and tilt/swivel/height adjustment for viewing convenience.",
                    Category = context.Categories.FirstOrDefault(c => c.CategoryName == "Monitors")
                }
            );
            context.SaveChanges();
        }

            /*if (!context.Orders.Any())
            {
                context.SaveChanges();
            }*/

        }
    }
}
