# 03 — E/S & formatage : exercices

> 📘 [Theory](../../01-theory/03-io-and-formatting/README.md) · 📚 [Examples](../../02-examples/03-io-and-formatting/README.md)

## 🟢 Échauffement — Carte de visite

**Énoncé.** Demande nom, prénom, âge, ville et affiche une carte de visite formatée :

```
+----------------------------+
| Charlot, Charlie           |
| 25 ans · Montréal          |
+----------------------------+
```

**Indices.**
- Largeur fixe avec `{0,-26}`.
- `new string('-', 28)` pour la ligne de séparation.

**Critères.**
- [ ] Bordures alignées même si le nom est court.
- [ ] Pas de saisie qui dépasse la largeur de la carte (ou tronquer avec `Substring`).

## 🟡 Application — Facture formatée

**Énoncé.** Lis 3 articles : **nom**, **prix unitaire**, **quantité**. Affiche un tableau :

```
Article         Qté    P. unit       Total
--------------------------------------------
Pomme            12      0,50 $      6,00 $
Croissant         3      2,75 $      8,25 $
Café              5      4,00 $     20,00 $
--------------------------------------------
                          Total :   34,25 $
                          TPS 5%:    1,71 $
                          TVQ 9.975%:3,42 $
                          À payer:  39,38 $
```

**Indices.**
- Spécificateurs `:C` pour la monnaie, `,N` pour l'alignement.
- Calculer TPS/TVQ avec `decimal` pour précision.

**Critères.**
- [ ] Colonnes alignées.
- [ ] Sommes correctes au centime près.
- [ ] Format monétaire culture `fr-CA`.

## 🔴 Défi — Reproductibilité multi-culture

**Énoncé.** Écris un programme qui affiche la même valeur `1234.5` selon **trois
cultures** : `fr-CA`, `en-US`, `InvariantCulture`. Puis lit la même chaîne en chaque
culture. Que se passe-t-il si tu lis `"1,5"` en `en-US` ?

**Indices.**
- `using System.Globalization;`
- `valeur.ToString("C2", new CultureInfo("fr-CA"))`.
- `double.Parse(s, CultureInfo.InvariantCulture)`.

**Critères.**
- [ ] Sortie comparative dans 3 colonnes.
- [ ] Comprendre pourquoi `"1,5"` parsée en `en-US` donne `15` et pas `1.5`.
- [ ] Recommandation finale écrite : pour les **fichiers techniques**, toujours
  `InvariantCulture`.

## 🔗 Voir aussi

- [Theory → 03-io-and-formatting](../../01-theory/03-io-and-formatting/README.md)
- [Examples → 03-io-and-formatting](../../02-examples/03-io-and-formatting/README.md)
