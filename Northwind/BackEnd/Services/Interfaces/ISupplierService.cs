using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
    public interface ISupplierService
    {
        Task<IEnumerable<Supplier>> GetSuppliers();

    }
}
