using Antitriche_diplome.models.ApiModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antitriche_diplome.projet_eleve
{
    public class ReponseWatcher
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public float Duration { get; set; }
        public ReponseWatcher()
        {
        }
        public ReponseWatcher(int id, DateTime timestamp, float duration)
        {
            Id = id;
            Timestamp = timestamp;
            Duration = duration;
        }
    }
}