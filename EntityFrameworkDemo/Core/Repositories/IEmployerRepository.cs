using System.Collections.Generic;
using EntityFrameworkDemo.Core.Domain;

namespace EntityFrameworkDemo.Core.Repositories
{
    public interface IEmployerRepository : IRepository<Employer>
    {
        bool AddEmployer(Employer employer);

        bool RemoveEmployer(Employer employer);

        IEnumerable<Worker> GetAllWorkers(Employer employer);
    }
}