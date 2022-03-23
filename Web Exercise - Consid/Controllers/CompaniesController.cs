using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_Exercise___Consid.Data;
using Web_Exercise___Consid.Interface;
using Web_Exercise___Consid.Models.Dtos;
using Web_Exercise___Consid.Models.Entities;

namespace Web_Exercise___Consid.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase

    {
        private readonly DataContext _context;
        private readonly ICompany _CompanyService;
        private readonly ILogger<CompaniesController> _logger;
        private readonly IMapper _mapper;
        public CompaniesController(DataContext context, ICompany service,ILogger<CompaniesController> logger,IMapper mapper)
        {
            _context = context;
            _CompanyService = service;
            _logger = logger;
            _mapper = mapper;
        }

        
        [HttpGet]
        public async Task<ActionResult<List<CompanyDto>>> Get()
        {
            try
            {
                var companies = await _CompanyService.GetAll();
                var companyDto = _mapper.Map<List<CompanyDto>>(companies);


                return Ok(companyDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"something went wrong in the {nameof(Get)}");
                return StatusCode(500,("Internal server error. Please try again later"));
               
            }
            
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<CompanyDto>> GetSpecific(Guid id)
        {
            try
            {
                   var dbCompany = await _CompanyService.GetById(id);
                    var companyDto = _mapper.Map<CompanyDto>(dbCompany);

                   return Ok(companyDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"something went wrong in the {nameof(GetSpecific)}");
                return StatusCode(500, ("Internal server error. Please try again later"));
            }
            
        
        }

        [HttpPost]
        public async Task<ActionResult<CompanyDto>> Add([FromBody] Company companies)
        {
            try
            {
                var newCompany = await _CompanyService.AddCompany(companies);
                var companyDto = _mapper.Map<CompanyDto>(newCompany);

                _logger.LogInformation("Company was succesfully created.");

                return Ok(companyDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"something went wrong in the {nameof(Add)}");
                return StatusCode(500, ("Internal server error. Please try again later"));
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Company>> Delete(Guid id)
        {
            try
            {
                
                var dbComapny = _CompanyService.GetById(id);
                await _CompanyService.DeleteCompany(await dbComapny);
                _logger.LogInformation("Company was succesfully deleted.");

                return Ok("Company was deleted.");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"something went wrong in the {nameof(Delete)}");
                return StatusCode(500, ("Internal server error. Please try again later"));
            }
        }
        [HttpPatch]
        public async Task<ActionResult<CompanyDto>> UpdateCompany([FromBody]Company company)
        {
            try
            {
                var dbCompany = await _CompanyService.UpdateCompany(company);
                var companyDto = _mapper.Map<CompanyDto>(dbCompany);
             
                _logger.LogInformation("Company was succesfully updated.");

                return Ok(companyDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"something went wrong in the {nameof(UpdateCompany)}");
                return StatusCode(500, ("Internal server error. Please try again later"));

            }

        }

    }
}
