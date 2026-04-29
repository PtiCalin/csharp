# 08 — POO : Polymorphisme & héritage

> 📚 [Examples](../../02-examples/08-oop-polymorphism/README.md) · 🏋️ [Exercises](../../03-exercices/08-oop-polymorphism/README.md)

## L1 — Intuition

Le **polymorphisme** = un même appel produit un **comportement différent** selon le type
réel de l'objet. La classe parent définit *quoi* faire (`abstract` ou `virtual`) ; les
classes filles définissent *comment* (`override`).

```text
       Logement (abstract)              ← définit l'API commune
        ▲          ▲
    Maison       Logis                  ← spécialisations
```

Un `Logement[]` peut contenir des `Maison` et des `Logis` ; appeler `.Cout()` sur chaque
élément fait *automatiquement* la bonne chose.

## L2 — Syntaxe essentielle

### Héritage simple

```csharp
public class Animal
{
    public string Nom { get; set; }
    public virtual string Crier() => "...";  // virtual = redéfinissable.
}

public class Chien : Animal                  // : Animal = hérite de Animal.
{
    public override string Crier() => "Wouf";  // override = redéfinit.
}
```

### Classe `abstract`

```csharp
public abstract class Logement
{
    protected double superficie;

    protected Logement(double superficie) { this.superficie = superficie; }

    public abstract double Cout();           // Sans corps : les filles DOIVENT redéfinir.
    public virtual string Description() =>   // Avec corps : les filles PEUVENT redéfinir.
        $"Logement de {superficie} m²";
}

public class Maison : Logement
{
    private int chambres;
    public Maison(double superficie, int chambres) : base(superficie)
    {
        this.chambres = chambres;
    }
    public override double Cout() => superficie * 250;
    public override string Description() => $"Maison de {chambres} chambres, {superficie} m²";
}
```

### Redéfinitions canoniques

```csharp
public override string ToString() =>
    $"{code} - {adresse} ({poids:F1} kg)";

public override bool Equals(object obj)
{
    if (obj is not Colis autre) return false;   // Test null + type combiné (C# 9+).
    return code == autre.code;                  // Égalité logique sur la clé métier.
}

public override int GetHashCode() => code.GetHashCode();   // Doit suivre Equals.
```

## L3 — Polymorphisme à l'œuvre

```csharp
Logement[] tab = new Logement[]
{
    new Maison(120, 3),
    new Logis(45, 1),
    new Maison(200, 5),
};

double total = 0;
foreach (Logement l in tab)
    total += l.Cout();                          // Appelle Maison.Cout ou Logis.Cout selon le type réel.
```

### `base` — accéder au parent

```csharp
public override string Description()
    => base.Description() + $" ({chambres} chambres)";   // Étend, ne remplace pas.
```

### `is` / `as` / pattern matching

```csharp
if (animal is Chien c)                          // Test + déclaration en une fois.
    c.Aboyer();

Chien chien = animal as Chien;                  // null si la conversion échoue.
if (chien != null) chien.Aboyer();
```

## L4 — Pièges

- ⚠️ **Oublier `override`** → la méthode fille **masque** au lieu de redéfinir
  (mot-clé `new` implicite). Compilateur émet un avertissement.
- ⚠️ Redéfinir `Equals` sans `GetHashCode` → bug dans `Dictionary` / `HashSet`.
- ⚠️ `abstract class` ne peut pas être **instanciée** directement : `new Logement(...)`
  → erreur.
- ⚠️ Constructeur d'une classe fille **doit** appeler `: base(...)` si le parent n'a
  pas de constructeur sans paramètres.
- ⚠️ Pas d'héritage **multiple de classes** en C#. Pour mutualiser des comportements
  croisés, utiliser des **interfaces** (`interface IComparable`).

## ✅ Vérifiez votre compréhension

1. Quelle est la différence entre `virtual` et `abstract` côté parent, et entre
   `override` et `new` côté enfant ?
2. Pourquoi redéfinir `Equals` impose-t-il aussi de redéfinir `GetHashCode` ?
3. Dans un `Logement[]`, comment l'appel `tab[i].Cout()` peut-il invoquer du code
   différent à chaque itération ?

## 🔗 Pour aller plus loin

- Microsoft Learn — [Polymorphism](https://learn.microsoft.com/dotnet/csharp/fundamentals/object-oriented/polymorphism)
- Examen final UdeM : [FinalA24](../../05-references/course-materials/UDEM_H26_IFT1179/assignements/exams/02-final/FinalA24)
