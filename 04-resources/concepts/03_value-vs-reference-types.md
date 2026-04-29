# Types valeur vs types référence : où vivent tes données ?

> 📘 Concept transversal — sous-jacent à [02 — Types](../../01-theory/02-types-and-variables/README.md), [07 — Classes](../../01-theory/07-oop-classes/README.md), [09 — Tableaux](../../01-theory/09-arrays/README.md).

L1, en une phrase :

> **Type valeur : la variable *contient* la donnée. Type référence : la variable
> *contient une adresse* qui pointe vers la donnée.** Cela change tout pour la
> copie, la comparaison et le passage en paramètre.

---

## 🗺️ Carte des types

| Catégorie     | Stockage     | Exemples                                                                 | Affectation copie… |
| ------------- | ------------ | ------------------------------------------------------------------------ | ------------------ |
| **Valeur**    | Pile (stack) | `int`, `double`, `bool`, `char`, `decimal`, `struct`, `enum`, `DateTime` | …la **valeur**     |
| **Référence** | Tas (heap)   | `class`, `string`, `object`, `array`, `delegate`, `interface`            | …l'**adresse**     |

> 🎯 **Mnémotechnique** : tout ce qui se déclare avec `class` est référence ;
> tout ce qui est `struct` ou primitif est valeur. `string` est l'exception
> qui se comporte « presque » comme un type valeur (immuable).

## 1. Démonstration de l'effet de copie

```csharp
// --- Type valeur ---
int a = 10;
int b = a;          // copie de la VALEUR
b = 20;
// a == 10, b == 20  →  indépendants

// --- Type référence ---
int[] x = { 1, 2, 3 };
int[] y = x;         // copie de l'ADRESSE
y[0] = 999;
// x[0] == 999       →  les deux variables pointent sur LE MÊME tableau
```

Conséquence directe : passer un `int[]` à une méthode et modifier ses cases
**affecte** le tableau de l'appelant. Passer un `int` ne l'affecte jamais.

## 2. Égalité : `==` ne compare pas la même chose

```csharp
// Types valeur : == compare les valeurs.
int a = 10; int b = 10;
Console.WriteLine(a == b);       // True ✅

// Classes : == compare les RÉFÉRENCES par défaut.
var c1 = new Colis("X42", 60);
var c2 = new Colis("X42", 60);
Console.WriteLine(c1 == c2);     // False ❗ (deux objets distincts)
Console.WriteLine(c1.Equals(c2)); // False sauf si Equals est redéfini

// string : exception. == compare les contenus (opérateur surchargé).
string s1 = "hello"; string s2 = "hel" + "lo";
Console.WriteLine(s1 == s2);     // True ✅
```

C'est pour cela que tu redéfinis `Equals` + `GetHashCode` quand tu veux que
deux objets « logiquement égaux » soient traités comme tels par `HashSet`,
`Dictionary`, `List.Contains`, etc.
([exercice 🔴 du module 08](../../03-exercices/08-oop-polymorphism/README.md#-défi--equals--gethashcode-cohérents)).

## 3. `null` : seulement pour les types référence

```csharp
int    n = null;        // ❌ ne compile pas (sauf int? — type nullable)
Colis  c = null;         // ✅ valide
```

Accéder à un membre via une référence `null` lève `NullReferenceException`.
C'est l'un des bugs les plus courants. Depuis C# 8, *Nullable Reference Types*
permet au compilateur d'avertir : `string?` autorise `null`, `string` ne devrait pas.

## 4. Boxing : quand un type valeur devient référence

```csharp
int n = 42;
object o = n;        // BOXING : alloue une boîte sur le tas, copie 42 dedans
int m = (int)o;      // UNBOXING : extrait la valeur

// Boxing implicite invisible :
ArrayList list = new ArrayList();
list.Add(42);        // 42 est boxé dans un object → coût de l'allocation
```

**Coût** : allocation tas + copie + travail du GC. Sur des boucles serrées,
c'est mesurable. C'est l'une des raisons d'exister des **génériques** :
`List<int>` ne fait **aucun** boxing, contrairement à `ArrayList`.

## 5. Passage en paramètre : quatre cas distincts

| Cas                               | Effet sur l'appelant                                                                                                                       |
| --------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------ |
| Type **valeur**, sans `ref`/`out` | Aucun (la méthode reçoit une copie)                                                                                                        |
| Type **valeur**, avec `ref`       | La méthode peut **modifier** la variable de l'appelant                                                                                     |
| Type **référence**, sans `ref`    | La méthode reçoit une **copie de l'adresse** : elle peut modifier les **champs** de l'objet, mais pas réassigner la variable de l'appelant |
| Type **référence**, avec `ref`    | La méthode peut **réassigner** la variable de l'appelant à un autre objet                                                                  |

```csharp
void Modifier(int n)        { n = 99; }
void Modifier(int[] tab)    { tab[0] = 99; }
void Reassigner(int[] tab)  { tab = new int[] { 7, 7, 7 }; }
void ReassignerRef(ref int[] tab) { tab = new int[] { 7, 7, 7 }; }

int    a = 1;            Modifier(a);             // a == 1   (inchangé)
int[]  b = { 1, 2, 3 };  Modifier(b);             // b[0] == 99 (modifié !)
int[]  c = { 1, 2, 3 };  Reassigner(c);           // c == { 1, 2, 3 } (référence locale changée)
int[]  d = { 1, 2, 3 };  ReassignerRef(ref d);    // d == { 7, 7, 7 } (réassigné)
```

## 6. `struct` : comment créer un type valeur sur mesure

```csharp
public struct Point
{
    public double X { get; }
    public double Y { get; }
    public Point(double x, double y) { X = x; Y = y; }
}

Point p1 = new Point(1, 2);
Point p2 = p1;                  // COPIE complète des deux doubles
```

Quand utiliser `struct` plutôt que `class` ?

✅ **Oui** si :
- la donnée est **petite** (≤ 16 octets typiquement),
- elle est **immuable**,
- elle représente une **valeur** au sens mathématique (point, couleur, durée).

❌ **Non** si :
- elle a une **identité** (un employé, un colis),
- elle est **mutable**,
- elle est volumineuse (la copie devient coûteuse).

## ✅ Vérifie ta compréhension

1. `string` est-il un type valeur ou un type référence ? Pourquoi se comporte-t-il
   « comme » un type valeur pour `==` ?
2. Pourquoi `List<Colis> liste = autreListe;` peut-il être source de bugs si
   l'on s'attend à une copie ?
3. Décris ce qui se passe en mémoire pour `int[] t = new int[3];`. Combien
   d'allocations ? Où ?
4. Si je veux qu'une méthode **remplace** la liste de l'appelant par une
   nouvelle instance, quel modificateur dois-je passer ?

## 🔗 Pour aller plus loin

- [Glossaire — Boxing, Référence, Valeur](../GLOSSARY.md)
- [Cheatsheet POO — Surcharge `==` et `Equals`](../../01-theory/cheatsheets/oop.md)
- Microsoft : [Value types vs reference types](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/value-types)
