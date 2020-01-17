using Deviget_UWP.Models;
using Deviget_UWP.RedditApi;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Deviget_UWP.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        #region Properties

        public RedditLinkListing LinkListing { get; private set; }

        public ObservableCollection<RedditLinkViewModel> Links { get; } = new ObservableCollection<RedditLinkViewModel>();

        private RedditLinkViewModel _selectedLink;
        public RedditLinkViewModel SelectedLink
        {
            get { return _selectedLink; }
            set
            {
                if (_selectedLink == value)
                    return;

                _selectedLink = value;
                OnPropertyChanged();

                if (_selectedLink != null)
                    _selectedLink.Unread = false;
            }
        }

        private bool _refreshing;
        public bool Refreshing
        {
            get { return _refreshing; }
            set
            {
                if (_refreshing == value)
                    return;

                _refreshing = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(RefreshButtonText));
                RefreshCommand.OnCanExecuteChanged();
            }
        }

        public string RefreshButtonText => Refreshing ? "Refreshing..." : "Refresh";

        #endregion

        #region Commands

        RelayCommand _refreshCommand;
        public RelayCommand RefreshCommand
        {
            get
            {
                if (_refreshCommand == null)
                    _refreshCommand = new RelayCommand((param) => Refresh(), (param) => !Refreshing);
                return _refreshCommand;
            }
        }

        RelayCommand _dismissCommand;
        public RelayCommand DismissCommand
        {
            get
            {
                if (_dismissCommand == null)
                    _dismissCommand = new RelayCommand((param) => Dismiss((RedditLinkViewModel)param));
                return _dismissCommand;
            }
        }

        RelayCommand _dismissAllCommand;
        public RelayCommand DismissAllCommand
        {
            get
            {
                if (_dismissAllCommand == null)
                    _dismissAllCommand = new RelayCommand((param) => DismissAll());
                return _dismissAllCommand;
            }
        }

        #endregion

        #region Methods

        private async void Refresh()
        {
            try
            {
                Refreshing = true;

                LinkListing = await RedditApiClient.Top();

                Links.Clear();
                foreach (var link in LinkListing.Links)
                {
                    Links.Add(new RedditLinkViewModel(link));
                }
            }
            finally
            {
                Refreshing = false;
            }
        }

        private void Dismiss(RedditLinkViewModel link)
        {
            Links.Remove(link);
        }

        private void DismissAll()
        {
            Links.Clear();
        }

        #endregion
    }
}
