using Demo.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Context
{
    public class MVCDBContext : DbContext
    {
        public MVCDBContext(DbContextOptions<MVCDBContext> options):base(options) 
        {
           
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // =>   optionsBuilder.UseSqlServer("Server = . ; Database = MVCDB ; Trusted_Connection = true ; MultipleActiveResultSet = true");
        
        public DbSet<Department> Departments { get; set; }
    }
}
