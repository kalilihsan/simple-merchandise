using Common;
using DTO.Request.Merchandise;
using Entity;
using Microsoft.EntityFrameworkCore;
using simple_merchandise.Context;
using simple_merchandise.Interface;
using simple_merchandise.Repository;

namespace simple_merchandise.Service
{
    public class MerchandiseService : IMerchandiseService
    {
        private readonly SupplierContext context;
        private readonly IGenericRepository repository;

        public MerchandiseService(SupplierContext supplierContext, IGenericRepository genericRepository)
        {
            context = supplierContext;
            repository = genericRepository;
        }

        public async Task ValidateNewMerchandiseType(AddNewMerchandiseTypeReqObj req)
        {
            Supplier? supplier = await (from s in context.Supplier
                                        where s.SupplierCode == req.SupplierCode
                                        select s).FirstOrDefaultAsync();

            if (supplier == null)
            {
                throw new CustomException(500, "Supplier Not Found");
            }

            MerchandiseType? merchandiseType = await (from mt in context.MerchandiseType
                                                      where mt.MerchandiseTypeCode == req.MerchandiseTypeCode
                                                      select mt).FirstOrDefaultAsync();

            if (merchandiseType != null)
            {
                throw new CustomException(500, "Merchandise Type Code Already Exists");
            }
        }

        public async Task AddNewMerchandiseType(AddNewMerchandiseTypeReqObj req)
        {
            MerchandiseType merchandiseType = new MerchandiseType()
            {
                SupplierCode = req.SupplierCode,
                MerchandiseTypeCode = req.MerchandiseTypeCode,
                MerchandiseTypeName = req.MerchandiseTypeName,
                IsActive = req.IsActive,
            };

            repository.Add(merchandiseType);
            await repository.SaveChangesAsync();
        }

        public async Task AddNewMerchandise(AddNewMerchandiseReqObj req)
        {
            Merchandise merchandise = new()
            {
                MerchandiseTypeCode = req.MerchandiseTypeCode,
                Price = req.Price,
            };

            repository.Add(merchandise);
            await repository.SaveChangesAsync();
        }
    }
}
