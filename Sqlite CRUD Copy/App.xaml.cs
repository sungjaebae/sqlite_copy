using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Threading;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Sqlite_CRUD_Copy.Contracts.Services;
using Sqlite_CRUD_Copy.Contracts.Views;
using Sqlite_CRUD_Copy.Core.Context;
using Sqlite_CRUD_Copy.Core.Contracts.Services;
using Sqlite_CRUD_Copy.Core.Models;
using Sqlite_CRUD_Copy.Core.Services;
using Sqlite_CRUD_Copy.Models;
using Sqlite_CRUD_Copy.Services;
using Sqlite_CRUD_Copy.ViewModels;
using Sqlite_CRUD_Copy.Views;

namespace Sqlite_CRUD_Copy
{
    // For more inforation about application lifecyle events see https://docs.microsoft.com/dotnet/framework/wpf/app-development/application-management-overview

    // WPF UI elements use language en-US by default.
    // If you need to support other cultures make sure you add converters and review dates and numbers in your UI to ensure everything adapts correctly.
    // Tracking issue for improving this is https://github.com/dotnet/wpf/issues/1946
    public partial class App : Application
    {
        private IHost _host;

        public T GetService<T>()
            where T : class
            => _host.Services.GetService(typeof(T)) as T;

        public App()
        {
        }

        private async void OnStartup(object sender, StartupEventArgs e)
        {
            var appLocation = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            InitializeDB(true);


            _host = Host.CreateDefaultBuilder(e.Args)
                    .ConfigureAppConfiguration(c =>
                    {
                        c.SetBasePath(appLocation);
                    })
                    .ConfigureServices(ConfigureServices)
                    .Build();

            await _host.StartAsync();
        }
        public static void InitializeDB(bool forceReset = false)
        {
            using (AppDbContext db = new AppDbContext())
            {
                //DB가 이미 만들어져 있다면 안만들자
                if (!forceReset && (db.GetService<IDatabaseCreator>() as RelationalDatabaseCreator).Exists())
                    return;
                //한번 지우고 다시만들자??
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
                //혹은 DatabaseFacade 객체를 만들어서도 실행가능

                CreateTestData(db);
            }
        }
        public static void CreateTestData(AppDbContext db)
        {
            UserDto[] Users=new UserDto[] {
    new UserDto{
        Name = "Yen Nguyen",
        Age = 4
    },
    new UserDto{
        Name = "Hayley Gaines",
        Age = 61
    },
    new UserDto{
        Name = "Claudia Knight",
        Age = 89
    },
    new UserDto{
        Name = "Kessie Gardner",
        Age = 79
    },
    new UserDto{
        Name = "Amethyst Stephens",
        Age = 95
    }
}; ;
            db.Users.AddRange(Users);
            db.SaveChanges();
        }
        private void ConfigureServices(HostBuilderContext context, IServiceCollection services)
        {
            // TODO WTS: Register your services, viewmodels and pages here

            // App Host
            services.AddHostedService<ApplicationHostService>();

            // Activation Handlers

            // Core Services
            services.AddSingleton<IFileService, FileService>();

            // Services
            services.AddSingleton<IPersistAndRestoreService, PersistAndRestoreService>();
            services.AddSingleton<ISampleDataService, DataService>();
            services.AddSingleton<IPageService, PageService>();
            services.AddSingleton<INavigationService, NavigationService>();

            // Views and ViewModels
            services.AddTransient<IShellWindow, ShellWindow>();
            services.AddTransient<ShellViewModel>();

            services.AddTransient<MainViewModel>();
            services.AddTransient<MainPage>();

            services.AddTransient<ContentGridViewModel>();
            services.AddTransient<ContentGridPage>();

            services.AddTransient<ContentGridDetailViewModel>();
            services.AddTransient<ContentGridDetailPage>();

            // Configuration
            services.Configure<AppConfig>(context.Configuration.GetSection(nameof(AppConfig)));
        }

        private async void OnExit(object sender, ExitEventArgs e)
        {
            await _host.StopAsync();
            _host.Dispose();
            _host = null;
        }

        private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            // TODO WTS: Please log and handle the exception as appropriate to your scenario
            // For more info see https://docs.microsoft.com/dotnet/api/system.windows.application.dispatcherunhandledexception?view=netcore-3.0
        }
    }
}
