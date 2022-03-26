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
