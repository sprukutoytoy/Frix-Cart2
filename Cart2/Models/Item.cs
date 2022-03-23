using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cart2.Models
{
    public class Item
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public double Weight { get; set; }

        public int PersonID { get; set; }

        public virtual Person person { get; set; }
    }
}