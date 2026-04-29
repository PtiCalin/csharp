# `private` vs `public` : qui voit quoi, et pourquoi

> 📘 Concept transversal — central dès le module [07 — POO Classes](../../01-theory/07-oop-classes/README.md).

L1, en une phrase :

> **`public` = porte ouverte sur la rue. `private` = pièce fermée à clé.
> L'encapsulation, c'est de garder le maximum de portes fermées tout en laissant
> passer ce qui doit passer.**

---

## 🗺️ Tous les modificateurs d'accès

| Mot-clé              | Visibilité                                    | Cas d'usage                   |
| -------------------- | --------------------------------------------- | ----------------------------- |
| `public`             | Partout                                       | API destinée à être consommée |
| `private`            | **Classe seule**                              | Détails d'implémentation      |
| `protected`          | Classe + classes dérivées                     | Hook pour sous-classes        |
| `internal`           | Même **assembly** (`.dll`)                    | API interne du projet         |
| `protected internal` | Dérivées **OU** même assembly                 | Rare, à éviter                |
| `private protected`  | Dérivées **DANS** même assembly               | Plus rare encore              |
| *(omis)*             | `private` pour membres, `internal` pour types | Le défaut C#                  |

> ⚠️ En C#, **le défaut diffère entre membres et types**. Sans modificateur :
> - `class Foo` → `internal`
> - `class Foo { int x; }` → `x` est `private`

## 1. Pourquoi le défaut sain est `private`

Quand tu hésites, **commence par `private`**. Tu peux toujours élargir plus
tard ; tu ne peux pas restreindre sans casser tous les appelants. C'est la
règle d'or des API : *« plus facile d'ouvrir une porte que de la refermer »*.

```csharp
public class Colis
{
    // Champ : private par défaut. ✅
    private double poids;

    // Méthode utilitaire interne : private explicite (pour la lisibilité).
    private bool EstSurpoids() => poids > 100;

    // Surface API publique, minimale.
    public double Poids => poids;
    public string Statut() => EstSurpoids() ? "Lourd" : "Standard";
}
```

À l'extérieur, tu n'as aucun moyen d'écrire `colis.poids = -42` ni d'appeler
`colis.EstSurpoids()`. La classe **garde le contrôle** de ses invariants.

## 2. Le piège : exposer un champ en `public`

```csharp
// ❌ Anti-pattern
public class Colis
{
    public double Poids;        // champ public, mutable, sans validation
}

var c = new Colis();
c.Poids = -999;                  // accepté en silence
```

Trois problèmes en cascade :

1. **L'invariant `Poids ≥ 0` n'existe pas** : il n'est défendu nulle part.
2. **L'API est figée** : si demain `Poids` doit dériver de `PoidsBrut + Emballage`,
   tu casses tous les appelants en passant en propriété.
3. **Aucun point d'observation** : impossible de logger une modification ou de
   notifier un changement.

La forme correcte :

```csharp
public class Colis
{
    private double _poids;

    public double Poids
    {
        get => _poids;
        set
        {
            if (value < 0) throw new ArgumentException(nameof(value));
            _poids = value;
        }
    }
}
```

L'API perçue est identique (`c.Poids = 60`) mais l'état est protégé.

## 3. `protected` : la porte dérobée pour les sous-classes

`protected` est conçu pour un cas précis : **un point d'extension
intentionnel** offert aux classes dérivées, **sans** l'ouvrir au reste du
monde.

```csharp
public abstract class Logement
{
    public string Adresse { get; }

    // Hook protégé : seules les sous-classes peuvent invoquer / redéfinir.
    protected virtual double TauxBase() => 12.0;

    public double LoyerMensuel() => Superficie * TauxBase();
    public double Superficie { get; }
    protected Logement(string adr, double sup) { Adresse = adr; Superficie = sup; }
}

public class Maison : Logement
{
    public Maison(string adr, double sup) : base(adr, sup) { }
    protected override double TauxBase() => 15.0;     // ✅ accès via héritage
}

// Ailleurs dans le code :
var m = new Maison("...", 100);
double t = m.TauxBase();           // ❌ inaccessible : protected
```

## 4. `internal` : l'API interne du projet

`internal` est le **secret le mieux gardé du C# débutant**. C'est le défaut des
types, et il dit : *« utilisable partout dans MA dll, invisible depuis
l'extérieur »*.

Cas typique :

```csharp
// Helper utilisé par plusieurs classes du projet, mais pas exposé aux clients.
internal static class GeocodageInterne
{
    internal static (double lat, double lng) Resoudre(string adresse) { ... }
}
```

Si tu publies cette dll sur NuGet, l'utilisateur n'a aucun moyen d'appeler
`GeocodageInterne.Resoudre`. Il est pourtant utilisable librement par toutes
tes autres classes du même assembly.

## 5. Heuristique de design

Pour chaque membre, pose-toi **dans cet ordre** :

1. Est-ce qu'**un seul** appelant l'utilise, dans la classe même ? → `private`.
2. Est-ce qu'**uniquement les sous-classes** doivent y accéder ? → `protected`.
3. Est-ce qu'**uniquement mon projet** doit l'utiliser ? → `internal`.
4. Est-ce documenté, stable, et destiné à des consommateurs externes ? → `public`.

> **Rappel** : un champ `public` est presque toujours une erreur de design.
> Préfère une **propriété** publique adossée à un champ privé.

## ✅ Vérifie ta compréhension

1. Peux-tu accéder à un membre `private` depuis une autre instance **de la même
   classe** ? (réponse contre-intuitive)
2. Quelle est la différence concrète entre `internal` et `public` quand on ne
   distribue pas la dll à l'extérieur ?
3. Pourquoi `protected` sans `virtual` est-il en général un signal de design
   bancal ?
4. Le défaut d'une **classe** est-il `private`, `internal` ou `public` ?

## 🔗 Pour aller plus loin

- [Cheatsheet POO — Modificateurs d'accès](../../01-theory/cheatsheets/oop.md)
- [Glossaire](../GLOSSARY.md)
