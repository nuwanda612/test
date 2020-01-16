using Deviget_UWP.RedditApi.DTOs;
using Deviget_UWP.RedditApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Deviget_UWP.RedditApi
{
    public static class RedditApiClient
    {
        // HttpClient is intended to be instantiated once and re-used throughout the life of an application.
        // See: https://docs.microsoft.com/en-us/dotnet/api/system.net.http.httpclient
        private static HttpClient _httpClient = null;
        private static HttpClient HttpClient
        {
            get
            {
                if (_httpClient == null)
                {
                    _httpClient = new HttpClient();
                    _httpClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("DevigetTest", Assembly.GetExecutingAssembly().GetName().Version.ToString()));
                    _httpClient.Timeout = TimeSpan.FromSeconds(5);
                }
                return _httpClient;
            }
        }

        public static async Task<RedditLinkListing> Top()
        {
            string responseString = await HttpClient.GetStringAsync("https://api.reddit.com/top");

            try
            {
                var response = JsonConvert.DeserializeObject<RedditLinkListingDTO>(responseString);
                return new RedditLinkListing
                {
                    Links = response.data.children.Select(child => new RedditLink
                    {
                        Author = child.data.author,
                        Title = child.data.title,
                        Score = child.data.score,
                        Url = child.data.url,
                        Thumbnail = child.data.thumbnail,
                        Created = DateTimeOffset.FromUnixTimeSeconds((long)child.data.created_utc).LocalDateTime,
                    }).ToList(),
                    After = response.data.after,
                    Before = response.data.before,
                };
            }
            catch (Exception ex)
            {
                // TODO: log
                throw new Exception("Unexpected response", ex);
            }
        }
    }
}
