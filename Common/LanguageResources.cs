using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class LanguageResources
    {
        private static string _currentLanguage = "English";

        private static readonly Dictionary<string, Dictionary<string, string>> Resources = new Dictionary<string, Dictionary<string, string>>()
        {
            { "English", new Dictionary<string, string>
                {
                    { "WindowTitle", "Welcome" },
                    { "HelloWorld", "Hello, World!" }
                }
            },
            { "Chinese", new Dictionary<string, string>
                {
                    { "WindowTitle", "欢迎" },
                    { "HelloWorld", "你好，世界！" }
                }
            }
            // 添加更多语言
        };

        public static string CurrentLanguage
        {
            get => _currentLanguage;
            set
            {
                if (_currentLanguage != value)
                {
                    _currentLanguage = value;
                    OnLanguageChanged();
                }
            }
        }

        public static string GetString(string key)
        {
            if (Resources.ContainsKey(_currentLanguage) && Resources[_currentLanguage].ContainsKey(key))
            {
                return Resources[_currentLanguage][key];
            }
            return key;
        }

        public static event Action LanguageChanged;

        private static void OnLanguageChanged()
        {
            LanguageChanged?.Invoke();
        }
    }
}
