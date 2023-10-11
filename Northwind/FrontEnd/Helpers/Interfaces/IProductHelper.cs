using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface IProductHelper
    {


        List<ProductViewModel> GetAll();
        ProductViewModel GetById(int id);
        ProductViewModel AddProduct(ProductViewModel ProductViewModel);
        ProductViewModel EdiProduct(ProductViewModel ProductViewModel);

        void DeleteProduct(int id);
    }
}
