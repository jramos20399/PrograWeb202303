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

        public bool AddCategory(Category category)
        {
            bool resultado =_unidadDeTrabajo._categoryDAL.Add(category);
            _unidadDeTrabajo.Complete();

            return resultado;

        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            IEnumerable<Category> categories;
            categories = await _unidadDeTrabajo._categoryDAL.GetAll();
            return categories;
        }
    }
}
