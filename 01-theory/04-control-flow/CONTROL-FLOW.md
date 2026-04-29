# 04 — Structures de contrôle

> Théorie · [Examples](../../02-examples/04-control-flow/README.md) · [Exercises](../../03-exercices/04-control-flow/README.md)

## L1 — Intuition

Le programme est un **train** ; les structures de contrôle sont les **aiguillages**.
`if` choisit une voie selon une condition, `switch` choisit parmi plusieurs voies
fixes selon une valeur.

## L2 — Définition formelle

### `if` / `else if` / `else`

```csharp
if (condition1)
{
    // bloc exécuté si condition1 est true
}
else if (condition2)
{
    // ...
}
else
{
    // fallback
}
```

- L'évaluation s'arrête à la **première branche vraie**.
- Les conditions sont des expressions de type `bool`.
- L'opérateur ternaire `cond ? a : b` retourne une valeur (pas une instruction).

### Opérateurs logiques

| Opérateur                        | Sens        | Court-circuit                              |
| -------------------------------- | ----------- | ------------------------------------------ |
| `&&`                             | ET          | Oui (n'évalue droite que si gauche vraie)  |
| `\|\|`                           | OU          | Oui (n'évalue droite que si gauche fausse) |
| `!`                              | NON         | —                                          |
| `==`, `!=`, `<`, `<=`, `>`, `>=` | Comparaison | —                                          |

### `switch` classique

```csharp
switch (jour)
{
    case "lundi":
    case "mardi":
        Console.WriteLine("Début de semaine");
        break;
    case "vendredi":
        Console.WriteLine("Presque le weekend");
        break;
    default:
        Console.WriteLine("Autre");
        break;
}
```

- `break` est **obligatoire** (pas de fall-through implicite comme en C).
- `case` peut être empilé pour grouper plusieurs valeurs.

### `switch` avec patterns (C# 7+)

```csharp
string lettre = note switch
{
    < 50  => "E",
    < 60  => "D",
    < 70  => "C",
    < 80  => "B",
    _     => "A"
};
```

- `_` = pattern « tout le reste » (équivalent `default`).
- Les patterns évaluent dans l'ordre.

## L3 — Exemple commenté

```csharp
// Calcul de la lettre selon une note (extrait IFT1179).
double note = 73.5;
string lettre;

if (note < 50)
    lettre = "E";
else if (note < 60)
    lettre = "D";
else if (note < 70)
    lettre = "C";
else if (note < 80)
    lettre = "B";
else
    lettre = "A";

Console.WriteLine($"Note: {note} → {lettre}");

// Équivalent moderne avec switch expression.
string lettre2 = note switch
{
    < 50 => "E",
    < 60 => "D",
    < 70 => "C",
    < 80 => "B",
    _    => "A"
};
```

## L4 — Cas limites & pièges

- ⚠️ **Affectation vs comparaison** : `if (x = 5)` ne compile pas en C# (sécurité), mais
  attention à `if (b = true)` qui compile pour les `bool`.
- ⚠️ **`switch` sur `string`** : sensible à la casse. Utiliser
  `jour.ToLowerInvariant()` avant le `switch` si nécessaire.
- ⚠️ **Court-circuit oublié** : `if (x != null && x.Length > 0)` est correct ;
  inverser l'ordre lance `NullReferenceException`.
- ⚠️ **Branches non exhaustives** : si toutes les branches assignent une variable,
  vérifier que **toutes les voies** la couvrent, sinon erreur de compilation
  « variable non assignée ».
- ⚠️ **Comparaison `double`** : `if (a == 0.1 + 0.2)` est piégeux. Utiliser
  `Math.Abs(a - b) < epsilon`.

## ✅ Vérifiez votre compréhension

1. Pourquoi `if (chaine != null && chaine.Length > 0)` ne plante pas si `chaine` est
   `null`, alors que l'inverse plante ?
2. Dans le calcul de note ci-dessus, pourquoi l'ordre des `else if` peut-il être
   simplifié à des comparaisons `<` au lieu de `>= ... && <` ?
3. Réécrivez en *switch expression* :
   « si l'âge < 18 → mineur, < 65 → adulte, sinon → senior ».

## 🔗 Voir aussi

- [Examples → 04-control-flow](../../02-examples/04-control-flow/README.md)
- [Exercises → 04-control-flow](../../03-exercices/04-control-flow/README.md)
- Théorie suivante : [05 — Boucles](../05-loops/README.md)
