using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deviget_UWP.Models
{
    public class RedditLink
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime Created { get; set; }
        public string Url { get; set; }
        public string ThumbnailUrl { get; set; }
        public int Score { get; set; }
        public int NumComments { get; set; }

        public string CreatedAgo
        {
            get
            {
                var deltaTime = DateTime.Now - Created;
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
    }
}
