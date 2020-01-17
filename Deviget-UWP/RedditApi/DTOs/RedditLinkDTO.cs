using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deviget_UWP.RedditApi.DTOs
{
    public class RedditLinkDTO : RedditObjectDTO<RedditLinkDTOData>
    {
    }

    public class RedditLinkDTOData
    {
        public string title { get; set; }
        public string author { get; set; }
        public decimal created_utc { get; set; }
        public string url { get; set; }
        public string thumbnail { get; set; }
        public int score { get; set; }
        public int num_comments { get; set; }
    }
}
