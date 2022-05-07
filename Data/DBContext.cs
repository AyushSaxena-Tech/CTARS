using MVCApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace MVCApplication.Data
{
    public class ClientGoalsContext : DbContext
    {
        public ClientGoalsContext(DbContextOptions<ClientGoalsContext> options) : base(options)
        {
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientGoal> ClientGoals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().ToTable("Client");
            modelBuilder.Entity<ClientGoal>().ToTable("ClientGoal");
        }
    }
}