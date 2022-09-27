using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antitriche_diplome.models.ApiModels
{
    public class ResultatAFK
    {
        public int Id { get; set; }
        public string Statut { get; set; }
        public DateTime TimeStamp { get; set; }
        public float Duration { get; set; }
        public Resultat Resultat { get; set; }
        public ResultatAFK() { }

    }
}
