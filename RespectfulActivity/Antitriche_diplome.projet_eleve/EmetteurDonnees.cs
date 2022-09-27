using Antitriche_diplome.models.ApiModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.RightsManagement;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using System.Threading.Tasks;
using System.Xml.XPath;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Antitriche_diplome.projet_eleve
{
    internal class EmetteurDonnees
    {
        private HttpClientService client;

        public EmetteurDonnees()
        {
            client = HttpClientServiceSingleton.Instance;
        }

        public async Task Envoie(Resultat _resultat)
        {
            var resultat = JsonConvert.SerializeObject(_resultat, new JsonSerializerSettings
            {
                PreserveReferencesHandling = PreserveReferencesHandling.All
            });
            var requestContent = new StringContent(resultat, Encoding.UTF8, "application/json");
            var r = await client.GetHttpClient().PostAsync("resultats", requestContent);
            
        }
    }
}