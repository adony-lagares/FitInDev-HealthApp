using Microsoft.EntityFrameworkCore;
using FitInDevApi.Models;

namespace FitInDevApi.Data
{
    public class FitContext : DbContext
    {
        public FitContext(DbContextOptions<FitContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Recommendation> Recommendations { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
    }
}
