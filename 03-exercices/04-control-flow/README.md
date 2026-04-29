# 04 — Structures de contrôle : exercices

> 📘 [Theory](../../01-theory/04-control-flow/README.md) · 📚 [Examples](../../02-examples/04-control-flow/README.md)

## 🟢 Échauffement — Pair / impair / zéro

**Énoncé.** Lis un entier, affiche `"pair"`, `"impair"` ou `"zéro"`.

**Indices.**
- Modulo `%`.
- Trois branches `if / else if / else`.

**Critères.** [ ] Cas `0`, positifs et négatifs traités correctement.

## 🟡 Application — Note → lettre (table UdeM)

**Énoncé.** Implémente la grille du cours IFT1179 :

| Pourcentage | Lettre |
|-------------|--------|
| ≥ 90 | A+ |
| 85-89 | A |
| 80-84 | A- |
| 77-79 | B+ |
| 73-76 | B |
| 70-72 | B- |
| 65-69 | C+ |
| 60-64 | C |
| 57-59 | C- |
| 53-56 | D+ |
| 50-52 | D |
| < 50 | E |

Implémente la fonction **deux fois** :
1. Avec une chaîne de `if / else if`.
2. Avec une *switch expression* sur des relations `<`.

**Indices.**
- L'ordre des comparaisons compte.
- Tester valeurs limites : `49.9`, `50`, `89.99`, `90`.

**Critères.**
- [ ] Les deux versions retournent **exactement** la même lettre pour 1000 valeurs aléatoires.
- [ ] Code de la *switch expression* est plus court d'au moins 30 %.

## 🔴 Défi — Calculatrice à 4 opérations

**Énoncé.** Programme interactif : demande deux nombres puis un opérateur
(`+ - * /`). Calcule et affiche le résultat. Boucle jusqu'à ce que l'utilisateur
saisisse `q`. Gère :
- Division par zéro → message d'erreur, pas de crash.
- Opérateur inconnu → message + nouvelle saisie.

**Indices.**
- `switch` avec un *pattern* `"+" or "-" or ...`.
- Validation `TryParse` à chaque saisie numérique.
- `do-while` pour le menu principal.

**Critères.**
- [ ] Aucune entrée utilisateur (même la plus aberrante) ne fait crasher le programme.
- [ ] Division par zéro intercepte **avant** l'exécution.
- [ ] Code linté sans avertissement.

## 🔗 Voir aussi

- [Theory → 04-control-flow](../../01-theory/04-control-flow/README.md)
- [Examples → 04-control-flow](../../02-examples/04-control-flow/README.md)
