using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class CategoryService : ICategoryService
    {

        public IUnidadDeTrabajo _unidadDeTrabajo;

        public CategoryService(IUnidadDeTrabajo unidadDeTrabajo)
        {
                _unidadDeTrabajo = unidadDeTrabajo;
        }


        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            IEnumerable<Category> categories;
            categories = await _unidadDeTrabajo._categoryDAL.GetAll();
            return categories;
        }
    }
}
