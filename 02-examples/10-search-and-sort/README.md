# 10 — Recherche & tri : exemples

> 📘 [Theory](../../01-theory/10-search-and-sort/README.md) · 🏋️ [Exercises](../../03-exercices/10-search-and-sort/README.md)

## Exemple 1 — Recherche dichotomique itérative

```csharp
public static int Dicho(int[] tab, int n, int cible)
{
    int g = 0, d = n - 1;
    while (g <= d)
    {
        int m = g + (d - g) / 2;                    // Évite débordement.
        if (tab[m] == cible) return m;
        if (tab[m] < cible)  g = m + 1;
        else                 d = m - 1;
    }
    return -1;
}
```

## Exemple 2 — Recherche dichotomique récursive

```csharp
public static int DichoRec(int[] tab, int g, int d, int cible)
{
    if (g > d) return -1;                           // Cas d'arrêt.
    int m = g + (d - g) / 2;
    if (tab[m] == cible) return m;
    return tab[m] < cible
        ? DichoRec(tab, m + 1, d, cible)
        : DichoRec(tab, g, m - 1, cible);
}
```

## Exemple 3 — Tri par sélection

```csharp
public static void TriSelection(int[] tab, int n)
{
    for (int i = 0; i < n - 1; i++)
    {
        int idxMin = i;
        for (int j = i + 1; j < n; j++)
            if (tab[j] < tab[idxMin])
                idxMin = j;

        if (idxMin != i)
            (tab[i], tab[idxMin]) = (tab[idxMin], tab[i]);
    }
}
```

## Exemple 4 — Quicksort

```csharp
public static void QuickSort(int[] tab, int debut, int fin)
{
    if (debut >= fin) return;

    int pivot = Partition(tab, debut, fin);
    QuickSort(tab, debut, pivot - 1);
    QuickSort(tab, pivot + 1, fin);
}

private static int Partition(int[] tab, int debut, int fin)
{
    int pivot = tab[fin];
    int i = debut - 1;

    for (int j = debut; j < fin; j++)
    {
        if (tab[j] <= pivot)
        {
            i++;
            (tab[i], tab[j]) = (tab[j], tab[i]);
        }
    }
    (tab[i + 1], tab[fin]) = (tab[fin], tab[i + 1]);
    return i + 1;
}
```

## Exemple 5 — Tri d'un tableau d'objets selon une propriété

```csharp
// Tri par poids croissant — tri par sélection sur Colis[].
public static void TrierParPoids(Colis[] tab, int n)
{
    for (int i = 0; i < n - 1; i++)
    {
        int idxMin = i;
        for (int j = i + 1; j < n; j++)
            if (tab[j].Poids < tab[idxMin].Poids)
                idxMin = j;

        if (idxMin != i)
            (tab[i], tab[idxMin]) = (tab[idxMin], tab[i]);
    }
}
```

## Exemple 6 — Comparer aux API standard

```csharp
int[] tab = { 5, 2, 8, 1, 9 };
Array.Sort(tab);                                    // Quicksort optimisé en interne.

int idx = Array.BinarySearch(tab, 8);               // Dichotomique sur tableau trié.
Console.WriteLine(idx);                             // 3
```

## 🔗 Voir aussi

- [Theory → 10-search-and-sort](../../01-theory/10-search-and-sort/README.md)
- [Exercises → 10-search-and-sort](../../03-exercices/10-search-and-sort/README.md)
