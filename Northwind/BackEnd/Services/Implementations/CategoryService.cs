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

        public bool DeteleCategory(Category category)
        {
            bool resultado = _unidadDeTrabajo._categoryDAL.Remove(category);
            _unidadDeTrabajo.Complete();

            return resultado;
        }

        public Category GetById(int id)
        {
            Category category;
            category =  _unidadDeTrabajo._categoryDAL.Get(id);
            return category;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            IEnumerable<Category> categories;
            categories = await _unidadDeTrabajo._categoryDAL.GetAll();
            return categories;
        }

        public bool UpdateCategory(Category category)
        {
            bool resultado = _unidadDeTrabajo._categoryDAL.Update(category);
            _unidadDeTrabajo.Complete();

            return resultado;
        }
    }
}
