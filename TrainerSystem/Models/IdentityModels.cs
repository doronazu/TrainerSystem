using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using TrainerSystem.Models.Application;

namespace TrainerSystem.Models
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Dog> Dogs { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<DogSize> DogSizes { get; set; }
        public DbSet<Vaccine> Vaccines { get; set; }
        public DbSet<AppFile> Files { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}