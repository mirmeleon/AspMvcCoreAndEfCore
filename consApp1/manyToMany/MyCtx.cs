using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace manyToMany
{
   public class MyCtx:DbContext
    {
        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }
       
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(
             @"Server=.;Database=DomashnoDb2;Integrated Security=True;"

                );

            base.OnConfiguring(builder);
        }
    
      protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<StudentCourse>()
                .HasKey(sc => new
                {
                    sc.StudentId,
                    sc.CourseId

                });


            builder
                .Entity<Student>()
                .HasMany(s => s.Courses)
                .WithOne(c => c.Student)
                .HasForeignKey(k => k.StudentId);

            builder
                .Entity<Course>()
                .HasMany(c => c.Students)
                .WithOne(c => c.Course)
                .HasForeignKey(k => k.CourseId);
        }
    }
}
