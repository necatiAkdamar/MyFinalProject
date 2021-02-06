using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //Context : Db tabloları ile proje classlarını bağlar
    public class NorthwindContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Northwind;Trusted_Connection=true");
        }

        public DbSet<Product> Products { get; set; }//concrete product ım vt nda products a bağlansın
        public DbSet<Category> Categories { get; set; }//concrete category ım vt nda Categories a bağlansın
        public DbSet<Customer> Customers { get; set; }//concrete customer ım vt nda Customers a bağlansın
        public DbSet<Order> Orders { get; set; }
    }
}
