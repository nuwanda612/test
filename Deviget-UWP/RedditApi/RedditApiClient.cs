using Deviget_UWP.Models;
using Deviget_UWP.RedditApi.DTOs;
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
                        Title = child.data.title,
                        Author = child.data.author,
                        Created = DateTimeOffset.FromUnixTimeSeconds((long)child.data.created_utc).LocalDateTime,
                        Url = child.data.url,
                        ThumbnailUrl = child.data.thumbnail,
                        NumComments = child.data.num_comments,
                        Score = child.data.score,
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
