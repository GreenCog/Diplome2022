using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Antitriche_diplome.projet_eleve
{
    internal class CollecteurBucket
    {
        private List<string> bucketNoms;

        static HttpClient httpClient = new HttpClient();
        private const string URLAction = "http://localhost:5600/api/0/buckets/";

        public CollecteurBucket()
        {
            bucketNoms = new List<string>();

            httpClient.BaseAddress = new Uri(URLAction);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            CollecterBucket();
        }

        private async void CollecterBucket()
        {
            HttpResponseMessage response = httpClient.GetAsync("").Result;
            if (response.IsSuccessStatusCode)
            {
                var listBucket = await response.Content.ReadAsStringAsync();

                Dictionary<string, Dictionary<string, string>> watchers = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(listBucket);

                foreach (Dictionary<string, string> dictWatchers in watchers.Values)
                {
                    foreach (KeyValuePair<string, string> watcher in dictWatchers)
                    {
                        if (watcher.Key == "id")
                        {
                            if (!watcher.Value.Contains("stopwatch"))
                            {
                                bucketNoms.Add(watcher.Value);
                                break;
                            }
                        }
                    }
                }
            }
            else
            {
                throw new Exception();
            }
        }

        public List<string> BucketNames
        {
            get => bucketNoms;
            set => bucketNoms = value;
        }
    }
}