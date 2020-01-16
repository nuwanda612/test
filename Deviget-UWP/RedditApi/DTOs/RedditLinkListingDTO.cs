using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deviget_UWP.RedditApi.DTOs
{
    public class RedditLinkListingDTO : RedditObjectDTO<RedditLinkListingDTOData>
    {
    }

    public class RedditLinkListingDTOData
    {
        public RedditLinkDTO[] children { get; set; }
        public string after { get; set; }
        public string before { get; set; }
    }
}
