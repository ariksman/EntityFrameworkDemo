using System;
using EntityFrameworkDemo.Core.Repositories;

namespace EntityFrameworkDemo.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IEmployerRepository Employers { get; }
        IWorkerRepository Workers { get; }
        int Complete();
        void Migrate();
    }
}
