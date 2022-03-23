using Web_Exercise___Consid.Models.Entities;

namespace Web_Exercise___Consid.Interface
{
    public interface ICompany
    {
        Task<List<Company>> GetAll();

        Task<Company> GetById(Guid id);

        Task<Company> AddCompany(Company company);

        Task<Company> UpdateCompany(Company company);
        Task<Company> DeleteCompany(Company company);
    }
}
