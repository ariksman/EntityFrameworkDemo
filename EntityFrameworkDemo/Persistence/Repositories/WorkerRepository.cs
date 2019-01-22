using System;
using System.Collections.Generic;
using System.Linq;
using EntityFrameworkDemo.Core.Domain;
using EntityFrameworkDemo.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkDemo.Persistence.Repositories
{
    public class WorkerRepository : Repository<Worker>, IWorkerRepository
    {
        public WorkerRepository(DbContext context) : base(context)
        {
        }

        public bool AddWorker(Worker worker)
        {
                DatabaseContext.Workers.Add(worker);
                return true;
        }

        public bool RemoveWorker(Worker worker)
        {
            throw new NotImplementedException();
        }

      public bool RemoveWorker(int workerId)
      {
        var localWorker = DatabaseContext.Workers.FirstOrDefault(w => w.WorkerId == workerId);
        DatabaseContext.Workers.Remove(localWorker ?? throw new InvalidOperationException());
        return true;
      }

      public Employer GetWorkerEmployer(Worker worker)
        {
            throw new NotImplementedException();
        }

        public List<Worker> GetAllWorkersWithEmployers()
        {
            var workers = DatabaseContext.Workers
                .Include(worker => worker.Employer1)
                .ToList();

            return workers;
        }

        public DatabaseContext DatabaseContext => Context as DatabaseContext;
    }
}