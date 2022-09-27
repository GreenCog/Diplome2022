using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antitriche_diplome.projet_eleve
{
    

    public partial class ReponseWatcherWeb : ReponseWatcher
    {
        public ReponseWatcherWeb() 
        {
            this.Data = new ReponseWatcherWebData();
        }
        public ReponseWatcherWeb(int id , DateTime timestamp, float duration, ReponseWatcherWebData data ) : base(id , timestamp, duration)
        {
            this.Data = data;

        }
        
        public ReponseWatcherWebData Data { get; set; }
    }

    public class ReponseWatcherWebData
    {
        public string url { get; set; }
        public string title { get; set; }
        public bool audible { get; set; }
        public bool incognito { get; set; }
        public int tabCount { get; set; }
    }

    
}
