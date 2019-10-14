using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProdutoMS.Models;

namespace ProdutoMS.DBContexts.dataGenerator
{
    public class msGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new ProductContext(serviceProvider.GetRequiredService<DbContextOptions<ProductContext>>());
            if (context.Categories.Any())
            {
                return;
            }

            context.Categories.Add(new Category() {Id = 1, Name = "cat 1" });
            context.Categories.Add(new Category() {Id = 2, Name = "cat 3" });
            context.Categories.Add(new Category() {Id = 3, Name = "cat 4" });
            
            
            if (context.Products.Any())
            {
                return;
            }
            
            context.Products.Add(new Product() {Id = 1, Name = "prod teste" , Price = 10m  , CategoryID = 1});
            context.Products.Add(new Product() {Id = 2, Name = "prod teste 2" , Price = 10m  , CategoryID = 2});
            context.Products.Add(new Product() {Id = 3, Name = "prod teste 3" , Price = 10m  , CategoryID = 3});

            context.SaveChanges();
        }
        
    }
}