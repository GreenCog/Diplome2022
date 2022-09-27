using System.Text.RegularExpressions;

namespace Antitriche_diplome.front.Service;

public static class AnalyseService
{
    //verification is matching with list pattern of regex
    public static bool IsMatching(string input, string paterne)
    {
        Regex regex = new Regex(paterne);
        return regex.IsMatch(input);
    }
    


}