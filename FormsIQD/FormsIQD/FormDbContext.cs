using FormsIQD.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormsIQD
{
    public class FormDbContext : DbContext
    {
        public FormDbContext(DbContextOptions<FormDbContext> options) : base(options) //ctor for dbcontext injection in startup.cs
        {
            //it's like writing code here, parent(options);

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Customer>().Ignore(c => c.guid); //either use this fluent method or use attributes in the model class [NotMapped]

            modelBuilder.Entity<FormModel>().ToTable("tblForms");

        }

        public DbSet<FormModel> Forms { get; set; }
    }
}
