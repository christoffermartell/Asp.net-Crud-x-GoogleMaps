using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_Exercise___Consid.Data;
using Web_Exercise___Consid.Interface;
using Web_Exercise___Consid.Models.Entities;

namespace Web_Exercise___Consid.Controllers
{
    [Route("api/[controller]")]
    public class StoreController : Controller
    {

        private readonly DataContext _context;
        private readonly IStores  _StoresService;

        public StoreController(DataContext context, IStores service)
        {
            _context = context;
            _StoresService = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Stores>>> Get()
        {
            try
            {
                return await _StoresService.GetAll();
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Stores>> GetSpecific(Guid id)
        {
            try
            {
                var dbStore = _StoresService.GetById(id);
                return await dbStore;
            }
            catch (Exception)
            {

                return BadRequest("Company name not found");
            }


        }

       

        [HttpPost]
        public async Task<ActionResult<List<Stores>>> Add([FromBody]Stores store )
        {
            _StoresService.AddStore(store);

            return await _context.Stores.ToListAsync();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Stores>> Delete(Guid id)
        {

            var dbStore = _StoresService.GetById(id);
            _StoresService.DeleteStore(await dbStore);

            return Ok("Company was deleted.");

        }
        [HttpPatch]
        public async Task<ActionResult<List<Stores>>> UpdateCompany([FromBody] Stores store)
        {
            
            try
            {
                var dbStore = await _StoresService.GetById(store.Id);



                _StoresService.UpdateStore(store);
                return Ok(store);
            }
            catch (Exception)
            {

                throw;
            }
            return BadRequest();
            
        }
    }
}
