# 02 — Types & variables : exercices

> 📘 [Theory](../../01-theory/02-types-and-variables/README.md) · 📚 [Examples](../../02-examples/02-types-and-variables/README.md)

## 🟢 Échauffement — Conversions de température

**Énoncé.** Demande une température en Celsius, retourne la valeur en Fahrenheit avec
2 décimales. Formule : `F = C × 9/5 + 32`.

**Indices.**
- `double.TryParse` pour la saisie.
- Attention à la division entière : `9/5 == 1` ! Forcer `9.0/5.0` ou `9.0/5`.

**Critères.**
- [ ] `0 → 32.00`, `100 → 212.00`, `-40 → -40.00`.
- [ ] Saisie invalide gérée sans crash.

## 🟡 Application — Calcul de monnaie exact

**Énoncé.** Lis trois prix d'articles (`double`) et un montant payé. Affiche la monnaie
à rendre avec format `C2`.

Refais ensuite la même chose avec `decimal`. **Compare** les deux sorties si les prix
sont `0.10`, `0.20`, `0.05` et le paiement `1.00`.

**Indices.**
- Avec `double` : `0.1 + 0.2 + 0.05` ne donne **pas** `0.35` exactement.
- Avec `decimal` : suffixe `m` (`0.1m`).

**Critères.**
- [ ] Constatation explicite de la différence.
- [ ] Conclusion écrite en commentaire : « pour de l'argent, utiliser `decimal` ».

## 🔴 Défi — Validation triple

**Énoncé.** Demande successivement :
1. Un **nom** non vide (string).
2. Un **âge** entier entre 0 et 130.
3. Un **revenu** positif (decimal).

Si une saisie est invalide, redemande **uniquement** la valeur fautive jusqu'à ce
qu'elle soit valide. Affiche ensuite un récapitulatif formaté.

**Indices.**
- Trois boucles `do-while` indépendantes.
- `string.IsNullOrWhiteSpace` pour le nom.
- `decimal.TryParse(..., out var r)` pour le revenu.

**Critères.**
- [ ] Aucune valeur invalide n'est jamais acceptée.
- [ ] Le programme ne plante jamais, quelle que soit la saisie.
- [ ] Le revenu s'affiche avec le format `C2` selon culture courante.

## 🔗 Voir aussi

- [Theory → 02-types-and-variables](../../01-theory/02-types-and-variables/README.md)
- [Examples → 02-types-and-variables](../../02-examples/02-types-and-variables/README.md)
