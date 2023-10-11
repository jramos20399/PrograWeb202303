using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class ProductController : Controller
    {



        IProductHelper productHelper;
        ICategoryHelper categoryHelper;
        ISupplierHelper supplierHelper;

        public ProductController(IProductHelper _productHelper
                                    , ICategoryHelper _categoryHelper
                                    , ISupplierHelper _supplierHelper
                )
        {
            productHelper = _productHelper;
            categoryHelper = _categoryHelper;
            supplierHelper = _supplierHelper;
        }
        // GET: ProductController
        public ActionResult Index()
        {
            List<ProductViewModel> products = productHelper.GetAll();

            return View(products);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {


            ProductViewModel product = productHelper.GetById(id);

            return View(product);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {


            ProductViewModel product = new ProductViewModel();
            product.Categories= categoryHelper.GetAll() ;
            product.Suppliers= supplierHelper.GetAll();    



            return View(product);
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductViewModel product)
        {
            try
            {
                productHelper.AddProduct(product);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            ProductViewModel product = productHelper.GetById(id);
            product.Suppliers = supplierHelper.GetAll();
            product.Categories = categoryHelper.GetAll();

            return View(product);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductViewModel product)
        {
            try
            {

                productHelper.EdiProduct(product);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            ProductViewModel product = productHelper.GetById(id);

            return View(product);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ProductViewModel product)
        {
            try
            {
                productHelper.DeleteProduct(product.ProductId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
