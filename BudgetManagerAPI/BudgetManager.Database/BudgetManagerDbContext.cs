using BudgetManager.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BudgetManager.Database
{
    public partial class BudgetManagerDbContext : DbContext
    {
        public BudgetManagerDbContext() : base() { }

        public BudgetManagerDbContext(DbContextOptions<BudgetManagerDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetParent(Directory.GetCurrentDirectory())!.FullName + "/BudgetManagerAPI/")
                    .AddJsonFile("appsettings.json")
                    .Build();
                var connectionString = configuration.GetConnectionString("BudgetManagerDatabase");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Expense>()
                .HasOne(x => x.User)
                .WithMany(x => x.Expenses)
                .OnDelete(DeleteBehavior.NoAction);
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<ExpenseCategory> ExpenseCategories { get; set; }
        public virtual DbSet<Expense> Expenses { get; set; }
    }
}
