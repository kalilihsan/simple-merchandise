using DTO.Request.Contact;

namespace simple_merchandise.Interface
{
    public interface IContactService
    {
        Task AddNewContact(AddContactReqObj req);
    }
}
