using System.Data.Common;
using Ott.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Ott.Data
{
    public class OttContext : DbContext
    {
        public OttContext(DbContextOptions<OttContext> opt ) : base(opt)
        {
            
        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Watchlist> Watchlists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //this is rule that defines thata profile cannot rate the same movie twice hence .IsUnique
            modelBuilder.Entity<Rating>().HasIndex(r => new{r.ProfileId, r.MovieId}).IsUnique();
            //this is rule that defines thata profile cannot add the same movie twice i watchlist .IsUnique
            modelBuilder.Entity<Watchlist>().HasIndex(w => new{w.ProfileId, w.MovieId}).IsUnique();
        }
    }
}