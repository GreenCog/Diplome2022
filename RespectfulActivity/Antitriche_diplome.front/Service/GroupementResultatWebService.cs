using System.ComponentModel.DataAnnotations;
using Antitriche_diplome.models.ApiModels;

namespace Antitriche_diplome.front.Service;

public class GroupementResultatWebService
{
    public string Titre { get; set; }
    [Display(Name = "Durée totale")]
    public float DureeTotal { get; set; }
    public List<ResultatWeb> ResultatWebs { get; set; }
    
    public GroupementResultatWebService( List<ResultatWeb> resultatWebs)
    {
        ResultatWebs = resultatWebs;
        Titre = resultatWebs.FirstOrDefault(x => true)?.Titre;
        
        this.DureeTotal = resultatWebs.Sum(x => x.Duration);
        
    }
}

