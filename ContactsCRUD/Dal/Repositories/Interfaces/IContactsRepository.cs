using Contacts.Core.Entities;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactsApi.Dal.Repositories.Interfaces
{
    /// <summary>
    /// Действия с таблицей Contacts
    /// </summary>
    public interface IContactsRepository
    {
        /// <summary>
        /// Получить список всех контактов
        /// </summary>
        /// <returns>Список объектов <see cref="Contact"/></returns>
        Task<List<Contact>> GetAllAsync();

        /// <summary>
        /// Получить контакт по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор контакта</param>
        /// <returns>Объект <see cref="Contact"/></returns>
        Task<Contact> GetAsync(ObjectId id);

        /// <summary>
        /// Создать контак
        /// </summary>
        /// <param name="contact">Объект создаваемого контакта</param>
        /// <returns>Идентификатор созданного контакта</returns>
        Task CreateAsync(Contact contact);

        /// <summary>
        /// Обновить контакт
        /// </summary>
        /// <param name="contact">Объект обновляемого контакта</param>
        /// <returns>Идентификатор обновленного контакта</returns>
        Task UpdateAsync(Contact contact);

        /// <summary>
        /// Удалить запись по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор контакта</param>
        Task DeleteAsync(ObjectId id);
    }
}
