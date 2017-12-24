using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace selfRef
{
    public class MyCtx : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; } 

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(
                @"Server=.;Database=DomashnoDb;Integrated Security=True;"
                );
            base.OnConfiguring(builder);
        }

        protected override void OnModelCreating(ModelBuilder bilder)
        {
            bilder
                .Entity<Employee>()
                .HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(k => k.DepartmentId);

            bilder
                .Entity<Employee>()
                .HasOne(e => e.Manager)
                .WithMany(e => e.ManagedEmployees)
                .HasForeignKey(k => k.ManagerId);
               
        }
}
}
