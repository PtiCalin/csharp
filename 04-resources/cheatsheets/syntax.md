# 📋 Cheatsheet — Syntaxe & types

## Squelette minimal

```csharp
using System;

namespace MonProjet;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello!");
    }
}
```

> .NET 6+ : *top-level statements* possibles (pas besoin de `Main` explicite).

## Types primitifs

| Type | Taille | Plage / précision | Suffixe litt. | Usage |
|------|--------|-------------------|---------------|-------|
| `bool` | 1 bit | `true` / `false` | — | Logique |
| `char` | 16 bits | UTF-16 unitaire | `'a'` | Caractère |
| `byte` | 8 bits non signé | 0–255 | — | Octet |
| `short` | 16 bits signé | ±32 K | — | Rare |
| `int` | 32 bits signé | ±2,1 G | — | Entier par défaut |
| `long` | 64 bits signé | ±9,2 E | `L` | Grand entier |
| `float` | 32 bits flottant | ~7 chiffres | `f` | Rare |
| `double` | 64 bits flottant | ~15 chiffres | `d` (opt.) | Calculs scientifiques |
| `decimal` | 128 bits décimal | ~28-29 chiffres | `m` | **Argent** |
| `string` | référence | UTF-16 immuable | `"..."` | Texte |

## Déclarations

```csharp
int n = 42;                    // type explicite
var n = 42;                    // type inféré (toujours int ici)
const double PI = 3.14159;     // constante (compile-time)
readonly int seed;             // assignable seulement au constructeur

string nom = "Charlie";
string vide = "";
string nul = null;             // ⚠️ accès aux membres = NullReferenceException
```

## Conversions

| Forme | Effet | Erreur si invalide |
|-------|-------|--------------------|
| `(int) d` | Cast explicite | `OverflowException` ou tronque |
| `Convert.ToInt32(s)` | Convertit | `FormatException` |
| `int.Parse(s)` | Parse strict | `FormatException` |
| **`int.TryParse(s, out n)`** | **Parse sûr** | retourne `false`, `n = 0` |
| `s.ToString()` | vers chaîne | jamais |
| `s.ToString("C2")` | formatée | culture-dépendant |

```csharp
if (!int.TryParse(saisie, out int age))
{
    Console.WriteLine("Saisie invalide.");
    return;
}
```

## Opérateurs

| Catégorie | Exemples |
|-----------|----------|
| Arithmétique | `+ - * / %` (modulo) |
| Affectation | `= += -= *= /= %=` |
| Comparaison | `== != < > <= >=` |
| Logique | `&& \|\| !` (court-circuit) |
| Bit-à-bit | `& \| ^ ~ << >>` |
| Ternaire | `cond ? a : b` |
| Null-cond. | `obj?.Membre`, `obj?[i]` |
| Null-coal. | `a ?? b`, `a ??= b` |

⚠️ **Division entière** : `5 / 2 == 2`. Force flottant : `5.0 / 2 == 2.5`.

## Mots-clés réservés (sélection)

`abstract` `as` `base` `bool` `break` `case` `catch` `class` `const` `continue`
`decimal` `default` `delegate` `do` `double` `else` `enum` `event` `false` `finally`
`float` `for` `foreach` `if` `int` `interface` `internal` `is` `long` `namespace`
`new` `null` `object` `out` `override` `params` `private` `protected` `public`
`readonly` `ref` `return` `sealed` `static` `string` `struct` `switch` `this`
`throw` `true` `try` `typeof` `using` `var` `virtual` `void` `while`

## Commentaires

```csharp
// commentaire ligne
/* bloc */
/// <summary>Documentation XML.</summary>
```

## 🔗 Voir aussi

- [Glossaire](../GLOSSARY.md)
- [02 — Types & variables](../02-types-and-variables/README.md)
