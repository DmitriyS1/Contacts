using MongoDB.Bson;

namespace Contacts.DTO.Responses
{
    /// <summary>
    /// Ответ, содержащий информацию о контакте
    /// </summary>
    public class ContactResponse
    {
        /// <summary>
        /// Идентификатор контакта
        /// </summary>
        public ObjectId Id { get; set; }
    }
}
