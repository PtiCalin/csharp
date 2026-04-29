# 04 — Structures de contrôle : exemples

> 📘 [Theory](../../01-theory/04-control-flow/README.md) · 🏋️ [Exercises](../../03-exercices/04-control-flow/README.md)

## Exemple 1 — Note finale (extrait IFT1179)

```csharp
public static string EnLettre(double globale)
{
    string lettre;
    if      (globale < 50)  lettre = "E";
    else if (globale < 53)  lettre = "D";
    else if (globale < 57)  lettre = "D+";
    else if (globale < 60)  lettre = "C-";
    else if (globale < 65)  lettre = "C";
    else if (globale < 70)  lettre = "C+";
    else if (globale < 73)  lettre = "B-";
    else if (globale < 77)  lettre = "B";
    else if (globale < 80)  lettre = "B+";
    else if (globale < 85)  lettre = "A-";
    else if (globale < 90)  lettre = "A";
    else                    lettre = "A+";
    return lettre;
}
```

## Exemple 2 — Même logique en switch expression

```csharp
public static string EnLettre(double globale) => globale switch
{
    < 50 => "E",
    < 53 => "D",
    < 57 => "D+",
    < 60 => "C-",
    < 65 => "C",
    < 70 => "C+",
    < 73 => "B-",
    < 77 => "B",
    < 80 => "B+",
    < 85 => "A-",
    < 90 => "A",
    _    => "A+"
};
```

## Exemple 3 — Court-circuit pour éviter `NullReferenceException`

```csharp
string nom = null;

// Sans court-circuit : crash sur .Length.
// if (nom.Length > 0 && nom != null)            // ❌

// Avec court-circuit : sûr.
if (nom != null && nom.Length > 0)               // ✅
    Console.WriteLine($"Nom : {nom}");
else
    Console.WriteLine("Pas de nom");
```

## Exemple 4 — `switch` classique sur `string`

```csharp
public static string Categorie(string jour) =>
    jour.ToLowerInvariant() switch
    {
        "samedi" or "dimanche"               => "Weekend",
        "lundi" or "mardi" or "mercredi"
                or "jeudi" or "vendredi"     => "Semaine",
        _                                    => "Inconnu"
    };
```

## Exemple 5 — Pattern matching avec `when`

```csharp
double note = 75;

string commentaire = note switch
{
    double n when n < 0 || n > 100 => "Note hors plage",
    < 50                            => "Échec",
    < 70                            => "Passable",
    < 85                            => "Bien",
    _                               => "Excellent"
};
```

## 🔗 Voir aussi

- [Theory → 04-control-flow](../../01-theory/04-control-flow/README.md)
- [Exercises → 04-control-flow](../../03-exercices/04-control-flow/README.md)
