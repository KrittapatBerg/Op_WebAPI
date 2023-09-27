using Microsoft.EntityFrameworkCore;
using Op_WebAPI.Models;

namespace Op_WebAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext() { }
        public DataContext(DbContextOptions options) : base(options) { }

        #region Table mapping
        public virtual DbSet<csAttraction> SightSeeings { get; set; }
        public virtual DbSet<csAddress> Addresses { get; set; }
        public virtual DbSet<csUser> Users { get; set; }
        public virtual DbSet<csReview> Reviews { get; set; }
        public virtual DbSet<csRating> Ratings { get; set; }
        #endregion

        #region Model creating 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        #endregion
    }
}
