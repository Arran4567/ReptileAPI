using ReptileAPI.Data.DAL.Repositories;
using ReptileAPI.Models;

namespace ReptileAPI.Data.DAL.WorkUnits
{
    public class AnimalWorkUnit : IDisposable
    {
        private ApplicationDbContext _context;
        private GenericRepository<Animal> animalRepository;

        public AnimalWorkUnit(ApplicationDbContext context)
        {
            _context = context;
        }

        public GenericRepository<Animal> AnimalRepository
        {
            get
            {
                if (animalRepository == null)
                {
                    animalRepository = new GenericRepository<Animal>(_context);
                }
                return animalRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        //Example
        //public IEnumerable<Job> GetUnassignedJobs()
        //{
        //     return JobRepository.Get(j => j.JobStatus.ID == (int)Enums.JobStatuses.JobCreated, q => q.OrderBy(j => j.DueWhen));
        //}
    }
}
