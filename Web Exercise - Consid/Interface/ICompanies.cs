using Web_Exercise___Consid.Models.Entities;

namespace Web_Exercise___Consid.Interface
{
    public interface ICompanies
    {
        Task<List<Companies>> GetAll();

        Task<Companies> GetById(Guid id);

        Task<Companies> AddCompany(Companies company);

        Task<Companies> UpdateCompany(Companies company);
        Task<Companies> DeleteCompany(Companies company);
    }
}
