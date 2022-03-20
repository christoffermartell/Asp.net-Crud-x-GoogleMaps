using Microsoft.EntityFrameworkCore;
using Web_Exercise___Consid.Data;
using Web_Exercise___Consid.Interface;
using Web_Exercise___Consid.Models.Entities;

namespace Web_Exercise___Consid.Service
{
    public class StoresService : IStores
    {
        private readonly DataContext _context;
        public StoresService(DataContext context)
        {
            _context = context;
        }
        public async Task<Stores> AddStore(Stores Store)
        {
            _context.Stores.Add(Store);
            _context.SaveChangesAsync();
            return Store;
        }

        public async Task<Stores> DeleteStore(Stores store)
        {
            _context.Stores.Remove(store);
            _context.SaveChangesAsync();

            return store;
        }

        public async Task<List<Stores>> GetAll()
        {
            return await _context.Stores.ToListAsync();
        }

        public async Task<Stores> GetById(Guid id)
        {
            return await _context.Stores.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Stores> UpdateStore(Stores Store)
        {
            var dbStore = await _context.Stores.FindAsync(Store.Id);

            if(dbStore != null)
            {
                dbStore.Name = Store.Name;
                dbStore.Adress = Store.Adress;
                dbStore.City = Store.City;
                dbStore.Zip = Store.Zip;
                dbStore.Country = Store.Country;
                dbStore.Longitude = Store.Longitude;
                dbStore.Latitude = Store.Latitude;

                _context.Stores.Update(dbStore);
                await _context.SaveChangesAsync();
            }
            return await _context.Stores.FirstOrDefaultAsync(x => x.Id == Store.Id);
        }
    }
}
