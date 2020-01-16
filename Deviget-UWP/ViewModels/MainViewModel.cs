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
    public class MainViewModel
    {
        #region Properties

        public RedditLinkListing LinkListing { get; private set; }

        public ObservableCollection<RedditLinkViewModel> Links { get; } = new ObservableCollection<RedditLinkViewModel>();

        #endregion

        #region Commands

        RelayCommand _refreshCommand;
        public ICommand RefreshCommand
        {
            get
            {
                if (_refreshCommand == null)
                    _refreshCommand = new RelayCommand((param) => DoRefresh());
                return _refreshCommand;
            }
        }

        #endregion

        #region Methods

        private async void DoRefresh()
        {
            LinkListing = await RedditApiClient.Top();

            Links.Clear();
            foreach (var link in LinkListing.Links)
            {
                Links.Add(new RedditLinkViewModel(link));
            }
        }

        #endregion
    }
}
