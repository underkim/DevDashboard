using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DevDashboard.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private string _title = "개발자 대시보드";
        private object _currentView;

        public MainViewModel()
        {
            ShowProblemListCommand = new RelayCommand(_ => ShowProblemList());
        }

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public object CurrentView
        {
            get => _currentView;
            set => SetProperty(ref _currentView, value);
        }

        public ICommand ShowProblemListCommand { get; }

        private void ShowProblemList()
        {
            CurrentView = new ProblemListViewModel(App.ProblemService);
        }
    }
}
