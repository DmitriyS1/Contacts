using System;
using System.Threading.Tasks;
using Contacts.DTO.Requests;
using ContactsApi.Dal.Repositories.Interfaces;
using ContactsApi.Exeptions;
using MongoDB.Bson;

namespace ContactsApi.Services
{
    public class ContactsService : IContactsService
    {
        private readonly IContactsRepository _contactsRepository;

        public ContactsService(IContactsRepository repository)
        {
            _contactsRepository = repository;
        }

        public async Task<ObjectId> UpdateAsync(ObjectId id, UpdateContactModel model)
        {
            var contact = await _contactsRepository.GetAsync(id);
            if (contact == null)
            {
                throw new NotFoundException();
            }

            contact.FirstName = !string.IsNullOrEmpty(model.FirstName) ? model.FirstName : contact.FirstName;
            contact.LastName = !string.IsNullOrEmpty(model.LastName) ? model.LastName : contact.LastName;
            contact.MiddleName = !string.IsNullOrEmpty(model.MiddleName) ? model.MiddleName : contact.MiddleName;
            contact.Phone = !string.IsNullOrEmpty(model.Phone) ? model.Phone : contact.Phone;
            contact.WorkPhone = !string.IsNullOrEmpty(model.WorkPhone) ? model.WorkPhone : contact.WorkPhone;
            contact.WorkPosition = !string.IsNullOrEmpty(model.WorkPosition) ? model.WorkPosition : contact.WorkPosition;
            contact.UpdatedAt = DateTime.UtcNow;

            await _contactsRepository.UpdateAsync(contact);

            return id;
        }

        public async Task DeleteAsync(ObjectId id)
        {
            var contact = await _contactsRepository.GetAsync(id);
            if (contact == null)
            {
                throw new NotFoundException();
            }

            await _contactsRepository.DeleteAsync(id);
        }
    }
}
