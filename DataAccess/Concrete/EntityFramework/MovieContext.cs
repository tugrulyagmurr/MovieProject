using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    //Context: Db tabloları ile proje classlarını bağlamak
    public class MovieContext:DbContext
    {
        public MovieContext()
        {
        }

        public MovieContext(DbContextOptions<MovieContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rating>()
                .HasKey(r => new { r.Id, r.UserId });
            modelBuilder.Entity<Rating>()
                .HasOne(r => r.Movie)
                .WithMany(m => m.Ratings)
                .HasForeignKey(r => r.Id);
            modelBuilder.Entity<Rating>()
                .HasOne(r => r.User)
                .WithMany(u => u.Ratings)
                .HasForeignKey(r => r.UserId);
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Movie;Trusted_Connection=true");
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Rating> Ratings { get; set; }
    }
}
