using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deviget_UWP.RedditApi.Models
{
    public class RedditLink
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime Created { get; set; }
        public string Url { get; set; }
        public string Thumbnail { get; set; }
        public int Score { get; set; }
    }
}
