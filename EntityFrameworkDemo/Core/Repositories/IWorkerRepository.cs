using System.Collections.Generic;
using EntityFrameworkDemo.Core.Domain;

namespace EntityFrameworkDemo.Core.Repositories
{
    public interface IWorkerRepository : IRepository<Worker>
    {
        bool AddWorker(Worker worker);

        bool RemoveWorker(Worker worker);

        Employer GetWorkerEmployer(Worker worker);
        List<Worker> GetAllWorkersWithEmployers();
    }
}