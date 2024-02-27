using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Project1.Models
{
    public class Category
    {
        [Key]
        public int id { get; set; }
        [Required]
        public String Name { get; set; }

        public int DisplayOder { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        
    }
}
