using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;
using NuGet.Protocol.Core.Types;

namespace FrontEnd.Helpers.Implementations
{
    public class ProductHelper : IProductHelper
    {
        IServiceRepository _repository;

        public ProductHelper(IServiceRepository serviceRepository)
        {
            _repository = serviceRepository;
        }

        public ProductViewModel AddProduct(ProductViewModel ProductViewModel)
        {
            ProductViewModel product = new ProductViewModel();
            HttpResponseMessage responseMessage = _repository.PostResponse("api/Product", ProductViewModel);
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                product = JsonConvert.DeserializeObject<ProductViewModel>(content);
            }

            return product;
        }

        public void DeleteProduct(int id)
        {
            HttpResponseMessage responseMessage = _repository.DeleteResponse("api/Product/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;

            }
        }

        public ProductViewModel EdiProduct(ProductViewModel ProductViewModel)
        {
            ProductViewModel product = new ProductViewModel();
            HttpResponseMessage responseMessage = _repository.PutResponse("api/Product", ProductViewModel);
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                product = JsonConvert.DeserializeObject<ProductViewModel>(content);
            }

            return product;
        }

        public List<ProductViewModel> GetAll()
        {
            List<ProductViewModel> lista = new List<ProductViewModel>();

            HttpResponseMessage responseMessage = _repository.GetResponse("api/Product");
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                lista = JsonConvert.DeserializeObject<List<ProductViewModel>>(content);
            }

            return lista;
        }

        public ProductViewModel GetById(int id)
        {
            ProductViewModel Product = new ProductViewModel();
            HttpResponseMessage responseMessage = _repository.GetResponse("api/Product/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                Product = JsonConvert.DeserializeObject<ProductViewModel>(content);
            }

            return Product;
        }
    }
}
