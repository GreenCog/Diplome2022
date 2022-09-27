using Antitriche_diplome.projet_eleve;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antitriche_diplome.models.ApiModels
{
    public class Resultat
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string? Test { get; set; }
        public string? NomEleve { get; set; }
        public string? PrenomEleve { get; set; }
        public string? Classe { get; set; }
        public List<ResultatAFK> ResultatAFKs { get; set; }
        public List<ResultatWindow> ResultatWindows { get; set; }
        public List<ResultatWeb> ResultatWebs { get; set; }
        public Resultat(DateTime date, string? test, string? nomEleve, string? prenomEleve, string? classe, List<ResultatAFK> resultatAFKs, List<ResultatWindow> resultatWindows, List<ResultatWeb> resultatWebs)
        {
            Date = date;
            Test = test;
            NomEleve = nomEleve;
            PrenomEleve = prenomEleve;
            Classe = classe;
            ResultatAFKs = resultatAFKs;
            ResultatWindows = resultatWindows;
            ResultatWebs = resultatWebs;
        }

        public Resultat()
        {
            ResultatAFKs = new List<ResultatAFK>();
            ResultatWindows = new List<ResultatWindow>();
            ResultatWebs = new List<ResultatWeb>();
        }
    }

}
