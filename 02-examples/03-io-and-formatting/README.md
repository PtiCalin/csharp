# 03 — E/S & formatage : exemples

> 📘 [Theory](../../01-theory/03-io-and-formatting/README.md) · 🏋️ [Exercises](../../03-exercices/03-io-and-formatting/README.md)

## Exemple 1 — Tableau de notes (composite formatting)

```csharp
using System;

string[] noms = { "Alice", "Bob", "Charlie", "Diane" };
int[]    notes = {    87,    62,        93,      71 };

// En-tête.
Console.WriteLine($"{"Nom",-12}{"Note",6}{"Lettre",10}");
Console.WriteLine(new string('-', 28));

for (int i = 0; i < noms.Length; i++)
{
    string lettre = notes[i] switch
    {
        >= 90 => "A",
        >= 80 => "B",
        >= 70 => "C",
        >= 60 => "D",
        _     => "F"
    };

    // {-12} = aligné gauche, largeur 12.
    // {6}    = aligné droite, largeur 6.
    Console.WriteLine($"{noms[i],-12}{notes[i],6}{lettre,10}");
}
```

## Exemple 2 — Catalogue de formats

```csharp
double prix    = 1234.5678;
double taux    = 0.14975;
int    code    = 42;
DateTime now   = DateTime.Now;

Console.WriteLine($"Monnaie     : {prix:C2}");        // 1 234,57 $
Console.WriteLine($"Fixe        : {prix:F2}");        // 1234.57
Console.WriteLine($"Nombre      : {prix:N2}");        // 1,234.57
Console.WriteLine($"Pourcentage : {taux:P1}");        // 15.0 %
Console.WriteLine($"Hexadécimal : {code:X4}");        // 002A
Console.WriteLine($"Zéros gauche: {code:D5}");        // 00042
Console.WriteLine($"Date ISO    : {now:yyyy-MM-dd}"); // 2026-04-28
Console.WriteLine($"Heure       : {now:HH\\:mm\\:ss}"); // 14:35:42
```

## Exemple 3 — Forcer la culture (fichiers techniques)

```csharp
using System.Globalization;

double valeur = 12.5;

// Culture courante (peut varier selon la machine).
Console.WriteLine(valeur.ToString("F2"));                              // « 12,50 » en fr-CA

// Culture invariante : reproductible, format anglo-saxon.
Console.WriteLine(valeur.ToString("F2", CultureInfo.InvariantCulture)); // « 12.50 »

// Lecture inverse.
double lu = double.Parse("12.50", CultureInfo.InvariantCulture);
```

## Exemple 4 — Boucle de menu

```csharp
int choix;
do
{
    Console.Clear();
    Console.WriteLine("=== Menu ===");
    Console.WriteLine("1. Ajouter");
    Console.WriteLine("2. Supprimer");
    Console.WriteLine("3. Lister");
    Console.WriteLine("0. Quitter");
    Console.Write("Votre choix : ");
}
while (!int.TryParse(Console.ReadLine(), out choix) || choix < 0 || choix > 3);
```

## 🔗 Voir aussi

- [Theory → 03-io-and-formatting](../../01-theory/03-io-and-formatting/README.md)
- [Exercises → 03-io-and-formatting](../../03-exercices/03-io-and-formatting/README.md)
