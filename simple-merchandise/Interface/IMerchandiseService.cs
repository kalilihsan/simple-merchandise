using DTO.Request.Merchandise;

namespace simple_merchandise.Interface
{
    public interface IMerchandiseService
    {
        Task AddNewMerchandise(AddNewMerchandiseReqObj req);
        Task AddNewMerchandiseType(AddNewMerchandiseTypeReqObj req);
        Task ValidateNewMerchandiseType(AddNewMerchandiseTypeReqObj req);
    }
}
