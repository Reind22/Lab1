using System.Runtime.Serialization;

namespace WpflLab1
{
    /// <summary>
    /// Модель дневной статистики.
    /// Хранит дату, количество выполненных привычек и процент выполнения.
    /// </summary>
    [DataContract]
    public class DailyStatistic
    {
        /// <summary>
        /// Дата записи статистики.
        /// </summary>
        [DataMember(Order = 1)]
        public string Date { get; set; }

        /// <summary>
        /// Количество выполненных привычек за день.
        /// </summary>
        [DataMember(Order = 2)]
        public int CompletedCount { get; set; }

        /// <summary>
        /// Процент выполнения привычек за день.
        /// </summary>
        [DataMember(Order = 3)]
        public string Percentage { get; set; }
    }
}
