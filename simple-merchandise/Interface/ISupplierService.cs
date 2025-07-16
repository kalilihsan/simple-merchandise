using DTO.Request.Supplier;

namespace simple_merchandise.Interface
{
    public interface ISupplierService
    {
        Task ValidateAddNewSupplier(AddSupplierReqObj req);
        Task AddNewSupplier(AddSupplierReqObj req);
    }
}
