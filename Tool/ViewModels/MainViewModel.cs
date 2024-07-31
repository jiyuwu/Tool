using Common;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Tool.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly LocalizationProxy _localizationProxy = new LocalizationProxy();

        public LocalizationProxy Localization => _localizationProxy;

        public MainViewModel()
        {
            LanguageResources.LanguageChanged += OnLanguageChanged;
        }

        private void OnLanguageChanged()
        {
            OnPropertyChanged(nameof(Localization));
        }

        public void ChangeLanguage(string language)
        {
            LanguageResources.CurrentLanguage = language;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
