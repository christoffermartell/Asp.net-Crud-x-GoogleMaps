using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_Exercise___Consid.Data;
using Web_Exercise___Consid.Interface;
using Web_Exercise___Consid.Models.Entities;

namespace Web_Exercise___Consid.Controllers
{
    [Route("api/[controller]")]
    public class CompaniesController : ControllerBase

    {
        private readonly DataContext _context;
        private readonly ICompanies _CompanyService;
        public CompaniesController(DataContext context, ICompanies service)
        {
            _context = context;
            _CompanyService = service;
        }


        [HttpGet]
        public async Task<ActionResult<List<Companies>>> Get()
        {
            try
            {
                return await _CompanyService.GetAll();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Companies>> GetSpecific(Guid id)
        {
            try
            {
                   var dbCompany = _CompanyService.GetById(id);
                   return await dbCompany;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        
        }

        [HttpPost]
        public async Task<ActionResult<List<Companies>>> Add([FromBody] Companies companies)
        {
            try
            {
            _CompanyService.AddCompany(companies);

            return await _context.Companies.ToListAsync();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Companies>> Delete(Guid id)
        {
            try
            {
            var dbComapny = _CompanyService.GetById(id);
            _CompanyService.DeleteCompany(await dbComapny);
           
            return Ok("Company was deleted.");

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        [HttpPatch]
        public async Task<ActionResult<List<Companies>>> UpdateCompany([FromBody]Companies company)
        {
            try
            {
                var dbCompany = await _CompanyService.GetById(company.Id);

                _CompanyService.UpdateCompany(company);
                return Ok(company);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }



          



            return BadRequest();
        }

    }
}
