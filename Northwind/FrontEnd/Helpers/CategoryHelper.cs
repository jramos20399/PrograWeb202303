using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class CategoryHelper
    {

        //A propósito para causar conflicto
        ServiceRepository _repository;

        public CategoryHelper()
        {
                _repository = new ServiceRepository();
        }



        public List<CategoryViewModel> GetAll()
        {

            List<CategoryViewModel> lista = new List<CategoryViewModel>();

            HttpResponseMessage responseMessage = _repository.GetResponse("api/Category");
            if (responseMessage!=null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                lista = JsonConvert.DeserializeObject<List<CategoryViewModel>>(content);
            }

            return lista;
        }



    }
}
