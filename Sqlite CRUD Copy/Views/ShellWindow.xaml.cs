using System.Windows.Controls;

using MahApps.Metro.Controls;

using Sqlite_CRUD_Copy.Contracts.Views;
using Sqlite_CRUD_Copy.ViewModels;

namespace Sqlite_CRUD_Copy.Views
{
    public partial class ShellWindow : MetroWindow, IShellWindow
    {
        public ShellWindow(ShellViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        public Frame GetNavigationFrame()
            => shellFrame;

        public void ShowWindow()
            => Show();

        public void CloseWindow()
            => Close();
    }
}
