# 📋 Cheatsheet — POO

## Squelette de classe

```csharp
public class Colis
{
    // 1. Champs (private)
    private double poids;

    // 2. Propriétés
    public string Code { get; }                       // lecture seule
    public double Poids
    {
        get => poids;
        private set
        {
            if (value < 0) throw new ArgumentException(nameof(value));
            poids = value;
        }
    }
    public string Statut { get; set; } = "EnAttente"; // valeur par défaut

    // 3. Constructeurs
    public Colis(string code) : this(code, 0) { }
    public Colis(string code, double poids)
    {
        Code = code;
        Poids = poids;                                // passe par le setter (validation)
    }

    // 4. Méthodes
    public double Cout() => Poids <= 50 ? 15 : Poids * 0.05;

    // 5. Override de méthodes Object
    public override string ToString() => $"{Code} ({Poids} kg)";
    public override bool Equals(object obj) => obj is Colis c && c.Code == Code;
    public override int GetHashCode() => Code.GetHashCode();
}
```

## Modificateurs d'accès

| Mot-clé              | Visibilité                             |
| -------------------- | -------------------------------------- |
| `public`             | Partout                                |
| `private`            | Classe seule (par défaut pour membres) |
| `protected`          | Classe + dérivées                      |
| `internal`           | Même assembly (par défaut pour types)  |
| `protected internal` | Dérivées **OU** même assembly          |
| `private protected`  | Dérivées **DANS** même assembly        |

## Propriétés : les 4 formes

```csharp
public int A { get; set; }                   // auto, mutable
public int B { get; }                        // auto, immuable (assignable au constructeur)
public int C { get; private set; }           // mutable seulement en interne
public int D                                 // avec validation
{
    get => _d;
    set
    {
        if (value < 0) throw new ArgumentException();
        _d = value;
    }
}
private int _d;
```

## Héritage

```csharp
public abstract class Logement                       // ← abstraite : pas instanciable
{
    public string Adresse { get; }
    protected Logement(string adresse) => Adresse = adresse;

    public abstract double LoyerMensuel();           // ← abstract : à implémenter
    public virtual string Description() =>           // ← virtual : redéfinissable
        $"Logement à {Adresse}";
}

public class Maison : Logement
{
    public int Chambres { get; }
    public Maison(string adr, int ch) : base(adr)    // ← appel constructeur parent
    {
        Chambres = ch;
    }

    public override double LoyerMensuel() =>         // ← override obligatoire
        500 + Chambres * 150;

    public override string Description() =>
        $"Maison {Chambres} ch. à {Adresse}";
}
```

## Surcharge vs redéfinition

|             | Surcharge (overload)     | Redéfinition (override)           |
| ----------- | ------------------------ | --------------------------------- |
| Mot-clé     | aucun                    | `override`                        |
| Lieu        | Même classe              | Sous-classe                       |
| Signatures  | **différentes** (params) | **identiques** au parent          |
| Lien parent | non                      | nécessite `virtual` ou `abstract` |
| Choix       | compile-time             | run-time (polymorphisme)          |

```csharp
// Surcharge : même nom, paramètres différents
public double Aire(double cote) => cote * cote;
public double Aire(double L, double l) => L * l;

// Redéfinition : remplace l'implémentation parent
public override string ToString() => $"...";
```

## Polymorphisme en pratique

```csharp
Logement[] tab = new Logement[]
{
    new Maison("rue A", 3),
    new Logis("rue B", 80, 7)
};

foreach (var l in tab)
    Console.WriteLine($"{l.Adresse} : {l.LoyerMensuel():C2}");
//                                    ↑ appel polymorphe : la BONNE méthode est invoquée
```

## `static` vs instance

|               | `static`        | instance         |
| ------------- | --------------- | ---------------- |
| Appartient à  | la classe       | un objet         |
| `this`        | ❌               | ✅                |
| Accès         | `Classe.Membre` | `obj.Membre`     |
| Polymorphisme | ❌               | ✅                |
| Mémoire       | une seule copie | une par instance |

## Mots-clés POO complémentaires

| Mot-clé        | Effet                                                    |
| -------------- | -------------------------------------------------------- |
| `abstract`     | Classe non instanciable / méthode sans corps             |
| `virtual`      | Méthode redéfinissable                                   |
| `override`     | Redéfinit une méthode `virtual` ou `abstract`            |
| `sealed`       | Empêche l'héritage (classe) ou la redéfinition (méthode) |
| `new` (modif.) | Masque un membre parent (rarement utile)                 |
| `base`         | Référence l'implémentation parente (`base.Methode()`)    |
| `this`         | Référence l'instance courante                            |
| `is` / `as`    | Test / cast sûr de type                                  |

```csharp
if (forme is Cercle c)         // pattern matching
    Console.WriteLine(c.Rayon);

var c = forme as Cercle;        // null si pas un Cercle
```

## 🔗 Voir aussi

- [Concepts → Classe / méthode / fonction / procédure / trigger](../concepts/class-method-function-procedure.md)
- [07 — POO Classes](../07-oop-classes/README.md)
- [08 — POO Polymorphisme](../08-oop-polymorphism/README.md)
