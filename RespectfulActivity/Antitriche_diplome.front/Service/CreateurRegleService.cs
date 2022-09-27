namespace Antitriche_diplome.front.Service;

public static class CreateurRegleService
{
    //generator for regex pattern that sensitive to the case of the letters in the word in parmater
    public static string createRegexSensitive(String word)
    {
        String regex = ".";
        
        for (int i = 0; i < word.Length; i++)
        {
            
            regex +=$"[{word[i]}{char.ToUpper(word[i])}]";
        }
        regex += ".+|";
        for (int i = 0; i < word.Length; i++)
        {
            
            regex +=$"[{word[i]}{char.ToUpper(word[i])}]";
        }
        regex += ".+|";
        for (int i = 0; i < word.Length; i++)
        {
            
            regex +=$"[{word[i]}{char.ToUpper(word[i])}]";
        }
        return regex;
        
    }
    
   
}