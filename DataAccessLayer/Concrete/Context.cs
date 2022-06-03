using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer("server=TONKA;database=Proje1;integrated security=true;");
        }
        DbSet<Company> COMPANIES { get; set; }
        DbSet<Doctor> DOCTORS { get; set; }
        DbSet<Employee> EMPLOYEES { get; set; }
        DbSet<Hospital> HOSPITALS { get; set; }
        DbSet<Note> NOTES { get; set; }



    }
}
