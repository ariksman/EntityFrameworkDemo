using System;
using System.IO;
using EntityFrameworkDemo.Core;
using EntityFrameworkDemo.Core.Repositories;
using EntityFrameworkDemo.Persistence.Repositories;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EntityFrameworkDemo.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;

        public UnitOfWork(DbContextOptions contextOptions)
        {
            _context = new DatabaseContext(contextOptions);

            Employers = new EmployerRepository(_context);
            Workers = new WorkerRepository(_context);

            Migrate();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                }
            }
        }

        public IEmployerRepository Employers { get; }
        public IWorkerRepository Workers { get; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Migrate()
        {
            try
            {
                _context.Database.EnsureCreated();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            try
            {
                _context.Database.Migrate();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }

    public class DatabaseConnectionFactory : IDesignTimeDbContextFactory<DatabaseContext>
    {
        public DatabaseConnectionFactory()
        {

        }

        public DatabaseContext CreateDbContext(string[] args)
        {
            var dir = GetInstallDirectory();
            return new DatabaseContext(CreateConnectionString(dir));
        }

        private string GetInstallDirectory()
        {
            var installationDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
            var filePath = Path.Combine(installationDirectory, "localDb.sqlite");

            return filePath;
        }

        private static DbContextOptions CreateConnectionString(string dataSource)
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = dataSource };
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);

            var optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseSqlite(connection);
            optionsBuilder.UseLazyLoadingProxies();
            return optionsBuilder.Options;
        }
    }
}