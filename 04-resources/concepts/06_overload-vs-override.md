# Surcharge (`overload`) vs redéfinition (`override`) : deux mécanismes que tout débutant confond

> 📘 Concept transversal — module [06 — Méthodes](../../01-theory/06-methods/README.md) et [08 — Polymorphisme](../../01-theory/08-oop-polymorphism/README.md).

L1, en une phrase :

> **Surcharger** : plusieurs méthodes du **même nom** dans la **même classe**,
> mais avec des **signatures différentes** — le compilateur choisit.
> **Redéfinir** : une **sous-classe** remplace l'implémentation d'une méthode
> `virtual` du parent — l'exécutable choisit à l'exécution.

---

## 🗺️ Comparaison directe

| Aspect                  | Surcharge (`overload`)            | Redéfinition (`override`)                      |
| ----------------------- | --------------------------------- | ---------------------------------------------- |
| Mot-clé                 | aucun                             | `override`                                     |
| Lieu de la déclaration  | Même classe (ou une seule classe) | Sous-classe                                    |
| Signatures              | **différentes** (params)          | **identiques** au parent                       |
| Méthode parent requise  | non                               | oui, et elle doit être `virtual` ou `abstract` |
| Quand le choix est fait | **compilation** (statique)        | **exécution** (dynamique)                      |
| Active le polymorphisme | ❌                                 | ✅                                              |
| Fréquence               | très courant                      | indispensable en POO                           |

## 1. Surcharge : commodité d'écriture

```csharp
public class Geometrie
{
    public static double Aire(double cote)            => cote * cote;            // carré
    public static double Aire(double L, double l)     => L * l;                  // rectangle
    public static double Aire(double rayon, bool _)   => Math.PI * rayon * rayon; // cercle
}

Geometrie.Aire(5);            // → carré : compile-time choisit la 1ère
Geometrie.Aire(3, 4);          // → rectangle : choisit la 2e
Geometrie.Aire(5.0, true);     // → cercle : choisit la 3e (à cause du bool)
```

Chaque appel est **résolu à la compilation** selon le **nombre et les types
des arguments**. Si tu mets ton code en pause au compilateur, il sait déjà
quelle méthode sera invoquée.

> ⚠️ **Le type de retour ne fait pas partie de la signature.** Tu ne peux pas
> avoir `int F()` et `double F()` dans la même classe. Le compilateur ne
> saurait pas choisir.

## 2. Redéfinition : mécanisme du polymorphisme

```csharp
public abstract class Logement
{
    public abstract double LoyerMensuel();          // pas d'implémentation
    public virtual string Description() =>          // implémentation par défaut
        $"Logement à {Adresse}";
    public string Adresse { get; }
    protected Logement(string adr) => Adresse = adr;
}

public class Maison : Logement
{
    public int Chambres { get; }
    public Maison(string adr, int ch) : base(adr) => Chambres = ch;

    public override double LoyerMensuel() => 500 + Chambres * 150;
    public override string Description() => $"Maison {Chambres} ch. à {Adresse}";
}
```

Le contrat est **identique** : même nom, mêmes paramètres, même type de
retour. Seule l'implémentation diffère.

L'effet polymorphe :

```csharp
Logement[] tab = { new Maison("rue A", 3), new Logis("rue B", 80, 7) };
foreach (Logement l in tab)
    Console.WriteLine(l.LoyerMensuel());
//                    ↑
// Le compilateur ne sait pas si c'est Maison.LoyerMensuel ou Logis.LoyerMensuel.
// C'est l'EXÉCUTION qui appelle la BONNE méthode selon le type réel de l'objet.
```

## 3. Le piège : `new` au lieu de `override`

```csharp
public class Animal
{
    public virtual string Crier() => "...";
}

public class Chat : Animal
{
    public new string Crier() => "Miaou";    // ❌ MASQUE, ne redéfinit pas
}

Animal a = new Chat();
Console.WriteLine(a.Crier());                // "..."  ❗ surprise

Chat c = new Chat();
Console.WriteLine(c.Crier());                // "Miaou"
```

`new` (modificateur, pas opérateur) **masque** la méthode parent : appelée via
une référence du type parent, elle ignore la version de l'enfant. C'est
**presque toujours** un bug, ou un changement de contrat délibéré qu'il faut
documenter.

Avec `override`, l'appel via la référence parent invoque bien la version de
l'enfant — c'est le polymorphisme.

## 4. Combiner les deux : surcharger ET redéfinir

C'est légal et courant :

```csharp
public class Logement
{
    public virtual string Decrire() => "...";
    public virtual string Decrire(bool detaille) => detaille ? "long" : "court";
}

public class Maison : Logement
{
    public override string Decrire() => "Maison";
    public override string Decrire(bool detaille) => detaille ? "Maison 4ch." : "Maison";
}
```

Surcharge entre les **deux signatures** ; redéfinition entre **parent et
enfant** sur chaque signature.

## 5. Règle de décision

| Situation                                                                           | Mécanisme                                         |
| ----------------------------------------------------------------------------------- | ------------------------------------------------- |
| Même classe, je veux offrir plusieurs façons d'appeler                              | **Surcharge**                                     |
| Sous-classe, je veux changer le comportement d'une méthode du parent                | **Redéfinition** (`override`)                     |
| Je veux que `arr[i].Methode()` choisisse la bonne implémentation selon le type réel | **Redéfinition** sur méthode `virtual`/`abstract` |
| Je veux deux retours différents pour le même nom                                    | ❌ Impossible — change de nom ou de paramètres     |

## 6. Cas spéciaux à connaître

### Override sur `Equals`, `GetHashCode`, `ToString`

Toute classe hérite de `object`, qui les déclare `virtual`. Tu peux donc les
redéfinir partout :

```csharp
public override string ToString() => $"Colis {Code}";
public override bool Equals(object obj) => obj is Colis c && c.Code == Code;
public override int GetHashCode() => Code.GetHashCode();
```

[Exercice 🔴 du module 08](../../03-exercices/08-oop-polymorphism/README.md#-défi--equals--gethashcode-cohérents).

### Surcharge d'opérateurs

Mécanisme distinct mais apparenté : `public static Colis operator +(Colis a, Colis b)`.

### `sealed override`

Tu redéfinis, **et** tu interdis aux sous-sous-classes de redéfinir à leur tour :

```csharp
public sealed override double LoyerMensuel() => ...;
```

## ✅ Vérifie ta compréhension

1. Peux-tu surcharger une méthode en ne changeant **que** son type de retour ?
   Pourquoi (pas) ?
2. `override` requiert que la méthode parent soit `virtual` ou `abstract`.
   Pourquoi cette contrainte ?
3. Tu écris `public new string Decrire() => ...` dans une sous-classe.
   Quelle est la différence visible côté appelant entre `new` et `override` ?
4. La méthode `string.Format(string fmt, object arg)` a 5 surcharges. Comment
   le compilateur choisit-il celle à invoquer pour `Format("{0}", 42)` ?

## 🔗 Pour aller plus loin

- [Cheatsheet POO — Surcharge vs redéfinition](../../01-theory/cheatsheets/oop.md)
- [Théorie 08 — Polymorphisme](../../01-theory/08-oop-polymorphism/README.md)
