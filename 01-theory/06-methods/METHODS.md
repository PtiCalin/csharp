# 06 — Méthodes

> 📚 [Examples](../../02-examples/06-methods/README.md) · 🏋️ [Exercises](../../03-exercices/06-methods/README.md)

## L1 — Intuition

Une méthode est une **action nommée et réutilisable**. Elle reçoit des **paramètres**
(entrées), exécute un bloc, et **retourne** éventuellement une valeur. La signature
(nom + types des paramètres) est son **contrat**.

## L2 — Anatomie

```csharp
public  static  int  Compter(Colis[] tab, int nb, double seuil)
//      ▲       ▲    ▲       ▲                                 ▲
//   visibilité │  type   nom              paramètres          │
//              │  retour                                       │
//        statique = appartient à la classe, pas à un objet
{
    int compteur = 0;
    for (int i = 0; i < nb; i++)
        if (tab[i].Poids > seuil)
            compteur++;
    return compteur;                    // Doit fournir la valeur du type de retour.
}
```

### Choix du type de retour

| L'énoncé dit…                         | Type de retour              |
| ------------------------------------- | --------------------------- |
| « afficher / modifier » sans résultat | `void`                      |
| « combien »                           | `int`                       |
| « est-ce que / vérifier »             | `bool`                      |
| « trouver l'objet »                   | type de la classe (`Colis`) |
| « trouver la position »               | `int`, `-1` si absent       |

### Modes de passage

| Mode                | Appel      | Init avant appel | Pour quoi                                                |
| ------------------- | ---------- | ---------------- | -------------------------------------------------------- |
| **Valeur** (défaut) | `M(x)`     | Oui              | Le code reçoit une copie.                                |
| `ref`               | `M(ref x)` | **Oui**          | Modifier une variable existante chez l'appelant.         |
| `out`               | `M(out x)` | Non              | Méthode **doit** assigner la variable ; sortie multiple. |
| `in`                | `M(in x)`  | Oui              | Lecture seule, optimisation pour `struct` lourds.        |

```csharp
// Exemple ref : modification d'une variable existante.
public static void DoubleEnPlace(ref int n) => n *= 2;

int x = 5;
DoubleEnPlace(ref x);                   // ref obligatoire à l'APPEL aussi.
// x vaut maintenant 10.

// Exemple out : sortie produite par la méthode.
public static bool TenterDivision(int a, int b, out int q)
{
    if (b == 0) { q = 0; return false; }
    q = a / b;
    return true;
}
```

## L3 — Surcharge

Plusieurs méthodes de **même nom** mais **signatures différentes** (nombre/types de
paramètres). Le compilateur choisit selon les arguments.

```csharp
public static double Aire(double cote)              => cote * cote;
public static double Aire(double L, double l)       => L * l;
public static double Aire(Cercle c)                 => Math.PI * c.Rayon * c.Rayon;
```

⚠️ Le **type de retour seul ne suffit pas** à différencier deux surcharges.

## L4 — Pièges

- ⚠️ Oublier `ref` à **l'appel** alors qu'il est dans la signature → erreur de
  compilation `CS1620`.
- ⚠️ Utiliser `out` pour une donnée déjà valide chez l'appelant : préférer `ref`.
- ⚠️ Méthode `static` qui essaie d'accéder à un champ d'instance : `CS0120`.
- ⚠️ Dépasser **5-6 paramètres** = signal pour introduire un objet/struct paramètres.
- ⚠️ Renvoyer `null` au lieu de `-1` ou d'un objet sentinelle = obligation de tests
  partout. Documenter le contrat de retour.

## ✅ Vérifiez votre compréhension

1. Quelle est la **différence sémantique** entre `ref` et `out` ?
2. Pourquoi `static double Methode(int x)` et `static int Methode(int x)` ne sont **pas**
   une surcharge valide ?
3. Pour une fonction qui « retourne combien d'éléments correspondent au critère », quel
   type de retour choisirais-tu ? Et si elle devait aussi remplir un tableau passé en
   paramètre ?

## 🔗 Pour aller plus loin

- Microsoft Learn — [Methods](https://learn.microsoft.com/dotnet/csharp/methods)
- [Préparation Intra — Méthodes](../../05-references/course-materials/UDEM_H26_IFT1179/notes/Pr%C3%A9paration%20Intra.md)
