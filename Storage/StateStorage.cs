using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace WpflLab1
{
    /// <summary>
    /// Состояние приложения, которое сохраняется между запусками:
    /// профиль пользователя, список привычек и выбранная тема.
    /// </summary>
    [DataContract]
    public class AppState
    {
        /// <summary>
        /// Профиль пользователя со всеми полями вкладки «Личные данные».
        /// </summary>
        [DataMember(Order = 1)]
        public UserProfile Profile { get; set; }

        /// <summary>
        /// Список привычек из таблицы на вкладке «Привычки».
        /// </summary>
        [DataMember(Order = 2)]
        public List<Habit> Habits { get; set; }

        /// <summary>
        /// Признак включённой тёмной темы, чтобы оформление восстанавливалось.
        /// </summary>
        [DataMember(Order = 3)]
        public bool IsDarkTheme { get; set; }
    }

    /// <summary>
    /// Чтение и запись состояния приложения в JSON-файл в папке профиля.
    /// Файл пишется через временный файл, чтобы не потерять данные при сбое.
    /// </summary>
    public static class StateStorage
    {
        /// <summary>
        /// Путь к файлу состояния: %AppData%\WpflLab1\state.json.
        /// </summary>
        public static string StatePath
        {
            get
            {
                string folder = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    "WpflLab1");
                return Path.Combine(folder, "state.json");
            }
        }

        /// <summary>
        /// Пытается прочитать сохранённое состояние.
        /// </summary>
        /// <param name="state">Прочитанное состояние или null, если файла нет.</param>
        /// <returns>true, если файл найден и успешно разобран.</returns>
        public static bool TryLoad(out AppState state)
        {
            state = null;

            try
            {
                string path = StatePath;
                if (!File.Exists(path))
                {
                    return false;
                }

                var serializer = new DataContractJsonSerializer(typeof(AppState));
                using (var stream = File.OpenRead(path))
                {
                    state = (AppState)serializer.ReadObject(stream);
                }

                return state != null;
            }
            catch (Exception)
            {
                // Битый или несовместимый файл не должен мешать запуску приложения.
                state = null;
                return false;
            }
        }

        /// <summary>
        /// Записывает состояние в файл.
        /// </summary>
        /// <param name="state">Состояние для сохранения.</param>
        public static void Save(AppState state)
        {
            string path = StatePath;
            string folder = Path.GetDirectoryName(path);

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            var serializer = new DataContractJsonSerializer(typeof(AppState));
            string tempPath = path + ".tmp";

            using (var stream = File.Create(tempPath))
            {
                serializer.WriteObject(stream, state);
            }

            // Замена через копию: старый файл не остаётся недописанным.
            File.Copy(tempPath, path, true);
            File.Delete(tempPath);
        }
    }
}
