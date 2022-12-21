using Core.Models;
using Core.Models.Customer.Identity;
using Core.Models.Customer.Personal;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Core.Connect
{
    public class RepositoryContext : IdentityDbContext<User>
    {
        protected readonly IConfiguration Configuration;

        public RepositoryContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = Configuration.GetConnectionString("WebApiDatabase");
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
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
