using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antitriche_diplome.models.ApiModels
{
    public class ResultatWindow
    {
        public int Id { get; set; }
        public string App { get; set; }
        public string Titre { get; set; }
        public DateTime TimeStamp { get; set; }
        public float Duration { get; set; }
        public Resultat Resultat { get; set; }
    }
}
