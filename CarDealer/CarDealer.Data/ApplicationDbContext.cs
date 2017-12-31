namespace CarDealer.Data
{
    using Microsoft.EntityFrameworkCore;
    using CarDealer.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using CarDealer.Data.Models;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Part> Parts { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Sale> Sales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(
            @"Server=.;Database=CarDealerDb;Integrated Security=True;"
               );

            base.OnConfiguring(builder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //many to many tia 3te //1
            builder
                .Entity<CarParts>()
                .HasKey(sc => new { sc.CarId, sc.PartId });
            //ot many to many (2)
            builder
                .Entity<CarParts>()
                .HasOne(cp => cp.Car)
                .WithMany(cp => cp.Parts)
                .HasForeignKey(cp => cp.CarId);
            //ot many to many(3)
            builder
                  .Entity<CarParts>()
                  .HasOne(cp => cp.Part)
                  .WithMany(cp => cp.Cars)
                  .HasForeignKey(cp => cp.PartId);

            builder
                .Entity<Car>()
                .HasMany(c => c.Parts)
                .WithOne(c => c.Car)
                .HasForeignKey(c => c.CarId);

            builder
                .Entity<Part>()
                .HasMany(p => p.Cars)
                .WithOne(p => p.Part)
                .HasForeignKey(p => p.PartId);

           
            builder
                .Entity<Supplier>()
                .HasMany(s => s.Parts)
                .WithOne(s => s.Supplier)
                .HasForeignKey(s => s.SupplierId);

           
            //one to one example
            //builder
            //    .Entity<Sale>()
            //    .HasOne(s => s.Car)
            //    .WithOne(s => s.Sale)
            //    .HasForeignKey<Car>(c => c.SaleId);

            //one to many
            builder
                .Entity<Sale>()
                .HasOne(s => s.Car)
                .WithMany(c => c.Sales)
                .HasForeignKey(s => s.CarId);

            //one to many
            builder
                .Entity<Sale>()
                .HasOne(c => c.Customer)
                .WithMany(c => c.Sales)
                .HasForeignKey(c => c.CustomerId);

            base.OnModelCreating(builder); //good practice to leave this from the base
        }
    }
}
