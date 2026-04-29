# 11 — Fichiers (E/S)

> 📚 [Examples](../../02-examples/11-file-io/README.md) · 🏋️ [Exercises](../../03-exercices/11-file-io/README.md)

## L1 — Intuition

Lire / écrire un fichier = **ouvrir un canal**, transférer du texte ligne par ligne,
**fermer** le canal. Oublier de fermer = ressources verrouillées (le fichier reste
ouvert pour le système).

```text
StreamReader  →  ReadLine()*  →  Close()
StreamWriter  →  WriteLine()*  →  Close()
```

## L2 — API essentielle

```csharp
using System.IO;                                    // Espace de noms requis.

// Lecture.
StreamReader lecteur = new StreamReader("entree.txt");
while (!lecteur.EndOfStream)
{
    string ligne = lecteur.ReadLine();
    Traiter(ligne);
}
lecteur.Close();

// Écriture.
StreamWriter ecrivain = new StreamWriter("sortie.txt");
ecrivain.WriteLine("Première ligne");
ecrivain.WriteLine($"Compteur : {n}");
ecrivain.Close();
```

### Pattern recommandé : `using`

`using` garantit la fermeture **même si une exception survient**.

```csharp
using (StreamReader lecteur = new StreamReader("entree.txt"))
{
    while (!lecteur.EndOfStream)
        Traiter(lecteur.ReadLine());
}   // Close() automatique ici, même en cas d'exception.

// C# 8+ : using déclaration (Close à la fin du bloc englobant).
using StreamReader lecteur2 = new StreamReader("entree.txt");
```

### Outils complémentaires

| API                                | Usage                                           |
| ---------------------------------- | ----------------------------------------------- |
| `File.ReadAllLines(path)`          | Charge tout le fichier d'un coup en `string[]`. |
| `File.ReadAllText(path)`           | Charge en une seule `string`.                   |
| `File.WriteAllLines(path, lignes)` | Écrit toutes les lignes (écrase).               |
| `File.AppendAllText(path, txt)`    | Ajoute en fin de fichier.                       |
| `File.Exists(path)`                | Vérifie l'existence avant lecture.              |
| `Path.Combine(a, b)`               | Construit un chemin portable (Windows / Linux). |

## L3 — Exemple complet (issu du cours)

```csharp
public static int LireColis(Colis[] tab, string chemin)
{
    int n = 0;
    using (StreamReader lecteur = new StreamReader(chemin))
    {
        while (!lecteur.EndOfStream && n < tab.Length)
        {
            string code    = lecteur.ReadLine();
            string adresse = lecteur.ReadLine();

            // TryParse plutôt que Parse : protège contre données corrompues.
            if (!double.TryParse(lecteur.ReadLine(), out double poids))
                continue;                           // Ignore la ligne fautive.

            string statut = lecteur.ReadLine();

            if (!double.TryParse(lecteur.ReadLine(), out double valeur))
                continue;

            tab[n++] = new Colis(code, adresse, poids, statut, valeur);
        }
    }
    return n;
}
```

## L4 — Pièges

- ⚠️ Oublier `Close()` (sans `using`) = **fuite de handle** ; le fichier reste verrouillé.
- ⚠️ Chemins en dur (`C:\Users\...\fichier.txt`) → casse sur la machine d'un autre.
  Utiliser `Path.Combine` + chemin **relatif** ou `AppDomain.CurrentDomain.BaseDirectory`.
- ⚠️ `double.Parse("1.5")` peut échouer en culture `fr-CA` (qui attend `"1,5"`).
  Forcer `CultureInfo.InvariantCulture` pour les fichiers techniques.
- ⚠️ Lire au-delà de `EndOfStream` → `ReadLine()` retourne `null` → `NullReferenceException`
  au prochain `Parse`.
- ⚠️ `StreamWriter` **écrase** par défaut. Pour ajouter, utiliser
  `new StreamWriter(path, append: true)`.

## ✅ Vérifiez votre compréhension

1. Pourquoi le bloc `using` est-il préférable à `Close()` manuel ?
2. Quelle est la différence entre `File.ReadAllLines` et `StreamReader` en boucle ?
   Quand chacun est-il préférable ?
3. Que retourne `ReadLine()` à la fin du fichier ? Comment l'utilises-tu pour piloter
   ta boucle ?

## 🔗 Pour aller plus loin

- Microsoft Learn — [File and Stream I/O](https://learn.microsoft.com/dotnet/standard/io/)
- TP3 — [`coasters.txt`](../../05-references/course-materials/UDEM_H26_IFT1179/assignements/TP3/coasters.txt) et [`Nations.txt`](../../05-references/course-materials/UDEM_H26_IFT1179/assignements/TP3/Nations.txt)
