using Microsoft.EntityFrameworkCore;
using Web_Exercise___Consid.Data;
using Web_Exercise___Consid.Interface;
using Web_Exercise___Consid.Models.Entities;

namespace Web_Exercise___Consid.Service
{
    public class CompaniesService : ICompanies
    {
        private readonly DataContext _context;
        public CompaniesService(DataContext context)
        {
            _context = context;   
        }
        public async Task<Companies> AddCompany(Companies company)
        {
            _context.Companies.Add(company);
            _context.SaveChangesAsync();
            return company;
        }

        public async Task<Companies> DeleteCompany(Companies company)
        {
            _context.Companies.Remove(company);
            _context.SaveChangesAsync();

            return  company;
        }

        public async Task<List<Companies>> GetAll()
        {
            return await _context.Companies.ToListAsync();
        }

        public async Task<Companies> GetById(Guid id)
        {
            return await _context.Companies.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Companies> UpdateCompany(Companies company)
        {
            var dbCompnay = await _context.Companies.FindAsync(company.Id);
            if (dbCompnay != null)
            {
               dbCompnay.OrganizationNumber = company.OrganizationNumber;
               dbCompnay.Name = company.Name;
               dbCompnay.Notes = company.Notes;
                _context.Companies.Update(dbCompnay);
              await  _context.SaveChangesAsync();
                
            }

            return await _context.Companies.FirstOrDefaultAsync(x => x.Id == company.Id);
        }
    }
}
