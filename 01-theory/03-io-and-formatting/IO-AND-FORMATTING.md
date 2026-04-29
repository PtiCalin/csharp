# 03 — Entrées/sorties console & formatage

> Théorie · [Examples](../../02-examples/03-io-and-formatting/README.md) · [Exercises](../../03-exercices/03-io-and-formatting/README.md)

## L1 — Intuition

`Console` est le **micro et le haut-parleur** du programme. `WriteLine` parle,
`ReadLine` écoute. Le formatage, c'est **mettre un costume** au nombre avant de le
montrer : monnaie, pourcentage, alignement.

## L2 — Définition formelle

### Méthodes principales de `Console`

| Méthode | Effet |
|---------|-------|
| `Write(x)` | Affiche sans saut de ligne |
| `WriteLine(x)` | Affiche puis `\n` |
| `ReadLine()` | Lit une ligne, retourne `string` (ou `null` si EOF) |
| `ReadKey()` | Lit une touche, retourne `ConsoleKeyInfo` |
| `Clear()` | Efface l'écran |

### Trois façons de composer du texte

| Style | Syntaxe | Quand |
|-------|---------|-------|
| **Concaténation** | `"Total: " + montant` | Très simple, peu de variables |
| **Composite** | `"Total: {0:C}", montant` | Plusieurs valeurs, format complexe |
| **Interpolation** | `$"Total: {montant:C}"` | Recommandé (lisible, type-safe) |

### Spécificateurs de format numérique

| Format | Effet | Ex. `montant = 1234.5` |
|--------|-------|-------------------------|
| `C` | Monnaie locale | `1 234,50 $` |
| `F2` | Virgule fixe, 2 décimales | `1234,50` |
| `N2` | Nombre + séparateurs | `1 234,50` |
| `P1` | Pourcentage (×100) | `123 450,0 %` |
| `E2` | Notation scientifique | `1,23E+003` |
| `D5` | Entier zéros à gauche | `01234` |
| `X4` | Hexadécimal | `04D2` |

### Alignement (composite formatting)

```csharp
Console.WriteLine($"|{nom,-10}|{prix,8:C}|");
//                   ↑ gauche    ↑ droite, format monnaie
```

## L3 — Exemple commenté

```csharp
using System;

// Lecture utilisateur typée et validée.
Console.Write("Votre prénom : ");
string prenom = Console.ReadLine();

Console.Write("Votre âge : ");
int age = int.Parse(Console.ReadLine()); // ⚠ Préférer TryParse en pratique.

// 1. Interpolation simple.
Console.WriteLine($"Bonjour {prenom}, vous avez {age} ans.");

// 2. Formatage numérique.
double salaire = 52487.90;
double tauxImpot = 0.2675;

Console.WriteLine($"Salaire brut  : {salaire:C}");      // 52 487,90 $
Console.WriteLine($"Taux d'impôt  : {tauxImpot:P1}");   // 26,8 %
Console.WriteLine($"Salaire net   : {salaire * (1 - tauxImpot):N2}");

// 3. Tableau aligné via composite formatting.
Console.WriteLine($"{"Item",-15}{"Qté",5}{"Prix",10}");
Console.WriteLine($"{"Pomme",-15}{12,5}{0.50,10:C}");
Console.WriteLine($"{"Croissant",-15}{3,5}{2.75,10:C}");
```

## L4 — Cas limites & pièges

- ⚠️ **`ReadLine` peut retourner `null`** (EOF, redirection). En contexte nullable
  activé, traiter explicitement le cas.
- ⚠️ **Pourcentage `P`** : `tauxImpot = 0.27` affiche `27,0 %`. Si vous passez `27`,
  vous obtiendrez `2 700,0 %`. La règle : `P` attend la **fraction**, pas le pourcent.
- ⚠️ **Culture locale** : `:C` affiche `$` ou `€` selon `CurrentCulture`. Pour des
  fichiers ou logs, forcer `CultureInfo.InvariantCulture`.
- ⚠️ **`Console.Write` vs `WriteLine`** : oublier `Line` après une question crée des
  invites collées, oublier sur l'invite est correct.
- ⚠️ **Caractères spéciaux** : `\n`, `\t`, `\\`, `\"`. Préfixe `@` pour ignorer
  l'échappement (`@"C:\dossier"`).

## ✅ Vérifiez votre compréhension

1. Vous voulez afficher `15,5 %` à partir de la valeur `0.155`. Quel format utiliser
   et **pourquoi** la valeur n'est-elle pas `15.5` ?
2. Différence à l'exécution entre `Console.Write("A "); Console.Write("B");` et
   `Console.WriteLine("A "); Console.WriteLine("B");` ?
3. Pourquoi `$"{montant,10:C}"` est-il préférable à
   `"{0,10:C}".PadLeft(10)` lorsqu'on aligne une colonne monétaire ?

## 🔗 Voir aussi

- [Examples → 03-io-and-formatting](../../02-examples/03-io-and-formatting/README.md)
- [Exercises → 03-io-and-formatting](../../03-exercices/03-io-and-formatting/README.md)
- Notes IFT1179 — table complète des formats : `05-references/.../Préparation Intra.md`
