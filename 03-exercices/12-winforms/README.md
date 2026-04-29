# 12 — WinForms : exercices

> 📘 [Theory](../../01-theory/12-winforms/README.md) · 📚 [Examples](../../02-examples/12-winforms/README.md)

> ⚠️ **Pré-requis.** Visual Studio 2022 (Workload « Développement .NET Desktop ») ou
> `dotnet new winforms` avec .NET 6+/8+.

## 🟢 Échauffement — Convertisseur Celsius ↔ Fahrenheit

**Énoncé.** Crée un projet WinForms avec :
- 2 `TextBox` (`txtCelsius`, `txtFahrenheit`).
- 2 `Button` (`btnVersF`, `btnVersC`).
- 1 `Label` de message d'erreur.

Sur clic, convertit la valeur saisie. Si saisie invalide → label en rouge.

**Critères.**
- [ ] Conventions de nommage respectées (`txt`, `btn`, `lbl`).
- [ ] Aucune saisie ne fait crasher l'app.
- [ ] Validation visuelle (couleur de fond ou label).

## 🟡 Application — Calculatrice d'épargne (TP1 Partie 2)

**Énoncé.** Réimplémente la calculatrice d'épargne du
[TP1 Partie 2](../../05-references/course-materials/UDEM_H26_IFT1179/assignements/TP1/IFT1179-A-H26_TP1_Partie2/Epargne) :

- Saisie : montant initial, taux annuel (%), durée (années), versement mensuel optionnel.
- Affichage : valeur finale, intérêts cumulés, tableau année par année.
- Validation : tous les champs numériques positifs.

**Indices.**
- `DataGridView` pour le tableau année par année.
- Formule mensuelle : `solde = solde × (1 + taux/12) + versement`.
- Boucle `for` sur `12 × annees` mois.

**Critères.**
- [ ] Les calculs correspondent à la solution du cours (vérifier sur 1 cas).
- [ ] Tableau lisible avec colonnes formatées (`C2`).
- [ ] Bouton « Effacer » remet l'interface à l'état initial.

## 🔴 Défi — Gestionnaire de colis WinForms

**Énoncé.** Porte le gestionnaire de colis (exo 09 + 11) en WinForms :

- `DataGridView` lié à un `BindingList<Colis>` pour afficher les colis.
- Formulaire d'ajout (Code, Adresse, Poids, Statut, Valeur) avec validation.
- Boutons : Ajouter, Modifier, Supprimer, Sauvegarder, Charger.
- Recherche : `TextBox` qui filtre la grille en temps réel.

**Indices.**
- `BindingList<T>` met à jour la grille automatiquement.
- `txtRecherche.TextChanged` pour le filtre instantané.
- Sauvegarde / chargement en réutilisant les méthodes de l'exo 11.

**Critères.**
- [ ] La grille se met à jour à chaque opération sans `Refresh()` explicite.
- [ ] Validation : pas de code vide, pas de poids négatif.
- [ ] Sauvegarde à la fermeture (événement `FormClosing`) avec confirmation.
- [ ] Filtre de recherche insensible à la casse.

## 🔗 Voir aussi

- [Theory → 12-winforms](../../01-theory/12-winforms/README.md)
- [Examples → 12-winforms](../../02-examples/12-winforms/README.md)
- Solution officielle : [`Epargne/`](../../05-references/course-materials/UDEM_H26_IFT1179/assignements/TP1/IFT1179-A-H26_TP1_Partie2/Epargne/)
