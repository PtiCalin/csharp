# 09 — Tableaux

> 📚 [Examples](../../02-examples/09-arrays/README.md) · 🏋️ [Exercises](../../03-exercices/09-arrays/README.md)

## L1 — Intuition

Un tableau = **liste de cases contiguës en mémoire**, toutes du **même type**, indexées
de `0` à `Length - 1`. Sa taille est **fixée à la création** et ne change plus.

Pour gérer une collection dont la taille varie en cours de programme : on utilise un
tableau plus grand que nécessaire + un compteur `nbElements` qui suit les cases
**effectivement utilisées**. C'est le patron du **remplissage partiel**.

## L2 — Syntaxe

### Déclaration & initialisation

```csharp
int[] notes = new int[10];                          // 10 cases initialisées à 0.
int[] primes = { 2, 3, 5, 7, 11 };                  // Initialisation littérale (taille 5).
Colis[] tabColis = new Colis[50];                   // 50 références null.
int nbColis = 0;                                    // Compteur de cases utilisées.

int[,] grille = new int[3, 4];                      // Tableau 2D : 3 lignes × 4 colonnes.
```

### Parcours

```csharp
for (int i = 0; i < notes.Length; i++)              // Avec indice.
    Console.WriteLine($"notes[{i}] = {notes[i]}");

foreach (int n in notes)                            // Sans indice — lecture seule.
    Console.WriteLine(n);

// Tableau partiellement rempli : boucler sur nbColis, PAS sur tab.Length.
for (int i = 0; i < nbColis; i++)
    Console.WriteLine(tabColis[i]);
```

## L3 — Patrons essentiels

### Insertion

```csharp
public static bool Inserer(Colis[] tab, ref int nb, Colis nouveau)
{
    if (nb >= tab.Length) return false;             // Tableau plein.
    tab[nb] = nouveau;
    nb++;
    return true;
}
```

### Recherche séquentielle

```csharp
// Variante 1 : retourne l'indice (-1 si absent).
public static int Trouver(Colis[] tab, int nb, string code)
{
    for (int i = 0; i < nb; i++)
        if (tab[i].Code == code)
            return i;
    return -1;
}

// Variante 2 : retourne l'objet (null si absent).
public static Colis Chercher(Colis[] tab, int nb, string code)
{
    for (int i = 0; i < nb; i++)
        if (tab[i].Code == code)
            return tab[i];
    return null;
}
```

### Suppression par décalage

```csharp
public static bool Supprimer(Colis[] tab, ref int nb, string code)
{
    int idx = Trouver(tab, nb, code);
    if (idx == -1) return false;

    for (int i = idx; i < nb - 1; i++)              // Décale tout vers la gauche.
        tab[i] = tab[i + 1];

    tab[nb - 1] = null;                             // Nettoie la dernière case.
    nb--;
    return true;
}
```

### Max / min

```csharp
public static Colis PlusLourd(Colis[] tab, int nb)
{
    if (nb <= 0) return null;
    Colis max = tab[0];
    for (int i = 1; i < nb; i++)
        if (tab[i].Poids > max.Poids)
            max = tab[i];
    return max;
}
```

## L4 — Pièges

- ⚠️ Boucler jusqu'à `tab.Length` au lieu de `nbElements` → traite des cases `null` →
  `NullReferenceException`.
- ⚠️ `tab[nb]` (juste après le dernier élément utilisé) → `IndexOutOfRangeException` à la
  lecture, OK à l'écriture pour insertion.
- ⚠️ Oublier d'incrémenter / décrémenter `nbElements` après ajout/suppression → décalage
  silencieux.
- ⚠️ Tableau de **types référence** (`Colis[]`) : les cases contiennent des
  **références**, modifier un objet via une case modifie aussi l'original.
- ⚠️ `new int[10]` initialise à `0`, `new bool[10]` à `false`, `new Colis[10]` à `null`.

## ✅ Vérifiez votre compréhension

1. Pourquoi initialiser `max` avec `tab[0]` plutôt qu'avec `int.MinValue` quand on
   cherche le maximum d'un tableau de `Colis` ?
2. Quelle convention de retour utilises-tu pour signaler « non trouvé » dans une
   recherche par indice ? Et par objet ?
3. Si tu supprimes l'élément à l'indice `i`, combien de décalages effectues-tu sur un
   tableau de `nb` éléments ? Pourquoi `nb - 1` dans la condition de boucle ?

## 🔗 Pour aller plus loin

- Microsoft Learn — [Arrays](https://learn.microsoft.com/dotnet/csharp/programming-guide/arrays/)
- TP3 du cours : [TP3.md](../../05-references/course-materials/UDEM_H26_IFT1179/assignements/TP3/TP3.md)
