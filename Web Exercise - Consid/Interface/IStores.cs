using Web_Exercise___Consid.Models.Entities;

namespace Web_Exercise___Consid.Interface
{
    public interface IStores
    {
        Task<List<Stores>> GetAll();

        Task<Stores> GetById(Guid id);

        Task<Stores> AddStore(Stores store);

        Task<Stores> UpdateStore(Stores store);
        Task<Stores> DeleteStore(Stores store);
    }
}
