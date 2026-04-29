# 09 — Tableaux : exercices

> 📘 [Theory](../../01-theory/09-arrays/README.md) · 📚 [Examples](../../02-examples/09-arrays/README.md)

## 🟢 Échauffement — Inversion en place

**Énoncé.** Écris `Inverser(int[] tab, int n)` qui inverse les `n` premières cases du
tableau **sans** créer de tableau auxiliaire.

**Indices.**
- Deux indices `g = 0` et `d = n - 1`, échanger jusqu'à se croiser.

**Critères.**
- [ ] `{1,2,3,4,5}` → `{5,4,3,2,1}`.
- [ ] Pas d'allocation supplémentaire.

## 🟡 Application — Gestionnaire de colis

**Énoncé.** Implémente une mini-CLI qui maintient un `Colis[]` de capacité 50 et un
compteur `nbColis`, avec ces opérations :

| Choix | Action |
|-------|--------|
| 1 | Ajouter (refuse si plein, refuse si code déjà présent) |
| 2 | Supprimer par code (recherche + décalage) |
| 3 | Lister tous les colis |
| 4 | Trouver le plus lourd |
| 5 | Compter ceux > 50 kg |
| 0 | Quitter |

**Critères.**
- [ ] Pas de `null` parcouru (boucler sur `nbColis`).
- [ ] Insertion refuse les doublons (`Code` unique).
- [ ] Suppression compacte le tableau.
- [ ] Toutes les opérations sont des **méthodes statiques** indépendantes du `Main`.

## 🔴 Défi — Statistiques avancées

**Énoncé.** À partir d'un `Colis[]` rempli, calcule sans LINQ :
- Le **poids moyen** des colis avec `valeur > 100`.
- Le **colis le plus proche** d'un poids cible (paramètre).
- Une **histogramme** des statuts : pour chaque statut distinct, combien de colis ?

Pour l'histogramme, utilise un `string[]` parallèle à un `int[]` (capacité 10).

**Indices.**
- Le « plus proche » → minimiser `Math.Abs(c.Poids - cible)`.
- L'histogramme : pour chaque colis, chercher si son statut est déjà connu ; sinon
  l'ajouter.

**Critères.**
- [ ] Histogramme compact : pas de cases vides intercalées.
- [ ] Aucun appel LINQ (`GroupBy`, `Where`, etc.).
- [ ] Affichage final aligné en colonnes.

## 🔗 Voir aussi

- [Theory → 09-arrays](../../01-theory/09-arrays/README.md)
- [Examples → 09-arrays](../../02-examples/09-arrays/README.md)
- TP3 : [`TP3.md`](../../05-references/course-materials/UDEM_H26_IFT1179/assignements/TP3/TP3.md)
