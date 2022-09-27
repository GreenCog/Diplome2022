
using Antitriche_diplome.models.ApiModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antitriche_diplome.projet_eleve
{
    public class FormateurDonnees
    {
        private List<ReponseWatcherAFK> reponseAFK;
        private List<ReponseWatcherWeb> reponseWeb;
        private List<ReponseWatcherWindow> reponseWindow;

        private List<ResultatAFK> resultatAFKs;
        private List<ResultatWindow> resultatWindows;
        private List<ResultatWeb> resultatWebs;

        private Resultat resultat;
        /// <summary>
        /// 
        /// </summary>
        public FormateurDonnees(Resultat resultat)
        {
            //list d'object en format reçu par l'api
            reponseAFK = new List<ReponseWatcherAFK>();
            reponseWeb = new List<ReponseWatcherWeb>();
            reponseWindow = new List<ReponseWatcherWindow>();
            //list d'bjet en format pour l'envoie pour la base de données 
            resultatAFKs = new List<ResultatAFK>();
            resultatWindows = new List<ResultatWindow>();
            resultatWebs = new List<ResultatWeb>();

            this.resultat = resultat;
        }

        public List<ResultatAFK> ResultatAFKs { get => resultatAFKs; set => resultatAFKs = value; }
        public List<ResultatWindow> ResultatWindows { get => resultatWindows; set => resultatWindows = value; }
        public List<ResultatWeb> ResultatWebs { get => resultatWebs; set => resultatWebs = value; }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="donneeEleve"></param>
        /// <param name="idBucket"></param>
        public void AjoutEtFormatDonnees(string donneeEleve, string idBucket)
        {
            if (idBucket.Contains("afk"))
            {
                reponseAFK = JsonConvert.DeserializeObject<List<ReponseWatcherAFK>>(donneeEleve);

                foreach (ReponseWatcherAFK rwa in reponseAFK)
                {
                    ResultatAFK resultatAFKTemp = new ResultatAFK();
                    
                    resultatAFKTemp.Duration = rwa.Duration;
                    resultatAFKTemp.TimeStamp = rwa.Timestamp;
                    resultatAFKTemp.Resultat = resultat;
                    resultatAFKTemp.Statut = rwa.Data.status;
                    resultatAFKs.Add(resultatAFKTemp);
                }
            }
            else if (idBucket.Contains("window"))
            {
                reponseWindow = JsonConvert.DeserializeObject<List<ReponseWatcherWindow>>(donneeEleve);

                foreach (ReponseWatcherWindow rww in reponseWindow)
                {
                    ResultatWindow resultatWindowTemp = new ResultatWindow();
                    
                    resultatWindowTemp.Duration = rww.Duration;
                    resultatWindowTemp.TimeStamp = rww.Timestamp;
                    resultatWindowTemp.App = rww.Data.app;
                    resultatWindowTemp.Titre = rww.Data.title;
                    resultatWindowTemp.Resultat = resultat;
                    resultatWindows.Add(resultatWindowTemp);
                }

            }
            else
            {
                reponseWeb = JsonConvert.DeserializeObject<List<ReponseWatcherWeb>>(donneeEleve);

                foreach (ReponseWatcherWeb rww in reponseWeb)
                {
                    ResultatWeb resultatWebTemp = new ResultatWeb();
                    
                    resultatWebTemp.Duration = rww.Duration;
                    resultatWebTemp.TimeStamp = rww.Timestamp;
                    resultatWebTemp.Url = rww.Data.url;
                    resultatWebTemp.Titre = rww.Data.title;
                    resultatWebTemp.Resultat = resultat;
                    resultatWebs.Add(resultatWebTemp);
                }
            }
        }
    }
}
