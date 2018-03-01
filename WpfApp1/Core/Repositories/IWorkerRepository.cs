using System.Collections.Generic;
using System.Windows.Documents;
using WpfApp.Core.Domain;

namespace WpfApp.Core.Repositories
{
    public interface IWorkerRepository : IRepository<Worker>
    {
        bool AddWorker(Worker worker);

        bool RemoveWorker(Worker worker);

        Employer GetWorkerEmployer(Worker worker);
        List<Worker> GetAllWorkersWithEmployers();
    }
}