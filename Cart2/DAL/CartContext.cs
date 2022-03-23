using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using Cart2.Models;

namespace Cart2.DAL
{
    public class CartContext: DbContext
    {
        public CartContext() : base("connectionString")
        {

        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}