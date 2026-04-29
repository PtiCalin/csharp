# `static` vs instance : qui possède le membre ?

> 📘 Concept transversal — utile au module [06 — Méthodes](../../01-theory/06-methods/README.md) et [07 — Classes](../../01-theory/07-oop-classes/README.md).

L1, en une phrase :

> **Membre `static` → appartient à la *classe*. Membre d'instance → appartient
> à *un objet* précis.** Le mot-clé `static` retire la notion d'instance et
> donc l'accès à `this`.

---

## 🗺️ Comparaison directe

| Aspect                               | `static`                        | Instance             |
| ------------------------------------ | ------------------------------- | -------------------- |
| Appartient à                         | la classe                       | un objet             |
| `this` accessible ?                  | ❌                               | ✅                    |
| Polymorphisme (`virtual`/`override`) | ❌                               | ✅                    |
| Appel                                | `Classe.Membre(...)`            | `obj.Membre(...)`    |
| Copie en mémoire                     | **une seule** pour le programme | **une par instance** |
| Initialisation                       | au premier accès au type        | à chaque `new`       |
| Sérialisation                        | ignoré par défaut               | inclus               |

## 1. Démonstration

```csharp
public class Compteur
{
    public static int Total = 0;        // partagé entre toutes les instances
    public int Numero { get; }          // propre à chaque instance

    public Compteur()
    {
        Total++;                         // toutes les instances incrémentent LE MÊME compteur
        Numero = Total;
    }
}

var a = new Compteur();   // Total = 1, a.Numero = 1
var b = new Compteur();   // Total = 2, b.Numero = 2
var c = new Compteur();   // Total = 3, c.Numero = 3

Console.WriteLine(Compteur.Total);   // 3   ← via la CLASSE
Console.WriteLine(a.Numero);          // 1   ← via une INSTANCE
// Console.WriteLine(a.Total);        ❌ ne compile pas : Total est static
```

C'est exactement le squelette demandé par l'[exercice 🔴 du module 07](../../03-exercices/07-oop-classes/README.md#-défi--compteur-statique-dinstances).

## 2. Méthode statique : utilitaire pur

Une méthode `static` ne dépend que de ses **paramètres**. Elle n'a accès à
aucun champ d'instance, et c'est cela qui la rend prévisible et testable.

```csharp
public static class Math2
{
    public const double Pi = 3.14159265359;
    public static double AireCercle(double r) => Pi * r * r;
    public static double Min(double a, double b) => a < b ? a : b;
}

// Aucune instance à créer. Aucun état à gérer.
double aire = Math2.AireCercle(5);
```

Les méthodes utilitaires comme `Math.Sqrt`, `string.Format`, `int.Parse` sont
toutes statiques pour cette raison.

## 3. Quand choisir quoi : règle de décision

Pose-toi **une seule question** : *« cette logique a-t-elle besoin de l'état
d'un objet précis pour fonctionner ? »*

| Si oui                                             | Méthode d'instance |
| -------------------------------------------------- | ------------------ |
| `colis.Cout()` — dépend du `Poids` du **ce** colis | ✅ instance         |
| `compte.Deposer(50)` — modifie **ce** compte       | ✅ instance         |

| Si non                                                              | Méthode statique |
| ------------------------------------------------------------------- | ---------------- |
| `Math.Max(a, b)` — pure combinaison de paramètres                   | ✅ static         |
| `Colis.LireFichier("colis.txt")` — fabrique sans instance préalable | ✅ static         |

> ⚠️ **Erreur fréquente** : transformer en `static` une méthode qui modifie
> implicitement un état partagé via des champs `static`. Tu obtiens des
> dépendances cachées et un code intestable. Si tu as besoin d'état partagé,
> il vaut presque toujours mieux passer cet état en paramètre.

## 4. Classe `static` : container pur

Une classe `static` ne peut **pas** être instanciée et ne peut contenir **que**
des membres `static`. Le compilateur garantit la cohérence.

```csharp
public static class FormatageMonnaie
{
    public static string Formater(decimal montant) =>
        montant.ToString("C2", CultureInfo.GetCultureInfo("fr-CA"));
}

// FormatageMonnaie.Formater(42.5m)        ✅
// new FormatageMonnaie()                  ❌ ne compile pas
```

Conviens-en pour des **utilitaires sans état**. Évite-la pour de la logique
métier (tu sacrifies polymorphisme, mocking, et extensibilité).

## 5. Constructeur statique

Un cas particulier : `static Compteur()` initialise les champs `static` au
premier accès au type. Une seule fois par exécution du programme.

```csharp
public class Configuration
{
    public static readonly DateTime DateDemarrage;

    static Configuration()                // appelé automatiquement, une seule fois
    {
        DateDemarrage = DateTime.UtcNow;
    }
}
```

Tu ne l'appelles **jamais** explicitement. Utile pour de la configuration
immuable initialisée tardivement.

## 6. Limites du `static`

| Tu **ne peux pas**…                                           | …parce que                                                    |
| ------------------------------------------------------------- | ------------------------------------------------------------- |
| Appeler une méthode d'instance depuis une `static` sans `new` | Pas de `this`                                                 |
| Marquer une `static` `virtual` ou `override` (en C# < 11)     | Polymorphisme = mécanisme d'instance                          |
| Hériter d'une classe `static`                                 | Contradiction : héritage = instances                          |
| Implémenter une interface en C# < 11                          | Idem (corrigé en partie en C# 11+ avec les *static abstract*) |

## ✅ Vérifie ta compréhension

1. Pourquoi `Math.Sqrt` est-elle statique alors que `string.Length` est
   d'instance ? Quelle question te poses-tu pour décider ?
2. Tu vois `obj.Methode()`. Comment savoir, sans IDE, si `Methode` est statique
   ou d'instance ? (réponse : tu **ne peux pas** ; en C# moderne, l'appel via
   instance d'une méthode statique génère même un avertissement.)
3. Que se passe-t-il en mémoire pour `Compteur.Total++` invoqué par 1000
   instances simultanément ? (indice : un seul emplacement, problème potentiel.)
4. Pourquoi est-il dangereux d'avoir un champ `static` mutable dans une
   application multi-thread ?

## 🔗 Pour aller plus loin

- [Cheatsheet POO — `static` vs instance](../../01-theory/cheatsheets/oop.md)
- [Concept — Classe / méthode / fonction / procédure / trigger](class-method-function-procedure.md)
