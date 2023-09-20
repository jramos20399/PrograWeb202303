using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();

    }
}
