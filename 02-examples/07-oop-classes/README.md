# 07 — POO Classes : exemples

> 📘 [Theory](../../01-theory/07-oop-classes/README.md) · 🏋️ [Exercises](../../03-exercices/07-oop-classes/README.md)

## Exemple 1 — Classe `Colis` complète (issue du cours IFT1179)

```csharp
public class Colis
{
    // Champs privés.
    private string code;
    private string adresse;
    private double poids;
    private string statut;
    private double valeur;

    // Constructeur complet.
    public Colis(string code, string adresse, double poids, string statut, double valeur)
    {
        this.code = code;
        this.adresse = adresse;
        this.poids = poids;
        this.statut = statut;
        this.valeur = valeur;
    }

    // Constructeur partiel — chaîne vers le complet.
    public Colis(string code, string adresse, double poids, double valeur)
        : this(code, adresse, poids, "Étiquette créée", valeur) { }

    // Constructeur minimal — usage : recherche / Equals.
    public Colis(string code) : this(code, "", 0, "", 0) { }

    // Propriétés.
    public string Code    => code;                          // Lecture seule.
    public string Adresse { get => adresse; set => adresse = value; }
    public double Poids
    {
        get => poids;
        set
        {
            if (value < 0) throw new ArgumentException("Poids négatif");
            poids = value;
        }
    }
    public string Statut  { get => statut;  set => statut = value; }
    public double Valeur  => valeur;

    // Propriété calculée.
    public double Cout
    {
        get
        {
            if (valeur >= 50) return 0;                     // Gratuit.
            if (poids <= 50)  return 15;                    // Forfait.
            return poids * 0.05;                            // Proportionnel.
        }
    }
}
```

## Exemple 2 — Utilisation

```csharp
Colis c1 = new Colis("X42", "Montréal", 12.5, "En transit", 25);
Colis c2 = new Colis("Y99", "Québec", 65, 80);              // Statut par défaut.

Console.WriteLine($"{c1.Code} → {c1.Adresse} ({c1.Poids:F1} kg, coût {c1.Cout:C})");

c1.Statut = "Livré";
c1.Poids  = 10;
// c1.Code = "Z00";                                          // ❌ pas de setter.
```

## Exemple 3 — Champs `static` (compteur global)

```csharp
public class Compteur
{
    public static int Total = 0;                            // Partagé par toutes les instances.
    public int Numero;                                       // Spécifique à l'instance.

    public Compteur()
    {
        Total++;
        Numero = Total;
    }
}

new Compteur(); new Compteur(); new Compteur();
Console.WriteLine(Compteur.Total);                          // 3
```

## Exemple 4 — Initialisation moderne (auto-properties + init-only)

```csharp
public class Point
{
    public double X { get; init; }                          // C# 9+ : assignable seulement à la création.
    public double Y { get; init; }
}

var p = new Point { X = 3, Y = 4 };
// p.X = 5;                                                  // ❌ après construction.
```

## 🔗 Voir aussi

- [Theory → 07-oop-classes](../../01-theory/07-oop-classes/README.md)
- [Exercises → 07-oop-classes](../../03-exercices/07-oop-classes/README.md)
