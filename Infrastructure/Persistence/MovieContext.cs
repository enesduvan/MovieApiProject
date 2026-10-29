using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieApi.Domain.Entities;
using Persistence.Identity;
//add-migration mig3
//update-database
namespace Persistence
{
    public class MovieContext : IdentityDbContext<AppUser>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.;Database=MovieDB;initial catalog=MovieApiDB;Trusted_Connection=true;Integrated Security=true;TrustServerCertificate=true;");
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Cast> Casts { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Series> Series { get; set; }
        public DbSet<RelatedMovie> RelatedMovies { get; set; }
    }
}
