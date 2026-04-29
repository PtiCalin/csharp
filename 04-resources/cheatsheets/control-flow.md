# 📋 Cheatsheet — Contrôle de flux

## `if / else if / else`

```csharp
if (note >= 90)        lettre = "A+";
else if (note >= 80)   lettre = "A";
else if (note >= 70)   lettre = "B";
else                   lettre = "F";
```

## Opérateur ternaire

```csharp
string parite = n % 2 == 0 ? "pair" : "impair";
```

## `switch` classique

```csharp
switch (statut)
{
    case "Expedie":
    case "EnTransit":
        Console.WriteLine("En route");
        break;
    case "Livre":
        Console.WriteLine("Reçu");
        break;
    default:
        Console.WriteLine("Inconnu");
        break;
}
```

⚠️ Chaque `case` doit se terminer par `break`, `return`, `throw` ou `goto case`.

## `switch` expression (C# 8+)

```csharp
string lettre = note switch
{
    >= 90 => "A+",
    >= 80 => "A",
    >= 70 => "B",
    _     => "F"
};
```

```csharp
string ligne = colis switch
{
    { Poids: > 100 } => "lourd",
    { Valeur: > 500 } => "précieux",
    _ => "standard"
};
```

## Boucles

| Forme                         | Quand l'utiliser                           |
| ----------------------------- | ------------------------------------------ |
| `for (int i = 0; i < n; i++)` | Compteur explicite, indice nécessaire      |
| `foreach (var x in coll)`     | Parcours sans modification, sans indice    |
| `while (cond) { ... }`        | Test **avant** chaque tour, peut zéro tour |
| `do { ... } while (cond);`    | Test **après**, garantit ≥ 1 tour (menus)  |

```csharp
// Compteur
for (int i = 0; i < tab.Length; i++)
    Console.WriteLine(tab[i]);

// foreach
foreach (var c in colis)
    Console.WriteLine(c.Code);

// while : lecture jusqu'à condition
string ligne;
while ((ligne = sr.ReadLine()) != null)
    traiter(ligne);

// do-while : menu interactif
int choix;
do
{
    AfficherMenu();
    choix = LireChoix();
} while (choix != 0);
```

## `break` et `continue`

| Mot-clé    | Effet                                          |
| ---------- | ---------------------------------------------- |
| `break`    | Sort **immédiatement** de la boucle / `switch` |
| `continue` | Saute à l'**itération suivante**               |
| `return`   | Sort de la **méthode** entière                 |

```csharp
foreach (var c in colis)
{
    if (c == null) continue;        // ignore et passe au suivant
    if (c.Code == "STOP") break;    // arrête tout le parcours
    traiter(c);
}
```

## Pièges classiques

| Code                                     | Bug                                                                  |
| ---------------------------------------- | -------------------------------------------------------------------- |
| `if (x = 5)`                             | Affectation au lieu de comparaison. Compile si `bool`, sinon erreur. |
| `for (int i = 0; i <= n; i++) tab[i]`    | `tab[n]` est hors-borne.                                             |
| `while (true) { ... }` sans `break`      | Boucle infinie.                                                      |
| `switch` sans `break`                    | Erreur de compilation (heureusement).                                |
| `for (double x = 0; x != 1.0; x += 0.1)` | Imprécision flottante → boucle infinie.                              |

## 🔗 Voir aussi

- [04 — Structures de contrôle](../04-control-flow/README.md)
- [05 — Boucles](../05-loops/README.md)
