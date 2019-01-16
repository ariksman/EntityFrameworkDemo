using EntityFrameworkDemo.Core;
using EntityFrameworkDemo.Core.Domain;

namespace EntityFrameworkDemo.ViewModels.HelperClasses
{
    public class DatabaseSeeder
    {
        private readonly IUnitOfWork _context;
        public DatabaseSeeder(IUnitOfWork context)
        {
            _context = context;
        }

        public void SeedDatabase()
        {
            var newEmployer1 = new Employer()
            {
                Name = "Fidelix",
            };
            var newEmployer2 = new Employer()
            {
                Name = "Nokia",
            };
            var newEmployer3 = new Employer()
            {
                Name = "Apple",
            };
            var newEmployer4 = new Employer()
            {
                Name = "Siemens",
            };
            var newEmployer5 = new Employer()
            {
                Name = "BMW",
            };

            _context.Employers.AddEmployer(newEmployer1);
            _context.Employers.AddEmployer(newEmployer2);
            _context.Employers.AddEmployer(newEmployer3);
            _context.Employers.AddEmployer(newEmployer4);
            _context.Employers.AddEmployer(newEmployer5);

            _context.Complete();

            var newWorker1 = new Worker()
            {
                Name = "Pekka",
                Age = 22,
                Employer1 = newEmployer1,
            };

            var newWorker2 = new Worker()
            {
                Name = "Jaska",
                Age = 24,
                Employer1 = newEmployer3,
            };
            var newWorker3 = new Worker()
            {
                Name = "Timo",
                Age = 44,
                Employer1 = newEmployer3,
            };
            var newWorker4 = new Worker()
            {
                Name = "Matti",
                Age = 55,
                Employer1 = newEmployer2,
            };
            var newWorker5 = new Worker()
            {
                Name = "Matti",
                Age = 33,
                Employer1 = newEmployer5,
            };
            var newWorker6 = new Worker()
            {
                Name = "Satu",
                Age = 28,
                Employer1 = newEmployer4,
            };
            var newWorker7 = new Worker()
            {
                Name = "Taina",
                Age = 32,
                Employer1 = newEmployer4,
            };
            var newWorker8 = new Worker()
            {
                Name = "Hanna",
                Age = 33,
                Employer1 = newEmployer2,
            };
            var newWorker9 = new Worker()
            {
                Name = "Sini",
                Age = 33,
                Employer1 = newEmployer5,
            };
            var newWorker10 = new Worker()
            {
                Name = "Matti",
                Age = 24,
                Employer1 = newEmployer5,
            };

            _context.Workers.AddWorker(newWorker1);
            _context.Workers.AddWorker(newWorker2);
            _context.Workers.AddWorker(newWorker3);
            _context.Workers.AddWorker(newWorker4);
            _context.Workers.AddWorker(newWorker5);
            _context.Workers.AddWorker(newWorker6);
            _context.Workers.AddWorker(newWorker7);
            _context.Workers.AddWorker(newWorker8);
            _context.Workers.AddWorker(newWorker9);
            _context.Workers.AddWorker(newWorker10);

            _context.Complete();
        }
    }
}
