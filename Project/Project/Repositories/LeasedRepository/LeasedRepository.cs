using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;

namespace Project.Repositories.LeasedRepository
{
    public class LeasedRepository: ILeasedRepository
    {
        protected readonly ProjectContext _context;
        protected readonly DbSet<Leased> _table;

        public LeasedRepository(ProjectContext context)
        {
            _context = context;
            _table = _context.Set<Leased>();
        }

        // Get all
        public async Task<List<Leased>> GetAllAsync()
        {
            return await _table.AsNoTracking().ToListAsync();
        }

        public IQueryable<Leased> GetAllAsQueryable()
        {
            return _table.AsNoTracking();
        }

        // Create
        public void Create(Leased entity)
        {
            _table.Add(entity);
        }
        public async Task CreateAsync(Leased entity)
        {
            await _table.AddAsync(entity);
        }
        public void CreateRange(IEnumerable<Leased> entities)
        {
            _table.AddRange(entities);
        }
        public async Task CreateRangeAsync(IEnumerable<Leased> entities)
        {
            await _table.AddRangeAsync(entities);
        }

        // Update
        public void Update(Leased entity)
        {
            _table.Update(entity);
        }
        public void UpdateRange(IEnumerable<Leased> entities)
        {
            _table.UpdateRange(entities);
        }

        // Delete
        public void Delete(Leased entity)
        {
            _table.Remove(entity);
        }
        public void DeleteRange(IEnumerable<Leased> entities)
        {
            _table.RemoveRange(entities);
        }

        // Find
        public Leased FindById(object id1, object id2)
        {
            return _table.Find(id1,id2);
        }
        public async Task<Leased> FindByIdAsync(object id1, object id2)
        {
            return await _table.FindAsync(id1,id2);
        }

        // Save
        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }
        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
        public void ShowLeasedByApartment(Guid apartmentId)
        {
            var leased = from l in _table
                         where l.ApartmentId == apartmentId
                         select l;

            foreach (Leased l in leased)
            {
                Console.WriteLine("User: " + l.UserId); ;

            }

        }
        public void ShowLeasedByUser(Guid userId)
        {
            var leased = from l in _table
                         where l.UserId == userId
                         select l;

            foreach (Leased l in leased)
            {
                Console.WriteLine("Apartment: " + l.ApartmentId);

            }
        }
    }
}
