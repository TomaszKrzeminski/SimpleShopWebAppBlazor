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



    public class Repository : IRepository
    {
        private ApplicationDbContext context { get; set; }
        public Repository(ApplicationDbContext context)
        {
            this.context = context;
        }


        public async Task<List<Product>> GetProductsAsync()
        {
            return await context.Products.Take(1000).ToListAsync();
        }



       public async Task<bool> AddProduct(Product product)
        {
            try
            {
                await context.Products.AddAsync(product);
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
            //context.DisposeAsync();
            context.Dispose();
        }
    }






}
