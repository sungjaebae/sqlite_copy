using System;
using System.Linq;

using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

using Sqlite_CRUD_Copy.Contracts.ViewModels;
using Sqlite_CRUD_Copy.Core.Contracts.Services;
using Sqlite_CRUD_Copy.Core.Models;

namespace Sqlite_CRUD_Copy.ViewModels
{
    public class ContentGridDetailViewModel : ObservableObject, INavigationAware
    {
        private readonly ISampleDataService _sampleDataService;
        private UserDto _user;

        public UserDto User
        {
            get { return _user; }
            set { SetProperty(ref _user, value); }
        }

        public ContentGridDetailViewModel(ISampleDataService sampleDataService)
        {
            _sampleDataService = sampleDataService;
        }

        public async void OnNavigatedTo(object parameter)
        {
            if (parameter is int userId)
            {
                var data = await _sampleDataService.GetContentGridDataAsync();
                User = data.First(i => i.UserId == userId);
            }
        }

        public void OnNavigatedFrom()
        {
        }
    }
}
