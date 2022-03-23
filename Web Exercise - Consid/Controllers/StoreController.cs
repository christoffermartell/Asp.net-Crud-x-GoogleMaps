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
    public class StoreController : Controller
    {

        private readonly DataContext _context;
        private readonly IStore _StoresService;
        private readonly ILogger<StoreController> _logger;
        private readonly IMapper _mapper;


        public StoreController(DataContext context, IStore service, ILogger<StoreController> logger, IMapper mapper)
        {
            _context = context;
            _StoresService = service;
            _logger = logger;
            _mapper = mapper;

        }

        [HttpGet]
        public async Task<ActionResult<List<StoreDto>>> Get()
        {
            try
            {
                var stores = await _StoresService.GetAll();
                var storeDto = _mapper.Map<List<StoreDto>>(stores);

                return Ok(storeDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"something went wrong in the {nameof(Get)}");
                return StatusCode(500, ("Internal server error. Please try again later"));
            }


        }

        [HttpGet]
        [Route("[Action]{id}")]
        public async Task<ActionResult<List<StoreDto>>> GetStoresOfCompany(Guid id)
        {
            try
            {
                var stores =  _context.Stores.Where(x => x.CompanyId == id).ToList();
                var storesDto = _mapper.Map<List<StoreDto>>(stores);
                return Ok(storesDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"something went wrong in the {nameof(GetStoresOfCompany)}");
                return StatusCode(500, ("Internal server error. Please try again later"));
            }


        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<StoreDto>> GetSpecific(Guid id)
        {
            try
            {   
                
                var dbStore = await _StoresService.GetById(id);
                var dbStoreDto = _mapper.Map<StoreDto>(dbStore);
                return Ok(dbStoreDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"something went wrong in the {nameof(GetSpecific)}");
                return StatusCode(500, ("Internal server error. Please try again later"));
            }


        }



        [HttpPost]
        [Route("[Action]")]
        public async Task<ActionResult<Store>> AddStore([FromBody] Store store)
        {
            try
            {
                var newStore = await _StoresService.AddStore(store);
                var storeDto = _mapper.Map<StoreDto>(newStore);

               
                _logger.LogInformation("Store was succesfully created.");
                return Ok(storeDto);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"something went wrong in the {nameof(AddStore)}");
                return StatusCode(500, ("Internal server error. Please try again later"));
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Store>> Delete(Guid id)
        {
            try
            {
                var dbStore = _StoresService.GetById(id);
               await _StoresService.DeleteStore(await dbStore);
                _logger.LogInformation("Store was succesfully deleted.");
                return Ok("Company was deleted.");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"something went wrong in the {nameof(Delete)}");
                return StatusCode(500, ("Internal server error. Please try again later"));
            }

        }
        [HttpPatch]
        public async Task<ActionResult<Store>> UpdateCompany([FromBody] Store store)
        {

            try
            {
                var dbStore = await _StoresService.UpdateStore(store);
                var storeDto = _mapper.Map<StoreDto>(dbStore);

                
                _logger.LogInformation("Store was succesfully updated.");
                return Ok(storeDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"something went wrong in the {nameof(UpdateCompany)}");
                return StatusCode(500, ("Internal server error. Please try again later"));
            }


        }

        [HttpPatch]
        [Route("updateLngLat")]
        public async Task<ActionResult<Store>> UpdateLngLat([FromHeader] Guid id, [FromHeader] string lng, [FromHeader] string lat)
        {
            try
            {
                await _StoresService.updateStoreDetails(id, lng, lat);
                _logger.LogInformation("Longitude and latitude was succesfully updated.");
                return Ok();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"something went wrong in the {nameof(UpdateLngLat)}");
                return StatusCode(500, ("Internal server error. Please try again later"));
            }
         
           
            

       
        }


    }
}
