using Contacts.DTO.Requests;
using MongoDB.Bson;
using System.Threading.Tasks;

namespace ContactsApi.Services
{
    /// <summary>
    /// Сервис для работы с контактами
    /// </summary>
    public interface IContactsService
    {
        /// <summary>
        /// Создать контакт
        /// </summary>
        /// <param name="model">Модель сздания контакта</param>
        Task<ObjectId> UpdateAsync(ObjectId id, UpdateContactModel model);

        /// <summary>
        /// Удалить контакт
        /// </summary>
        /// <param name="id">Идентификатор контакта</param>
        Task DeleteAsync(ObjectId id);
    }
}
