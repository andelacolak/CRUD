using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CRUDVjezba.Models
{
    public class StudentContext : DbContext
    {
        public StudentContext() : base()
        { }
        public StudentContext(DbContextOptions<StudentContext> options)
            : base(options)
        { }

        
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = FacultyDb; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = True; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<ExampleClass> Html { get; set; }
    }
}
