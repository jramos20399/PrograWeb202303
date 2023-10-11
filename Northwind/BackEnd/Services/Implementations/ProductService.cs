using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class ProductService : IProductService
    {
        IUnidadDeTrabajo _unidadDeTrabajo;
        public ProductService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }


        public Task<bool> Add(Product product)
        {
            try
            {
                _unidadDeTrabajo._productDAL.Add(product);
                _unidadDeTrabajo.Complete();
                return Task.FromResult(true);
            }
            catch (Exception)
            {

                return Task.FromResult(false);
            }
          
        }

        public Task<bool> Delete(int id)
        {
            try
            {
                Product product = new Product { ProductId = id };

                _unidadDeTrabajo._productDAL.Remove(product);
                _unidadDeTrabajo.Complete();
                return Task.FromResult(true);
            
            }
            catch (Exception)
            {

                return Task.FromResult(false); ;
            }
        }

        public async Task<Product> GetById(int id)
        {
            Product product = _unidadDeTrabajo._productDAL.Get(id);
            return product;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            IEnumerable<Product> products = await _unidadDeTrabajo._productDAL.GetAll();
            return products;
        }

        public Task<bool> Update(Product product)
        {
            try
            {
                _unidadDeTrabajo._productDAL.Update(product);
                _unidadDeTrabajo.Complete();
                return Task.FromResult(true);
            }
            catch (Exception)
            {

                return Task.FromResult(false);
            }
            
        }
    }
}
