using DTO.Request.Contact;
using Entity;
using simple_merchandise.Context;
using simple_merchandise.Interface;
using simple_merchandise.Repository;

namespace simple_merchandise.Service
{
    public class ContactService : IContactService
    {
        private readonly SupplierContext context;
        private readonly IGenericRepository repository;

        public ContactService(SupplierContext supplierContext, IGenericRepository genericRepository)
        {
            context = supplierContext;
            repository = genericRepository;
        }

        public async Task AddNewContact(AddContactReqObj req)
        {
            Contact newContact = new Contact()
            {
                Name = req.ContactName,
                PhoneNumber = req.ContactNumber
            };

            repository.Add(newContact);
            await repository.SaveChangesAsync();
        }
    }
}
