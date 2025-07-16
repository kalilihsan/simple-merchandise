using DTO.Request.Contact;
using DTO.Response;
using Microsoft.AspNetCore.Mvc;
using simple_merchandise.Interface;

namespace simple_merchandise.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ContactController : ControllerBase
    {
        private readonly IContactService iContactService;

        public ContactController(IContactService contactService)
        {
            iContactService = contactService;
        }

        [HttpPost]
        [Route("AddNewContact")]
        public async Task<IActionResult> AddNewContact(AddContactReqObj req)
        {
            await iContactService.AddNewContact(req);
            return new JsonResult(new BaseResponse());
        }
    }
}
