# 09 — Tableaux : exemples

> 📘 [Theory](../../01-theory/09-arrays/README.md) · 🏋️ [Exercises](../../03-exercices/09-arrays/README.md)

## Exemple 1 — Gestion d'un tableau partiellement rempli

```csharp
const int CAPACITE = 50;
Colis[] tabColis = new Colis[CAPACITE];
int nbColis = 0;

// Ajout.
public static bool Ajouter(Colis[] tab, ref int n, Colis nouveau)
{
    if (n >= tab.Length) return false;
    tab[n++] = nouveau;
    return true;
}

// Affichage.
public static void Afficher(Colis[] tab, int n)
{
    for (int i = 0; i < n; i++)
        Console.WriteLine($"{i,3}. {tab[i]}");
}
```

## Exemple 2 — Recherche séquentielle (3 variantes)

```csharp
// Variante 1 : présence (bool).
public static bool Existe(Colis[] tab, int n, string code)
{
    for (int i = 0; i < n; i++)
        if (tab[i].Code == code)
            return true;
    return false;
}

// Variante 2 : indice (int, -1 si absent).
public static int IndiceDe(Colis[] tab, int n, string code)
{
    for (int i = 0; i < n; i++)
        if (tab[i].Code == code)
            return i;
    return -1;
}

// Variante 3 : objet (null si absent).
public static Colis Trouver(Colis[] tab, int n, string code)
{
    for (int i = 0; i < n; i++)
        if (tab[i].Code == code)
            return tab[i];
    return null;
}
```

## Exemple 3 — Suppression par décalage

```csharp
public static bool Supprimer(Colis[] tab, ref int n, string code)
{
    int idx = IndiceDe(tab, n, code);
    if (idx == -1) return false;

    for (int i = idx; i < n - 1; i++)
        tab[i] = tab[i + 1];

    tab[n - 1] = null;                              // Libère la référence.
    n--;
    return true;
}
```

## Exemple 4 — Max via `ref`

```csharp
public static void PlusLourd(Colis[] tab, int n, ref Colis max)
{
    if (n <= 0) return;

    max = tab[0];
    for (int i = 1; i < n; i++)
        if (tab[i].Poids > max.Poids)
            max = tab[i];
}

// Utilisation
Colis lourd = null;
PlusLourd(tabColis, nbColis, ref lourd);
if (lourd != null) Console.WriteLine($"Plus lourd : {lourd}");
```

## Exemple 5 — Tableaux liés (synchronisation)

```csharp
string[] noms  = { "Z", "A", "M" };
double[] notes = {  85, 92,  73 };
int n = 3;

// Tri par nom — permuter dans LES DEUX tableaux.
for (int i = 0; i < n - 1; i++)
{
    int idxMin = i;
    for (int j = i + 1; j < n; j++)
        if (string.Compare(noms[j], noms[idxMin]) < 0)
            idxMin = j;

    (noms[i], noms[idxMin])   = (noms[idxMin], noms[i]);    // Swap noms.
    (notes[i], notes[idxMin]) = (notes[idxMin], notes[i]);  // Swap notes EN PARALLÈLE.
}
```

## 🔗 Voir aussi

- [Theory → 09-arrays](../../01-theory/09-arrays/README.md)
- [Exercises → 09-arrays](../../03-exercices/09-arrays/README.md)
