using BackEnd.Models;
using BackEnd.Services.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        /// <summary>
        /// Convierte Product en ProducModel
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        ProductModel Convertir(Product product)
        {
            return new ProductModel
            {
                CategoryId = product.CategoryId,
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                SupplierId = product.SupplierId,
                QuantityPerUnit = product.QuantityPerUnit,
                UnitPrice = product.UnitPrice,
                UnitsInStock = product.UnitsInStock,
                UnitsOnOrder = product.UnitsOnOrder,
                ReorderLevel = product.ReorderLevel,
                Discontinued = product.Discontinued

            };
        }


        /// <summary>
        /// Convierte ProductModel en Product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        Product Convertir(ProductModel product)
        {
            return new Product
            {
                CategoryId = product.CategoryId,
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                SupplierId = product.SupplierId,
                QuantityPerUnit = product.QuantityPerUnit,
                UnitPrice = product.UnitPrice,
                UnitsInStock = product.UnitsInStock,
                UnitsOnOrder = product.UnitsOnOrder,
                ReorderLevel = product.ReorderLevel,
                Discontinued = product.Discontinued

            };
        }


        IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;  
        }


        // GET: api/<ProductController>
        [HttpGet]
        public async Task <IActionResult> Get()
        {
            IEnumerable<Product> products =await _productService.GetProducts();
            List<ProductModel> productModels = new List<ProductModel>();

            foreach (var item in products)
            {
                productModels.Add(this.Convertir(item));
            }


            return Ok(productModels);
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Product product =await _productService.GetById(id);
            return Ok(this.Convertir(product));
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductModel productModel)
        {
            Product product = this.Convertir(productModel);

            _productService.Add(product);



            return Ok(Convertir(product));
        }

        // PUT api/<ProductController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ProductModel productModel)
        {
            Product product = this.Convertir(productModel);

            _productService.Update(product);



            return Ok(Convertir(product));
        }

        // DELETE api/<ProductController>/5
        [HttpDelete]
        public void Delete(int id)
        {
            _productService.Delete(id);

        }
    }
}
