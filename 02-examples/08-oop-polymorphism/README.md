# 08 — Polymorphisme : exemples

> 📘 [Theory](../../01-theory/08-oop-polymorphism/README.md) · 🏋️ [Exercises](../../03-exercices/08-oop-polymorphism/README.md)

## Exemple 1 — Hiérarchie `Logement` (extrait FinalA24)

```csharp
public abstract class Logement
{
    protected string adresse;
    protected double superficie;

    protected Logement(string adresse, double superficie)
    {
        this.adresse = adresse;
        this.superficie = superficie;
    }

    public string Adresse    => adresse;
    public double Superficie => superficie;

    // Doit être redéfinie par chaque sous-classe.
    public abstract double LoyerMensuel();

    // Peut être redéfinie ; sinon, comportement par défaut.
    public override string ToString()
        => $"{GetType().Name} - {adresse} ({superficie} m², loyer {LoyerMensuel():C})";
}

public class Maison : Logement
{
    private int chambres;

    public Maison(string adresse, double superficie, int chambres)
        : base(adresse, superficie)
    {
        this.chambres = chambres;
    }

    public override double LoyerMensuel()
        => superficie * 12 + chambres * 150;
}

public class Logis : Logement                       // Appartement.
{
    private int etage;

    public Logis(string adresse, double superficie, int etage)
        : base(adresse, superficie)
    {
        this.etage = etage;
    }

    public override double LoyerMensuel()
        => superficie * 18 + (etage > 5 ? 200 : 0);
}
```

## Exemple 2 — Polymorphisme à l'usage

```csharp
Logement[] tab = new Logement[]
{
    new Maison("123 rue Sainte-Catherine, Montréal", 120, 3),
    new Logis ("456 boul. René-Lévesque, Montréal",  60, 8),
    new Maison("789 ch. de la Côte-Sainte-Catherine", 200, 5),
};

double totalLoyer = 0;
foreach (Logement l in tab)
{
    Console.WriteLine(l);                           // Appelle ToString polymorphe.
    totalLoyer += l.LoyerMensuel();                 // Appelle Maison ou Logis selon le type réel.
}

Console.WriteLine($"\nTotal mensuel : {totalLoyer:C}");
```

## Exemple 3 — Redéfinition d'`Equals` et `ToString`

```csharp
public class Colis
{
    private string code;
    private string adresse;

    public Colis(string code, string adresse) { this.code = code; this.adresse = adresse; }
    public string Code => code;

    public override string ToString() => $"Colis {code} → {adresse}";

    public override bool Equals(object obj)
    {
        if (obj is not Colis autre) return false;
        return code == autre.code;                  // Égalité = même clé métier.
    }

    public override int GetHashCode() => code?.GetHashCode() ?? 0;
}

// Usage
var c1 = new Colis("X42", "Montréal");
var c2 = new Colis("X42", "Québec");
Console.WriteLine(c1.Equals(c2));                  // True : même code, malgré adresse ≠.
Console.WriteLine(c1);                              // « Colis X42 → Montréal »
```

## Exemple 4 — Pattern matching sur le type

```csharp
public static double LoyerAvecRabais(Logement l)
{
    return l switch
    {
        Maison m when m.Superficie > 200 => m.LoyerMensuel() * 0.95,
        Logis  lo                        => lo.LoyerMensuel(),
        _                                 => l.LoyerMensuel()
    };
}
```

## 🔗 Voir aussi

- [Theory → 08-oop-polymorphism](../../01-theory/08-oop-polymorphism/README.md)
- [Exercises → 08-oop-polymorphism](../../03-exercices/08-oop-polymorphism/README.md)
- Examen final UdeM : [`FinalA24`](../../05-references/course-materials/UDEM_H26_IFT1179/assignements/exams/02-final/FinalA24)
