using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DemoApp
{
    public class VoteService
    {
        readonly HttpClient _httpClient;

        public VoteService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(Configuration.ApiEndpoint)
            };
        }

        public async Task<bool> Vote(string voteOption)
        {
            try
            {
                var content = new StringContent($"\"{voteOption}\"");
                content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                var response = await _httpClient.PostAsync("votes", content);
                return response.IsSuccessStatusCode;
            }
            catch(Exception ex)
            {
                Debug.WriteLine("Exception occured: " + ex.Message);
                return false;
            }
        }

        public async Task<Dictionary<string, int>> GetVotes()
        {
            var response = await _httpClient.GetStringAsync("votes");
            var result = JsonConvert.DeserializeObject<Dictionary<string, int>>(response);
            return result;
        }
    }
}
