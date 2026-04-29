# 07 — POO : Classes, objets, propriétés

> 📚 [Examples](../../02-examples/07-oop-classes/README.md) · 🏋️ [Exercises](../../03-exercices/07-oop-classes/README.md)

## L1 — Intuition

Une **classe** est un **moule** ; un **objet** est une **pièce coulée** dans ce moule.
La classe regroupe :
- **données** (champs privés) — l'état interne, protégé du monde extérieur,
- **comportement** (méthodes) — ce que l'objet sait faire,
- **points d'accès contrôlés** (propriétés) — l'interface publique.

C'est l'**encapsulation** : le monde extérieur ne touche jamais directement aux champs.

## L2 — Squelette canonique

```csharp
public class Colis
{
    // 1. Champs privés — l'état interne.
    private string code;
    private string adresse;
    private double poids;
    private string statut;

    // 2. Constructeur complet — initialise tous les champs.
    public Colis(string code, string adresse, double poids, string statut)
    {
        this.code = code;               // this.code = champ ; code = paramètre.
        this.adresse = adresse;
        this.poids = poids;
        this.statut = statut;
    }

    // 3. Constructeur partiel — chaîne vers le complet via : this(...).
    public Colis(string code, string adresse, double poids)
        : this(code, adresse, poids, "Étiquette créée") { }

    // 4. Constructeur minimal — pour comparaisons / recherches.
    public Colis(string code) : this(code, "", 0, "") { }

    // 5. Propriétés — interface publique sur les champs.
    public string Code   { get { return code; } }                       // Lecture seule.
    public string Adresse { get => adresse; set => adresse = value; }   // Lecture-écriture (syntaxe expression-bodied).
    public double Poids
    {
        get => poids;
        set                                                              // Validation dans le setter.
        {
            if (value < 0) throw new ArgumentException("Poids négatif interdit");
            poids = value;
        }
    }
    public string Statut { get => statut; set => statut = value; }

    // 6. Propriété calculée (sans champ dédié).
    public double Cout
    {
        get
        {
            if (poids <= 50) return 15;
            return poids * 0.05;
        }
    }
}
```

### Mots-clés clés

| Mot-clé     | Sens                                                                |
| ----------- | ------------------------------------------------------------------- |
| `public`    | Accessible partout                                                  |
| `private`   | Accessible uniquement dans la classe (défaut pour champs)           |
| `protected` | Accessible dans la classe et ses dérivées                           |
| `internal`  | Accessible dans le même assembly                                    |
| `static`    | Appartient à la classe, pas à un objet                              |
| `readonly`  | Champ assignable seulement à la déclaration ou dans un constructeur |
| `this`      | Référence à l'objet courant                                         |

## L3 — Utilisation

```csharp
Colis c1 = new Colis("X42", "Montréal", 12.5, "Étiquette créée");
Colis c2 = new Colis("Y99", "Québec", 30);   // Constructeur partiel : statut = défaut.

c1.Statut = "En transit";                     // OK : Statut a un setter.
// c1.Code = "Z00";                           // ❌ Erreur de compilation : Code est lecture seule.

double frais = c1.Cout;                       // Propriété calculée.
```

### Champs `static` vs d'instance

```csharp
public class Compteur
{
    public static int Total = 0;              // Partagé par tous les objets.
    public int Local = 0;                     // Propre à chaque instance.

    public Compteur() { Total++; Local = Total; }
}
```

## L4 — Pièges

- ⚠️ Oublier `private` sur un champ → exposition involontaire. Utiliser propriété pour
  l'accès public.
- ⚠️ Dans un setter, écrire `Poids = value;` (la propriété) au lieu de `poids = value;`
  (le champ) → **récursion infinie** → `StackOverflowException`.
- ⚠️ Constructeur qui oublie d'initialiser un champ → valeur par défaut (`0`, `null`,
  `false`) — bug silencieux.
- ⚠️ Confondre **objet égal** (`Equals`, contenu) et **référence égale** (`==` par
  défaut sur les classes, qui compare les adresses).
- ⚠️ `new Colis(...)` toujours sur le **tas** ; les classes sont des types **référence**.
  Deux variables peuvent pointer vers le même objet (alias).

## 🔬 Approfondissement

### Champ vs propriété : pourquoi cette distinction est cruciale

Un **champ public** est une porte ouverte sur l'état interne. Tout code peut
écrire `colis.poids = -42` et l'objet se retrouve dans un état physiquement
absurde sans que tu le saches. Une **propriété** intercale un point de contrôle
entre le monde extérieur et la donnée :

```csharp
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
```

Trois bénéfices, gagnés sans changer l'API perçue (l'utilisateur écrit toujours
`colis.Poids = 60`) :

1. **Préservation des invariants** — un colis ne peut jamais avoir un poids
   négatif, par construction.
2. **Évolution sans casser les appelants** — si demain le poids dérive d'autres
   champs (poids brut + emballage), tu modifies `get` sans toucher au code
   appelant.
3. **Observabilité** — tu peux logger, déclencher un événement, marquer l'objet
   comme « modifié ». Impossible avec un champ.

C'est précisément ce qui est validé dans le critère « `colis.Poids = -5` lance
une exception » de l'[exercice 🟡 — Classe `Colis` complète](../../03-exercices/07-oop-classes/README.md#-application--classe-colis-complète).

### Constructeurs chaînés : `: this(...)` et le principe DRY

Quand une classe a plusieurs constructeurs, **dupliquer la logique
d'initialisation** est une bombe à retardement. Si demain tu ajoutes une
validation au champ `Code`, tu dois penser à la répéter dans **tous** les
constructeurs — et tu vas oublier l'un d'entre eux.

Le chaînage `: this(...)` impose qu'un seul constructeur fasse le **vrai
travail** ; les autres ne font que fournir des valeurs par défaut :

```csharp
public Colis(string code) : this(code, 0, 0, "EnAttente") { }
public Colis(string code, double poids) : this(code, poids, 0, "EnAttente") { }

// Le seul "vrai" constructeur — toute la validation est ici.
public Colis(string code, double poids, double valeur, string statut)
{
    if (string.IsNullOrWhiteSpace(code)) throw new ArgumentException(nameof(code));
    Code = code;
    Poids = poids;
    Valeur = valeur;
    Statut = statut;
}
```

Cette technique est exactement ce que demande l'exercice 🟡 ; elle prépare aussi
l'usage de `: base(...)` pour appeler le constructeur d'une classe parente,
introduit au [module 08](../08-oop-polymorphism/README.md).

### Propriété calculée vs méthode : où tracer la ligne ?

`Cout` peut s'écrire de deux façons sémantiquement équivalentes :

```csharp
public double Cout => Poids <= 50 ? 15 : Poids * 0.05;     // propriété calculée
public double Cout() => Poids <= 50 ? 15 : Poids * 0.05;   // méthode
```

Convention C# (et .NET en général) :

| Choisir une **propriété** si...                  | Choisir une **méthode** si...                                        |
| ------------------------------------------------ | -------------------------------------------------------------------- |
| Le calcul est **rapide** (< quelques opérations) | Le calcul est coûteux (boucle, E/S)                                  |
| L'appel n'a **aucun effet de bord**              | Il modifie l'état ou fait une E/S                                    |
| Deux appels successifs retournent la même valeur | Le résultat peut varier sans changement d'état (ex : `DateTime.Now`) |
| Sémantiquement, c'est un **attribut** de l'objet | Sémantiquement, c'est une **action**                                 |

`colis.Cout` se lit comme « le coût *du* colis ». `colis.Envoyer()` se lit comme
« envoie *le* colis ». La différence n'est pas technique, elle est **sémantique**.

### Encapsulation : pas un simple `private`

L'encapsulation, ce n'est **pas** « tout passer en `private` ». C'est une
**discipline de conception** qui répond à la question : *« quel ensemble
minimal de portes laisser ouvertes pour qu'une instance puisse remplir son
rôle ? »*.

Un objet bien encapsulé satisfait trois propriétés :

1. **Invariants protégés** — il est **impossible**, par construction, de placer
   l'objet dans un état incohérent (poids négatif, code vide, statut inconnu).
2. **Surface API minimale** — l'extérieur ne voit que ce dont il a besoin pour
   collaborer ; les détails d'implémentation restent libres d'évoluer.
3. **Responsabilité claire** — le code qui maintient les invariants vit
   **dans** la classe. Si l'invariant est violé, on sait où chercher.

C'est cette discipline qui transforme un programme C# en un système
maintenable sur des années plutôt qu'en une collection de structures de
données partagées.

## ✅ Vérifiez votre compréhension

1. Pourquoi exposer un champ via une **propriété** plutôt que le rendre `public` directement ?
2. Quel est le rôle de `: this(...)` dans un constructeur ?
3. Que vaut `c1 == c2` si `c1` et `c2` sont deux `Colis` avec exactement les mêmes
   champs ? (sans redéfinition de `Equals`)
4. Décris un cas où une **propriété calculée** est préférable à une méthode.

## 🔗 Pour aller plus loin

- Microsoft Learn — [Classes](https://learn.microsoft.com/dotnet/csharp/fundamentals/types/classes)
- TP du cours : [TP1.md](../../05-references/course-materials/UDEM_H26_IFT1179/assignements/TP1/TP1.md)
- [Préparation Intra — POO](../../05-references/course-materials/UDEM_H26_IFT1179/notes/Pr%C3%A9paration%20Intra.md)
