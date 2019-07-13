using System;
using System.Collections.Generic;

namespace Contacts.Core.Entities
{
    /// <summary>
    /// Информация о контакте
    /// </summary>
    public class Contact
    {
        /// <summary>
        /// Идентификатор записи
        /// </summary>
        public int Id { get; set; }

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
        public List<Messenger> Messengers { get; set; } // Добавить метод для заполнения мессенджеров контакта

        /// <summary>
        /// Дата создания записи
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Дата обновления записи
        /// </summary>
        public DateTime UpdatedAt { get; set; }
    }
}
