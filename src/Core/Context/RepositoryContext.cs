using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Core
{
    public class RepositoryContext : IdentityDbContext<User>
    {
        protected readonly IConfiguration Configuration;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public RepositoryContext(DbContextOptions options, IConfiguration configuration) : base(options)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
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
