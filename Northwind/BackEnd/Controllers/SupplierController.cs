using BackEnd.Services.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {

        ISupplierService _supplierService { get; set; }

        public SupplierController(ISupplierService supplierService)
        {
                _supplierService = supplierService;
        }





        // GET: api/<SupplierController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<Supplier> suppliers = await _supplierService.GetSuppliers();

            return Ok(suppliers);
        }

        // GET api/<SupplierController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SupplierController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SupplierController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SupplierController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
