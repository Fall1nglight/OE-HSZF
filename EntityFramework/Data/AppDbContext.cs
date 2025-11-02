using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Data;

public sealed class AppDbContext : DbContext
{
    public DbSet<Person> People { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Prize> Prizes { get; set; }
    public DbSet<PersonPrize> PersonPrizes { get; set; }

    public AppDbContext()
    {
        Database.EnsureCreated();
    }

    public void Seed()
    {
        #region Persons

        var johnDoe = new Person
        {
            Name = "John Doe",
            Job = "Construct worker",
            Age = 20,
        };

        var milanJanov = new Person
        {
            Name = "Milan Janov",
            Job = "Programmer",
            Age = 27,
        };

        var davidCold = new Person
        {
            Name = "David Cold",
            Job = "Project Manager",
            Age = 32,
        };

        People.Add(johnDoe);
        People.Add(milanJanov);
        People.Add(davidCold);

        SaveChanges();
        #endregion

        #region Reviews

        var johnDoeReview = new Review
        {
            PersonId = johnDoe.Id,
            Text = "Poor performance",
            Mark = 1,
        };

        var milanJanovReview = new Review
        {
            PersonId = milanJanov.Id,
            Text = "Skilled",
            Mark = 4,
        };

        var davidColdReview1 = new Review
        {
            PersonId = davidCold.Id,
            Text = "Excellent",
            Mark = 5,
        };

        var davidColdReview2 = new Review
        {
            PersonId = davidCold.Id,
            Text = "Efficient",
            Mark = 4,
        };

        Reviews.Add(johnDoeReview);
        Reviews.Add(milanJanovReview);
        Reviews.Add(davidColdReview1);
        Reviews.Add(davidColdReview2);
        SaveChanges();
        #endregion

        #region Prizes

        var greatestPrize = new Prize { Name = "Greatest Prize" };
        var employeeOfTheMonthPrize = new Prize { Name = "Employee of The Month Prize" };
        Prizes.Add(greatestPrize);
        Prizes.Add(employeeOfTheMonthPrize);
        SaveChanges();

        List<PersonPrize> personPrizes =
        [
            new PersonPrize { PersonId = milanJanov.Id, PrizeId = employeeOfTheMonthPrize.Id },
            new PersonPrize { PersonId = milanJanov.Id, PrizeId = greatestPrize.Id },
            new PersonPrize { PersonId = davidCold.Id, PrizeId = employeeOfTheMonthPrize.Id },
        ];

        PersonPrizes.AddRange(personPrizes);
        SaveChanges();

        #endregion
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connStr =
            "Server=SZABOLCS-PC;Database=HSZF;Trusted_Connection=True;TrustServerCertificate=True;";

        optionsBuilder.UseSqlServer(connStr);
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ConfigurePersonsTable(modelBuilder);
        ConfigureReviewsTable(modelBuilder);
        ConfigurePrizesTable(modelBuilder);
        ConfigurePersonPrizesTable(modelBuilder);
        base.OnModelCreating(modelBuilder);
    }

    private void ConfigurePersonsTable(ModelBuilder modelBuilder)
    {
        var builder = modelBuilder.Entity<Person>();
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Job).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Age).IsRequired();

        // kapcsolatok
        builder
            .HasMany(x => x.Reviews)
            .WithOne(x => x.Person)
            .HasForeignKey(x => x.PersonId)
            .OnDelete(DeleteBehavior.Cascade);
    }

    private void ConfigureReviewsTable(ModelBuilder modelBuilder)
    {
        var builder = modelBuilder.Entity<Review>();
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Text).IsRequired().HasMaxLength(300);
        builder.Property(x => x.Mark).IsRequired();
    }

    private void ConfigurePrizesTable(ModelBuilder modelBuilder)
    {
        var builder = modelBuilder.Entity<Prize>();
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
    }

    private void ConfigurePersonPrizesTable(ModelBuilder modelBuilder)
    {
        var builder = modelBuilder.Entity<PersonPrize>();

        builder.HasKey(x => new { x.PersonId, x.PrizeId });

        builder
            .HasOne(x => x.Person)
            .WithMany(x => x.PersonPrizes)
            .HasForeignKey(x => x.PersonId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(x => x.Prize)
            .WithMany(x => x.PersonPrizes)
            .HasForeignKey(x => x.PrizeId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
