# 05 — Boucles : exemples

> 📘 [Theory](../../01-theory/05-loops/README.md) · 🏋️ [Exercises](../../03-exercices/05-loops/README.md)

## Exemple 1 — Somme et moyenne

```csharp
int[] notes = { 87, 62, 93, 71, 55, 89 };

int somme = 0;
for (int i = 0; i < notes.Length; i++)
    somme += notes[i];

double moyenne = (double)somme / notes.Length;     // Cast pour éviter division entière.
Console.WriteLine($"Somme   : {somme}");
Console.WriteLine($"Moyenne : {moyenne:F2}");
```

## Exemple 2 — Recherche avec sortie anticipée

```csharp
public static int Trouver(int[] tab, int n, int cible)
{
    for (int i = 0; i < n; i++)
        if (tab[i] == cible)
            return i;                              // Sort dès trouvé : optimal.
    return -1;
}
```

## Exemple 3 — Comptage conditionnel

```csharp
public static int CompterPositifs(double[] tab, int n)
{
    int compteur = 0;
    for (int i = 0; i < n; i++)
        if (tab[i] > 0)
            compteur++;
    return compteur;
}
```

## Exemple 4 — Saisie validée (`do-while`)

```csharp
int choix;
do
{
    Console.Write("Choix (1-3) : ");
}
while (!int.TryParse(Console.ReadLine(), out choix) || choix < 1 || choix > 3);
```

## Exemple 5 — Lecture jusqu'à fin de fichier

```csharp
using System.IO;

int compteur = 0;
using (StreamReader sr = new StreamReader("entree.txt"))
{
    while (!sr.EndOfStream)
    {
        string ligne = sr.ReadLine();
        if (!string.IsNullOrWhiteSpace(ligne))
            compteur++;
    }
}
Console.WriteLine($"{compteur} ligne(s) non vide(s).");
```

## Exemple 6 — Max avec garde

```csharp
public static double PlusGrand(double[] tab, int n)
{
    if (n <= 0) throw new ArgumentException("Tableau vide");

    double max = tab[0];                           // Initialisation = 1er élément.
    for (int i = 1; i < n; i++)                    // Démarre à 1.
        if (tab[i] > max)
            max = tab[i];
    return max;
}
```

## Exemple 7 — Suppression à rebours

```csharp
// Supprimer les valeurs négatives en place. À rebours pour éviter de fausser les indices.
public static int RetirerNegatifs(int[] tab, int n)
{
    for (int i = n - 1; i >= 0; i--)
    {
        if (tab[i] < 0)
        {
            for (int j = i; j < n - 1; j++)
                tab[j] = tab[j + 1];
            n--;
        }
    }
    return n;
}
```

## 🔗 Voir aussi

- [Theory → 05-loops](../../01-theory/05-loops/README.md)
- [Exercises → 05-loops](../../03-exercices/05-loops/README.md)
