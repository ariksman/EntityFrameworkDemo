using System;
using WpfApp.Core.Repositories;

namespace WpfApp.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IEmployerRepository Employers { get; }
        IWorkerRepository Workers { get; }
        int Complete();
        void Migrate();
    }
}
