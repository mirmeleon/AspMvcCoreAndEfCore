namespace hw01
{
    using Microsoft.EntityFrameworkCore;

    public class MyDbContext : DbContext
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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                 .Entity<Employee>()
                 .HasOne(e => e.Department)
                 .WithMany(d => d.Employees)
                 .HasForeignKey(e => e.DepartmentId);

           
        }
    }
}
