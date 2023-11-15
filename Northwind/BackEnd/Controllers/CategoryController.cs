using BackEnd.Models;
using BackEnd.Services.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]

    [Authorize]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        public ICategoryService _categoryService;
        ILogger<CategoryController> _logger;

        private Category Convertir(CategoryModel category)
        {
            return new Category
            {
                CategoryId = category.CategoryId,
                Description = category.Description,
                CategoryName = category.CategoryName
            };
        
        }


        private CategoryModel Convertir(Category category)
        {
            return new CategoryModel
            {
                CategoryId = category.CategoryId,
                Description = category.Description,
                CategoryName = category.CategoryName
            };

        }

        public CategoryController(ICategoryService categoryService, ILogger<CategoryController> logger)
        {
                _categoryService = categoryService;
            _logger = logger;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogError("***********PRUEBA ERROR **************");
            IEnumerable<Category> lista =  _categoryService.GetCategoriesAsync().Result; 
            List<CategoryModel> categories =  new List<CategoryModel>();

            foreach (var item in lista)
            {
                categories.Add(Convertir(item));

            }

            return Ok(categories);
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            _logger.LogInformation("***********PRUEBA INFROMACION  **************");
            Category category = _categoryService.GetById(id);
            CategoryModel categoryModel = Convertir(category);

            return Ok(categoryModel);
        }

        // POST api/<CategoryController>
        [HttpPost]
        public IActionResult Post([FromBody] CategoryModel category)
        {
            Category entity = Convertir(category);
            _categoryService.AddCategory(entity);
            return Ok(Convertir(entity));

        }

        // PUT api/<CategoryController>/5
        [HttpPut]
        public IActionResult Put( [FromBody] CategoryModel category)
        {
            Category entity = Convertir(category);
            _categoryService.UpdateCategory(entity);
            return Ok(Convertir(entity));
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
