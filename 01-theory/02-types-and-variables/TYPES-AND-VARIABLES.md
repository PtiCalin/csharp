# 02 — Types & variables

> Théorie · [Examples](../../02-examples/02-types-and-variables/README.md) · [Exercises](../../03-exercices/02-types-and-variables/README.md)

## L1 — Intuition

Une variable est une **étiquette** collée sur une boîte. Le **type** dit ce qu'on a le
droit de mettre dedans : un nombre entier, une lettre, un objet… C# vérifie le type
**à la compilation** : interdit de mettre une chaîne dans une boîte « entier ».

## L2 — Définition formelle

### Types valeur vs types référence

| Catégorie     | Stockage     | Exemples                                  | Affectation     |
| ------------- | ------------ | ----------------------------------------- | --------------- |
| **Valeur**    | Pile (stack) | `int`, `double`, `bool`, `char`, `struct` | Copie la valeur |
| **Référence** | Tas (heap)   | `string`, `object`, `Array`, classes      | Copie l'adresse |

### Types numériques principaux

| Type      | Taille        | Plage                | Usage typique             |
| --------- | ------------- | -------------------- | ------------------------- |
| `int`     | 32 bits       | ±2,1 milliards       | Compteurs, indices        |
| `long`    | 64 bits       | ±9 × 10¹⁸            | Grands entiers            |
| `double`  | 64 bits       | ~15 chiffres signif. | Valeurs réelles générales |
| `decimal` | 128 bits      | ~28 chiffres exacts  | Argent, finance           |
| `bool`    | 1 bit logique | `true`/`false`       | Conditions                |
| `char`    | 16 bits       | un caractère Unicode | Lettres                   |

### Conversions

| Mécanisme           | Quand                        | Risque                                  |
| ------------------- | ---------------------------- | --------------------------------------- |
| **Implicite**       | `int → long`, `int → double` | Aucune (élargissement)                  |
| **Cast explicite**  | `(int)3.7`                   | Troncature, dépassement silencieux      |
| **`Parse`**         | `int.Parse("42")`            | Lance `FormatException` si invalide     |
| **`TryParse`**      | `int.TryParse(s, out n)`     | Retourne `bool`, **jamais d'exception** |
| **`Convert.ToXxx`** | Conversion typée générique   | `null` toléré (renvoie 0)               |

### Mots-clés essentiels

- `var` — type **inféré** à la compilation, pas dynamique.
- `const` — constante connue à la compilation, immuable.
- `readonly` — affectable uniquement dans le constructeur.

## L3 — Exemple commenté

```csharp
// Déclaration explicite avec initialisation.
int age = 25;

// var infère le type à partir de la valeur de droite (toujours int ici).
var nom = "Charlie"; // nom est de type string, pas dynamique.

// Conversion explicite avec cast (perte des décimales).
double pi = 3.14159;
int piTronque = (int)pi; // = 3, pas 3.14

// Lecture utilisateur : Console.ReadLine retourne string, jamais int.
Console.Write("Age : ");
string saisie = Console.ReadLine();

// Parse : lance FormatException si saisie n'est pas un entier.
int ageEntier = int.Parse(saisie);

// TryParse : pattern recommandé pour entrée utilisateur (pas d'exception).
if (int.TryParse(saisie, out int ageValide))
{
    Console.WriteLine($"Âge valide : {ageValide}");
}
else
{
    Console.WriteLine("Saisie invalide.");
}
```

## L4 — Cas limites & pièges

- ⚠️ **`double` n'est pas exact** : `0.1 + 0.2 == 0.3` est **`false`**. Pour l'argent,
  utiliser `decimal`.
- ⚠️ **Cast destructeur** : `(int)3.99 == 3`, pas 4. Pour arrondir : `Math.Round`.
- ⚠️ **`Parse` plante** sur entrée vide ou non numérique. Toujours préférer `TryParse`
  pour de la saisie utilisateur (cf. cours IFT1179).
- ⚠️ **`var` ≠ dynamique** : `var x = 5; x = "abc";` ne compile pas. C# reste typé
  statiquement.
- ⚠️ **Culture** : `double.Parse("3.14")` échoue en culture française (qui attend `3,14`).
  Utiliser `CultureInfo.InvariantCulture` pour les fichiers.

## 🔬 Approfondissement

### Pourquoi `double` ment quand il s'agit d'argent

`double` est encodé en **binaire flottant IEEE 754**. Or, des nombres décimaux
banals comme `0,1` ou `0,2` n'ont **pas** de représentation binaire finie : ils
deviennent des approximations infinies, tronquées à 64 bits. La somme de deux
approximations n'est elle-même qu'une approximation, et l'erreur s'accumule à
chaque opération. C'est pourquoi `0.1 + 0.2` produit `0.30000000000000004` et non
`0.3`. Sur une seule addition l'écart est invisible ; sur **mille factures**, il
devient une rupture de bilan comptable.

`decimal`, lui, encode les valeurs en **base 10** sur 128 bits. `0.1m` est
**exactement** un dixième. Le coût : opérations 5 à 10× plus lentes que `double`,
et plage plus restreinte. Le compromis se résout par une règle simple :

> ⚖️ **Argent, taxes, taux d'intérêt → `decimal`. Mesures physiques, statistiques,
> graphismes → `double`.**

Tu vérifieras ce comportement de tes propres yeux dans
[exercice 🟡 — Calcul de monnaie exact](../../03-exercices/02-types-and-variables/README.md#-application--calcul-de-monnaie-exact).

### Le pattern `TryParse` : pourquoi il est canonique

`int.Parse("abc")` lance `FormatException`. C'est le bon comportement quand tu
**sais** que la chaîne provient d'une source maîtrisée (un fichier produit par
ton propre programme, par exemple). Mais pour une **saisie utilisateur**, tu ne
peux jamais faire cette hypothèse. Lever puis attraper une exception coûte
typiquement 100 à 1000× plus cher qu'un test de validité, et exprime mal
l'intention : « je tente une conversion qui pourrait échouer » n'est pas une
condition exceptionnelle, c'est un cas nominal.

D'où la convention `TryXxx(input, out result) → bool` du framework. Elle est
omniprésente : `int.TryParse`, `double.TryParse`, `DateTime.TryParse`,
`Dictionary.TryGetValue`, `Queue.TryDequeue`. **Quand tu vois `TryXxx`, attends-toi
à un `out` et à un `bool`.**

```csharp
if (!double.TryParse(saisie, NumberStyles.Any,
                     CultureInfo.InvariantCulture, out double valeur))
{
    Console.Error.WriteLine("Saisie invalide, on ignore.");
    return;
}
```

C'est précisément le squelette demandé par l'[exercice 🔴 — Validation triple](../../03-exercices/02-types-and-variables/README.md#-défi--validation-triple).

### `var` : ce que ça change, ce que ça ne change pas

`var` est purement un **raccourci syntaxique** pour le compilateur : il infère
le type **statique** à partir de l'expression d'initialisation. **Au runtime, le
type est le même** que si tu l'avais écrit explicitement. La preuve :

```csharp
var x = 5;
x = "abc";    // ❌ Erreur de compilation : Cannot convert string to int
```

`var` n'est **pas** `dynamic` (qui, lui, repousse le typage à l'exécution). Il
gagne sa place dans deux contextes :

1. **Quand le type à droite est verbeux ou évident** :
   `var dict = new Dictionary<string, List<Colis>>();` plutôt que de répéter le
   type complet.
2. **Avec des types anonymes** : `var p = new { Nom = "X", Prix = 5 };` — ici
   `var` est obligatoire, on n'a pas de nom de type à écrire.

Inversement, **évite `var`** quand le type ajoute de la lisibilité au lecteur
humain : `int compteur = 0;` est plus clair que `var compteur = 0;` à 50 lignes
de distance.

### Culture & parsing : la trappe du `12,5`

`double.Parse("12,5")` retourne `125.0` en culture **anglo-américaine** (la
virgule est un séparateur de milliers ignoré) et `12.5` en culture **française**
(la virgule est le séparateur décimal). Le code n'émet **aucun avertissement**.
C'est l'un des bugs les plus pernicieux du parsing.

Règle d'hygiène :

| Source de la chaîne                           | Culture à employer             |
| --------------------------------------------- | ------------------------------ |
| Saisie utilisateur formatée localement        | `CultureInfo.CurrentCulture`   |
| Fichier de données technique (CSV, JSON, log) | `CultureInfo.InvariantCulture` |
| Communication réseau (API)                    | `CultureInfo.InvariantCulture` |

L'[exercice 🔴 — Reproductibilité multi-culture](../../03-exercices/03-io-and-formatting/README.md#-défi--reproductibilité-multi-culture)
te fait toucher du doigt cette trappe en imprimant la même valeur dans trois
cultures.

## ✅ Vérifiez votre compréhension

1. Pourquoi `decimal` est-il préféré à `double` pour des montants ? Donnez un exemple
   numérique précis où `double` échoue.
2. Quelle différence concrète entre `int.Parse(s)` et `int.TryParse(s, out n)` à
   l'exécution si `s = "abc"` ?
3. Soit `string s = "12,5"`. En culture française, que retourne `double.Parse(s)` ?
   Et en `InvariantCulture` ?

## 🔗 Voir aussi

- [Examples → 02-types-and-variables](../../02-examples/02-types-and-variables/README.md)
- [Exercises → 02-types-and-variables](../../03-exercices/02-types-and-variables/README.md)
- Théorie suivante : [03 — E/S et formatage](../03-io-and-formatting/README.md)
