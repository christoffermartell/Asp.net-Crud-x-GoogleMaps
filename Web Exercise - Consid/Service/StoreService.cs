using Microsoft.EntityFrameworkCore;
using Web_Exercise___Consid.Data;
using Web_Exercise___Consid.Interface;
using Web_Exercise___Consid.Models.Entities;

namespace Web_Exercise___Consid.Service
{
    public class StoreService : IStore
    {
        private readonly DataContext _context;
        private readonly ICompany _CompanyService;
        public StoreService(DataContext context,ICompany company)
        {
            _context = context;
            _CompanyService = company;
        }
        public async Task<Store> AddStore(Store Store)
        {

            var company = await _CompanyService.GetById(Store.CompanyId);
            Store.Companies = company;

            if (Store.Companies == null)
            {
                throw new ArgumentNullException(nameof(Store));
            }

            _context.Stores.Add(Store);
            await  _context.SaveChangesAsync();
            return Store;
        }

        public async Task<Store> DeleteStore(Store store)
        {
            _context.Stores.Remove(store);
           await _context.SaveChangesAsync();

            return store;
        }

      

        public async Task<List<Store>> GetAll()
        {
            return await _context.Stores.ToListAsync();
        }

        public async Task<Store> GetById(Guid id)
        {
            return await _context.Stores.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Store> UpdateStore(Store Store)
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

        public async Task<Store> updateStoreDetails(Guid id, string lat, string lng)
        {
            var dbStore = await _context.Stores.FindAsync(id);

            if(dbStore != null)
            {
                dbStore.Longitude = lng;
                dbStore.Latitude = lat;

                _context.Stores.Update(dbStore);
                await _context.SaveChangesAsync();
            }
            return await _context.Stores.FirstOrDefaultAsync(x => x.Id ==id);
        }
    }
}
