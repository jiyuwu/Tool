using Business;
using Common;
using IService;
using Microsoft.Extensions.DependencyInjection;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Tool.Util;

namespace Tool.ViewModels
{
    public class ArticleViewModel : BindableBase
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly LocalizationProxy _localizationProxy = new LocalizationProxy();

        public LocalizationProxy Localization => _localizationProxy;
        //public string Name { get; set; } = "YCH";
        private string name = "YCH";
        private readonly IArticleService _service;
        //ArticleBll articleBll=new ArticleBll();
        ArticleBll articleBll;
        public string Name
        {
            get { return name; }
            set
            {
                SetProperty<string>(ref name, value);
            }
        }
        public ArticleViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<LanguageChangedEvent>().Subscribe(OnLanguageChanged);
            _service =App.ServiceProvider.GetService<IArticleService>();
            articleBll = new ArticleBll(_service);
            Task.Run(async () => {
                await Task.Delay(2000);
                Name = "这是个测试";
            });
        }
        private void OnLanguageChanged(string language)
        {
            // 在语言更改时更新 UI
            RaisePropertyChanged(nameof(Localization));
        }
        public ICommand ClickCommand
        {
            get => new DelegateCommand<object>(ButtonClick);
        }
        private void ButtonClick(object obj)
        {
            this.Name = "哈哈哈哈！" + (string)obj;
            Model.Article article = new Model.Article();
            article.Title = "1111";
            article.Content = "222";
            article.Status = 1;
            article.CreateTime = DateTime.Now;
            articleBll.addArticle(article);
        }
    }
}
