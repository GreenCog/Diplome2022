using System.ComponentModel;

namespace Antitriche_diplome.models.ApiModels;

public class Regle
{
    public int Id { get; set; }
    public string Nom { get; set; }
    public string Paterne { get; set; }
    public string Commentaire { get; set; }
    [DisplayName("Type de règle")]
    public EnumTypeRegle TypeRegle { get; set; }
    [DisplayName("Utilisation de la règle")]
    public EnumUtilisationRegle UtilisationRegle { get; set; }
}

public enum EnumUtilisationRegle
{
    [Description("Règle pour autoriser")] Autorise = 1,
    [Description("Règle pour interdire")] Interdit = 2,
    [Description("Règle ignorée")] Neutre = 3
}

public enum EnumTypeRegle
{
    [Description("Règle pour les urls")] 
    Web = 1,
    [Description("Règle pour le nom des application")]
    Application = 2
}