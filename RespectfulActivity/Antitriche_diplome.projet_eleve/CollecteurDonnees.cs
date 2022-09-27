using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Documents;
using Newtonsoft.Json;
using System.Security.Policy;
using System.Windows;


namespace Antitriche_diplome.projet_eleve
{
    internal class CollecteurDonnees
    {
        private DateTime heureDebut;

        private FormateurDonnees formateur;
        static HttpClient httpClient = new HttpClient();
        private const string URLAction = "http://localhost:5600/api/0/buckets/";
        
        public CollecteurDonnees(DateTime heureDebut, FormateurDonnees formateur)
        {
            this.heureDebut = heureDebut;
            this.formateur = formateur;
            
            //création client http
            httpClient.BaseAddress = new Uri(URLAction);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private async void CollecterDonnee(string idBucket)
        {
            //Générer les paramètres en format pour la requête 
            string aujourdhui = heureDebut.ToString("yyyy-MM-dd");
            string demain = heureDebut.AddDays(1).ToString("yyyy-MM-dd");

            idBucket = idBucket + "/events";
            string param = "?end=" + demain + "&start" + aujourdhui;

            HttpResponseMessage response = httpClient.GetAsync(idBucket + param).Result;
            if (response.IsSuccessStatusCode)
            {
                 
                string donnee_eleve = await response.Content.ReadAsStringAsync();
                formateur.AjoutEtFormatDonnees(donnee_eleve, idBucket);
            }
            else
            {
                MessageBox.Show(
                    "Une erreur est survenue lors de l'appel vers Activity Watch. Vérifiez qu'il est bien en cours d'exécution en background !");
            }
        }

        public async void CollecterDonnees(List<string> bucketNoms)
        {
            foreach (string id in bucketNoms)
            {
                CollecterDonnee(id);
            }
        }
    }
}