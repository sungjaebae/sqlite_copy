using System.Windows.Controls;

namespace Sqlite_CRUD_Copy.Contracts.Views
{
    public interface IShellWindow
    {
        Frame GetNavigationFrame();

        void ShowWindow();

        void CloseWindow();
    }
}
