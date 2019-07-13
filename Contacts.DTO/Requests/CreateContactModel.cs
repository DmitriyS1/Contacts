using Contacts.Core.Entities;
using System.Collections.Generic;

namespace Contacts.DTO.Requests
{
    /// <summary>
    /// Модель для создания контакта
    /// </summary>
    public class CreateContactModel
    {
        /// <summary>
        /// Имя контакта
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия контакта
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Отчество контакта
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Телефон контакта
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Рабочий телефон контакта
        /// </summary>
        public string WorkPhone { get; set; }

        /// <summary>
        /// Должность контакта
        /// </summary>
        public string WorkPosition { get; set; }

        /// <summary>
        /// Список мессенджеров контакта
        /// </summary>
        public List<Messenger> Messengers { get; set; }
    }
}
