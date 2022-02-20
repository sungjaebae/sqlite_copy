using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

using Sqlite_CRUD_Copy.Contracts.Services;
using Sqlite_CRUD_Copy.Contracts.ViewModels;
using Sqlite_CRUD_Copy.Core.Contracts.Services;
using Sqlite_CRUD_Copy.Core.Models;

namespace Sqlite_CRUD_Copy.ViewModels
{
    public class ContentGridViewModel : ObservableObject, INavigationAware
    {
        private readonly INavigationService _navigationService;
        private readonly ISampleDataService _sampleDataService;
        private ICommand _navigateToDetailCommand;

        public ICommand NavigateToDetailCommand => _navigateToDetailCommand ?? (_navigateToDetailCommand = new RelayCommand<UserDto>(NavigateToDetail));

        public ObservableCollection<UserDto> Source { get; } = new ObservableCollection<UserDto>();

        public ContentGridViewModel(ISampleDataService sampleDataService, INavigationService navigationService)
        {
            _sampleDataService = sampleDataService;
            _navigationService = navigationService;
        }

        public async void OnNavigatedTo(object parameter)
        {
            Source.Clear();

            // Replace this with your actual data
            var data = await _sampleDataService.GetContentGridDataAsync();
            foreach (var item in data)
            {
                Source.Add(item);
            }
        }

        public void OnNavigatedFrom()
        {
        }

        private void NavigateToDetail(UserDto user)
        {
            _navigationService.NavigateTo(typeof(ContentGridDetailViewModel).FullName, user.UserId);
        }
    }
}
