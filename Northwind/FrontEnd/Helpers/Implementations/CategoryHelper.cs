using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class CategoryHelper : ICategoryHelper
    {

        public string Token { get; set; }

        IServiceRepository _repository;

        public CategoryHelper(IServiceRepository serviceRepository)
        {
            _repository = serviceRepository;
        }

        public CategoryViewModel AddCategory(CategoryViewModel categoryViewModel)
        {

            CategoryViewModel category = new CategoryViewModel();
            HttpResponseMessage responseMessage = _repository.PostResponse("api/Category",categoryViewModel);
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                category = JsonConvert.DeserializeObject<CategoryViewModel>(content);
            }

            return category;
        }

        public void DeleteCategory(int id)
        {
           
            HttpResponseMessage responseMessage = _repository.DeleteResponse("api/Category/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                
            }

            
        }

        public CategoryViewModel EditCategory(CategoryViewModel categoryViewModel)
        {

            CategoryViewModel category = new CategoryViewModel();
            HttpResponseMessage responseMessage = _repository.PutResponse("api/Category", categoryViewModel);
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                category = JsonConvert.DeserializeObject<CategoryViewModel>(content);
            }

            return category;
        }

        public List<CategoryViewModel> GetAll()
        {

            _repository.Client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);


            List<CategoryViewModel> lista = new List<CategoryViewModel>();

            HttpResponseMessage responseMessage = _repository.GetResponse("api/Category");
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                lista = JsonConvert.DeserializeObject<List<CategoryViewModel>>(content);
            }

            return lista;
        }

        public CategoryViewModel GetById(int id)
        {
            CategoryViewModel category = new CategoryViewModel();
            HttpResponseMessage responseMessage = _repository.GetResponse("api/Category/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                category = JsonConvert.DeserializeObject<CategoryViewModel>(content);
            }

            return category;
        }
    }
}
