# `interface` vs `abstract class` : contrat ou squelette ?

> 📘 Concept transversal — module [08 — Polymorphisme](../../01-theory/08-oop-polymorphism/README.md).

L1, en une phrase :

> **Interface** = pur **contrat**, sans état. *« Voici ce que tu dois savoir
> faire. »*  **Classe abstraite** = **squelette partiellement implémenté**,
> avec état partagé. *« Voici ce que tu hérites, voici ce qu'il te reste à
> remplir. »*

---

## 🗺️ Comparaison directe

| Aspect                                    | `interface`                           | `abstract class`                                                                   |
| ----------------------------------------- | ------------------------------------- | ---------------------------------------------------------------------------------- |
| Instanciable ?                            | ❌                                     | ❌                                                                                  |
| Peut contenir des champs                  | ❌                                     | ✅                                                                                  |
| Peut contenir des constructeurs           | ❌                                     | ✅ (appelés via `: base(...)`)                                                      |
| Peut implémenter / hériter                | hérite de `interface`                 | hérite **d'une seule** `class` (abstract ou non), implémente plusieurs `interface` |
| Une classe peut-elle en avoir plusieurs ? | ✅ plusieurs interfaces                | ❌ une seule classe parent                                                          |
| Modificateurs des membres                 | `public` implicite                    | tous (`public`, `protected`, `private`…)                                           |
| Implémentation par défaut                 | ✅ depuis C# 8 (mais limité)           | ✅                                                                                  |
| Représente sémantiquement                 | une **capacité** (« est capable de ») | une **identité** (« est un »)                                                      |

## 1. Interface : décrire un contrat

```csharp
public interface IExpedible
{
    string Code { get; }
    void Expedier(DateTime date);
}

public class Colis : IExpedible
{
    public string Code { get; }
    public DateTime? DateExpedition { get; private set; }

    public Colis(string code) => Code = code;

    public void Expedier(DateTime date) => DateExpedition = date;
}

public class Lettre : IExpedible
{
    public string Code { get; }
    public void Expedier(DateTime date) { /* ... */ }
}

// Bénéfice : on traite Colis et Lettre uniformément, sans héritage commun.
void TraiterEnvoi(IExpedible e, DateTime d) => e.Expedier(d);
```

Une interface ne dit **rien** sur l'état, l'implémentation, ou la hiérarchie.
Elle **expose des capacités**. Une classe peut en implémenter plusieurs :

```csharp
public class Colis : IExpedible, IComparable<Colis>, IEquatable<Colis>
{
    // ... une signature à honorer pour chaque interface
}
```

> 🎯 **Convention** : nom préfixé par `I` (`IComparable`, `IDisposable`).

## 2. Classe abstraite : factoriser du code commun

```csharp
public abstract class Logement
{
    public string Adresse { get; }
    public double Superficie { get; }

    protected Logement(string adr, double sup)      // état initialisé une seule fois
    {
        Adresse = adr;
        Superficie = sup;
    }

    public abstract double LoyerMensuel();          // ← contrat à remplir

    public virtual string Description() =>          // ← implémentation par défaut
        $"{GetType().Name} à {Adresse}";

    protected double TauxParMetreCarre() =>          // ← helper partagé
        Superficie > 100 ? 12.0 : 15.0;
}

public class Maison : Logement
{
    public int Chambres { get; }
    public Maison(string adr, double sup, int ch) : base(adr, sup) => Chambres = ch;

    public override double LoyerMensuel() =>
        Superficie * TauxParMetreCarre() + Chambres * 150;
}
```

Tu obtiens **trois choses qu'une interface ne peut pas offrir** :
1. **État partagé** (`Adresse`, `Superficie`).
2. **Initialisation centralisée** (`base(...)`).
3. **Helpers protégés** (`TauxParMetreCarre`) que toutes les sous-classes
   peuvent appeler sans les redéfinir.

## 3. La règle de décision

```
Réponds à : « est-ce une CAPACITÉ ou une IDENTITÉ ? »

  ┌─ CAPACITÉ ─────────────┐         ┌─ IDENTITÉ ─────────────┐
  │ « x est capable de... » │         │ « x EST UN... »          │
  │ ex : IDisposable        │         │ ex : Animal, Logement     │
  │     IComparable          │         │     Forme                  │
  └─ → interface ──────────┘         └─ → abstract class ─────┘

  Tu hésites ?
  ⤷ Réfléchis aux **sous-types** :
     - tous partagent du **code commun** ?       → abstract class
     - chaque sous-type a une logique distincte ? → interface
  ⤷ Réfléchis à l'**héritage multiple** :
     - tu auras besoin de plusieurs « parents » ? → forcément interfaces
     - une seule famille suffit ?                 → abstract class possible
```

## 4. Combiner les deux : la stratégie pragmatique

C'est la combinaison qui domine en .NET moderne :

```csharp
// 1. Le contrat public.
public interface IRepository<T>
{
    T? Trouver(int id);
    void Sauvegarder(T entite);
}

// 2. Une base abstraite qui factorise le code commun.
public abstract class RepositoryBase<T> : IRepository<T>
{
    protected readonly string fichier;
    protected RepositoryBase(string f) => fichier = f;

    public abstract T? Trouver(int id);
    public abstract void Sauvegarder(T entite);

    protected string Lire() => File.ReadAllText(fichier);
}

// 3. Implémentations concrètes.
public class ColisRepository : RepositoryBase<Colis> { ... }
public class LogementRepository : RepositoryBase<Logement> { ... }
```

Les **consommateurs** dépendent de `IRepository<T>` (testable, mockable). Les
**implémenteurs** dérivent de `RepositoryBase<T>` (gain de code partagé).

## 5. Pièges à éviter

| Erreur                                                                                                    | Pourquoi c'est un problème                                                                                                                              |
| --------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Mettre des champs publics dans une interface (impossible avant C# 8 ; possible mais à éviter aujourd'hui) | Casse l'idée de contrat sans état                                                                                                                       |
| Faire une classe abstraite **sans** méthode `abstract`                                                    | Une `class` non-abstract suffirait                                                                                                                      |
| Faire une interface avec **trop** de membres (`fat interface`)                                            | Force les implémenteurs à coder des méthodes qu'ils n'utilisent pas. **ISP** (*Interface Segregation Principle*) : préfère plusieurs petites interfaces |
| Utiliser une classe abstraite **uniquement** pour partager 2-3 lignes de code                             | Mieux vaut une méthode statique d'extension ou une composition                                                                                          |

## 6. Tableau récapitulatif

| Tu veux…                                           | Choisis                                           |
| -------------------------------------------------- | ------------------------------------------------- |
| Définir une **capacité** transversale              | `interface`                                       |
| Permettre l'héritage **multiple**                  | `interface`                                       |
| Découpler conception et implémentation (DI, mocks) | `interface`                                       |
| Factoriser du **code** entre sous-classes          | `abstract class`                                  |
| Imposer un **état** initialisé via constructeur    | `abstract class`                                  |
| Décrire une **identité** ou une famille de types   | `abstract class`                                  |
| Mélanger les deux (pattern courant)                | **interface** + `abstract class` qui l'implémente |

## ✅ Vérifie ta compréhension

1. Pourquoi `IDisposable` est-il une interface plutôt qu'une classe abstraite ?
2. Quelle limitation t'oblige à passer par une interface plutôt qu'une classe
   abstraite quand tu veux qu'une classe hérite à la fois de `Forme` et de
   `IComparable<T>` ?
3. Une classe abstraite peut-elle avoir un constructeur `public` ? Si oui, qui
   peut l'appeler ?
4. Implémentation par défaut d'interface (C# 8+) : pourquoi est-ce
   controversé ? (Indice : ça brouille la frontière contrat/héritage.)

## 🔗 Pour aller plus loin

- [Cheatsheet POO — Héritage et abstraction](../../01-theory/cheatsheets/oop.md)
- [Théorie 08 — Polymorphisme](../../01-theory/08-oop-polymorphism/README.md)
- Microsoft : [When to use interfaces or abstract classes](https://learn.microsoft.com/dotnet/standard/design-guidelines/choosing-between-class-and-interface)
