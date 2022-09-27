using Antitriche_diplome.projet_eleve;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antitriche_diplome.projet_eleve
{
    
    
    public partial class ReponseWatcherWindow : ReponseWatcher
    {
        public ReponseWatcherWindow() 
        {
            this.Data = new ReponseWatcherWindowData();
        }
        public ReponseWatcherWindow(int id , DateTime timestamp, float duration, ReponseWatcherWindowData data) : base(id , timestamp, duration)
        {
            this.Data = data;
        }
        
        public ReponseWatcherWindowData Data { get; set; }
    }

    public class ReponseWatcherWindowData
    {
        public string app { get; set; }
        public string title { get; set; }
    }

    
}
