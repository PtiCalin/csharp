# Classe, méthode, fonction, procédure, trigger : démêler le vocabulaire

> 📘 Concept transversal — utile dès le module [06 — Méthodes](../06-methods/README.md) et [07 — POO Classes](../07-oop-classes/README.md).

L1, en une phrase :

> **En C# : tout vit dans une *classe*. Les unités d'action s'appellent toutes des
> *méthodes* — peu importe qu'on les appelle « fonctions », « procédures » ou
> « handlers » dans d'autres langages.**

C'est la première chose à intérioriser. Les sections qui suivent dépaquettent
pourquoi cette phrase cache plusieurs nuances importantes.

---

## 🗺️ Carte des termes

| Terme            | Mot-clé C# ?                            | Définition courte                                            | Exemple typique                     |
| ---------------- | --------------------------------------- | ------------------------------------------------------------ | ----------------------------------- |
| **Classe**       | ✅ `class`                               | Plan décrivant un type de référence (état + comportement)    | `class Colis { ... }`               |
| **Méthode**      | ❌ (pas un mot-clé, c'est une catégorie) | Bloc d'action **défini dans une classe**                     | `public void Afficher() { ... }`    |
| **Fonction**     | ❌                                       | Synonyme **informel** de « méthode qui retourne une valeur » | `int Carre(int n) => n * n;`        |
| **Procédure**    | ❌                                       | Synonyme **informel** de « méthode `void` »                  | `void Loguer(string m) { ... }`     |
| **Trigger**      | ❌ (terme SQL)                           | En C# : équivalent conceptuel = **événement**                | `button.Click += OnClick;`          |
| **Événement**    | ✅ `event`                               | Notification déclenchée vers des abonnés                     | `event EventHandler Click;`         |
| **Délégué**      | ✅ `delegate`                            | *Type* d'une référence vers méthode                          | `Action`, `Func<T, R>`              |
| **Constructeur** | ❌ (méthode spéciale)                    | Méthode appelée par `new` pour initialiser                   | `public Colis(string code) { ... }` |
| **Propriété**    | ❌ (syntaxe particulière)                | Couple `get`/`set` qui ressemble à un champ                  | `public int Poids { get; set; }`    |

> ⚠️ Beaucoup de confusion vient du fait que les mots **fonction** et **procédure**
> ne sont **pas des mots-clés C#**. Ils sont hérités de Pascal, VB6, Fortran, et du
> SQL/PL-SQL. En C#, **tout** est une *méthode* ; on précise éventuellement « qui
> retourne quelque chose » ou « `void` ».

---

## 1. Classe vs méthode : conteneur vs action

### L1 — intuition

Une **classe** est un **plan d'usine**. Une **méthode** est un **bouton de la machine
fabriquée**.

- La classe `Voiture` décrit ce qu'est *toute* voiture.
- L'instance `mavoiture = new Voiture("Honda Civic")` est *une* voiture.
- La méthode `mavoiture.Klaxonner()` est une *action* qu'on demande à cette voiture.

### L2 — formulation précise

Une **classe** est :

- une **déclaration de type** (référence) ;
- contenant des **membres** : champs, propriétés, méthodes, constructeurs, événements ;
- pouvant être **instanciée** avec `new` (sauf si `abstract` ou `static`).

Une **méthode** est :

- un **bloc nommé de code paramétrable** ;
- déclaré **à l'intérieur** d'un type (classe, struct, interface, record) ;
- avec une signature `nom(paramètres)` et un type de retour (ou `void`) ;
- invocable depuis ailleurs via `obj.Methode(...)` (instance) ou `Type.Methode(...)` (statique).

### L3 — exemple commenté

```csharp
public class Colis                                  // ← CLASSE : le plan
{
    public string Code { get; }                     // ← PROPRIÉTÉ (membre)
    public double Poids { get; private set; }       // ← PROPRIÉTÉ avec setter restreint

    public Colis(string code, double poids)         // ← CONSTRUCTEUR (méthode spéciale)
    {
        Code = code;
        Poids = poids;
    }

    public double Cout()                            // ← MÉTHODE retournant un double
    {                                                //    (informellement : « fonction »)
        return Poids <= 50 ? 15 : Poids * 0.05;
    }

    public void Afficher()                          // ← MÉTHODE void
    {                                                //    (informellement : « procédure »)
        Console.WriteLine($"{Code} : {Cout():C2}");
    }
}
```

Trois invocations distinctes :

```csharp
Colis c = new Colis("X42", 60);     // appel du CONSTRUCTEUR via new
double prix = c.Cout();              // appel d'une méthode-fonction (retourne)
c.Afficher();                        // appel d'une méthode-procédure (effet de bord)
```

### L4 — ce qu'il faut éviter de confondre

| Erreur fréquente                                         | Réalité                                                                                             |
| -------------------------------------------------------- | --------------------------------------------------------------------------------------------------- |
| « `Cout` est une fonction, `Afficher` est une méthode. » | Non. Les **deux sont des méthodes**. La différence est que l'une retourne `double`, l'autre `void`. |
| « Une classe est une grosse fonction. »                  | Non. Une classe **n'exécute rien** par elle-même. Elle décrit un type.                              |
| « `new Colis(...)` appelle la classe. »                  | Imprécis. `new` **alloue une instance** puis appelle le **constructeur**, qui est une méthode.      |
| « `static` rend une classe en méthode. »                 | Non. `static` retire la notion d'instance ; la méthode reste une méthode.                           |

---

## 2. Fonction vs procédure : un héritage Pascal

### Origine

Pascal, VB6, Fortran, Ada distinguaient :

- **`function`** : retourne une valeur, *peut* être utilisée dans une expression.
- **`procedure`** : ne retourne rien, exécute uniquement des effets de bord.

C# (comme Java, C++, Python) **a aboli cette distinction syntaxique**. Le langage
n'a qu'une seule construction : la **méthode**. C'est le **type de retour** qui
détermine la « variété ».

### Tableau de correspondance

| Concept Pascal/VB6                    | Équivalent C#       | Forme                     |
| ------------------------------------- | ------------------- | ------------------------- |
| `function Carre(n: integer): integer` | méthode avec retour | `int Carre(int n)`        |
| `procedure Saluer(nom: string)`       | méthode `void`      | `void Saluer(string nom)` |
| `function ... : void` (n'existe pas)  | méthode `void`      | idem                      |

### Pourquoi conserver le vocabulaire ?

Parce qu'**il décrit l'intention** :

- une « fonction » = **calcule** quelque chose, *idéalement* sans effet de bord
  → on l'attend **pure**, **prévisible**, **testable** facilement ;
- une « procédure » = **fait** quelque chose, *forcément* avec effet de bord
  (E/S, modification d'état, log) → on l'attend **impérative**.

### Heuristique de design

> Si une méthode **modifie l'état du monde** (E/S, mutation, exception métier),
> qu'elle soit `void` quand c'est cohérent. Si une méthode **calcule un résultat
> à partir de ses entrées**, qu'elle retourne ce résultat et n'ait pas d'effet
> de bord.

C'est la base de la **séparation commande/requête** (CQS), et c'est ce qui rend un
code C# lisible.

### Exemple commenté

```csharp
// 🔵 « Fonction » au sens Pascal : pure, sans effet de bord, testable.
public static double TauxTaxes(double sousTotal, double taux) =>
    sousTotal * taux;

// 🔴 « Procédure » au sens Pascal : effet de bord (écriture console).
public static void AfficherFacture(Facture f)
{
    Console.WriteLine($"Total : {f.Total:C2}");
}

// ⚠️ Hybride à éviter : modifie ET retourne. Difficile à raisonner.
public static double AjouterEtCalculer(List<Article> liste, Article a)
{
    liste.Add(a);                          // effet de bord
    return liste.Sum(x => x.Prix);          // calcul
}
```

---

## 3. Méthode statique vs méthode d'instance

### L1

- **Méthode d'instance** : appartient à *un objet* précis. Accède à `this` et aux champs.
- **Méthode statique** : appartient *à la classe*. Pas de `this`. Pas d'état d'instance.

### L2 — règle d'invocation

```csharp
public class Math2
{
    public static double Pi => 3.14159;             // membre statique

    public static double AireCercle(double r) =>    // méthode statique
        Pi * r * r;
}

public class Compteur
{
    private int valeur;
    public void Incrementer() => valeur++;          // méthode d'instance
}

double a = Math2.AireCercle(5);                     // via la CLASSE
var c = new Compteur(); c.Incrementer();            // via une INSTANCE
```

### L4 — quand choisir quoi ?

| Choisir `static` si...                     | Choisir d'instance si...                       |
| ------------------------------------------ | ---------------------------------------------- |
| la méthode ne dépend que de ses paramètres | elle dépend de l'état d'un objet               |
| utilitaire (`Math.Sqrt`, `string.Format`)  | comportement métier (`colis.Cout()`)           |
| pas de polymorphisme nécessaire            | tu veux pouvoir redéfinir dans une sous-classe |

> ⚠️ Une méthode `static` ne peut pas être `virtual` ni `override` (en C# < 11).
> Le polymorphisme repose sur l'instance.

---

## 4. Triggers en C# : c'est quoi vraiment ?

Le mot **trigger** vient du monde **SQL** :

- **Trigger SQL** = procédure stockée exécutée automatiquement sur un événement de
  table (INSERT/UPDATE/DELETE).

C# **n'a pas de mot-clé `trigger`**. Le concept équivalent est l'**événement**
combiné à un **gestionnaire d'événement** (handler).

### Tableau de mapping

| Monde SQL                                  | Monde C#                                                |
| ------------------------------------------ | ------------------------------------------------------- |
| `CREATE TRIGGER ... ON Table AFTER INSERT` | `event EventHandler Inserted;` + `Inserted += handler;` |
| Corps du trigger                           | Méthode handler (`void OnInserted(...)`)                |
| « Le trigger se déclenche »                | « L'événement est levé » (`Inserted?.Invoke(...)`)      |
| Plusieurs triggers possibles               | Plusieurs handlers abonnés au même événement            |

### L3 — événement WinForms

```csharp
public partial class FormTp1 : Form
{
    public FormTp1()
    {
        InitializeComponent();

        // 🔔 Abonnement : « quand le bouton est cliqué, appelle BtnCalculer_Click »
        btnCalculer.Click += BtnCalculer_Click;
    }

    // 🎯 Handler : c'est une MÉTHODE classique, dont la signature respecte le contrat
    //    de l'événement Click (EventHandler).
    private void BtnCalculer_Click(object sender, EventArgs e)
    {
        // ... action déclenchée par le « trigger » utilisateur (clic)
    }
}
```

### L4 — différences clés à retenir

| Aspect        | Trigger SQL                 | Événement C#                                                                   |
| ------------- | --------------------------- | ------------------------------------------------------------------------------ |
| Déclenchement | Le SGBD, automatiquement    | Du code applicatif, explicitement (`Invoke`) ou par le framework (clic, timer) |
| Abonnement    | Définition unique au schéma | `+=` à n'importe quel moment, plusieurs abonnés                                |
| Désabonnement | `DROP TRIGGER`              | `-=` à tout moment                                                             |
| Persistance   | Stocké dans la base         | Vit en mémoire avec l'objet                                                    |

> ✅ Si quelqu'un te dit en C# « il faut un trigger sur ce bouton », il veut dire :
> *abonne un gestionnaire à l'événement `Click`*. Le mot est métaphorique.

---

## 5. Diagramme de dépendances

```
                ┌────────────────────┐
                │      CLASSE        │  (déclare un type)
                │  ─────────────     │
                │  • champs          │  ← état
                │  • propriétés      │  ← état exposé
                │  • CONSTRUCTEUR    │  ← initialise
                │  • MÉTHODES        │  ← comportement
                │  • ÉVÉNEMENTS      │  ← notification
                └─────────┬──────────┘
                          │ instanciée par new
                          ▼
                ┌────────────────────┐
                │      OBJET         │
                │   (instance)       │
                └─────────┬──────────┘
                          │
            ┌─────────────┼──────────────┐
            ▼             ▼              ▼
      [méthodes      [propriétés    [événements
       d'instance]    get/set]       += handler]

      Méthodes statiques : appartiennent à la classe, pas à l'objet.
```

---

## ✅ Vérifie ta compréhension

1. Quelle est la **différence formelle** entre une « fonction » et une « procédure »
   en C# ? (Indice : il n'y en a pas au niveau du langage.)
2. Pourquoi `new Colis(...)` n'est-il **pas** un appel direct à la classe ?
3. Tu vois `obj.Methode()`. Comment savoir si `Methode` est statique ou d'instance
   sans regarder sa déclaration ? (Indice : si l'appel via une *instance* compile,
   c'est ambigu — vérifier dans la signature.)
4. Quelle est la différence entre **lever** un événement (`Invoke`) et **s'y
   abonner** (`+=`) ? Qui fait quoi dans `btnCalculer.Click += BtnCalculer_Click;` ?
5. Donne **un cas** où tu écrirais une méthode `static` et **un cas** où tu
   écrirais la même chose en méthode d'instance. Justifie.

---

## 🔗 Pour aller plus loin

- [Glossaire](../GLOSSARY.md) — définitions formelles des termes individuels
- [06 — Méthodes](../06-methods/README.md) — signature, surcharge, `ref`/`out`
- [07 — POO Classes](../07-oop-classes/README.md) — champ, propriété, encapsulation
- [12 — WinForms](../12-winforms/README.md) — événements en pratique
- [Cheatsheet OOP](../cheatsheets/oop.md) — rappel syntaxique
