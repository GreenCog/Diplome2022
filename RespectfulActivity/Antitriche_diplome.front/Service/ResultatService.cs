using System.Net.Http.Headers;
using Antitriche_diplome.models.ApiModels;
using Newtonsoft.Json;

namespace Antitriche_diplome.front.Service;

public interface IResultatService
{
    public Task<List<ResultatDTO>> getResultats();
    public Task<Resultat> getResultat(int id);
}


public class ResultatService : IResultatService
{
    private HttpClientService _httpClientService;

    public ResultatService()
    {
        _httpClientService = HttpClientServiceSingleton.Instance;
    }


    public async Task<List<ResultatDTO>> getResultats()
    {
        HttpResponseMessage reponse = _httpClientService.GetHttpClient().GetAsync($"api/Resultats").Result;
        
        if (!reponse.IsSuccessStatusCode) throw new Exception();
        var resultatString = await reponse.Content.ReadAsStringAsync();
        var resultatDtos = JsonConvert.DeserializeObject<List<ResultatDTO>>(resultatString);
        return resultatDtos;

    }

    public async Task<Resultat> getResultat(int id)
    {
        
        HttpResponseMessage reponse = _httpClientService.GetHttpClient().GetAsync($"api/Resultats/{id}").Result;
        
        if (!reponse.IsSuccessStatusCode) throw new Exception();
        var resultatString = await reponse.Content.ReadAsStringAsync();
        var resultat = JsonConvert.DeserializeObject<Resultat>(resultatString);
        return resultat;
    }
}