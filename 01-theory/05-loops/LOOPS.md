# 05 — Boucles

> Théorie · [Examples](../../02-examples/05-loops/README.md) · [Exercises](../../03-exercices/05-loops/README.md)

## L1 — Intuition

Une boucle est une **playlist en répétition**. `for` connaît à l'avance le nombre de
chansons ; `while` joue tant qu'on ne lui dit pas stop ; `do-while` joue **au moins
une fois** avant de vérifier.

## L2 — Définition formelle

### Arbre de décision

```
1. Nombre d'itérations connu ?            → for
2. Inconnu, dépend d'une condition ?      → while
3. Au moins une exécution garantie ?      → do-while
4. Parcours de collection sans indice ?   → foreach
```

### `for` — iteration indexée

```csharp
for (int i = 0; i < n; i++)
{
    // i = 0, 1, ..., n-1
}
```

Trois parties : **initialisation** ; **condition** (testée avant chaque itération) ;
**incrément** (exécuté après chaque itération).

### `while` — pré-test

```csharp
while (condition)
{
    // exécuté 0 fois ou plus
}
```

### `do-while` — post-test

```csharp
do
{
    // exécuté 1 fois ou plus
}
while (condition);
```

### `foreach` — parcours

```csharp
foreach (var element in collection)
{
    // accès en lecture, sans indice
}
```

### Mots-clés de contrôle

| Mot-clé    | Effet                                  |
| ---------- | -------------------------------------- |
| `break`    | Sort de la boucle immédiatement        |
| `continue` | Passe à l'itération suivante           |
| `return`   | Sort de la méthode (donc de la boucle) |

## L3 — Exemple commenté

```csharp
// Recherche séquentielle sur tableau partiellement rempli.
// nbColis = nombre réel d'éléments (≤ taille du tableau).
public static int IndiceDe(Colis[] tab, int nbColis, string code)
{
    for (int i = 0; i < nbColis; i++)   // Parcours indexé jusqu'à la dernière case utile.
    {
        if (tab[i].Code == code)        // Test d'égalité sur la clé.
            return i;                   // Retour immédiat : plus efficace qu'un break + variable.
    }
    return -1;                          // Convention : -1 = non trouvé.
}

// Lecture d'un fichier : on ignore le nombre total de lignes.
using var lecteur = new StreamReader("colis.txt");
while (!lecteur.EndOfStream)
{
    string ligne = lecteur.ReadLine();
    Console.WriteLine(ligne);
}

// Saisie utilisateur : on doit demander au moins une fois.
int choix;
do
{
    Console.Write("Entrez 1, 2 ou 3 : ");
    int.TryParse(Console.ReadLine(), out choix);
}
while (choix < 1 || choix > 3);
```

## L4 — Cas limites & pièges

- ⚠️ **`tab.Length` vs `nbElements`** : sur un tableau partiellement rempli, boucler
  jusqu'à `tab.Length` lit des cases `null` ou par défaut (cf. notes IFT1179).
- ⚠️ **Boucle infinie** : oublier l'incrément (`while (i < n) { ... }` sans `i++`)
  ou condition jamais fausse.
- ⚠️ **Modification pendant `foreach`** : ajouter/supprimer dans la collection lance
  `InvalidOperationException`. Préférer `for` à rebours pour la suppression.
- ⚠️ **`do-while` mal utilisé** : si la condition initiale peut déjà être fausse,
  utiliser `while`.
- ⚠️ **Dépassement d'indice** : dernier indice valide = `nbElements - 1`. Le piège
  classique de l'examen.

## ✅ Vérifiez votre compréhension

1. Quelle boucle choisir pour valider une saisie utilisateur (au moins une demande,
   répéter tant qu'invalide) ? Justifier.
2. Pourquoi `for (int i = nb-1; i >= 0; i--)` est-il préférable à `for (int i = 0;
   ...)` lorsqu'on supprime des éléments ?
3. Dans le fichier de colis, pourquoi `while (!lecteur.EndOfStream)` plutôt que
   `for (int i = 0; i < ?; i++)` ?

## 🔗 Voir aussi

- [Examples → 05-loops](../../02-examples/05-loops/README.md)
- [Exercises → 05-loops](../../03-exercices/05-loops/README.md)
- Théorie suivante : [06 — Méthodes](../06-methods/README.md)
