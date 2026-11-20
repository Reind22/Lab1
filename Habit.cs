using System.Runtime.Serialization;

namespace WpflLab1
{
    /// <summary>
    /// Модель привычки.
    /// Хранит название, время выполнения и статус завершения.
    /// </summary>
    [DataContract]
    public class Habit
    {
        /// <summary>
        /// Название привычки.
        /// </summary>
        [DataMember(Order = 1)]
        public string Name { get; set; }

        /// <summary>
        /// Время выполнения привычки.
        /// </summary>
        [DataMember(Order = 2)]
        public string Time { get; set; }

        /// <summary>
        /// Признак выполнения привычки.
        /// </summary>
        [DataMember(Order = 3)]
        public bool IsCompleted { get; set; }
    }
}
