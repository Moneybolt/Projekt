using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class AppDbContext : IdentityDbContext<IdentityUser>
{
    public DbSet<TravelEntity> Travel { get; set; }
    public DbSet<OrganizationEntity> Organization { get; set; }
    private string DbPath { get; set; }
    public AppDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "travel.db");

    }
    protected override void OnConfiguring(DbContextOptionsBuilder options) =>
    options.UseSqlite($"Data Source={DbPath}");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        var user = new IdentityUser()
        {
            Id = Guid.NewGuid().ToString(),
            UserName = "test",
            NormalizedUserName = "TEST",
            Email = "test@wsei.pl",
            NormalizedEmail = "TEST@WSEI.PL",
            EmailConfirmed = true,

        };
        var regularUser = new IdentityUser()
        {
            Id = Guid.NewGuid().ToString(),
            UserName = "normal",
            NormalizedUserName = "NORMAL",
            Email = "normal@wsei.pl",
            NormalizedEmail = "NORMAL@WSEI.PL",
            EmailConfirmed = true,
        };

        PasswordHasher<IdentityUser> passwordHasher1 = new PasswordHasher<IdentityUser>();
        user.PasswordHash = passwordHasher1.HashPassword(user, "Admin@21");
        modelBuilder.Entity<IdentityUser>().HasData(user);

        PasswordHasher<IdentityUser> passwordHasher2 = new PasswordHasher<IdentityUser>();
        regularUser.PasswordHash = passwordHasher2.HashPassword(regularUser, "test123");
        modelBuilder.Entity<IdentityUser>().HasData(regularUser);


        var adminRole = new IdentityRole()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "admin",
            NormalizedName = "ADMIN"
        };
        adminRole.ConcurrencyStamp = adminRole.Id;

        var userRole = new IdentityRole()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "user",
            NormalizedName = "USER"
        };

        modelBuilder.Entity<IdentityRole>().HasData(adminRole);
        modelBuilder.Entity<IdentityRole>().HasData(userRole);

        modelBuilder.Entity<IdentityUserRole<string>>()
            .HasData(
                new IdentityUserRole<string>
                {
                    RoleId = adminRole.Id,
                    UserId = user.Id,
                },
                new IdentityUserRole<string>
                {
                    UserId = regularUser.Id,
                    RoleId = userRole.Id
                }
            );

        modelBuilder.Entity<TravelEntity>()
           .HasOne(e => e.Organization)
           .WithMany(o => o.Travel)
           .HasForeignKey(e => e.OrganizationId);

        modelBuilder.Entity<OrganizationEntity>().HasData(
            new OrganizationEntity(){Id = 101, Title = "Test", Nip = "123123", Regon = "14124"},
            new OrganizationEntity(){Id = 102, Title = "Testowy", Nip = "12431", Regon = "12412f"}
        );
        modelBuilder.Entity<TravelEntity>().HasData(
            new TravelEntity()
            {
                Id = 1,
                Name = "Test",
                Start_Date = "2014-12-12",
                End_Date = "2018-07-11",
                Start_Place = "Kraków",
                End_Place = "Praga",
                Participants = 27,
                Guide = "Szymon",
                OrganizationId = 101,
            },
            new TravelEntity()
            {
                Id = 2,
                Name = "Nazwa",
                Participants = 49,
                Guide = "Jarosław",
                OrganizationId = 102,
            }
            );
        modelBuilder.Entity<OrganizationEntity>()
         .OwnsOne(e => e.Address)
         .HasData(
            new { OrganizationEntityId = 101, City = "Kraków", Street = "Św.Filipa 17", PostalCode = "31-150", Region = "Małopolskie" },
            new { OrganizationEntityId = 102, City = "Rzeszów", Street = "Hetmańska 12", PostalCode = "39-200", Region = "Podkarpackie" }
            );
    }
}

