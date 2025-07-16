using DTO.Request.Supplier;
using DTO.Response;
using Microsoft.AspNetCore.Mvc;
using simple_merchandise.Interface;

namespace simple_merchandise.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService iSupplierService;

        public SupplierController(ISupplierService iSupplierService)
        {
            this.iSupplierService = iSupplierService;
        }

        [HttpPost]
        [Route("AddNewSupplier")]
        public async Task<IActionResult> AddNewSupplier(AddSupplierReqObj req)
        {
            await iSupplierService.ValidateAddNewSupplier(req);
            await iSupplierService.AddNewSupplier(req);

            return new JsonResult(new BaseResponse());
        }
    }
}
