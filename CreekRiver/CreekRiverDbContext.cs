using Microsoft.EntityFrameworkCore;
using CreekRiver.Models;

public class CreekRiverDbContext : DbContext
{
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<Campsite> Campsites { get; set; }
    public DbSet<CampsiteType> CampsiteTypes { get; set; }
    public CreekRiverDbContext(DbContextOptions<CreekRiverDbContext> context) : base(context)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // seed data with campsite types
        modelBuilder.Entity<CampsiteType>().HasData(new CampsiteType[]
        {
        new CampsiteType {Id = 1, CampsiteTypeName = "Tent", FeePerNight = 15.99M, MaxReservationDays = 7},
        new CampsiteType {Id = 2, CampsiteTypeName = "RV", FeePerNight = 26.50M, MaxReservationDays = 14},
        new CampsiteType {Id = 3, CampsiteTypeName = "Primitive", FeePerNight = 10.00M, MaxReservationDays = 3},
        new CampsiteType {Id = 4, CampsiteTypeName = "Hammock", FeePerNight = 12M, MaxReservationDays = 7}
        });

        modelBuilder.Entity<Campsite>().HasData(new Campsite[]
        {
            new Campsite {Id = 1, CampsiteTypeId = 1, Nickname = "Barred Owl", ImageUrl="https://tnstateparks.com/assets/images/content-images/campgrounds/249/colsp-area2-site73.jpg"},
            new Campsite {Id = 2, CampsiteTypeId = 2, Nickname = "Red Fox", ImageUrl="https://tnstateparks.com/assets/images/content-images/campgrounds/249/colsp-area2-site74.jpg"},
            new Campsite {Id = 3, CampsiteTypeId = 3, Nickname = "White Tail Deer", ImageUrl="https://tnstateparks.com/assets/images/content-images/campgrounds/249/colsp-area2-site75.jpg"},
            new Campsite {Id = 4, CampsiteTypeId = 3, Nickname = "Black Bear", ImageUrl="https://tnstateparks.com/assets/images/content-images/campgrounds/249/colsp-area2-site76.jpg"},
            new Campsite {Id = 5, CampsiteTypeId = 4, Nickname = "Wild Turkey", ImageUrl="https://tnstateparks.com/assets/images/content-images/campgrounds/249/colsp-area2-site77.jpg"}

        });

        modelBuilder.Entity<UserProfile>().HasData(new UserProfile[]
        {
            new UserProfile {Id = 1, FirstName = "John", LastName = "Doe", Email = "johndoe@email.com"}
        });
    }
}