# 07 — POO Classes : exercices

> 📘 [Theory](../../01-theory/07-oop-classes/README.md) · 📚 [Examples](../../02-examples/07-oop-classes/README.md)

## 🟢 Échauffement — Classe `Etudiant`

**Énoncé.** Crée une classe `Etudiant` avec :
- Champs privés : `matricule` (string), `nom` (string), `moyenne` (double).
- Constructeur complet.
- Propriétés en lecture seule pour `Matricule` et `Nom`.
- Propriété en lecture-écriture pour `Moyenne`, avec validation `[0; 100]`.

**Critères.**
- [ ] `etudiant.Matricule = "..."` ne compile pas.
- [ ] `etudiant.Moyenne = 150` lance `ArgumentException`.

## 🟡 Application — Classe `Colis` complète

**Énoncé.** Implémente la classe `Colis` du cours UdeM avec :
- Champs : `code`, `adresse`, `poids`, `statut`, `valeur`.
- **3 constructeurs** chaînés via `: this(...)`.
- Propriétés selon les règles métier (cf. [Theory § L2](../../01-theory/07-oop-classes/README.md#l2--squelette-canonique)).
- Propriété calculée `Cout` :
  - Si `valeur ≥ 50` → `0` (assurance offerte).
  - Si `poids ≤ 50` → `15` (forfait).
  - Sinon → `poids × 0.05`.

Teste avec :

```csharp
var c1 = new Colis("X42", "Montréal", 30, 25);   // poids ≤ 50, valeur < 50  → 15
var c2 = new Colis("Y99", "Québec",   80, 30);   // poids > 50, valeur < 50  → 4.0
var c3 = new Colis("Z11", "Laval",    20, 70);   // valeur ≥ 50              → 0
```

**Critères.**
- [ ] Les 3 cas ci-dessus retournent les valeurs attendues.
- [ ] `c1.Code = "..."` ne compile pas.
- [ ] `c1.Poids = -5` lance une exception.

## 🔴 Défi — Compteur statique d'instances

**Énoncé.** Étends `Colis` avec :
- Un champ `static int Total` qui compte le nombre de colis créés.
- Un compteur d'instance `Numero` attribué à la création (1, 2, 3, …).
- Une méthode `static Reset()` qui remet `Total` à 0.

Démontre par un programme :

```csharp
var c1 = new Colis("A");
var c2 = new Colis("B");
Console.WriteLine($"{c1.Numero}, {c2.Numero}, total={Colis.Total}");
// 1, 2, total=2
```

**Critères.**
- [ ] `Total` est accessible via la classe (`Colis.Total`), pas via une instance.
- [ ] `Numero` est unique par instance.
- [ ] `Reset()` n'efface pas les `Numero` déjà attribués.

## 🔗 Voir aussi

- [Theory → 07-oop-classes](../../01-theory/07-oop-classes/README.md)
- [Examples → 07-oop-classes](../../02-examples/07-oop-classes/README.md)
- TP1 : [`TP1.md`](../../05-references/course-materials/UDEM_H26_IFT1179/assignements/TP1/TP1.md)
