using Microsoft.EntityFrameworkCore;
using MVC_Project1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;



namespace MVC_Project1.Data
{
    public class ApplicationDbContext: Microsoft.EntityFrameworkCore.DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options)
            :base(options)
        {

        }
        public Microsoft.EntityFrameworkCore.DbSet<Category> category { get; set; }
    }
}
