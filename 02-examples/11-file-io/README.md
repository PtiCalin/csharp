# 11 — Fichiers (E/S) : exemples

> 📘 [Theory](../../01-theory/11-file-io/README.md) · 🏋️ [Exercises](../../03-exercices/11-file-io/README.md)

## Exemple 1 — Lecture ligne par ligne (`StreamReader`)

```csharp
using System.IO;

public static int LireFichier(string[] lignes, int max, string chemin)
{
    int n = 0;
    using (StreamReader sr = new StreamReader(chemin))
    {
        while (!sr.EndOfStream && n < max)
        {
            lignes[n++] = sr.ReadLine();
        }
    }
    return n;
}
```

## Exemple 2 — Lecture structurée (extrait IFT1179)

```csharp
public static int LireColis(Colis[] tab, string chemin)
{
    int n = 0;
    using StreamReader sr = new StreamReader(chemin);

    while (!sr.EndOfStream && n < tab.Length)
    {
        string code    = sr.ReadLine();
        string adresse = sr.ReadLine();

        if (!double.TryParse(sr.ReadLine(), out double poids))
            continue;                               // Ignore ligne fautive.

        string statut = sr.ReadLine();

        if (!double.TryParse(sr.ReadLine(), out double valeur))
            continue;

        tab[n++] = new Colis(code, adresse, poids, statut, valeur);
    }
    return n;
}
```

## Exemple 3 — Écriture (`StreamWriter`)

```csharp
public static void Sauvegarder(Colis[] tab, int n, string chemin)
{
    using StreamWriter sw = new StreamWriter(chemin);

    for (int i = 0; i < n; i++)
    {
        sw.WriteLine(tab[i].Code);
        sw.WriteLine(tab[i].Adresse);
        sw.WriteLine(tab[i].Poids);
        sw.WriteLine(tab[i].Statut);
        sw.WriteLine(tab[i].Valeur);
    }
}
```

## Exemple 4 — API simplifiée `File.*`

```csharp
// Charge tout le fichier d'un coup (OK pour fichiers < quelques MB).
string[] lignes = File.ReadAllLines("notes.txt");
foreach (string l in lignes)
    Console.WriteLine(l);

// Écriture en un seul appel.
File.WriteAllLines("export.txt", lignes);

// Append (ajout sans écraser).
File.AppendAllText("journal.log", $"[{DateTime.Now:O}] Démarrage\n");
```

## Exemple 5 — Format CSV minimal

```csharp
public static void EcrireCsv(Colis[] tab, int n, string chemin)
{
    using StreamWriter sw = new StreamWriter(chemin);
    sw.WriteLine("Code,Adresse,Poids,Statut,Valeur");           // En-tête.

    for (int i = 0; i < n; i++)
    {
        var c = tab[i];
        // Échappe les virgules dans les champs en encadrant de guillemets.
        sw.WriteLine($"{c.Code},\"{c.Adresse}\",{c.Poids},{c.Statut},{c.Valeur}");
    }
}
```

## Exemple 6 — Vérifier l'existence

```csharp
string chemin = Path.Combine(AppContext.BaseDirectory, "data", "colis.txt");

if (!File.Exists(chemin))
{
    Console.Error.WriteLine($"Fichier manquant : {chemin}");
    return;
}

// Lecture sécurisée.
foreach (string ligne in File.ReadLines(chemin))
    Console.WriteLine(ligne);
```

## 🔗 Voir aussi

- [Theory → 11-file-io](../../01-theory/11-file-io/README.md)
- [Exercises → 11-file-io](../../03-exercices/11-file-io/README.md)
