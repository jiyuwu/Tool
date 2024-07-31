using System.ComponentModel;

namespace Common
{
    public class LocalizationProxy : INotifyPropertyChanged
    {
        public string this[string key] => LanguageResources.GetString(key);

        public event PropertyChangedEventHandler PropertyChanged;

        public LocalizationProxy()
        {
            LanguageResources.LanguageChanged += OnLanguageChanged;
        }

        private void OnLanguageChanged()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(string.Empty));
        }
    }
}
