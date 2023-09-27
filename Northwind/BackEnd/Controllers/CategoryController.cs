using BackEnd.Models;
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

        public CategoryController(ICategoryService categoryService)
        {
                _categoryService = categoryService;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public IActionResult Get()
        {
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
