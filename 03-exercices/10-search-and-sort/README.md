# 10 — Recherche & tri : exercices

> 📘 [Theory](../../01-theory/10-search-and-sort/README.md) · 📚 [Examples](../../02-examples/10-search-and-sort/README.md)

## 🟢 Échauffement — Dichotomique sur `int[]`

**Énoncé.** Écris une fonction itérative `int Dicho(int[] tab, int n, int cible)` qui
retourne l'indice de `cible` ou `-1`. Vérifie sur :

```csharp
int[] t = { 1, 3, 5, 7, 9, 11, 13, 15 };
Dicho(t, 8,  7);                 // 3
Dicho(t, 8, 12);                 // -1
Dicho(t, 8,  1);                 // 0
Dicho(t, 8, 15);                 // 7
```

**Critères.** [ ] 4 cas OK. [ ] Boucle s'arrête en O(log n) (compter les itérations).

## 🟡 Application — Tri par sélection sur tableaux liés

**Énoncé.** Soit deux tableaux parallèles :

```csharp
string[] noms  = { "Charlie", "Alice", "Diane", "Bob" };
int[]    notes = {        87,      92,      71,    64 };
int n = 4;
```

Trie par **note décroissante**, en **synchronisant** `noms` et `notes`. Vérifie après
tri : `noms[0] = "Alice"`, `notes[0] = 92`.

**Indices.**
- Trouver l'**indice** du max dans la portion non triée.
- Échanger en parallèle dans les deux tableaux.

**Critères.**
- [ ] Synchronisation conservée à 100 %.
- [ ] Aucun appel à `Array.Sort`.
- [ ] Test : `(noms[i], notes[i])` reste un couple cohérent ∀ i.

## 🔴 Défi — Top-K avec dichotomique

**Énoncé.** Étant donné un tableau **trié décroissant** de notes (10 000 valeurs entre
0 et 100), implémente :
- `int CompterAuMoins(int[] tab, int n, int seuil)` en `O(log n)` qui retourne le nombre
  de notes `≥ seuil`.
- `int[] TopK(int[] tab, int n, int k)` qui retourne les `k` premières.

**Indices.**
- Pour `CompterAuMoins` : recherche dichotomique de la **position d'insertion**.
- Pour `TopK` : `Array.Copy` ou copie manuelle, surtout pas de tri (déjà trié).

**Critères.**
- [ ] `CompterAuMoins` ne fait **pas** de boucle linéaire.
- [ ] `TopK` retourne exactement `k` éléments (ou moins si `n < k`).
- [ ] Mesurer les itérations sur 10 000 éléments : `CompterAuMoins` < 20 itérations.

## 🔗 Voir aussi

- [Theory → 10-search-and-sort](../../01-theory/10-search-and-sort/README.md)
- [Examples → 10-search-and-sort](../../02-examples/10-search-and-sort/README.md)
