using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface ICategoryHelper
    {

        string Token { get; set; }
        List<CategoryViewModel> GetAll();
        CategoryViewModel GetById(int id);
        CategoryViewModel AddCategory(CategoryViewModel categoryViewModel);
        CategoryViewModel EditCategory(CategoryViewModel categoryViewModel);

        void DeleteCategory(int id);

    }
}
