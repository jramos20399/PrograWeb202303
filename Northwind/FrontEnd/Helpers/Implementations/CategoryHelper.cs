using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class CategoryHelper: ICategoryHelper
    {

        IServiceRepository _repository;

        public CategoryHelper(IServiceRepository serviceRepository)
        {
            _repository = serviceRepository;
        }

        public CategoryViewModel AddCategory(CategoryViewModel categoryViewModel)
        {
            throw new NotImplementedException();
        }

        public List<CategoryViewModel> GetAll()
        {

            List<CategoryViewModel> lista = new List<CategoryViewModel>();

            HttpResponseMessage responseMessage = _repository.GetResponse("api/Category");
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                lista = JsonConvert.DeserializeObject<List<CategoryViewModel>>(content);
            }

            return lista;
        }



    }
}
