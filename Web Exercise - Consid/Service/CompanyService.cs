using Microsoft.EntityFrameworkCore;
using Web_Exercise___Consid.Data;
using Web_Exercise___Consid.Interface;
using Web_Exercise___Consid.Models.Entities;

namespace Web_Exercise___Consid.Service
{
    public class CompanyService : ICompany
    {
        private readonly DataContext _context;
        
        public CompanyService(DataContext context )
        {
            _context = context;   
            
        }
        public async Task<Company> AddCompany(Company company)
        {
            
                _context.Companies.Add(company);
                await _context.SaveChangesAsync();
                return company;
            
        }

        public async Task<Company> DeleteCompany(Company company)
        {
            _context.Companies.Remove(company);
           await _context.SaveChangesAsync();

            return  company;
        }

        public async Task<List<Company>> GetAll()
        {
            return await _context.Companies.ToListAsync();
        }

        public async Task<Company> GetById(Guid id)
        {
           
         
            return await _context.Companies.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Company> UpdateCompany(Company company)
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
