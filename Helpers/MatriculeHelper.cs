using System;
using System.Text;
using System.Text.RegularExpressions;

public class MatriculeGenerator
{
    public static string GenererMatricule(string nom, string prenom, DateTime dateNaissance)
    {
        // 1. Nettoyage des chaînes (suppression des accents, espaces et caractères spéciaux)
        string nomNettoye = NettoyerChaine(nom);
        string prenomNettoye = NettoyerChaine(prenom);

        // 2. Extraire 2 lettres du nom (complété par 'X' si trop court)
        string codeNom = (nomNettoye.Length >= 2) ? nomNettoye.Substring(0, 2) : nomNettoye.PadRight(2, 'X');

        // 3. Extraire 2 lettres du prénom (complété par 'X' si trop court)
        string codePrenom = (prenomNettoye.Length >= 2) ? prenomNettoye.Substring(0, 2) : prenomNettoye.PadRight(2, 'X');

        // 4. Formater la date de naissance sur 6 chiffres (AnnéeMoisJour -> AAMMJJ)
        string codeDate = dateNaissance.ToString("yyMMdd");

        // 6. Assemblage final : 2 + 2 + 6 + 2 = 12 caractères
        return $"{codeNom}{codePrenom}{codeDate}{new string(DateTime.UtcNow.Year.ToString())}";
    }

    private static string NettoyerChaine(string texte)
    {
        if (string.IsNullOrWhiteSpace(texte)) return "";

        // Met en majuscules
        texte = texte.ToUpperInvariant();

        // Normalise pour séparer les accents des lettres
        string texteNormalise = texte.Normalize(NormalizationForm.FormD);
        
        // Supprime les accents et caractères non alpha (garde uniquement A-Z)
        Regex regex = new Regex("[^A-Z]");
        return regex.Replace(texteNormalise, "");
    }
}