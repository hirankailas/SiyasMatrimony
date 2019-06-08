using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SiyasMatrimony.API.Models;
namespace SiyasMatrimony.API.Data
{
    public class DataContext : IdentityDbContext<User,Role,int,IdentityUserClaim<int>,UserRole,IdentityUserLogin<int>,
                                IdentityRoleClaim<int>,IdentityUserToken<int>>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){ }
       // public DbSet<User> Users { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Value> Values { get; set; }
        public DbSet<Religion> Religions { get; set; }
        public DbSet<Caste> Castes { get; set; }
        public DbSet<Star> Stars { get; set; }
        public DbSet<Rashi> Rashis { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<UserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                .WithMany(ur => ur.UserRoles)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();

                userRole.HasOne(ur => ur.User)
                .WithMany(ur => ur.UserRoles)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();
            });
            builder.Entity<State>()
                .HasOne<Country>(p=>p.Country)
                .WithMany(q=>q.States)
                .HasForeignKey(ur=>ur.country_id);
            builder.Entity<City>()
                .HasOne<State>(p=>p.State)
                .WithMany(q=>q.Cities)
                .HasForeignKey(ur=>ur.state_id);
            builder.Entity<City>()
                .HasOne<Country>(p=>p.Country)
                .WithMany(q=>q.Cities)
                .HasForeignKey(ctctry => ctctry.country_id);

            //builder.Entity<User>().Property(m=>m.Name).IsRequired();
        } 
    }
}

