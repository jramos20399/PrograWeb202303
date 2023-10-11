using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class SupplierHelper : ISupplierHelper
    {

        IServiceRepository _repository;

        public SupplierHelper(IServiceRepository service)
        {
                _repository = service;
        }

        public List<SupplierViewModel> GetAll()
        {
            List<SupplierViewModel> lista = new List<SupplierViewModel>();
            HttpResponseMessage response = _repository.GetResponse("api/supplier");



            if (response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;
               lista= JsonConvert.DeserializeObject<List<SupplierViewModel>>(content);
            }

            return lista;
            
        }
    }
}
