using DevDashboard.Core.Models;
using DevDashboard.Core.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DevDashboard.WPF.ViewModels
{
    public class ProblemListViewModel : ViewModelBase
    {
        private readonly IProblemService _problemService;
        private ObservableCollection<ProblemDto> _problems;
        private ProblemDto _selectedProblem;
        private bool _isLoading;

        public ProblemListViewModel(IProblemService problemService)
        {
            _problemService = problemService;
            _problems = new ObservableCollection<ProblemDto>();

            LoadCommand = new AsyncRelayCommand(async _ => await LoadProblemsAsync());
            DeleteCommand = new AsyncRelayCommand(async _ => await DeleteProblemAsync(), _ => SelectedProblem != null);

            // 초기 로드
            LoadCommand.Execute(null);
        }

        public ObservableCollection<ProblemDto> Problems
        {
            get => _problems;
            set => SetProperty(ref _problems, value);
        }

        public ProblemDto SelectedProblem
        {
            get => _selectedProblem;
            set => SetProperty(ref _selectedProblem, value);
        }

        public bool IsLoading
        {
            get => _isLoading;
            set => SetProperty(ref _isLoading, value);
        }

        public ICommand LoadCommand { get; }
        public ICommand DeleteCommand { get; }

        private async Task LoadProblemsAsync()
        {
            IsLoading = true;
            var problems = await _problemService.GetAllAsync();
            Problems = new ObservableCollection<ProblemDto>(problems);
            IsLoading = false;
        }

        private async Task DeleteProblemAsync()
        {
            if (SelectedProblem == null) return;

            await _problemService.DeleteAsync(SelectedProblem.Id);
            await LoadProblemsAsync();
        }
    }
}
