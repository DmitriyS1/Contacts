using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts.DTO.Requests
{
    /// <summary>
    /// Модель для обновления информации о контакте
    /// </summary>
    public class UpdateContactModel
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
    }
}
