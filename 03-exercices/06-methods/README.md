# 06 — Méthodes : exercices

> 📘 [Theory](../../01-theory/06-methods/README.md) · 📚 [Examples](../../02-examples/06-methods/README.md)

## 🟢 Échauffement — Trois utilitaires

**Énoncé.** Implémente comme méthodes `static` :
1. `Min(int a, int b, int c)` — retourne le plus petit.
2. `EstPair(int n)` — retourne `bool`.
3. `Saluer(string nom)` — `void`, affiche `Bonjour, <nom>`.

**Critères.** [ ] Signatures correctes (type de retour, paramètres). [ ] Aucun champ
global utilisé.

## 🟡 Application — Surcharge de `Aire`

**Énoncé.** Crée une classe statique `Geometrie` avec :
- `Aire(double cote)` — carré.
- `Aire(double L, double l)` — rectangle.
- `Aire(double rayon, bool cercle)` — cercle si `cercle == true`.
- `Aire(double base_, double hauteur, bool triangle)` — triangle si `triangle == true`.

Pourquoi peut-on **pas** distinguer `Aire(double, double)` rectangle et
`Aire(double, double)` losange par les diagonales ?

**Critères.**
- [ ] Toutes les surcharges compilent.
- [ ] Réflexion écrite : la signature ne dépend **pas** du nom des paramètres.

## 🔴 Défi — `ref` vs `out` : tri à deux retours

**Énoncé.** Écris une méthode `static void MinMax(int[] tab, int n, out int min, out int max)`
qui retourne les deux extrema en **une seule passe**. Puis une variante
`MinMax(int[] tab, int n, ref int min, ref int max)` qui ne réinitialise pas si le
tableau est vide.

Compare :
- Quel `mode` choisir si l'appelant veut juste recevoir les valeurs ?
- Quel `mode` choisir si l'appelant a déjà des valeurs initiales pertinentes (par ex.
  fusion avec un autre tableau) ?

**Indices.**
- `out` = la méthode **doit** assigner la variable.
- `ref` = la variable doit être assignée **avant** l'appel ; la méthode **peut** la
  laisser inchangée.

**Critères.**
- [ ] La version `out` n'oblige pas l'appelant à pré-initialiser.
- [ ] La version `ref` fonctionne pour fusionner deux passes successives.
- [ ] Réponse rédigée justifiant le choix de mode.

## 🔗 Voir aussi

- [Theory → 06-methods](../../01-theory/06-methods/README.md)
- [Examples → 06-methods](../../02-examples/06-methods/README.md)
