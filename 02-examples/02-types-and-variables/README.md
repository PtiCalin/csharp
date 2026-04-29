# 02 — Types & variables : exemples

> 📘 [Theory](../../01-theory/02-types-and-variables/README.md) · 🏋️ [Exercises](../../03-exercices/02-types-and-variables/README.md)

## Exemple 1 — Conversions sûres et risquées

```csharp
using System;

// Conversion implicite (toujours sûre).
int n = 42;
double d = n;                                       // OK : 42.0

// Cast explicite (peut tronquer).
double pi = 3.99;
int approx = (int)pi;                               // 3 (et NON 4 — pas d'arrondi)

// Arrondi correct.
int arrondi = (int)Math.Round(pi);                  // 4

// Cast avec dépassement silencieux.
int tropGrand = (int)2_500_000_000.0;               // résultat indéterminé sur int 32-bit.

// Conversion sécurisée.
string saisie = "abc";
if (!int.TryParse(saisie, out int valeur))
    Console.WriteLine("Saisie non numérique");
else
    Console.WriteLine($"OK : {valeur}");
```

## Exemple 2 — Le piège des `double`

```csharp
// Comparaison naïve sur des doubles : presque toujours fausse.
double a = 0.1 + 0.2;
double b = 0.3;

Console.WriteLine(a == b);                          // False !
Console.WriteLine(a);                               // 0.30000000000000004

// Solution 1 : marge de tolérance.
const double EPSILON = 1e-9;
bool egal = Math.Abs(a - b) < EPSILON;              // True

// Solution 2 : decimal pour calcul exact (argent).
decimal ma = 0.1m + 0.2m;
decimal mb = 0.3m;
Console.WriteLine(ma == mb);                        // True
```

## Exemple 3 — `var` n'est pas dynamique

```csharp
var x = 42;                                         // x est int (inféré).
// x = "abc";                                       // ❌ Compile error : x est int.

var liste = new System.Collections.Generic.List<string>();   // évite la répétition de type.
```

## Exemple 4 — Saisie utilisateur robuste

```csharp
Console.Write("Votre âge : ");
string saisie = Console.ReadLine();

while (!int.TryParse(saisie, out int age) || age < 0 || age > 130)
{
    Console.Write("Âge invalide. Réessayez : ");
    saisie = Console.ReadLine();
}

// Ici on est sûrs d'avoir un âge valide.
Console.WriteLine($"Âge accepté.");
```

## 🔗 Voir aussi

- [Theory → 02-types-and-variables](../../01-theory/02-types-and-variables/README.md)
- [Exercises → 02-types-and-variables](../../03-exercices/02-types-and-variables/README.md)
