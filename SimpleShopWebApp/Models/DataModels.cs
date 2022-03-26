using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SimpleShopWebApp.Models
{

    public class Cart
    {


        public Cart()
        {
            Products = new List<Product>();
        }

        public int CartId { get; set; }

        public string UserId { get; set; }



        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }



        public virtual List<Product> Products { get; set; }


    }

    public enum Sex
    {
        Mężczyzna, Kobieta
    }
    public class ApplicationUser : IdentityUser
    {


        public void SetUser(ApplicationUser user)
        {



            this.FirstName = user.FirstName;
            this.Surname = user.Surname;
            this.Dateofbirth = user.Dateofbirth;
            this.Email = user.Email;
            this.City = user.City;
            this.Street = user.Street;
            this.HouseNumber = user.HouseNumber;
            this.PostalCode = user.PostalCode;


        }


        public string FirstName { get; set; } = "Testowe 1";
        public string Surname { get; set; } = "Testowe 1";

        public Sex sex { get; set; } = Sex.Kobieta;
        public DateTime Dateofbirth { get; set; } = DateTime.Now;
        public string City { get; set; } = "Miasto";

        public string Street { get; set; } = "Ulica";

        public string PostalCode { get; set; } = "86-100";

        public string HouseNumber { get; set; } = "10";


        public override string PhoneNumber { get; set; } = "794219756";

        public string UserImagePath { get; set; } = "~/wwwroot/UserImages/DefaultUserPicture.jpg";

        public int Points { get; set; } = 0;

        public bool Blocked { get; set; } = false;

        public void AddPoint()
        {
            Points += 1;
        }





        public ApplicationUser()
        {





        }

        public virtual Cart cart { get; set; }

        public Instructor Instructor { get; set; }



    }
    public class Category
    {

        public Category()
        {
            Products = new List<Product>();
            Payments = new List<Payment>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }


        public virtual List<Product> Products { get; set; }
        public virtual List<Payment> Payments { get; set; }

    }
    public class Product
    {

        public Product()
        {
            DateTimeStart = DateTime.Now;
            DateTimeEnd = DateTime.Now;
            ProductName = "ProductName";
            ProductImagePath = "None";
            PricePerPerson = 10;
            PriceHour = 10;
            Status = true;

        }

        public int ProductId { get; set; }
        public DateTime DateTimeStart { get; set; }
        public DateTime DateTimeEnd { get; set; }
        public string ProductName { get; set; }
        public string ProductImagePath { get; set; }
        public double PriceHour { get; set; }
        public double PricePerPerson { get; set; }
        public bool Status { get; set; }


        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }


        public int? CartId { get; set; }
        public virtual Cart Cart { get; set; }

    }
    public class Instructor
    {

        public Instructor()
        {
            Payments = new List<Payment>();
        }

        public int InstructorId { get; set; }       

        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public virtual List<Payment> Payments { get; set; }


    }




    public class Payment
    {
        public int PaymentId { get; set; }
        public double PricePerHour { get; set; }


        public int? InstructorId { get; set; }
        public virtual Instructor Instructor { get; set; }

        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }



    }




}
