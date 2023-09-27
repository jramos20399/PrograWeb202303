using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Category GetById(int id);
        bool AddCategory(Category category);
        bool UpdateCategory(Category category);
        bool DeteleCategory(Category category);


    }
}
