# 10 — Recherche & tri

> 📚 [Examples](../../02-examples/10-search-and-sort/README.md) · 🏋️ [Exercises](../../03-exercices/10-search-and-sort/README.md)

## L1 — Intuition

Deux familles d'opérations omniprésentes sur les tableaux :

- **Rechercher** un élément : séquentielle (toujours) ou dichotomique (tableau trié).
- **Trier** un tableau : sélection (simple), quicksort (rapide).

Le choix de l'algorithme dépend de **propriétés du tableau** (trié ?) et de **contraintes
de performance** (taille, fréquence d'appel).

## L2 — Recherche dichotomique (binary search)

**Préalable absolu : tableau trié.** À chaque étape, on coupe l'intervalle de recherche
en deux.

```csharp
public static int Dicho(int[] tab, int n, int cible)
{
    int gauche = 0;
    int droite = n - 1;

    while (gauche <= droite)
    {
        int milieu = (gauche + droite) / 2;
        if (tab[milieu] == cible) return milieu;
        if (tab[milieu] < cible)  gauche = milieu + 1;
        else                       droite = milieu - 1;
    }
    return -1;
}
```

| Algorithme   | Complexité | Préalable |
| ------------ | ---------- | --------- |
| Séquentielle | O(n)       | aucun     |
| Dichotomique | O(log n)   | **trié**  |

## L3 — Tri par sélection

À chaque tour, trouver le plus petit du sous-tableau restant et le mettre en tête.

```csharp
public static void TriSelection(int[] tab, int n)
{
    for (int i = 0; i < n - 1; i++)
    {
        int idxMin = i;
        for (int j = i + 1; j < n; j++)
            if (tab[j] < tab[idxMin])
                idxMin = j;

        // Permutation tab[i] ↔ tab[idxMin].
        int tmp = tab[i];
        tab[i] = tab[idxMin];
        tab[idxMin] = tmp;
    }
}
```

Complexité : **O(n²)**. Simple à coder, lent sur grands tableaux.

### Tri rapide (quicksort)

```csharp
public static void QuickSort(int[] tab, int debut, int fin)
{
    if (debut >= fin) return;                       // Cas d'arrêt.

    int pivot = Partition(tab, debut, fin);
    QuickSort(tab, debut, pivot - 1);               // Partie gauche.
    QuickSort(tab, pivot + 1, fin);                 // Partie droite.
}

private static int Partition(int[] tab, int debut, int fin)
{
    int pivot = tab[fin];                           // Pivot = dernier élément.
    int i = debut - 1;
    for (int j = debut; j < fin; j++)
    {
        if (tab[j] <= pivot)
        {
            i++;
            (tab[i], tab[j]) = (tab[j], tab[i]);    // Swap (C# 7+).
        }
    }
    (tab[i + 1], tab[fin]) = (tab[fin], tab[i + 1]);
    return i + 1;
}
```

Complexité moyenne **O(n log n)**, pire cas O(n²) si tableau déjà trié + pivot mal choisi.

### Synchroniser deux tableaux

Si `nomColis[i]` correspond à `poidsColis[i]`, **toute permutation** doit s'appliquer
aux deux tableaux simultanément. Sinon les paires se désynchronisent.

## L4 — Pièges

- ⚠️ Lancer une dichotomique sur un tableau **non trié** → retourne au hasard ou `-1`
  faussement.
- ⚠️ Quicksort sans **cas d'arrêt** clair → `StackOverflowException`.
- ⚠️ Trier le tableau « pilote » sans synchroniser les tableaux liés.
- ⚠️ `(gauche + droite) / 2` peut **déborder** sur de gros `int`. Préférer
  `gauche + (droite - gauche) / 2`.
- ⚠️ Dans l'API standard, préférer `Array.Sort` et `Array.BinarySearch` sauf en contexte
  pédagogique.

## ✅ Vérifiez votre compréhension

1. Pourquoi la dichotomique exige-t-elle un tableau **trié** ? Que se passe-t-il si on
   triche ?
2. Combien de comparaisons **au pire** pour rechercher dans un tableau de 1 024 éléments
   en séquentielle ? En dichotomique ?
3. Dans un tri par sélection sur deux tableaux liés (poids + adresse), où dois-tu
   placer la permutation supplémentaire ?

## 🔗 Pour aller plus loin

- Microsoft Learn — [`Array.Sort`](https://learn.microsoft.com/dotnet/api/system.array.sort)
- [Préparation Intra — Recherche & tri](../../05-references/course-materials/UDEM_H26_IFT1179/notes/Pr%C3%A9paration%20Intra.md)
