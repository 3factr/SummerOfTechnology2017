using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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

        public async Task<IList<VoteResult>> GetVotes()
        {
            Dictionary<string, int> result;

            try
            {
                var response = await _httpClient.GetStringAsync("votes");
                result = JsonConvert.DeserializeObject<Dictionary<string, int>>(response);
            }
            catch(Exception ex)
            {
                Debug.WriteLine("Exception occured: " + ex.Message);
                return null;
            }

            var total = result.Sum(kvp => kvp.Value);

            var resultList = new List<VoteResult>();
            foreach(var kvp in result)
            {
                resultList.Add(new VoteResult(kvp.Key, kvp.Value, total));
            }

            resultList.Sort();
            return resultList;
        }
    }
}
