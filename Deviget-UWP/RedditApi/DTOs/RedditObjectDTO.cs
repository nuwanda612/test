using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deviget_UWP.RedditApi.DTOs
{
    public class RedditObjectDTO<T>
    {
        public string kind { get; set; }
        public T data { get; set; }
    }
}
