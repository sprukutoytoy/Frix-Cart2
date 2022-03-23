using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Cart2.Models;

namespace Cart2.DAL
{
    public class CartDataInitializer : DropCreateDatabaseIfModelChanges<CartContext>
    {
        protected override void Seed(CartContext context)
        {
            var persons = new List<Person>
            {
                new Person
                {
                    Id = 1,
                    Name = "Brian",
                    Number="123456789"
                }
            };
            persons.ForEach(p => context.Persons.Add(p));
            context.SaveChanges();

            var items = new List<Item>
            {
                new Item
                {
                    Id = 1,
                    Title = "Item 01",
                    Weight = 1,
                    PersonID = 1
                }
            };
            items.ForEach(i => context.Items.Add(i));
            context.SaveChanges();
        }
    }
}