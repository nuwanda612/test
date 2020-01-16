using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deviget_UWP.Models
{
    public class RedditLinkListing
    {
        public List<RedditLink> Links { get; set; }
        public string After { get; set; }
        public string Before { get; set; }
    }
}
