using System.Collections.Generic;
using WpfApp.Core.Domain;

namespace WpfApp.Core.Repositories
{
    public interface IEmployerRepository : IRepository<Employer>
    {
        bool AddEmployer(Employer employer);

        bool RemoveEmployer(Employer employer);

        IEnumerable<Worker> GetAllWorkers(Employer employer);
    }
}