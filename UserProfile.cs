using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WpflLab1
{
    /// <summary>
    /// Модель данных пользователя.
    /// Хранит персональные данные, настройки отображения и уровень активности.
    /// </summary>
    [DataContract]
    public class UserProfile
    {
        /// <summary>
        /// Имя пользователя.
        /// </summary>
        [DataMember(Order = 1)]
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия пользователя.
        /// </summary>
        [DataMember(Order = 2)]
        public string LastName { get; set; }

        /// <summary>
        /// Пароль пользователя.
        /// </summary>
        [DataMember(Order = 3)]
        public string Password { get; set; }

        /// <summary>
        /// Дата рождения пользователя.
        /// </summary>
        [DataMember(Order = 4)]
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// Уровень образования пользователя.
        /// </summary>
        [DataMember(Order = 5)]
        public string Education { get; set; }

        /// <summary>
        /// Список выбранных хобби.
        /// </summary>
        [DataMember(Order = 6)]
        public List<string> Hobbies { get; set; }

        /// <summary>
        /// Флаг получения уведомлений.
        /// </summary>
        [DataMember(Order = 7)]
        public bool NotificationsEnabled { get; set; }

        /// <summary>
        /// Флаг публичного отображения статистики.
        /// </summary>
        [DataMember(Order = 8)]
        public bool PublicStatistics { get; set; }

        /// <summary>
        /// Флаг автоматического сохранения данных.
        /// </summary>
        [DataMember(Order = 9)]
        public bool AutoSave { get; set; }

        /// <summary>
        /// Уровень активности пользователя (Низкий, Средний, Высокий).
        /// </summary>
        [DataMember(Order = 10)]
        public string ActivityLevel { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="UserProfile"/> со значениями по умолчанию.
        /// </summary>
        public UserProfile()
        {
            Hobbies = new List<string>();
        }
    }
}
