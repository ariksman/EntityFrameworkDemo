using System.IO;
using CommonServiceLocator;
using EntityFrameworkDemo.Core;
using EntityFrameworkDemo.Core.Repositories;
using EntityFrameworkDemo.Persistence;
using EntityFrameworkDemo.Persistence.Repositories;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Unity;

namespace EntityFrameworkDemo.ViewModels
{
    public class ViewModelLocator
    {

        private readonly UnityContainer _unityContainer;
        private readonly LifetimeManager _mainWindowLifetimeManager = new ContainerControlledLifetimeManager();
        private readonly LifetimeManager _databaseLifetimeManager = new TransientLifetimeManager();

        public ViewModelLocator()
        {
            // Register SimpleIoc as the IOC container
            //ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            //SimpleIoc.Default.Register<MainViewModel>();

            // Register Unity as the IOC container
            _unityContainer = new UnityContainer();
            ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(_unityContainer));

            _unityContainer.RegisterType<IUnitOfWork, UnitOfWork>("LocalDatabase", _databaseLifetimeManager, new InjectionConstructor(CreateConnectionString()));

            _unityContainer.RegisterType<MainViewModel>(_mainWindowLifetimeManager);

            _unityContainer.RegisterType(typeof(IRepository<>), typeof(Repository<>));
            _unityContainer.RegisterType(typeof(IEmployerRepository), typeof(EmployerRepository));
            _unityContainer.RegisterType(typeof(IWorkerRepository), typeof(WorkerRepository));
        }

        public MainViewModel MainViewModel
        {
            get { return ServiceLocator.Current.GetInstance<MainViewModel>(); }
        }

        private DbContextOptions CreateConnectionString()
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = GetDatabaseFile() };
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);

            var optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseSqlite(connection);
            return optionsBuilder.Options;
        }

        private string GetDatabaseFile()
        {
            var installationDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
            var filePath = Path.Combine(installationDirectory, "localDb.sqlite");

            return filePath;
        }
    }
}
