namespace consApp1
{
    using Microsoft.EntityFrameworkCore;
    public class MyDbContext : DbContext
    {
        //opisvame kakvi tablici imame
     //   public DbSet<Person> People { get; set; }

      public DbSet<Student> Studetns { get; set; }
        public DbSet<Course> Courses { get; set; }
        //kazvame mu kak da se svurje s bazata
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(
               @"Server=.;Database=TestDb;Integrated Security=True;"
                );

            //kat ne znaem kakvo pravim izvikvame i basovia method
            base.OnConfiguring(builder);

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //opisvame si composite kluch
            builder
                .Entity<StudentCourse>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });



            builder
                 .Entity<Student>()
                 .HasMany(s => s.Courses)
                 .WithOne(sc => sc.Student)
                 .HasForeignKey(s=>s.StudentId);

            builder
                .Entity<Course>()
                .HasMany(c => c.Students)
                .WithOne(c => c.Course)
                .HasForeignKey(c => c.CourseId);
        }

    }
}
