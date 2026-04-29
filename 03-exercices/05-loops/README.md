# 05 — Boucles : exercices

> 📘 [Theory](../../01-theory/05-loops/README.md) · 📚 [Examples](../../02-examples/05-loops/README.md)

## 🟢 Échauffement — Table de multiplication

**Énoncé.** Lis un entier `n` (1-12), affiche sa table de multiplication de 1 à 10.

**Critères.** [ ] `n × i` correct pour tous les `i ∈ [1; 10]`. [ ] Format aligné.

## 🟡 Application — Statistiques sur un tableau

**Énoncé.** Soit le tableau `int[] notes = { 87, 62, 93, 71, 55, 89, 78, 64, 90, 73 };`.
Calcule sans utiliser LINQ :
- la **somme**, la **moyenne**,
- la **note maximale** et son **indice**,
- le **nombre** de notes ≥ 70.

**Indices.**
- Une seule boucle suffit pour tout calculer (efficacité).
- Initialiser `max` avec `notes[0]` et `idxMax = 0`.

**Critères.**
- [ ] Résultats : somme=762, moyenne=76.2, max=93 à idx=2, count(≥70)=6.
- [ ] Pas de méthode LINQ (`Max`, `Sum`, etc.) dans cette version.

## 🔴 Défi — Devinette adaptative

**Énoncé.** Le programme tire un nombre secret entre 1 et 100. L'utilisateur devine.
Après chaque saisie, indiquer `"plus haut"`, `"plus bas"`, ou `"trouvé !"`.

Variantes :
- Limite à **7 tentatives** (suffisant pour [1;100] avec dichotomie).
- Compte le nombre de tentatives, affiche le score final.
- Refuse les saisies hors plage [1;100].

**Indices.**
- `Random rnd = new Random(); int secret = rnd.Next(1, 101);`
- `do-while` jusqu'à trouvé OU 7 tentatives écoulées.
- `int.TryParse` à chaque saisie.

**Critères.**
- [ ] Programme insensible aux saisies invalides.
- [ ] Affiche `"Bravo en X tentatives !"` ou `"Perdu, c'était Y."`.
- [ ] Possibilité de relancer une partie sans redémarrer le programme.

## 🔗 Voir aussi

- [Theory → 05-loops](../../01-theory/05-loops/README.md)
- [Examples → 05-loops](../../02-examples/05-loops/README.md)
