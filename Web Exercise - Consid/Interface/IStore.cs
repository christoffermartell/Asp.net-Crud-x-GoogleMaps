using Web_Exercise___Consid.Models.Entities;

namespace Web_Exercise___Consid.Interface
{
    public interface IStore
    {
        Task<List<Store>> GetAll();

        Task<Store> GetById(Guid id);

        Task<Store> AddStore(Store store);

        Task<Store> UpdateStore(Store store);
        Task<Store> DeleteStore(Store store);

        Task<Store> updateStoreDetails(Guid id, string lat, string lng);

       
    }
}
