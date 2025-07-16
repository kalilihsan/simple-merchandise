using Common;
using DTO.Request.Supplier;
using Entity;
using Microsoft.EntityFrameworkCore;
using simple_merchandise.Context;
using simple_merchandise.Interface;
using simple_merchandise.Repository;

namespace simple_merchandise.Service
{
    public class SupplierService : ISupplierService
    {
        private readonly SupplierContext context;
        private readonly IGenericRepository repository;

        public SupplierService(SupplierContext supplierContext, IGenericRepository genericRepository)
        {
            context = supplierContext;
            repository = genericRepository;
        }

        public async Task ValidateAddNewSupplier(AddSupplierReqObj addSupplierReqObj)
        {
            Supplier? supplier = await (from s in context.Supplier
                                        where s.SupplierCode.ToUpper() == addSupplierReqObj.SupplierCode.ToUpper()
                                        select s).FirstOrDefaultAsync();

            if (supplier != null)
            {
                throw new CustomException(500, "Supplier Code Already Exists");
            }
        }

        public async Task AddNewSupplier(AddSupplierReqObj addSupplierReqObj)
        {
            Supplier supplier = new Supplier()
            {
                SupplierCode = addSupplierReqObj.SupplierCode,
                SupplierName = addSupplierReqObj.SupplierName,
            };

            repository.Add(supplier);
            await repository.SaveChangesAsync();
        }
    }
}
