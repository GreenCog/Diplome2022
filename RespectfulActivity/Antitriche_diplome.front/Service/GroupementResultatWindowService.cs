using System.ComponentModel.DataAnnotations;
using Antitriche_diplome.models.ApiModels;

namespace Antitriche_diplome.front.Service;

public class GroupementResultatWindowService
{
    public string App { get; set; }
    [Display(Name = "Durée totale")]
    public float DureeTotal { get; set; }
    public List<ResultatWindow> ResultatWindows { get; set; }
    
    public GroupementResultatWindowService( List<ResultatWindow> resultatWindows)
    {
        ResultatWindows = resultatWindows;
        App = resultatWindows.FirstOrDefault(x => true)?.App;
        
        DureeTotal = resultatWindows.Sum(x => x.Duration);
        
    }
}