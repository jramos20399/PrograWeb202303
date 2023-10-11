using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class SupplierService : ISupplierService
    {

        public IUnidadDeTrabajo _unidadDeTrabajo;

        public SupplierService(IUnidadDeTrabajo unidadDeTrabajo)
        {
                _unidadDeTrabajo = unidadDeTrabajo;
        }

        public async Task<IEnumerable<Supplier>> GetSuppliers()
        {
           IEnumerable<Supplier> suppliers = new List<Supplier>();
            suppliers = await _unidadDeTrabajo._supplierDAL.GetAll();
            return suppliers;
        }
    }
}
