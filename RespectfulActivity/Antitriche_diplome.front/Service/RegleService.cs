using System.Text;
using Antitriche_diplome.models.ApiModels;
using Newtonsoft.Json;

namespace Antitriche_diplome.front.Service;

public interface IRegleService
{
    public Task<List<Regle>> getRegles();
    public Task<List<Regle>> getReglesWebActives();
    public Task<List<Regle>> getReglesWindowActives();
    public Task<Regle> getRegle(int id);
    public Task postRegle(Regle regle);
    public Task putRegle(Regle regle);
    public Task deleteRegle(int id);
}

public class RegleService : IRegleService
{
    private HttpClientService _httpClientService;

    public RegleService()
    {
        _httpClientService = HttpClientServiceSingleton.Instance;
    }


    public async Task<List<Regle>> getRegles()
    {
        HttpResponseMessage reponse = _httpClientService.GetHttpClient().GetAsync($"api/regles").Result;

        if (!reponse.IsSuccessStatusCode) throw new Exception();
        var reglesString = await reponse.Content.ReadAsStringAsync();
        var regles = JsonConvert.DeserializeObject<List<Regle>>(reglesString);
        return regles;
    }

    public async Task<Regle> getRegle(int id)
    {
        HttpResponseMessage reponse = _httpClientService.GetHttpClient().GetAsync($"api/Regles/{id}").Result;

        if (!reponse.IsSuccessStatusCode) throw new Exception();
        var regleString = await reponse.Content.ReadAsStringAsync();
        var regle = JsonConvert.DeserializeObject<Regle>(regleString);
        return regle;
    }

    public async Task postRegle(Regle _regle)
    {
        var regle = JsonConvert.SerializeObject(_regle);
        var requestContent = new StringContent(regle, Encoding.UTF8, "application/json");
        var reponse = await _httpClientService.GetHttpClient().PostAsync($"api/Regles", requestContent);
        if (!reponse.IsSuccessStatusCode) throw new Exception();
        
    }

    public async Task putRegle(Regle _regle)
    {
        var regle = JsonConvert.SerializeObject(_regle);
        var requestContent = new StringContent(regle, Encoding.UTF8, "application/json");
        var reponse = await _httpClientService.GetHttpClient().PutAsync($"api/Regles/{_regle.Id}", requestContent);
        if (!reponse.IsSuccessStatusCode) throw new Exception();
        
    }

    public async Task deleteRegle(int id)
    {
        var reponse = await _httpClientService.GetHttpClient().DeleteAsync($"api/Regles/{id}");
        if (!reponse.IsSuccessStatusCode) throw new Exception();
        
    }

    public async Task<List<Regle>> getReglesWebActives()
    {
        HttpResponseMessage reponse = _httpClientService.GetHttpClient().GetAsync($"api/regles").Result;

        if (!reponse.IsSuccessStatusCode) throw new Exception();
        var reglesString = await reponse.Content.ReadAsStringAsync();
        var regles = JsonConvert.DeserializeObject<List<Regle>>(reglesString);
        var reglesTrie =  regles
            .Where(x => x.TypeRegle == EnumTypeRegle.Web)
            .Where(x => x.UtilisationRegle != EnumUtilisationRegle.Neutre)
            .ToList();
        return reglesTrie;
    }

    public async Task<List<Regle>> getReglesWindowActives()
    {
        HttpResponseMessage reponse = _httpClientService.GetHttpClient().GetAsync($"api/regles").Result;

        if (!reponse.IsSuccessStatusCode) throw new Exception();
        var reglesString = await reponse.Content.ReadAsStringAsync();
        var regles = JsonConvert.DeserializeObject<List<Regle>>(reglesString);
        var reglesTrie =  regles
            .Where(x => x.TypeRegle == EnumTypeRegle.Application)
            .Where(x => x.UtilisationRegle != EnumUtilisationRegle.Neutre)
            .ToList();
        return reglesTrie;
    }
}