using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimpleShopWebApp.Data;

namespace SimpleShopWebApp.Models
{


    public interface IRepository : IDisposable
    {



        Task<bool> AddProduct(Product product);

        Task<List<Product>> GetProductsAsync();

    }



    public class Repository : IDisposable
    {
        private ApplicationDbContext context { get; set; }
        public Repository(ApplicationDbContext context)
        {
            this.context = context;
        }


        public async Task<string> RemoveProduct(RemoveProductData data)
        {
            string text = "";
            try
            {
            text = "Usunięto wydarzenie " + data.ProductName + " z dnia " + data.ProductStartTime;
            Product product = context.Products.Find(data.ProductId);
            context.Products.Remove(product);
            await context.SaveChangesAsync();               
                
            }
            catch(Exception ex)
            {
                text = "Nie można usunąć wydarzenia " + data.ProductName + " z dnia " + data.ProductStartTime;
            }

            return text;


        }




        public async Task<List<RemoveProductData>> GetProductsRemoveData()
        {       


            try
            {
                Task<List<RemoveProductData>> list = context.Products.Select(x => new RemoveProductData { ProductId = x.ProductId, ProductName = x.ProductName, ProductStartTime = x.DateTimeStart, ProductEndTime = x.DateTimeEnd }).ToListAsync<RemoveProductData>();
                return await list;
            }
            catch(Exception ex)
            {
                return new List<RemoveProductData>();
            }


        }



        public async Task<List<Product>> GetProductsAsync()
        {
            return await context.Products.Take(1000).ToListAsync();
        }



       //public async Task<bool> AddProduct(Product product)
       // {
       //     try
       //     {
       //         await context.Products.AddAsync(product);
       //         await context.SaveChangesAsync();
       //         return true;
       //     }
       //     catch (Exception ex)
       //     {
       //         return false;
       //     }
       // }



        public async Task< List<Instructor>>  GetInstructors()
        {
            List<Instructor> list =await context.Instructors.ToListAsync();
            return list;
        }


        public async Task<bool> AddInstructor(AddCategoryToInstructor add)
        {
            try
            {
                ApplicationUser user = context.Users.Include(x=>x.Instructor).ThenInclude(x=>x.Payments).ThenInclude(x=>x.PaymentCategories)
                    .Where(x=>x.Id==add.userToAdd.Id).FirstOrDefault();

                if(user.Instructor==null)
                {
                user.Instructor = new Instructor() { ApplicationUserId = add.userToAdd.Id,InstructorEmail=add.userToAdd.Email };
                await context.SaveChangesAsync();
                }
               

                    bool checkPayment = user.Instructor.Payments.Any(x => x.PricePerHour == add.Salary );
                    bool checkCategory = user.Instructor.Payments.Where(x => x.PricePerHour == add.Salary).SelectMany(x => x.PaymentCategories).Any(x=>x.category.CategoryName==add.Category);
                    if(!checkPayment)
                    {

                        Instructor instructor = context.Instructors.Find(user.Instructor.InstructorId);

                        Payment payment1 = new Payment() { PricePerHour = add.Salary };
                        instructor.Payments.Add(payment1);
                        await context.SaveChangesAsync();

                        Category category1 = context.Categories.Where(x => x.CategoryName == add.Category).FirstOrDefault();
                        PaymentCategory paycat = new PaymentCategory()
                        {
                             category = category1,
                             CategoryId=category1.CategoryId,
                              payment = payment1,
                              PaymentId=payment1.PaymentId
                        };

                        Payment p = context.Payments.Find(payment1.PaymentId);
                        p.PaymentCategories.Add(paycat);
                        await  context.SaveChangesAsync();

                        Category c = context.Categories.Find(category1.CategoryId);
                        c.PaymentCategories.Add(paycat);
                        await context.SaveChangesAsync();





                }
                    else if(checkPayment==true&&checkCategory==false)
                    {

                        Payment payment = user.Instructor.Payments.Where(x => x.PricePerHour == add.Salary).FirstOrDefault();

                        Category category = context.Categories.Where(x => x.CategoryName == add.Category).FirstOrDefault();


                        PaymentCategory paymentCategory = new PaymentCategory()
                        {

                            category = category,
                            CategoryId = category.CategoryId,
                            payment = payment,
                            PaymentId = payment.PaymentId

                        };

                        payment.PaymentCategories.Add(paymentCategory);
                        await context.SaveChangesAsync();


                       category.PaymentCategories.Add(paymentCategory);
                       await context.SaveChangesAsync();


                }                  
                              

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }

        }


        public async Task<List<string>> GetActivities()
        {
            List<string> list = new List<string>();
            try
            {

                list =await context.Categories.Select(x => x.CategoryName).ToListAsync();
                return list;
            }
            catch(Exception ex)
            {
                return list;

            }


        }
        public async Task<bool> AddProduct(Product product)
        {
            try
            {
                 context.Products.Add(product);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }



        public async Task<List<ApplicationUser>> GetUsers()
        {
            List<ApplicationUser> list = new List<ApplicationUser>();
            try
            {

                list =await context.Users.ToListAsync();
                return list;
            }
            catch (Exception ex)
            {
                return list;
            }


        }

        public async Task<List<string>> GetInstructors()
        {

            List<string> Instructors = new List<string>();

            try
            {
                
                return Instructors;
            }
            catch(Exception ex)
            {
                return Instructors;
            }

        }




        public async Task<bool> AddProduct2(Product product)
        {
            try
            {

                context.Products.Add(product);
                context.Entry<Product>(product).State = EntityState.Added;
                context.Attach<Product>(product);
                

                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public void Dispose()
        {
            context.DisposeAsync();
        }

        //public void Dispose()
        //{

        //    context.DisposeAsync();
        //}
    }






}
