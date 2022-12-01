using Core.Models;
using Core.Models.Customer.Identity;
using Core.Models.Customer.Personal;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Core.Connect
{
    public class RepositoryContext : IdentityDbContext<User>
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=;database=demo");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Business> Businesses { get; set; }
        public DbSet<ConfigCorp> ConfigCorps { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<HistoryChangeExpense> HistoryChangeExpenses { get; set; }
        public DbSet<HistoryChangeIncome> HistoryChangeIncomes { get; set; }
        public DbSet<HistoryChangeInfo> HistoryChangeInfos { get; set; }
        public DbSet<CategoryExpense> GetCategoryExpenses { get; set; }
        public DbSet<DetailExpense> DetailExpenses { get; set; }
        public DbSet<CategoryInCome> CategoryInComes { get; set; }
        public DbSet<DetailInCome> DetailInComes { get; set; }
    }
}
