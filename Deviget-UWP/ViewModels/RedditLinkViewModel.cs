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

        public RedditLinkViewModel(RedditLink redditLink)
        {
            RedditLink = redditLink ?? throw new ArgumentException(nameof(redditLink));
        }
    }
}
