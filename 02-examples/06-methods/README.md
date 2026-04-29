# 06 — Méthodes : exemples

> 📘 [Theory](../../01-theory/06-methods/README.md) · 🏋️ [Exercises](../../03-exercices/06-methods/README.md)

## Exemple 1 — Méthodes utilitaires statiques

```csharp
public static class Stats
{
    public static double Moyenne(double[] tab, int n)
    {
        if (n <= 0) return 0;
        double somme = 0;
        for (int i = 0; i < n; i++)
            somme += tab[i];
        return somme / n;
    }

    public static int Compter(double[] tab, int n, double seuil)
    {
        int c = 0;
        for (int i = 0; i < n; i++)
            if (tab[i] >= seuil) c++;
        return c;
    }

    public static bool Existe(double[] tab, int n, double cible)
    {
        for (int i = 0; i < n; i++)
            if (tab[i] == cible) return true;
        return false;
    }
}
```

## Exemple 2 — `ref` : modifier une variable existante

```csharp
public static void Echanger(ref int a, ref int b)
{
    int tmp = a;
    a = b;
    b = tmp;
}

// Utilisation
int x = 1, y = 2;
Echanger(ref x, ref y);                            // ref OBLIGATOIRE à l'appel aussi.
Console.WriteLine($"x={x}, y={y}");                // x=2, y=1
```

## Exemple 3 — `out` : sortie multiple

```csharp
public static bool ConvertirEntier(string s, out int valeur)
{
    if (int.TryParse(s, out valeur))
        return true;
    valeur = 0;
    return false;
}

// Utilisation
if (ConvertirEntier("42", out int n))
    Console.WriteLine($"Reçu {n}");
```

## Exemple 4 — Surcharge

```csharp
public static double Aire(double cote)              => cote * cote;
public static double Aire(double L, double l)       => L * l;
public static double Aire(double r, bool cercle)    => Math.PI * r * r;

double a1 = Aire(5);                               // Carré 5×5     = 25
double a2 = Aire(3, 4);                            // Rectangle 3×4 = 12
double a3 = Aire(2, true);                         // Cercle r=2    ≈ 12.57
```

## Exemple 5 — Méthode qui retourne un objet (extrait IFT1179)

```csharp
public static Colis TrouverPlusLourd(Colis[] tab, int n)
{
    if (n <= 0) return null;
    Colis max = tab[0];
    for (int i = 1; i < n; i++)
        if (tab[i].Poids > max.Poids)
            max = tab[i];
    return max;
}
```

## 🔗 Voir aussi

- [Theory → 06-methods](../../01-theory/06-methods/README.md)
- [Exercises → 06-methods](../../03-exercices/06-methods/README.md)
