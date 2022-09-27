using System.Net;
using System.Net.Http.Headers;

namespace Antitriche_diplome.front.Service;

public class HttpClientService
{
    private HttpClient httpclient;
    public HttpClientService()
    {
        httpclient = new HttpClient();
        httpclient.BaseAddress = new Uri("");
        httpclient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        
    }
    public HttpClient GetHttpClient()
    {
        return httpclient;
    }
}
//create singleton for this class
public class HttpClientServiceSingleton
{
    private static HttpClientService _instance;
    public static HttpClientService Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new HttpClientService();
            }
            return _instance;
        }
    }
}