using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antitriche_diplome.projet_eleve
{
    

    public partial class ReponseWatcherAFK : ReponseWatcher
    {
        public ReponseWatcherAFKData Data { get; set; }

        public ReponseWatcherAFK() 
        {
            Data = new ReponseWatcherAFKData();
        }
        public ReponseWatcherAFK(int id, DateTime timestamp, float duration,  ReponseWatcherAFKData data) : base(id,timestamp,duration )
        {
            this.Data = data;
        }
        
        
    }

    public class ReponseWatcherAFKData
    {
        public string status { get; set; }
    }

    
}
