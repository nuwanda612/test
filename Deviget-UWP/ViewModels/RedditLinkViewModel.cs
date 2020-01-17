using Deviget_UWP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deviget_UWP.ViewModels
{
    public class RedditLinkViewModel
    {
        public RedditLink RedditLink { get; private set; }

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
