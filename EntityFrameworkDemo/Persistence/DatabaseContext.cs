using EntityFrameworkDemo.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkDemo.Persistence
{
    public sealed class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Employer> Employers { get; set; }
        public DbSet<Worker> Workers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite("Data Source=test.db");
        }

/*        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DatabaseContext>(options => options.UseSqlite("Data Source=blog.db"));
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employer>()
                .HasMany(employer => employer.Workers)
                .WithOne(worker => worker.Employer1);
        }

    }
}
