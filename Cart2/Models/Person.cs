using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cart2.Models
{
    public class Person
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [StringLength(10)]
        public string Number { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}