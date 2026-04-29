# 11 — Fichiers (E/S) : exercices

> 📘 [Theory](../../01-theory/11-file-io/README.md) · 📚 [Examples](../../02-examples/11-file-io/README.md)

## 🟢 Échauffement — Compter les lignes

**Énoncé.** Écris `int CompterLignes(string chemin)` qui retourne le nombre de lignes
non vides du fichier. Utilise `using StreamReader`.

**Critères.** [ ] Aucune fuite de handle. [ ] Gère le fichier inexistant
(`FileNotFoundException`). [ ] Compte correct en présence de lignes vides
intercalées.

## 🟡 Application — Charger des coasters

**Énoncé.** À partir du fichier
[`coasters.txt`](../../05-references/course-materials/UDEM_H26_IFT1179/assignements/TP3/coasters.txt) du TP3 :

1. Crée une classe `Coaster` avec champs pertinents (nom, parc, vitesse, hauteur, etc.).
2. Écris `int LireCoasters(Coaster[] tab, string chemin)` qui charge le fichier dans
   un tableau de capacité 200, retourne le nombre lu.
3. Affiche le top 5 par **vitesse** décroissante.

**Indices.**
- Inspecte d'abord le format réel du fichier (séparateur, ordre des champs).
- Utilise `string.Split(';')` ou `'\t'` selon le format.
- `CultureInfo.InvariantCulture` pour les nombres décimaux.

**Critères.**
- [ ] Aucun crash si le fichier contient une ligne corrompue.
- [ ] `n` retourné = nombre de coasters effectivement chargés.
- [ ] Top 5 affiché dans un tableau aligné.

## 🔴 Défi — Persistance complète d'un gestionnaire de colis

**Énoncé.** Étends ton gestionnaire de colis (exo 09) :

| Action | Comportement |
|--------|--------------|
| Au démarrage | Charge `colis.txt` s'il existe, sinon démarre vide. |
| Avant de quitter | Sauvegarde l'état dans `colis.txt`. |
| Option « Exporter CSV » | Écrit `colis.csv` avec en-tête. |
| Option « Importer CSV » | Lit `colis.csv` et **fusionne** (refuse les doublons par `Code`). |

**Indices.**
- `Path.Combine(AppContext.BaseDirectory, "colis.txt")` pour un chemin portable.
- Sauvegarde dans un format simple : 5 lignes par colis.
- CSV : attention aux virgules dans les adresses → encadrer avec `"..."`.

**Critères.**
- [ ] L'app peut être fermée et rouverte sans perte de données.
- [ ] L'import CSV de colis déjà connus n'introduit pas de doublons.
- [ ] Tous les flux fichier sont gérés via `using`.
- [ ] Tester sur un fichier corrompu : message d'erreur clair, pas de crash.

## 🔗 Voir aussi

- [Theory → 11-file-io](../../01-theory/11-file-io/README.md)
- [Examples → 11-file-io](../../02-examples/11-file-io/README.md)
- Données du TP3 : [`coasters.txt`](../../05-references/course-materials/UDEM_H26_IFT1179/assignements/TP3/coasters.txt), [`Nations.txt`](../../05-references/course-materials/UDEM_H26_IFT1179/assignements/TP3/Nations.txt)
