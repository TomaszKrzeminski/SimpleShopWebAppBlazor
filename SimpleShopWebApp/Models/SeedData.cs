using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SimpleShopWebApp.Data;

namespace SimpleShopWebApp.Models
{
    public class SeedData
    {

        public ApplicationDbContext context;
        IRepository repository;
        public SeedData(ApplicationDbContext context)
        {
            this.context = context;

        }



        public void EnsurePopulated()
        {





            void SeedRoles()
            {

                try
                {


                    var roleStore = new RoleStore<IdentityRole>(context);

                    if (!context.Roles.Any(r => r.Name == "NewUser" || r.Name == "UserRole" || r.Name == "Administrator"))
                    {

                        roleStore.CreateAsync(new IdentityRole { Name = "Administrator", NormalizedName = "Administrator" });


                        roleStore.CreateAsync(new IdentityRole { Name = "UserRole", NormalizedName = "UserRole" });



                        roleStore.CreateAsync(new IdentityRole { Name = "NewUser", NormalizedName = "NewUser" });
                    }


                    context.SaveChangesAsync();





                }
                catch (Exception ex)
                {

                }
            }



            void AddCategoryToProduct()
            {



                Category kangury = context.Categories.Where(x => x.CategoryName == "Kangury").FirstOrDefault();
                Category zumba = context.Categories.Where(x => x.CategoryName == "Zumba").FirstOrDefault();
                Category urodziny = context.Categories.Where(x => x.CategoryName == "Urodziny").FirstOrDefault();



                List<Product> list = context.Products.Where(x => x.ProductName.StartsWith("Kangury")).ToList();

                foreach (var item in list)
                {
                    kangury.Products.Add(item);
                }

                context.SaveChanges();


                List<Product> list2 = context.Products.Where(x => x.ProductName.StartsWith("Zumba")).ToList();

                foreach (var item in list2)
                {
                    zumba.Products.Add(item);
                }

                context.SaveChanges();

                List<Product> list3 = context.Products.Where(x => x.ProductName.StartsWith("Urodziny")).ToList();

                foreach (var item in list3)
                {
                    urodziny.Products.Add(item);
                }

                context.SaveChanges();


            }




            Product SeedProducts(string Name, double Price, double Price2, string Path, DateTime s, DateTime e)
            {
                Product product = new Product();
                product.ProductName = Name;
                product.DateTimeStart = s;
                product.DateTimeEnd = e;
                product.PricePerPerson = Price;
                product.PriceHour = Price2;
                product.Status = true;
                product.ProductImagePath = Path;
                context.Products.Add(product);
                context.SaveChanges();
                return product;
            }
            void SeedCategories()
            {
                List<string> list = new List<string>() { "Kangury", "Zumba", "Urodziny" };

                foreach (var item in list)
                {
                    context.Categories.Add(new Category() { CategoryName = item });
                    context.SaveChanges();
                }
            }




            void SeedAdmin(string Name, string Surname, string Sex, string City, string Email, DateTime Dateofbirth)
            {


                try
                {
                    DateTime Now = DateTime.Now;
                    TimeSpan ts = Now - Dateofbirth;
                    int age = ts.Days / 365;

                    var User = new ApplicationUser()
                    {

                        Email = Email,
                        FirstName = Name,
                        Surname = Surname,
                        City = City,
                        Dateofbirth = Dateofbirth,
                        UserName = Email,
                        EmailConfirmed = true,
                        LockoutEnabled = true,
                        SecurityStamp = Guid.NewGuid().ToString(),
                        NormalizedEmail = Email.ToUpper(),
                        NormalizedUserName = Email.ToUpper(),
                    };

                    if (!context.Users.Any(u => u.UserName == User.UserName))
                    {
                        var password = new PasswordHasher<ApplicationUser>();
                        var hashed = password.HashPassword(User, "Sekret123@");
                        User.PasswordHash = hashed;
                        UserStore<ApplicationUser> userStore;

                        userStore = new UserStore<ApplicationUser>(context);

                        userStore.CreateAsync(User).Wait();
                        ////////
                        Claim claim = new Claim(ClaimTypes.Email, User.Email);
                        List<Claim> claims = new List<Claim>();
                        claims.Add(claim);
                        userStore.AddClaimsAsync(User, claims);
                        userStore.AddToRoleAsync(User, "Administrator").Wait();

                    }
                    context.SaveChanges();

                }
                catch (Exception ex)
                {

                }






            }

            void SeedUser(string Name, string Surname, string Sex, string City, string Email, DateTime Dateofbirth)
            {


                try
                {
                    DateTime Now = DateTime.Now;
                    TimeSpan ts = Now - Dateofbirth;
                    int age = ts.Days / 365;

                    var User = new ApplicationUser()
                    {

                        FirstName = Name,
                        Email = Email,
                        Surname = Surname,
                        //Sex = Sex,
                        City = City,
                        Dateofbirth = Dateofbirth,
                        UserName = Email,
                        EmailConfirmed = true,
                        LockoutEnabled = true,
                        SecurityStamp = Guid.NewGuid().ToString(),
                        NormalizedEmail = Email.ToUpper(),
                        NormalizedUserName = Email.ToUpper(),
                    };

                    if (!context.Users.Any(u => u.UserName == User.UserName))
                    {
                        var password = new PasswordHasher<ApplicationUser>();
                        var hashed = password.HashPassword(User, "Sekret123@");
                        User.PasswordHash = hashed;
                        UserStore<ApplicationUser> userStore;

                        userStore = new UserStore<ApplicationUser>(context);

                        //userStore.CreateAsync(User).Wait();
                        userStore.CreateAsync(User).Wait();
                        ////////
                        Claim claim = new Claim(ClaimTypes.Email, User.Email);
                        List<Claim> claims = new List<Claim>();
                        claims.Add(claim);
                        userStore.AddClaimsAsync(User, claims).Wait();
                        userStore.AddToRoleAsync(User, "UserRole").Wait();

                    }
                    context.SaveChanges();

                }
                catch (Exception ex)
                {

                }






            }



            if (context.Database.EnsureCreated())
            {
                if (!context.Users.Any())
                {

                    SeedRoles();

                    SeedAdmin("Ada", "Krzemińska", "Kobieta", "Świecie", "Ada@gmail.com", new DateTime(1984, 8, 21));
                    SeedUser("User1", "Surname1", "Kobieta", "Świecie", "user1@gmail.com", DateTime.Now);
                    SeedUser("User2", "Surname2", "Kobieta", "Świecie", "user2@gmail.com", DateTime.Now);
                    SeedUser("User3", "Surname3", "Kobieta", "Świecie", "user3@gmail.com", DateTime.Now);


                    SeedProducts("Zumba1", 10, 0, "~/wwwroot/AdminImages/Zumba.jpg", new DateTime(2022, 4, 7, 18, 30, 0), new DateTime(2022, 3, 7, 19, 30, 0));
                    SeedProducts("Zumba2", 10, 0, "~/wwwroot/AdminImages/Zumba.jpg", new DateTime(2022, 4, 7, 18, 30, 0), new DateTime(2022, 4, 7, 19, 30, 0));
                    SeedProducts("Zumba3", 10, 0, "~/wwwroot/AdminImages/Zumba.jpg", new DateTime(2022, 5, 7, 18, 30, 0), new DateTime(2022, 5, 7, 19, 30, 0));
                    SeedProducts("Zumba4", 10, 0, "~/wwwroot/AdminImages/Zumba.jpg", new DateTime(2022, 4, 7, 18, 30, 0), new DateTime(2022, 6, 7, 19, 30, 0));


                    SeedProducts("Kangury5", 10, 0, "~/wwwroot/AdminImages/Kangoo.jpg", new DateTime(2022, 4, 7, 17, 30, 0), new DateTime(2022, 3, 7, 18, 30, 0));
                    SeedProducts("Kangury6", 10, 0, "~/wwwroot/AdminImages/Kangoo.jpg", new DateTime(2022, 4, 7, 17, 30, 0), new DateTime(2022, 4, 7, 18, 30, 0));
                    SeedProducts("Kangury7", 10, 0, "~/wwwroot/AdminImages/Kangoo.jpg", new DateTime(2022, 4, 7, 17, 30, 0), new DateTime(2022, 5, 7, 18, 30, 0));
                    SeedProducts("Kangury8", 10, 0, "~/wwwroot/AdminImages/Kangoo.jpg", new DateTime(2022, 4, 7, 17, 30, 0), new DateTime(2022, 6, 7, 18, 30, 0));



                    SeedProducts("Urodziny9", 10, 0, "~/wwwroot/AdminImages/Urodziny.jpg", new DateTime(2022, 4, 3, 17, 30, 0), new DateTime(2022, 3, 7, 18, 30, 0));
                    SeedProducts("Urodziny10", 10, 0, "~/wwwroot/AdminImages/Urodziny.jpg", new DateTime(2022, 4, 3, 17, 30, 0), new DateTime(2022, 4, 7, 18, 30, 0));



                    SeedCategories();
                    AddCategoryToProduct();


                }


            }




        }




    }
}
