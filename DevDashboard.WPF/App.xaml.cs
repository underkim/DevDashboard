using DevDashboard.Core.Services;
using DevDashboard.Data;
using DevDashboard.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DevDashboard.WPF
{
    /// <summary>
    /// App.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class App : Application
    {
        public static AppDbContext DbContext { get; private set; }
        public static IProblemRepository ProblemRepository { get; private set; }
        public static ISolutionRepository SolutionRepository { get; private set; }
        public static IProblemService ProblemService { get; private set; }
        public static ISolutionService SolutionService { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // 의존성 초기화
            DbContext = new AppDbContext();
            ProblemRepository = new ProblemRepository(DbContext);
            SolutionRepository = new SolutionRepository(DbContext);
            ProblemService = new ProblemService(ProblemRepository);
            SolutionService = new SolutionService(SolutionRepository);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            DbContext?.Dispose();
            base.OnExit(e);
        }
    }
}
