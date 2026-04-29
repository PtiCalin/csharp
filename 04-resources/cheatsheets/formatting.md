# 📋 Cheatsheet — E/S & formatage

## Console

```csharp
Console.Write("sans saut");
Console.WriteLine("avec saut");
string s = Console.ReadLine();          // lit une ligne (string ou null en EOF)
ConsoleKeyInfo k = Console.ReadKey();   // une touche
```

## Interpolation `$"..."`

```csharp
string nom = "Charlie"; double prix = 4.5;
Console.WriteLine($"{nom} doit {prix:C2}");      // Charlie doit 4,50 $
Console.WriteLine($"{nom,-10} | {prix,8:C2}");   // alignement
```

## Spécificateurs de format

| Code       | Effet                 | Exemple `1234.5`     |
| ---------- | --------------------- | -------------------- |
| `C` / `C2` | Monnaie               | `1 234,50 $` (fr-CA) |
| `F2`       | Flottant fixe         | `1234.50`            |
| `N` / `N0` | Nombre + séparateurs  | `1 234,5`            |
| `P` / `P1` | Pourcentage (×100)    | `123 450,0 %`        |
| `E` / `E2` | Scientifique          | `1.23E+003`          |
| `D5`       | Entier pad-zéro       | `01234`              |
| `X`        | Hexa majuscule        | `4D2`                |
| `0` / `#`  | Modèles personnalisés | `0,000.00`           |

## Alignement

```csharp
$"{val,10}"     // largeur 10, droite
$"{val,-10}"    // largeur 10, gauche
$"{val,10:F2}"  // alignement + format
```

## Cultures

```csharp
using System.Globalization;

var fr = new CultureInfo("fr-CA");
var en = new CultureInfo("en-US");
Console.WriteLine((1234.5).ToString("C2", fr));    // 1 234,50 $
Console.WriteLine((1234.5).ToString("C2", en));    // $1,234.50
Console.WriteLine((1234.5).ToString("C2", CultureInfo.InvariantCulture));
```

> ⚠️ **Pour fichiers techniques** : toujours `InvariantCulture`. Pour affichage
> utilisateur : culture courante (`CultureInfo.CurrentCulture`).

## Composer une chaîne

| Méthode                         | Quand utiliser                             |
| ------------------------------- | ------------------------------------------ |
| `$"..."`                        | Interpolation lisible (privilégier)        |
| `string.Format("Hello {0}", x)` | Quand format dynamique                     |
| `+`                             | Concaténation simple, peu de variables     |
| `StringBuilder`                 | Boucle qui construit beaucoup de fragments |

```csharp
var sb = new StringBuilder();
for (int i = 0; i < 1000; i++) sb.AppendLine($"Ligne {i}");
string result = sb.ToString();
```

## Caractères spéciaux

| Échappement | Signification           |
| ----------- | ----------------------- |
| `\n`        | Saut de ligne           |
| `\t`        | Tabulation              |
| `\\`        | Antislash               |
| `\"`        | Guillemet               |
| `\u00E9`    | Caractère Unicode (`é`) |

```csharp
string chemin = @"C:\Users\Charlie\";    // verbatim : pas d'échappement
string multi = """
    Ligne 1
    Ligne 2
    """;                                  // raw string (C# 11+)
```

## 🔗 Voir aussi

- [03 — E/S & formatage](../03-io-and-formatting/README.md)
- Microsoft : [Format types in .NET](https://learn.microsoft.com/dotnet/standard/base-types/formatting-types)
