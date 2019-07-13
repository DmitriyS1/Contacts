using Contacts.Core.Enums;

namespace Contacts.Core.Entities
{
    /// <summary>
    /// Класс, описывающий данные мессенджера для контакта
    /// </summary>
    public class Messenger
    {
        /// <summary>
        /// Названи мессенджера
        /// </summary>
        public MessengersNames Name { get; set; }

        /// <summary>
        /// Аккаунт для связи в мессенджере
        /// </summary>
        public string Account { get; set; }
    }
}
