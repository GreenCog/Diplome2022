using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antitriche_diplome.models.ApiModels
{
    public class ResultatDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string? Test { get; set; }
        public string? NomEleve { get; set; }
        public string? PrenomEleve { get; set; }
        public string? Classe { get; set; }
        public ResultatDTO() { }
        public ResultatDTO(Resultat resultat)
        {
            Id = resultat.Id;
            Date = resultat.Date;
            Test = resultat.Test;
            NomEleve = resultat.NomEleve;
            PrenomEleve = resultat.PrenomEleve;
            Classe = resultat.Classe;
        }
    }


}

