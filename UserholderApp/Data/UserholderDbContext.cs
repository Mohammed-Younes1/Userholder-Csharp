using Microsoft.EntityFrameworkCore;

namespace UserholderApp.Models
{
    public class UserholderDbContext : DbContext
    {
        public UserholderDbContext(DbContextOptions<UserholderDbContext> options)
            : base(options)
        {
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Geo> Geos { get; set; }
        public DbSet<Posts> Posts { get; set; }
        public DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>()
                .HasMany(u => u.Posts)
                .WithOne(p => p.Users)
                .HasForeignKey(p => p.UserId);

            modelBuilder.Entity<Address>()
                .HasOne(a => a.Geo)
                .WithOne(g => g.Address)
                .HasForeignKey<Geo>(g => g.Id);

            modelBuilder.Entity<Users>()
                .HasOne(u => u.Address)
                .WithMany()
                .HasForeignKey(u => u.AddressId);

            modelBuilder.Entity<Users>()
                .HasOne(u => u.Company)
                .WithMany()
                .HasForeignKey(u => u.CompanyId);
        }
    }
}
