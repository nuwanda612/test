using Deviget_UWP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Deviget_UWP.ViewModels
{
    public class RedditLinkViewModel : ViewModelBase
    {
        public RedditLink RedditLink { get; private set; }

        private bool _unread = true;
        public bool Unread
        {
            get { return _unread; }
            set
            {
                if (_unread == value)
                    return;

                _unread = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(UnreadIconVisibility));
                OnPropertyChanged(nameof(TextColor));
            }
        }

        public Visibility UnreadIconVisibility => Unread ? Visibility.Visible : Visibility.Hidden;

        public Brush TextColor => Unread ? Brushes.White : Brushes.LightGray;

        public string CreatedAgo
        {
            get
            {
                var deltaTime = DateTime.Now - RedditLink.Created;
                if (deltaTime >= TimeSpan.FromDays(1))
                    return $"{deltaTime.Days} days ago";
                else if (deltaTime >= TimeSpan.FromHours(1))
                    return $"{deltaTime.Hours} hours ago";
                else if (deltaTime >= TimeSpan.FromMinutes(1))
                    return $"{deltaTime.Minutes} minutes ago";
                else
                    return "Seconds ago";
            }
        }

        public RedditLinkViewModel(RedditLink redditLink)
        {
            RedditLink = redditLink ?? throw new ArgumentException(nameof(redditLink));
        }
    }
}
