# 📋 Cheatsheet — Fichiers (E/S)

## Lire ligne par ligne

```csharp
using System.IO;

using (var sr = new StreamReader("colis.txt"))
{
    string ligne;
    while ((ligne = sr.ReadLine()) != null)
    {
        // traiter
    }
}                          // ← Dispose() appelé automatiquement
```

> ✅ `using` garantit fermeture du flux **même en cas d'exception**.

## Écrire ligne par ligne

```csharp
using (var sw = new StreamWriter("rapport.txt"))     // écrase
// using (var sw = new StreamWriter("rapport.txt", append: true))   // ajoute
{
    sw.WriteLine("=== Rapport ===");
    sw.WriteLine($"Date : {DateTime.Now:yyyy-MM-dd}");
}
```

## `using` déclaration (C# 8+)

```csharp
using var sr = new StreamReader("colis.txt");
string ligne = sr.ReadLine();
// Dispose au bloc englobant
```

## Helpers `File.*`

```csharp
string contenu = File.ReadAllText("doc.txt");
string[] lignes = File.ReadAllLines("doc.txt");
File.WriteAllText("out.txt", "Hello");
File.WriteAllLines("out.txt", new[] { "L1", "L2" });
File.AppendAllText("log.txt", "...\n");
bool exists = File.Exists("doc.txt");
File.Delete("temp.txt");
```

> ⚠️ Charge **tout** en mémoire. Inadapté aux gros fichiers (> ~100 Mo).

## Parsing robuste

```csharp
using var sr = new StreamReader("colis.txt");
string ligne;
int numLigne = 0;
while ((ligne = sr.ReadLine()) != null)
{
    numLigne++;
    if (string.IsNullOrWhiteSpace(ligne)) continue;          // ignore vides

    var champs = ligne.Split(';');
    if (champs.Length != 5)
    {
        Console.Error.WriteLine($"L{numLigne}: format invalide");
        continue;
    }

    if (!double.TryParse(champs[2], NumberStyles.Any,
                         CultureInfo.InvariantCulture, out var poids))
    {
        Console.Error.WriteLine($"L{numLigne}: poids invalide");
        continue;
    }

    // ... construire l'objet
}
```

## Chemins portables

```csharp
using System.IO;

string dossier = AppContext.BaseDirectory;             // dossier de l'exe
string chemin = Path.Combine(dossier, "data", "colis.txt");

// Composants
string nom = Path.GetFileName(chemin);                 // colis.txt
string ext = Path.GetExtension(chemin);                // .txt
string sansExt = Path.GetFileNameWithoutExtension(chemin);
string parent = Path.GetDirectoryName(chemin);
```

> ✅ **Toujours** `Path.Combine` plutôt que concaténer avec `"\\"` ou `"/"`.

## Encodage

```csharp
using System.Text;

using var sr = new StreamReader("doc.txt", Encoding.UTF8);
using var sw = new StreamWriter("out.txt", append: false, Encoding.UTF8);
```

> Par défaut : UTF-8 (sans BOM) sur .NET 6+. **Toujours préciser** si tu interagis
> avec un fichier d'origine inconnue (`Encoding.GetEncoding(1252)` pour Windows-1252).

## Exceptions à gérer

| Exception                     | Cause typique                  |
| ----------------------------- | ------------------------------ |
| `FileNotFoundException`       | Fichier introuvable            |
| `DirectoryNotFoundException`  | Dossier introuvable            |
| `UnauthorizedAccessException` | Permissions / lecture seule    |
| `IOException`                 | Verrouillé, disque plein, etc. |
| `FormatException`             | `Parse` sur valeur invalide    |

```csharp
try
{
    using var sr = new StreamReader(chemin);
    // ...
}
catch (FileNotFoundException)
{
    Console.WriteLine("Fichier introuvable.");
}
catch (UnauthorizedAccessException)
{
    Console.WriteLine("Accès refusé.");
}
catch (IOException ex)
{
    Console.WriteLine($"Erreur E/S : {ex.Message}");
}
```

## CSV : règle des virgules dans les valeurs

```csharp
// Si une valeur contient une virgule, l'encadrer de guillemets
// et doubler les guillemets internes :
//   Charlie, dit "le bon"     →   "Charlie, dit ""le bon"""
```

> Pour CSV non-trivial : utiliser une lib (`CsvHelper`).

## 🔗 Voir aussi

- [11 — Fichiers (E/S)](../11-file-io/README.md)
- Microsoft : [File and stream I/O](https://learn.microsoft.com/dotnet/standard/io/)
