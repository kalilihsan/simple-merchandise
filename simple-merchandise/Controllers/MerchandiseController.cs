using DTO.Request.Merchandise;
using DTO.Response;
using Microsoft.AspNetCore.Mvc;
using simple_merchandise.Interface;

namespace simple_merchandise.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class MerchandiseController : ControllerBase
    {
        private readonly IMerchandiseService iMerchandiseService;

        public MerchandiseController(IMerchandiseService iMerchandiseService)
        {
            this.iMerchandiseService = iMerchandiseService;
        }

        [HttpPost]
        [Route("AddNewMerchandiseType")]
        public async Task<IActionResult> AddNewMerchandiseType(AddNewMerchandiseTypeReqObj req)
        {
            await iMerchandiseService.ValidateNewMerchandiseType(req);
            await iMerchandiseService.AddNewMerchandiseType(req);

            return new JsonResult(new BaseResponse());
        }

        [HttpPost]
        [Route("AddNewMerchandise")]
        public async Task<IActionResult> AddNewMerchandise(AddNewMerchandiseReqObj req)
        {
            await iMerchandiseService.AddNewMerchandise(req);

            return new JsonResult(new BaseResponse());
        }
    }
}
