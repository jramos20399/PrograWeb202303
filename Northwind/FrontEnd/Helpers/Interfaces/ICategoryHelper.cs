using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface ICategoryHelper
    {
        List<CategoryViewModel> GetAll();
        CategoryViewModel AddCategory(CategoryViewModel categoryViewModel);
    }
}
