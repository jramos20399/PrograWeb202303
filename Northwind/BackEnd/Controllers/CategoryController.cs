using BackEnd.Services.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        public ICategoryService _categoryService;


        public CategoryController(ICategoryService categoryService)
        {
                _categoryService = categoryService;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<IEnumerable<Category>> Get()
        {
            return await _categoryService.GetCategoriesAsync();
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Category category = _categoryService.GetById(id);


            return Ok(category);
        }

        // POST api/<CategoryController>
        [HttpPost]
        public IActionResult Post([FromBody] Category category)
        {

            _categoryService.AddCategory(category);
            return Ok(category);

        }

        // PUT api/<CategoryController>/5
        [HttpPut]
        public IActionResult Put( [FromBody] Category category)
        {
            _categoryService.UpdateCategory(category);
            return Ok(category);
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Category category = new Category
            {
                CategoryId = id
            };

            _categoryService.DeteleCategory(category);

            return Ok();
        }
    }
}
