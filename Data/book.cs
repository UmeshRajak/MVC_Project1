using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Project1.Data
{
    public class book
    {
        public int id { get; set; }
        public string Title { get; set; }

        public string Author { get; set; }
        public string Description { get; set; }

        public string Category { get; set; }
        public string Language { get; set; }
        public int? TotalPages { get; set; }
        public string Rating { get; set; }
        public string Opinion { get; set; }

        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
