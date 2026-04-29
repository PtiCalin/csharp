# 08 — Polymorphisme : exercices

> 📘 [Theory](../../01-theory/08-oop-polymorphism/README.md) · 📚 [Examples](../../02-examples/08-oop-polymorphism/README.md)

## 🟢 Échauffement — `Forme` abstraite

**Énoncé.** Crée une classe `abstract Forme` avec :
- Méthode `abstract double Aire()`.
- Méthode `virtual string Description()` retournant `"Forme inconnue"`.

Sous-classes : `Cercle(rayon)`, `Rectangle(L, l)`, `Triangle(base, hauteur)`.
Chacune redéfinit `Aire()` ; `Cercle` redéfinit aussi `Description()`.

**Critères.**
- [ ] `new Forme()` ne compile pas.
- [ ] `Cercle.Description()` retourne quelque chose comme `"Cercle de rayon X"`.
- [ ] Les autres classes héritent du `Description()` par défaut.

## 🟡 Application — Hiérarchie `Logement` (FinalA24)

**Énoncé.** Reprends la hiérarchie `Logement` / `Maison` / `Logis` du cours
([code de référence](../../05-references/course-materials/UDEM_H26_IFT1179/assignements/exams/02-final/FinalA24)) :
- `Logement` est abstraite : `Adresse`, `Superficie`, `LoyerMensuel()` abstraite.
- `Maison(adresse, superficie, chambres)` : loyer = `superficie × 12 + chambres × 150`.
- `Logis(adresse, superficie, etage)` : loyer = `superficie × 18 + (etage > 5 ? 200 : 0)`.

Implémente :
1. Un `Logement[]` pré-rempli avec 5 logements mixtes.
2. Une méthode `static double TotalLoyers(Logement[] tab)`.
3. Une méthode `static Logement PlusCher(Logement[] tab)`.

**Critères.**
- [ ] `tab[i].LoyerMensuel()` invoque la bonne implémentation.
- [ ] `PlusCher` traverse une seule fois le tableau.
- [ ] `Console.WriteLine(tab[i])` affiche un message lisible (redéfinir `ToString`).

## 🔴 Défi — `Equals` + `GetHashCode` cohérents

**Énoncé.** Étends ta classe `Colis` (ex. 07) avec :
- `override bool Equals(object obj)` : deux colis sont égaux si leurs `Code` sont égaux.
- `override int GetHashCode()` : cohérent avec `Equals`.
- `override string ToString()` : `"Colis {Code} → {Adresse} ({Poids} kg)"`.

Vérifie avec :

```csharp
var c1 = new Colis("X42", "Montréal", 10);
var c2 = new Colis("X42", "Québec",   25);
var c3 = new Colis("Y99", "Laval",    30);

Console.WriteLine(c1.Equals(c2));                 // True
Console.WriteLine(c1.Equals(c3));                 // False

var set = new HashSet<Colis> { c1, c2, c3 };       // Contiendra 2 éléments (c1 == c2).
Console.WriteLine(set.Count);                      // 2
```

**Critères.**
- [ ] Le `HashSet` contient bien 2 éléments.
- [ ] `c1.Equals(null)` retourne `false` sans crash.
- [ ] `Equals` utilise `is not Colis` ou `as` pour la conversion sûre.

## 🔗 Voir aussi

- [Theory → 08-oop-polymorphism](../../01-theory/08-oop-polymorphism/README.md)
- [Examples → 08-oop-polymorphism](../../02-examples/08-oop-polymorphism/README.md)
