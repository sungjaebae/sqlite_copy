using System.Windows.Controls;

using Sqlite_CRUD_Copy.ViewModels;

namespace Sqlite_CRUD_Copy.Views
{
    public partial class ContentGridDetailPage : Page
    {
        public ContentGridDetailPage(ContentGridDetailViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
