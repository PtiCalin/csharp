---
sticker: lucide//file-badge
course: []
type: exam
date:
tags:
  - school
  - school/udem
  - school/udem/ift1179
  - school/note
  - school/note/exam-prep
  - programming
  - programming/csharp
  - programming/oop
  - programming/console
  - programming/oop/class
  - programming/oop/object
  - programming/oop/encapsulation
  - programming/oop/polymorphism
  - programming/oop/constructor
  - programming/oop/property
  - programming/oop/static
  - programming/oop/override
  - programming/oop/equals
  - programming/method
  - programming/method/void
  - programming/method/return
  - programming/method/ref
  - programming/method/out
  - programming/method/static
  - programming/control-flow
  - programming/control-flow/for
  - programming/control-flow/while
  - programming/control-flow/do-while
  - programming/control-flow/if
  - programming/array
  - programming/array/search
  - programming/array/sequential-search
  - programming/array/binary-search
  - programming/array/sort
  - programming/array/selection-sort
  - programming/array/quicksort
  - programming/array/insertion
  - programming/array/deletion
  - programming/array/shift
  - programming/io
  - programming/io/streamreader
  - programming/io/file-reading
  - programming/io/parse
  - programming/io/tryparse
  - programming/validation
  - programming/error-handling
  - programming/bound-check
  - programming/output
  - programming/output/formatting
  - programming/output/interpolation
  - programming/output/composite-format
---

```table-of-contents
title: CONTENTS
style: nestedList # TOC style (nestedList|nestedOrderedList|inlineFirstLevel)
minLevel: 0 # Include headings from the specified level
maxLevel: 0 # Include headings up to the specified level
include:
exclude:
includeLinks: true # Make headings clickable
hideWhenEmpty: false # Hide TOC if no headings are found
debugInConsole: false # Print debug info in Obsidian console
```

---
# ✨ Terminologie

| Terme                  | Définition claire                                   |
| ---------------------- | --------------------------------------------------- |
| Classe                 | Modèle pour créer des objets                        |
| Objet                  | Instance d’une classe                               |
| Champ                  | Variable membre privée                              |
| Constructeur           | Méthode appelée lors du new                         |
| Propriété              | Interface publique pour accéder aux champs          |
| Encapsulation          | Protection des données via private                  |
| Polymorphisme          | Redéfinition de méthodes héritées                   |
| override               | Mot-clé pour redéfinir méthode                      |
| this                   | Référence à l’objet courant                         |
| Cast                   | Conversion explicite de type                        |
| Argument               | Valeur envoyée lors de l’appel                      |
| return                 | Valeur retournée                                    |
| ref                    | Passage par référence (doit être initialisé)        |
| out                    | Passage par sortie (initialisation non obligatoire) |
| Indice                 | Position dans le tableau                            |
| Length                 | Taille du tableau                                   |
| Recherche séquentielle | Parcours un à un                                    |
| nbElements             | Nombre réel d’éléments utilisés                     |
| void                   | Méthode qui ne retourne rien                        |


---
# 📝 Notes

## Squelette standard pour les classes

```c#
class NomClasse // Déclare une classe nommée NomClasse.
{
    // Champs privés
    private string champ1; // Champ texte privé, accessible seulement à l’intérieur de la classe.
    private int champ2;    // Champ entier privé, accessible seulement à l’intérieur de la classe.

    // Constructeur principal
    public NomClasse(string champ1, int champ2) // Constructeur qui reçoit les 2 valeurs nécessaires.
    {
        this.champ1 = champ1; // this.champ1 = champ de l’objet courant, champ1 = paramètre reçu.
        this.champ2 = champ2; // Assigne la valeur du paramètre au champ privé champ2.
    }

    // Constructeur alternatif
    public NomClasse(string champ1) // Constructeur surchargé qui reçoit seulement champ1.
    {
        this.champ1 = champ1; // Assigne le paramètre champ1 au champ privé correspondant.
        this.champ2 = 0;      // Donne une valeur par défaut à champ2 quand elle n’est pas fournie.
    }

    // Propriété lecture-écriture
    public string Champ1 // Propriété publique pour lire/modifier champ1.
    {
        get { return champ1; }   // Retourne la valeur actuelle de champ1.
        set { champ1 = value; }  // Met à jour champ1 avec la nouvelle valeur reçue (value).
    }

    // Propriété lecture seule
    public int Champ2 // Propriété publique en lecture seule pour champ2.
    {
        get { return champ2; } // Retourne champ2, sans setter donc non modifiable de l’extérieur.
    }

    // Redéfinition ToString
    public override string ToString() // Redéfinit l’affichage texte de l’objet.
    {
        return champ1 + " " + champ2; // Concatène champ1 et champ2 dans une seule chaîne.
    }

    // Redéfinition Equals
    public override bool Equals(object obj) // Redéfinit la comparaison d’égalité entre objets.
    {
        if (obj == null || !(obj is NomClasse)) // Vérifie que obj n’est pas null et est du bon type.
            return false; // Si non, les objets ne sont pas égaux.

        NomClasse autre = (NomClasse)obj; // Convertit obj en NomClasse pour accéder à ses champs.

        return this.champ1 == autre.champ1; // Critère d’égalité: même valeur de champ1.
    }
}
```

---
## 🧭 Quoi utiliser quand

| Si l’énoncé dit… | Utilise | Pourquoi |
| --- | --- | --- |
| « Vérifier si l’élément existe » | `bool` | Réponse oui/non seulement |
| « Trouver où est l’élément » | `int` (indice) | Permet ensuite modifier/supprimer |
| « Retourner l’objet trouvé » | Type objet (`Colis`) | Donne accès direct aux propriétés |
| « Modifier un seul élément trouvé » | Recherche + `break`/`return` | Arrête dès que c’est fait |
| « Modifier tous les éléments » | Boucle complète sans `break` | Il faut parcourir toute la table |
| « Retourner max/min » | Variable temporaire + boucle dès `i = 1` | Compare au courant optimal |
| « Besoin de plusieurs infos en sortie » | `ref` ou `out` | Permet de renvoyer via paramètres |
| « Lecture seule d’un champ » | Propriété avec `get` | Encapsulation sans modification externe |
| « Lecture + écriture » | Propriété avec `get` + `set` | Contrôle l’accès public au champ |
| « Comparer deux objets métier » | `override Equals(object obj)` | Comparaison sur la clé (ex: `code`) |

### Astuces

- Utilise `void` si la méthode **agit** (modifie) sans valeur à retourner.
- Utilise un type de retour (`int`, `bool`, `Colis`, etc.) si la méthode **doit fournir un résultat**.
- En recherche séquentielle: si trouvé et fini, `return` immédiatement.
- Pour max/min: initialise avec `tab[0]`, puis commence la boucle à `1`.
- `ref`: variable déjà initialisée à l’appel; `out`: initialisation non obligatoire avant l’appel.

---
## POO de base 

- Classe, objet, champs privés, encapsulation.
- Constructeurs : complet, partiel (valeurs par défaut), minimal (comparaison/recherche).
- Propriétés `get` / `set` et validation dans `set`.
- Différence méthode d’objet vs méthode `static`.
- Champs `static` (info commune à toute la classe).

🎯 **À savoir faire rapidement à l’examen**
- Écrire une classe complète (champs privés + constructeurs + propriétés).
- Ajouter une validation simple dans un `set` (ex: borner entre 0 et 100).
- Distinguer un appel d’objet (`obj.Methode()`) et un appel de classe (`Classe.MethodeStatic()`).

⚠️ **Pièges fréquents**
- Oublier `private` sur les champs.
- Confondre variable d’instance et variable `static`.
- Oublier de mettre une valeur par défaut dans le constructeur partiel.


---
## Méthodes

| Si l’énoncé dit… | Signature / choix | Pourquoi |
| --- | --- | --- |
| « Afficher / modifier / traiter » sans résultat attendu | `public static void Nom(...)` | Action seulement, pas de valeur de retour |
| « Compter combien » | `public static int Nom(...)` | Le résultat est un nombre |
| « Vérifier si existe / valide » | `public static bool Nom(...)` | Réponse logique oui/non |
| « Trouver l’élément » | `public static Colis Nom(...)` (ou type de classe) | Retour direct de l’objet |
| « Trouver position » | `public static int Nom(...)` avec `-1` si absent | Convention claire pour non trouvé |
| « Modifier un paramètre reçu » | Paramètre `ref` | Le changement doit sortir de la méthode |
| « Renvoyer une info supplémentaire » | Paramètre `out` | Retour multiple simple |
| « Utiliser pour toute la classe » | `static` | Pas besoin d’instance |

### Règles ultra utiles à l’intra

- Commence par écrire le **type de retour** (c’est souvent l’indice principal de l’énoncé).
- Si l’énoncé contient « retourne », évite `void`.
- Si la méthode cherche un seul élément, retourne dès trouvé (`return`).
- Si la méthode modifie une collection complète, évite le `return` prématuré.
- Utilise des noms de méthode verbes: `Compter...`, `Trouver...`, `Modifier...`, `Existe...`.

### Mini arbre de décision

1. L’énoncé demande-t-il une valeur à retourner ?
    - Non → `void`
    - Oui → passe à 2
2. Valeur logique ? → `bool`
3. Valeur numérique (nombre/indice) ? → `int`/`double`
4. Objet complet ? → type de la classe (`Colis`, etc.)

---
### `this`, surcharge et polymorphisme

- `this.champ` pour lever les conflits nom champ/paramètre.
- `: this(...)` pour chaîner les constructeurs.
- `return this` dans une méthode qui retourne l’objet courant.
- Surcharge de constructeurs/méthodes (même nom, signatures différentes).


---
## Boucles

| Si l’énoncé dit… | Utilise | Pourquoi |
| --- | --- | --- |
| « Parcourir un tableau avec indice » | `for (int i = 0; i < nb; i++)` | Contrôle précis de l’indice |
| « Chercher un élément » | `for` + `if` + `return`/`break` | Stoppe dès trouvé |
| « Modifier tous les éléments » | `for` complet sans arrêt | Tous doivent être traités |
| « Lire jusqu’à la fin d’un fichier » | `while (!lecteur.EndOfStream)` | Nombre de lignes inconnu |
| « Répéter tant qu’une condition est vraie » | `while (condition)` | Boucle conditionnelle simple |
| « Au moins une exécution garantie » | `do { ... } while (condition);` | Exécute puis teste |
| « Max/min dans un tableau » | Init avec `tab[0]`, boucle `i = 1` | Évite comparer élément avec lui-même |
| « Supprimer par décalage » | `for (int i = indice; i < nb - 1; i++)` | Recolle les éléments à gauche |

### Astuces

- Pour un tableau partiellement rempli, boucle jusqu’à `nb`, pas `tab.Length`.
- Pour une recherche: `return` dès trouvé = plus efficace et plus clair.
- Pour un comptage, initialise `compteur = 0` puis `compteur++` quand condition vraie.
- Pour max/min, ne jamais oublier de vérifier que `nb > 0` dans un vrai contexte applicatif.
- Attention aux bornes: dernier indice valide = `nb - 1`.

### Choix de boucle

1. Tu connais le nombre d’itérations ? → `for`
2. Tu ne le connais pas, dépend d’une condition ? → `while`
3. Tu dois exécuter au moins une fois ? → `do-while`
4. Tu cherches un seul élément ? → boucle + arrêt dès trouvé


---
## Constructeurs

🧠 **Astuces**
- Le constructeur doit initialiser les champs essentiels dès la création de l’objet.
- Le constructeur partiel sert à poser des valeurs par défaut cohérentes.
- Le constructeur minimal sert souvent à créer un objet temporaire pour comparer/rechercher.
- Si paramètre et champ ont le même nom, utilise `this.champ`.

⚠️ **Pièges fréquents**
- Oublier d’initialiser un champ important dans un constructeur.
- Mettre une valeur par défaut incohérente avec l’énoncé.
- Confondre constructeur partiel et constructeur minimal.

✔ Constructeur complet

```c#
this.champ = param; // Affecte la valeur du paramètre au champ de l'objet courant.
```

✔ Constructeur partiel avec valeur par défaut

```c#
public Colis(string code, string adresse, double poids, double valeur) // Constructeur partiel : certaines valeurs sont imposées par défaut.
{ // Début du constructeur.
    this.code = code; // Initialise le code du colis.
    this.adresse = adresse; // Initialise l'adresse de livraison.
    this.poids = poids; // Initialise le poids.
    this.valeur = valeur; // Initialise la valeur du colis.
    this.statut = "Étiquette créée"; // Assigne le statut initial par défaut.
} // Fin du constructeur.
```

✔ Constructeur minimal (comparaison)

```c#
public Colis(string code) // Constructeur minimal : initialise seulement la clé de comparaison.
{ // Début du constructeur minimal.
    this.code = code; // Garde uniquement le code pour les recherches/comparaisons (Equals).
} // Fin du constructeur minimal.
```

---
## Redéfinition de *Equals*

🧠 **Astuces**
- `Equals` compare l’identité logique d’un objet (souvent un champ clé).
- Ordre classique attendu : test `null` + test du type + cast + comparaison finale.
- Si deux objets sont égaux selon `Equals`, leur champ clé doit être identique.

```c#
public override bool Equals(object obj) // Redéfinit l'égalité pour la classe Colis.
{ // Début de Equals.
    if (obj == null || !(obj is Colis)) // Vérifie null et le bon type avant tout.
        return false; // Si l'objet n'est pas un Colis valide, ils ne sont pas égaux.

    Colis autre = (Colis)obj; // Convertit l'objet générique en Colis pour accéder à ses champs.

    return this.code == autre.code; // Compare le champ clé (code) pour décider l'égalité.
} // Fin de Equals.
```

🗝️ **Éléments clés**
- override
- object en paramètre
- cast
- comparaison champ clé

---
## Propriétés

🧠 **Astuces**
- Utilise une propriété **lecture seule** quand l’appelant ne doit pas modifier la donnée.
- Utilise une propriété **lecture + écriture** quand la modification externe est autorisée.
- Une propriété **calculée** n’a souvent pas de champ dédié : elle calcule à partir d’autres champs.
- Dans un `set`, `value` représente la nouvelle valeur envoyée à la propriété.

⚠️ **Pièges fréquents**
- Retourner la mauvaise variable dans le `get`.
- Oublier la validation dans un `set` quand l’énoncé impose des bornes.
- Essayer d’écrire dans une propriété qui n’a pas de `set`.
- Mettre une logique lourde/ambiguë dans une propriété au lieu d’une méthode.

### Lecture

```c#
public double Poids // Propriété publique en lecture seule.
{ // Début de la propriété Poids.
    get { return poids; } // Retourne la valeur du champ privé poids.
} // Fin de la propriété Poids.
```

### Lecture + écriture

```c#
public string Statut // Propriété publique en lecture et écriture.
{ // Début de la propriété Statut.
    get { return statut; } // Lit et retourne la valeur actuelle de statut.
    set { statut = value; } // Modifie statut avec la valeur reçue dans value.
} // Fin de la propriété Statut.
```

### Calculée (Type Count)

```c#
public double Cout // Propriété calculée : la valeur est déterminée à la lecture.
{ // Début de la propriété Cout.
    get // Exécuté à chaque lecture de Cout.
    { // Début du calcul.
        if (valeur >= 50) // Si la valeur du colis est au moins 50.
            return 0; // Le coût est gratuit.

        if (poids <= 50) // Sinon, si le poids est de 50 ou moins.
            return 15; // Coût fixe de 15.

        return poids * 0.05; // Sinon, coût proportionnel au poids.
    } // Fin du calcul.
} // Fin de la propriété Cout.
```

---
## Tableaux, recherches et tris

- Recherche séquentielle (`bool`, indice, objet).
- Recherche dichotomique (tableau trié).
- Tri par sélection + permutation.
- Tri rapide (QuickSort) + partition.
- Synchroniser plusieurs tableaux lors d’un tri.

🧠 **Astuces**
- La recherche dichotomique exige un tableau **déjà trié**.
- En tri de 2 tableaux liés (ex: taille/poids), il faut permuter dans les **deux** tableaux.
- En récursif (QuickSort / dicho récursive), définis toujours un **cas d’arrêt** clair.
- Si l’énoncé demande seulement présence → `bool`; si modification/suppression ensuite → indice.
- Préfère `TryParse` quand la donnée peut être invalide (entrée utilisateur).
- Si tu utilises `Parse`, assure-toi que le format du fichier est garanti.
- Continue de remplir jusqu’à `nbElements` et retourne ce nombre pour éviter de traiter des cases nulles.
- N’oublie pas de fermer le lecteur (`Close`) après la lecture.

⚠️ **Pièges fréquents**
- Boucler sur `tab.Length` au lieu de `nbElements` quand le tableau est partiellement rempli.
- Oublier de décrémenter/incrémenter `nbElements` après suppression/insertion.
- Appeler une recherche dichotomique sur un tableau non trié.
- Trier un tableau principal sans synchroniser les tableaux liés.

Déclaration

```c#
Colis[] tabColis = new Colis[50]; // Réserve un tableau de 50 références vers des objets Colis.
int nbColis = 0; // Compte le nombre réel de cases utilisées dans le tableau.
```

## Recherche séquentielle

```c#
public static void LivrerColis(Colis[] tab, int nb, string codeRecherche)
{
    Colis cible = new Colis(codeRecherche);

    for (int i = 0; i < nb; i++)
    {
        if (tab[i].Equals(cible))
        {
            tab[i].Statut = "Le colis a été livré à destination.";
            return;
        }
    }
}
```

**🗝️ Éléments clés**
- Objet temporaire
- Equals
- return dès trouvé

---
## Lecture de fichiers

```c#
using System.IO; // Donne accès à StreamReader et aux opérations de lecture de fichier.

public static int LireFichier(Colis[] tab) // Lit le fichier et remplit le tableau de colis.
{ // Début de la méthode.
    StreamReader lecteur = new StreamReader("aLivrer.txt"); // Ouvre le fichier en lecture.

    int compteur = 0; // Nombre de colis effectivement lus.

    while (!lecteur.EndOfStream) // Continue tant qu'il reste des lignes à lire.
    { // Début de la boucle de lecture.
        string code = lecteur.ReadLine(); // Lit la ligne du code de repérage.
        string adresse = lecteur.ReadLine(); // Lit la ligne de l'adresse.
        double poids = double.Parse(lecteur.ReadLine()); // Lit puis convertit la ligne du poids.
        string statut = lecteur.ReadLine(); // Lit la ligne du statut.
        double valeur = double.Parse(lecteur.ReadLine()); // Lit puis convertit la ligne de la valeur.

        tab[compteur] = new Colis(code, adresse, poids, statut, valeur); // Crée l'objet Colis et le place dans le tableau.
        compteur++; // Passe à la prochaine case active.
    } // Fin de la boucle.

    lecteur.Close(); // Ferme le fichier après la lecture.
    return compteur; // Retourne le nombre réel de colis chargés.
} // Fin de la méthode.
```

**🗝️ Éléments clés**
- StreamReader
- while (!EndOfStream)
- ReadLine x5
- Parse
- Instanciation
- compteur++

---
## Passage par référence

🧠 **Astuces**
- `ref` est utile quand la méthode doit **modifier une variable existante** chez l’appelant.
- Pour un patron max/min, initialise avec le premier élément (`tab[0]`), puis compare à partir de `i = 1`.
- Ajoute une garde (`nb <= 0`) si le tableau peut être vide en contexte réel.

⚠️ **Pièges fréquents**
- Oublier `ref` dans la **signature** ou dans l’**appel** (il faut les deux).
- Utiliser `tab[0]` sans vérifier que `nb > 0`.
- Croire que `ref` est obligatoire pour modifier le contenu d’un tableau (faux : pour les éléments, non).

```c#
public static void PlusLourd(Colis[] tab, int nb, ref Colis max) // Reçoit le tableau, le nombre actif et une référence vers la variable résultat.
{ // Début de la méthode.
    if (nb <= 0) // Sécurise le cas d'un tableau vide (aucun colis actif).
        return; // Quitte sans modifier max si rien à comparer.

    max = tab[0]; // Initialise le plus lourd avec le premier colis actif.

    for (int i = 1; i < nb; i++) // Parcourt les autres colis à partir du 2e.
    { // Début de la boucle de comparaison.
        if (tab[i].Poids > max.Poids) // Si le colis courant est plus lourd que le max actuel.
            max = tab[i]; // Met à jour la référence du plus lourd.
    } // Fin de la boucle.
} // Fin de la méthode.
```

Appel: 

```c#
Colis plusLourd = null; // Variable qui recevra le résultat via ref.
PlusLourd(tabColis, nbColis, ref plusLourd); // Appel avec ref obligatoire pour permettre la modification.

if (plusLourd != null) // Vérifie qu'un résultat a bien été trouvé.
    Console.WriteLine(plusLourd.Statut); // Affiche le statut du colis le plus lourd.
```

🧠 **À retenir (exam)**
- Par défaut, les paramètres sont passés par valeur (copie locale).
- `ref` : variable initialisée avant l’appel; `out` : initialisation dans la méthode.
- Pour retourner plusieurs infos d’un coup, `out` est souvent la solution la plus simple.
- Un tableau passé en paramètre peut voir son contenu modifié sans `ref`.

### Quand choisir `ref` ou `out` ?

- Utilise `ref` si la variable a déjà une valeur utile avant l’appel.
- Utilise `out` si la méthode doit obligatoirement produire la valeur.
- Si tu veux seulement modifier des objets **dans** un tableau, pas besoin de `ref` sur le tableau.

---
## Formatage (Console.WriteLine)

### Tableau complet des formats

| Type | Format | Signification | Exemple d’expression | Résultat typique* |
| --- | --- | --- | --- | --- |
| Numérique | `C` / `C2` | Monnaie (avec symbole local) | `{montant:C}` | `$1,234.50` |
| Numérique | `D` / `D5` | Entier décimal (zéros à gauche) | `{nb:D5}` | `00042` |
| Numérique | `E` / `E2` | Notation scientifique | `{val:E2}` | `1.23E+003` |
| Numérique | `F` / `F2` | Virgule fixe | `{val:F2}` | `1234.50` |
| Numérique | `G` | Format général (le plus compact) | `{val:G}` | `1234.5` |
| Numérique | `N` / `N2` | Nombre avec séparateurs de milliers | `{val:N2}` | `1,234.50` |
| Numérique | `P` / `P1` | Pourcentage (×100 à l’affichage) | `{ratio:P1}` | `27.5 %` |
| Numérique | `R` | Round-trip (précision max float/double) | `{val:R}` | `0.30000000000000004` |
| Numérique | `X` / `X4` | Hexadécimal (entiers) | `{nb:X4}` | `00FF` |
| Date/heure | `d` | Date courte | `{date:d}` | `2026-02-25` / `25/02/2026` |
| Date/heure | `D` | Date longue | `{date:D}` | `mercredi 25 février 2026` |
| Date/heure | `t` | Heure courte | `{date:t}` | `14:35` |
| Date/heure | `T` | Heure longue | `{date:T}` | `14:35:42` |
| Date/heure | `f` | Date longue + heure courte | `{date:f}` | `25 février 2026 14:35` |
| Date/heure | `g` | Date courte + heure courte | `{date:g}` | `25/02/2026 14:35` |
| Date/heure | `yyyy-MM-dd` | Patron personnalisé | `{date:yyyy-MM-dd}` | `2026-02-25` |
| Date/heure | `HH:mm:ss` | Heure personnalisée 24h | `{date:HH:mm:ss}` | `14:35:42` |
| Alignement | `{0,10}` | Aligne à droite (largeur 10) | `"|{0,10}|", nom` | `|       Alex|` |
| Alignement | `{0,-10}` | Aligne à gauche (largeur 10) | `"|{0,-10}|", nom` | `|Alex      |` |

\* Le rendu exact dépend de la culture active (`fr-CA`, `en-US`, etc.).

⚠️ **Pièges fréquents**
- Utiliser `P` avec `25` alors que tu voulais `25 %` (en `P`, la valeur attendue est souvent `0.25`).
- Oublier les accolades `{}` en interpolation (`$"..."`).
- Confondre interpolation (`$"...{var:format}..."`) et composite (`"...{0:format}...", var`).


### Interpolation moderne

```c#
double montant = 125.5; // Montant numérique à afficher.
double tauxTaxe = 0.14975; // Ratio (14.975 %) pour démontrer le format P.

Console.WriteLine($"Total: {montant:C}"); // C = format monétaire selon la culture active.
Console.WriteLine($"Montant fixe: {montant:F2}"); // F2 = 2 décimales fixes.
Console.WriteLine($"Taxe: {tauxTaxe:P}"); // P = pourcentage (0.14975 -> 14.98 %).
```

### Composite formatting

```c#
double montant = 125.5; // Valeur à injecter dans le patron de format.
double tauxTaxe = 0.14975; // Deuxième valeur pour démontrer plusieurs index.

Console.WriteLine("Total: {0:C}", montant); // {0:C} = argument d'indice 0 en format monnaie.
Console.WriteLine("Montant fixe: {0:F2}", montant); // {0:F2} = argument 0 avec 2 décimales.
Console.WriteLine("Taxe: {0:P}", tauxTaxe); // {0:P} = argument 0 en pourcentage.
Console.WriteLine("Résumé -> Total: {0:C} | Taxe: {1:P}", montant, tauxTaxe); // Utilise 2 index dans la même ligne.
```

🧠 **À retenir (exam)**
- Interpolation et composite font la même chose: choisis celle que tu lis le plus vite.
- `P` multiplie l’affichage par 100 automatiquement.
- Pour éviter les surprises de format, garde des valeurs cohérentes (`0.2` pour 20 %, pas `20`).

---
# Exemples

## Gestion de colis

### Données sur l'ensemble des colis

#### Compter colis livrés

📝 **Description** : Compte le nombre de colis dont le statut est `"Livré"`.

💡 **Astuce** : Patron typique de comptage à l’exam = `compteur = 0` puis `compteur++` dans le `if`.

```c#
public static int CompterLivres(Colis[] tab, int nb) // Méthode qui retourne le nombre de colis livrés.
{ // Début de la méthode.
    int compteur = 0; // Variable qui accumule le nombre de colis livrés.

    for (int i = 0; i < nb; i++) // Parcourt uniquement les cases actives du tableau.
    { // Début de la boucle de comptage.
        if (tab[i].Statut == "Livré") // Vérifie si le colis courant est marqué livré.
            compteur++; // Incrémente le compteur quand la condition est vraie.
    } // Fin de la boucle.

    return compteur; // Retourne le total de colis livrés.
} // Fin de la méthode.
```

### Retourner colis selon critères

#### Trouver le colis le plus cher

📝 **Description** : Retourne l’objet `Colis` ayant la plus grande valeur.

💡 **Astuce** : Toujours initialiser avec `tab[0]`, puis comparer à partir de `i = 1`.

⚠️ Piège exam : commencer à 1, pas 0.

```c#
public static Colis PlusCher(Colis[] tab, int nb) // Retourne le colis ayant la plus grande valeur.
{ // Début de la méthode.
    Colis max = tab[0]; // Initialise le maximum avec le premier colis actif.

    for (int i = 1; i < nb; i++) // Compare les autres colis à partir du 2e.
    { // Début de la boucle de comparaison.
        if (tab[i].Valeur > max.Valeur) // Si le colis courant vaut plus que le max actuel.
            max = tab[i]; // Met à jour la référence du colis maximum.
    } // Fin de la boucle.

    return max; // Retourne le colis le plus cher trouvé.
} // Fin de la méthode.
```
#### Retourner tous les colis lourds (> 20kg)

📝 **Description** : Compte combien de colis dépassent 20 kg.

💡 **Astuce** : Si l’énoncé demande « combien », pense immédiatement à un retour `int`.

```c#
public static int CompterLourds(Colis[] tab, int nb) // Compte les colis dont le poids dépasse 20.
{ // Début de la méthode.
    int compteur = 0; // Initialise le compteur à zéro.

    for (int i = 0; i < nb; i++) // Parcourt toutes les cases actives.
    { // Début de la boucle.
        if (tab[i].Poids > 20) // Vérifie si le colis courant est lourd (> 20 kg).
            compteur++; // Incrémente le compteur si la condition est vraie.
    } // Fin de la boucle.

    return compteur; // Retourne le nombre de colis lourds.
} // Fin de la méthode.
```

#### Retourner le colis le plus léger (avec ref)

📝 **Description** : Trouve le colis le plus léger et le renvoie via un paramètre `ref`.

💡 **Astuce** : `ref` est utile quand la méthode doit modifier une variable reçue en argument.

```c#
public static void PlusLeger(Colis[] tab, int nb, ref Colis min) // Place dans min le colis le plus léger.
{ // Début de la méthode.
    min = tab[0]; // Initialise min avec le premier colis actif.

    for (int i = 1; i < nb; i++) // Parcourt les autres colis.
    { // Début de la boucle de comparaison.
        if (tab[i].Poids < min.Poids) // Si le colis courant est plus léger que min.
            min = tab[i]; // Met à jour la référence du minimum.
    } // Fin de la boucle.
} // Fin de la méthode.
```

### Modifier le statut des colis

#### Modifier le statut d'un colis trouvé

📝 **Description** : Cherche un colis par code et met son statut à `"Livré"`.

💡 **Astuce** : Utilise `break` ou `return` dès la modification pour éviter du travail inutile.

```c#
public static void Livrer(Colis[] tab, int nb, string code) // Change le statut du colis trouvé en "Livré".
{ // Début de la méthode.
    for (int i = 0; i < nb; i++) // Parcourt les colis actifs.
    { // Début de la boucle de recherche.
        if (tab[i].Equals(new Colis(code))) // Compare le colis courant avec le code recherché.
        { // Début du bloc si trouvé.
            tab[i].Statut = "Livré"; // Met à jour le statut du colis trouvé.
            break; // Stoppe après modification
        } // Fin du bloc si trouvé.
    } // Fin de la boucle.
} // Fin de la méthode.
```

#### Annuler tous les colis

📝 **Description** : Applique le statut `"Annulé"` à tous les colis actifs du tableau.

💡 **Astuce** : Ici, aucun arrêt anticipé : il faut parcourir toute la boucle.

```c#
public static void AnnulerTout(Colis[] tab, int nb) // Met tous les colis actifs au statut annulé.
{ // Début de la méthode.
    for (int i = 0; i < nb; i++) // Parcourt chaque colis actif.
    { // Début de la boucle.
        tab[i].Statut = "Annulé"; // Applique le statut "Annulé" au colis courant.
    } // Fin de la boucle.
} // Fin de la méthode.
```


### Recherche d'un colis dans la table

#### Retour booléen
Colis présent dans la liste -> oui / non

📝 **Description** : Vérifie si un colis avec ce code existe au moins une fois.

💡 **Astuce** : Retourne `true` dès trouvé; sinon `false` à la fin.

```c#
public static bool Existe(Colis[] tab, int nb, string code) // Vérifie la présence d'un colis par code.
{ // Début de la méthode.
    for (int i = 0; i < nb; i++) // Parcourt les colis actifs.
    { // Début de la boucle de recherche.
        if (tab[i].Code == code) // Compare le code courant avec le code recherché.
            return true; // Retourne vrai dès qu'un match est trouvé.
    } // Fin de la boucle.

    return false; // Retourne faux si aucun colis ne correspond.
} // Fin de la méthode.
```

👉 Retourne **Oui ou Non**
- true → le colis existe
- false → il n’existe pas
❌ Pas d'information sur où il est, combien il y en a.
❌ Pas d'accès direct à l’objet

**Utilise bool si :**
- On te demande seulement de vérifier l’existence
- Aucun traitement supplémentaire n’est demandé

### Retour indice

📝 **Description** : Retourne la position du colis recherché dans le tableau.

💡 **Astuce** : La convention `-1` signifie « non trouvé » et simplifie les traitements après.


```c#
public static int TrouverIndice(Colis[] tab, int nb, string code) // Retourne l'indice du colis recherché.
{ // Début de la méthode.
    for (int i = 0; i < nb; i++) // Parcourt les colis actifs.
    { // Début de la boucle de recherche.
        // Compare le code du colis actuel avec le code recherché
        if (tab[i].Equals(new Colis(code))) // Vérifie si le colis courant correspond.
            return i; // On retourne l'indice dès qu'on trouve
    } // Fin de la boucle.

    return -1; // Convention : -1 signifie "non trouvé"
} // Fin de la méthode.
```

Utilise indice si :
- On demande de modifier le colis
- On demande de supprimer
- On demande d’afficher info précise
- On demande d’utiliser ref

### Supprimer un colis (décalage du tableau)

📝 **Description** : Supprime un colis en décalant tous les éléments à gauche.

💡 **Astuce** : Après le décalage, pense à faire `nb--` pour garder un nombre d’éléments valide.

```c#
public static void Supprimer(Colis[] tab, ref int nb, string code) // Supprime un colis et compacte le tableau.
{ // Début de la méthode.
    int indice = TrouverIndice(tab, nb, code); // Cherche l'indice du colis à supprimer.

    if (indice == -1) // Vérifie si le colis est absent.
        return; // Quitte sans rien modifier si non trouvé.

    // Décale tous les éléments vers la gauche
    for (int i = indice; i < nb - 1; i++) // Recolle les éléments à partir de l'indice supprimé.
    { // Début de la boucle de décalage.
        tab[i] = tab[i + 1]; // Copie l'élément de droite vers la case courante.
    } // Fin de la boucle.

    nb--; // Important : on réduit le nombre d'éléments actifs
} // Fin de la méthode.
```


### Lecture sécurisée avec TryParse

📝 **Description** : Valide une saisie numérique sans provoquer d’exception.

💡 **Astuce** : Préfère `TryParse` à `Parse` quand la saisie vient de l’utilisateur.

```c#
double poids; // Variable qui recevra la valeur convertie.
if (double.TryParse(Console.ReadLine(), out poids)) // Tente de lire et convertir l'entrée en double.
{ // Début du cas valide.
    Console.WriteLine("Poids valide"); // Confirme que la conversion a réussi.
} // Fin du cas valide.
else // Cas où la conversion échoue.
{ // Début du cas invalide.
    Console.WriteLine("Erreur de saisie"); // Affiche un message d'erreur.
} // Fin du cas invalide.
```

## Gestion de bibliothèque

### Constructeurs (classe `Livre`)

#### Constructeur complet

📝 **Description** : Initialise tous les champs nécessaires à la création d’un livre.

💡 **Astuce** : En exam, c’est le constructeur principal le plus demandé.

```c#
public Livre(string isbn, string titre, string auteur, int nbExemplaires) // Constructeur complet d'un livre.
{ // Début du constructeur.
    this.isbn = isbn; // Initialise l'identifiant ISBN.
    this.titre = titre; // Initialise le titre du livre.
    this.auteur = auteur; // Initialise le nom de l'auteur.
    this.nbExemplaires = nbExemplaires; // Initialise le nombre d'exemplaires.
    this.statut = "Disponible"; // Définit le statut initial.
} // Fin du constructeur.
```

#### Constructeur partiel (valeurs par défaut)

📝 **Description** : Reçoit moins d’informations et complète avec des valeurs par défaut.

💡 **Astuce** : Très utile quand l’énoncé dit « si info manquante, mettre valeur par défaut ».

```c#
public Livre(string isbn, string titre) // Constructeur partiel avec valeurs par défaut.
{ // Début du constructeur.
    this.isbn = isbn; // Initialise l'identifiant ISBN.
    this.titre = titre; // Initialise le titre.
    this.auteur = "Inconnu"; // Assigne une valeur par défaut à l'auteur.
    this.nbExemplaires = 1; // Assigne un stock initial par défaut.
    this.statut = "Disponible"; // Assigne le statut initial.
} // Fin du constructeur.
```

#### Constructeur minimal (comparaison)

📝 **Description** : Sert surtout pour les recherches/comparaisons avec `Equals`.

💡 **Astuce** : Garde uniquement le champ clé (ici `isbn`).

```c#
public Livre(string isbn) // Constructeur minimal pour comparaison/recherche.
{ // Début du constructeur minimal.
    this.isbn = isbn; // Initialise uniquement la clé de comparaison.
} // Fin du constructeur minimal.
```

### Redéfinition de `Equals`

📝 **Description** : Deux livres sont considérés égaux s’ils ont le même ISBN.

💡 **Astuce** : Pattern classique: test `null`, test du type, cast, comparaison du champ clé.

```c#
public override bool Equals(object obj) // Redéfinit l'égalité logique de Livre.
{ // Début de Equals.
    if (obj == null || !(obj is Livre)) // Vérifie null et le type attendu.
        return false; // Retourne faux si l'objet ne peut pas être comparé.

    Livre autre = (Livre)obj; // Convertit l'objet reçu vers le type Livre.

    return this.isbn == autre.isbn; // Compare les ISBN pour décider l'égalité.
} // Fin de Equals.
```

### Recherche dans un tableau

#### Retour booléen

📝 **Description** : Vérifie si un livre existe déjà dans la collection.

💡 **Astuce** : Utilise ce format quand on te demande juste « existe / n’existe pas ».

```c#
public static bool ExisteLivre(Livre[] tab, int nb, string isbn) // Vérifie la présence d'un livre par ISBN.
{ // Début de la méthode.
    for (int i = 0; i < nb; i++) // Parcourt les livres actifs.
    { // Début de la boucle de recherche.
        if (tab[i].ISBN == isbn) // Compare l'ISBN courant avec la valeur recherchée.
            return true; // Retourne vrai dès qu'un livre correspond.
    } // Fin de la boucle.

    return false; // Retourne faux si aucun livre n'est trouvé.
} // Fin de la méthode.
```

#### Retour indice

📝 **Description** : Retourne la position du livre, sinon `-1`.

💡 **Astuce** : L’indice est parfait si l’étape suivante est une modification ou une suppression.

```c#
public static int TrouverIndiceLivre(Livre[] tab, int nb, string isbn) // Retourne l'indice d'un livre par ISBN.
{ // Début de la méthode.
    for (int i = 0; i < nb; i++) // Parcourt la partie active du tableau.
    { // Début de la boucle de recherche.
        if (tab[i].Equals(new Livre(isbn))) // Compare le livre courant avec un objet-clé.
            return i; // Retourne l'indice dès qu'un match est trouvé.
    } // Fin de la boucle.

    return -1; // Retourne -1 si aucun livre ne correspond.
} // Fin de la méthode.
```

### Modifier un élément trouvé

#### Emprunter un livre

📝 **Description** : Passe un livre au statut emprunté et décrémente le stock.

💡 **Astuce** : Vérifie toujours les deux conditions: livre trouvé **et** stock disponible.

```c#
public static void EmprunterLivre(Livre[] tab, int nb, string isbn) // Emprunte un livre si disponible.
{ // Début de la méthode.
    int indice = TrouverIndiceLivre(tab, nb, isbn); // Cherche le livre ciblé.

    if (indice == -1) // Vérifie si le livre est introuvable.
        return; // Quitte immédiatement si absent.

    if (tab[indice].NbExemplaires <= 0) // Vérifie s'il reste du stock.
        return; // Quitte si aucun exemplaire n'est disponible.

    tab[indice].NbExemplaires--; // Décrémente le stock après emprunt.
    tab[indice].Statut = "Emprunté"; // Met à jour le statut du livre.
} // Fin de la méthode.
```


## Gestion d'étudiants

### Données sur l'ensemble des étudiants

#### Compter les étudiants en réussite (>= 60)

📝 **Description** : Compte le nombre d’étudiants ayant une note finale d’au moins 60.

💡 **Astuce** : Le seuil (`>= 60`) est souvent un critère explicite dans l’énoncé.

```c#
public static int CompterReussites(Etudiant[] tab, int nb) // Compte les étudiants ayant réussi.
{ // Début de la méthode.
    int compteur = 0; // Initialise le compteur de réussites.

    for (int i = 0; i < nb; i++) // Parcourt les étudiants actifs.
    { // Début de la boucle de comptage.
        if (tab[i].NoteFinale >= 60) // Vérifie si la note finale atteint le seuil de réussite.
            compteur++; // Incrémente le nombre de réussites.
    } // Fin de la boucle.

    return compteur; // Retourne le total des étudiants en réussite.
} // Fin de la méthode.
```

#### Trouver l'étudiant avec la meilleure note

📝 **Description** : Retourne l’étudiant qui possède la note finale maximale.

💡 **Astuce** : C’est le même patron que max/min des colis; seul le champ comparé change.

```c#
public static Etudiant Meilleur(Etudiant[] tab, int nb) // Retourne l'étudiant avec la meilleure note.
{ // Début de la méthode.
    Etudiant max = tab[0]; // Initialise le maximum avec le premier étudiant.

    for (int i = 1; i < nb; i++) // Compare les autres étudiants à partir du 2e.
    { // Début de la boucle de comparaison.
        if (tab[i].NoteFinale > max.NoteFinale) // Vérifie si la note courante dépasse le max actuel.
            max = tab[i]; // Met à jour l'étudiant ayant la meilleure note.
    } // Fin de la boucle.

    return max; // Retourne l'étudiant trouvé.
} // Fin de la méthode.
```

### Modifier des données

#### Ajouter un bonus à tous les étudiants

📝 **Description** : Ajoute un bonus à chaque note finale, avec plafond à 100.

💡 **Astuce** : Ajouter une borne (`if > 100`) montre une bonne gestion des contraintes métier.

```c#
public static void AjouterBonus(Etudiant[] tab, int nb, double bonus) // Ajoute un bonus à chaque note.
{ // Début de la méthode.
    for (int i = 0; i < nb; i++) // Parcourt tous les étudiants actifs.
    { // Début de la boucle de mise à jour.
        tab[i].NoteFinale += bonus; // Ajoute le bonus à la note de l'étudiant courant.

        if (tab[i].NoteFinale > 100) // Vérifie si la note dépasse la borne maximale.
            tab[i].NoteFinale = 100; // Applique un plafond à 100.
    } // Fin de la boucle.
} // Fin de la méthode.
```

#### Modifier la note d'un étudiant par matricule

📝 **Description** : Met à jour la note d’un étudiant précis identifié par son matricule.

💡 **Astuce** : `return` dès la modification évite de continuer la recherche inutilement.

```c#
public static void ModifierNote(Etudiant[] tab, int nb, string matricule, double nouvelleNote) // Modifie la note d'un étudiant ciblé.
{ // Début de la méthode.
    for (int i = 0; i < nb; i++) // Parcourt les étudiants actifs.
    { // Début de la boucle de recherche.
        if (tab[i].Matricule == matricule) // Vérifie si le matricule courant correspond.
        { // Début du bloc si trouvé.
            tab[i].NoteFinale = nouvelleNote; // Met à jour la note finale.
            return; // Arrête dès que la modification est effectuée.
        } // Fin du bloc si trouvé.
    } // Fin de la boucle.
} // Fin de la méthode.
```

### Recherche dans la table

#### Retour booléen (présence)

📝 **Description** : Indique si un matricule est présent dans le tableau.

💡 **Astuce** : Utilise `bool` quand l’énoncé ne demande ni indice ni objet.

```c#
public static bool ExisteEtudiant(Etudiant[] tab, int nb, string matricule) // Vérifie la présence d'un matricule.
{ // Début de la méthode.
    for (int i = 0; i < nb; i++) // Parcourt le tableau actif des étudiants.
    { // Début de la boucle de recherche.
        if (tab[i].Matricule == matricule) // Compare le matricule courant avec celui recherché.
            return true; // Retourne vrai dès qu'un étudiant est trouvé.
    } // Fin de la boucle.

    return false; // Retourne faux si aucun étudiant ne correspond.
} // Fin de la méthode.
```

#### Retour indice (position)

📝 **Description** : Donne l’indice de l’étudiant recherché pour permettre une action ensuite.

💡 **Astuce** : Très utile avant un `Supprimer(...)`, `Modifier(...)` ou un affichage ciblé.

```c#
public static int TrouverIndiceEtudiant(Etudiant[] tab, int nb, string matricule) // Retourne la position d'un étudiant.
{ // Début de la méthode.
    for (int i = 0; i < nb; i++) // Parcourt les étudiants actifs.
    { // Début de la boucle de recherche.
        if (tab[i].Matricule == matricule) // Vérifie la correspondance sur le matricule.
            return i; // Retourne l'indice dès qu'un match est trouvé.
    } // Fin de la boucle.

    return -1; // Convention non trouvé.
} // Fin de la méthode.
```

### Lecture sécurisée avec TryParse (notes)

📝 **Description** : Contrôle qu’une entrée clavier est bien une note numérique.

💡 **Astuce** : En exam, `TryParse` + message d’erreur clair = points faciles en robustesse.

```c#
double note; // Variable qui recevra la valeur convertie.
if (double.TryParse(Console.ReadLine(), out note)) // Tente de convertir l'entrée utilisateur en note numérique.
{ // Début du cas valide.
    Console.WriteLine("Note valide"); // Confirme que la note est bien numérique.
} // Fin du cas valide.
else // Cas où la conversion échoue.
{ // Début du cas invalide.
    Console.WriteLine("Entrée invalide"); // Informe que l'entrée n'est pas valide.
} // Fin du cas invalide.
```

## Gestion de comptes bancaires

### Constructeurs (classe `CompteBancaire`)

#### Constructeur complet

📝 **Description** : Initialise toutes les informations d’un compte.

💡 **Astuce** : C’est le format standard si l’énoncé fournit toutes les données.

```c#
public CompteBancaire(string numero, string titulaire, double solde) // Constructeur complet d'un compte bancaire.
{ // Début du constructeur.
    this.numero = numero; // Initialise le numéro de compte.
    this.titulaire = titulaire; // Initialise le titulaire du compte.
    this.solde = solde; // Initialise le solde.
    this.statut = "Actif"; // Définit le statut initial du compte.
} // Fin du constructeur.
```

#### Constructeur partiel (solde par défaut)

📝 **Description** : Crée un compte avec un solde initial par défaut.

💡 **Astuce** : Très utile quand l’énoncé précise « si absent, considérer 0 ».

```c#
public CompteBancaire(string numero, string titulaire) // Constructeur partiel avec solde initial par défaut.
{ // Début du constructeur.
    this.numero = numero; // Initialise le numéro de compte.
    this.titulaire = titulaire; // Initialise le titulaire.
    this.solde = 0; // Assigne un solde initial de 0.
    this.statut = "Actif"; // Définit le statut initial du compte.
} // Fin du constructeur.
```

#### Constructeur minimal (comparaison)

📝 **Description** : Sert aux recherches/comparaisons selon le numéro de compte.

💡 **Astuce** : Réutilisable directement avec `Equals(new CompteBancaire(numero))`.

```c#
public CompteBancaire(string numero) // Constructeur minimal pour recherche/comparaison.
{ // Début du constructeur minimal.
    this.numero = numero; // Initialise uniquement la clé de comparaison.
} // Fin du constructeur minimal.
```

### Méthodes utiles d’examen

#### Dépôt (validation simple)

📝 **Description** : Ajoute un montant au solde seulement si le montant est positif.

💡 **Astuce** : Toujours valider les entrées (`<= 0`) avant de modifier les données.

```c#
public static void Depot(CompteBancaire[] tab, int nb, string numero, double montant) // Dépose un montant sur un compte.
{ // Début de la méthode.
    int indice = TrouverIndiceCompte(tab, nb, numero); // Cherche la position du compte cible.

    if (indice == -1 || montant <= 0) // Vérifie que le compte existe et que le montant est valide.
        return; // Quitte sans modification si condition invalide.

    tab[indice].Solde += montant; // Ajoute le montant au solde du compte.
} // Fin de la méthode.
```

#### Retrait (avec vérification de fonds)

📝 **Description** : Retire un montant seulement si le compte existe et a assez d’argent.

💡 **Astuce** : Condition classique d’exam : `montant > 0` **et** `solde >= montant`.

```c#
public static bool Retrait(CompteBancaire[] tab, int nb, string numero, double montant) // Tente de retirer un montant d'un compte.
{ // Début de la méthode.
    int indice = TrouverIndiceCompte(tab, nb, numero); // Trouve le compte concerné.

    if (indice == -1 || montant <= 0) // Valide existence du compte et montant positif.
        return false; // Échec immédiat si condition invalide.

    if (tab[indice].Solde < montant) // Vérifie la disponibilité des fonds.
        return false; // Échec si solde insuffisant.

    tab[indice].Solde -= montant; // Effectue le retrait du solde.
    return true; // Indique que l'opération a réussi.
} // Fin de la méthode.
```

#### Retour indice (recherche)

📝 **Description** : Retourne la position d’un compte à partir de son numéro.

💡 **Astuce** : Garde la convention `-1` pour simplifier les traitements suivants.

```c#
public static int TrouverIndiceCompte(CompteBancaire[] tab, int nb, string numero) // Retourne l'indice du compte recherché.
{ // Début de la méthode.
    for (int i = 0; i < nb; i++) // Parcourt les comptes actifs.
    { // Début de la boucle de recherche.
        if (tab[i].Equals(new CompteBancaire(numero))) // Compare le compte courant avec la clé numéro.
            return i; // Retourne l'indice dès correspondance.
    } // Fin de la boucle.

    return -1; // Retourne -1 si le compte est absent.
} // Fin de la méthode.
```

#### Transfert entre deux comptes

📝 **Description** : Déplace un montant d’un compte source vers un compte destination.

💡 **Astuce** : Réutilise `Retrait` puis `Depot` pour éviter de dupliquer la logique.

```c#
public static bool Transferer(CompteBancaire[] tab, int nb, string source, string destination, double montant) // Transfère un montant entre deux comptes.
{ // Début de la méthode.
    if (!Retrait(tab, nb, source, montant)) // Tente d'abord de débiter le compte source.
        return false; // Échec du transfert si le retrait échoue.

    Depot(tab, nb, destination, montant); // Crédite ensuite le compte destination.
    return true; // Confirme que le transfert est complété.
} // Fin de la méthode.
```

#### Trouver le compte avec le plus grand solde

📝 **Description** : Retourne le compte ayant le solde maximal.

💡 **Astuce** : Même patron max/min : init `tab[0]`, boucle dès `i = 1`.

```c#
public static CompteBancaire PlusRiche(CompteBancaire[] tab, int nb) // Retourne le compte avec le solde maximal.
{ // Début de la méthode.
    CompteBancaire max = tab[0]; // Initialise le maximum avec le premier compte actif.

    for (int i = 1; i < nb; i++) // Compare les autres comptes à partir du 2e.
    { // Début de la boucle de comparaison.
        if (tab[i].Solde > max.Solde) // Vérifie si le solde courant dépasse le max actuel.
            max = tab[i]; // Met à jour la référence du compte le plus riche.
    } // Fin de la boucle.

    return max; // Retourne le compte trouvé.
} // Fin de la méthode.
```

## Gestion de réservations de salles

### Méthodes un peu moins fréquentes mais utiles

#### Insertion ordonnée (par heure)

📝 **Description** : Insère une réservation dans un tableau déjà trié par `HeureDebut`.

💡 **Astuce** : Pattern important : chercher la position, décaler à droite, insérer, puis `nb++`.

```c#
public static void InsererOrdreHeure(Reservation[] tab, ref int nb, Reservation nouvelle) // Insère une réservation dans un tableau trié.
{ // Début de la méthode.
    int pos = 0; // Position d'insertion initiale.

    while (pos < nb && tab[pos].HeureDebut <= nouvelle.HeureDebut) // Cherche la première position où insérer.
    { // Début de la recherche de position.
        pos++; // Avance tant que l'ordre est respecté.
    } // Fin de la recherche.

    for (int i = nb; i > pos; i--) // Décale à droite pour libérer une case.
    { // Début de la boucle de décalage.
        tab[i] = tab[i - 1]; // Copie l'élément de gauche vers la droite.
    } // Fin de la boucle.

    tab[pos] = nouvelle; // Place la nouvelle réservation au bon endroit.
    nb++; // Met à jour le nombre d'éléments actifs.
} // Fin de la méthode.
```

#### Supprimer toutes les réservations annulées (compactage)

📝 **Description** : Retire toutes les réservations annulées sans créer un nouveau tableau.

💡 **Astuce** : Technique à 2 indices (`lecture` / `ecriture`) très rentable à l’exam.

```c#
public static void SupprimerAnnulees(Reservation[] tab, ref int nb) // Supprime en place les réservations annulées.
{ // Début de la méthode.
    int ecriture = 0; // Indice où recopier les éléments à conserver.

    for (int lecture = 0; lecture < nb; lecture++) // Parcourt chaque réservation active.
    { // Début de la boucle de compactage.
        if (tab[lecture].Statut != "Annulée") // Garde seulement les réservations non annulées.
        { // Début du bloc de copie.
            tab[ecriture] = tab[lecture]; // Recopie l'élément conservé vers la gauche.
            ecriture++; // Avance la prochaine position d'écriture.
        } // Fin du bloc de copie.
    } // Fin de la boucle.

    nb = ecriture; // Nouveau nombre d'éléments actifs après compactage.
} // Fin de la méthode.
```

#### Retourner plusieurs statistiques avec `out`

📝 **Description** : Calcule en un seul passage le nombre de réservations confirmées et annulées.

💡 **Astuce** : Utilise `out` quand l’énoncé veut plusieurs résultats sans créer de classe.

```c#
public static void CompterStatuts(Reservation[] tab, int nb, out int nbConfirmees, out int nbAnnulees) // Retourne deux statistiques via out.
{ // Début de la méthode.
    nbConfirmees = 0; // Initialise le compteur des réservations confirmées.
    nbAnnulees = 0; // Initialise le compteur des réservations annulées.

    for (int i = 0; i < nb; i++) // Parcourt toutes les réservations actives.
    { // Début de la boucle de comptage.
        if (tab[i].Statut == "Confirmée") // Vérifie le statut confirmée.
            nbConfirmees++; // Incrémente le compteur des confirmées.
        else if (tab[i].Statut == "Annulée") // Vérifie le statut annulée.
            nbAnnulees++; // Incrémente le compteur des annulées.
    } // Fin de la boucle.
} // Fin de la méthode.
```

#### Copier seulement les réservations d’une salle donnée

📝 **Description** : Copie dans un 2e tableau les réservations correspondant à un numéro de salle.

💡 **Astuce** : Méthode pratique pour filtrer sans modifier le tableau original.

```c#
public static int CopierParSalle(Reservation[] source, int nbSource, Reservation[] destination, int noSalle) // Copie les réservations d'une salle donnée.
{ // Début de la méthode.
    int nbDest = 0; // Compte le nombre d'éléments copiés.

    for (int i = 0; i < nbSource; i++) // Parcourt le tableau source actif.
    { // Début de la boucle de filtrage.
        if (source[i].NoSalle == noSalle) // Vérifie si la réservation correspond à la salle demandée.
        { // Début du bloc de copie.
            destination[nbDest] = source[i]; // Copie la réservation dans le tableau destination.
            nbDest++; // Avance l'indice de la prochaine case destination.
        } // Fin du bloc de copie.
    } // Fin de la boucle.

    return nbDest; // Retourne le nombre de réservations copiées.
} // Fin de la méthode.
```

#### Inverser l’ordre d’un tableau actif

📝 **Description** : Inverse les réservations entre `0` et `nb - 1`.

💡 **Astuce** : Patron classique avec deux index (`gauche`/`droite`) et variable temporaire.

```c#
public static void InverserOrdre(Reservation[] tab, int nb) // Inverse l'ordre des éléments actifs du tableau.
{ // Début de la méthode.
    int gauche = 0; // Index du début.
    int droite = nb - 1; // Index de fin de la zone active.

    while (gauche < droite) // Continue tant que les index ne se croisent pas.
    { // Début de la boucle d'inversion.
        Reservation temp = tab[gauche]; // Sauvegarde la valeur de gauche.
        tab[gauche] = tab[droite]; // Copie la valeur de droite à gauche.
        tab[droite] = temp; // Place l'ancienne valeur gauche à droite.

        gauche++; // Avance l'index gauche vers le centre.
        droite--; // Recule l'index droit vers le centre.
    } // Fin de la boucle.
} // Fin de la méthode.
```

## Gestion d'inventaire d'entrepôt

### Méthodes utiles d’examen

#### Retour indice (recherche par code)

📝 **Description** : Retourne l’indice d’un produit à partir de son code, sinon `-1`.

💡 **Astuce** : Patron très utile avant `Modifier`, `Supprimer` ou `Approvisionner`.

```c#
public static int TrouverIndiceProduit(Produit[] tab, int nb, string code) // Cherche la position d'un produit par son code.
{ // Début de la méthode.
    for (int i = 0; i < nb; i++) // Parcourt uniquement les produits actifs.
    { // Début de la boucle de recherche.
        if (tab[i].Equals(new Produit(code))) // Compare le produit courant avec un produit-clé.
            return i; // Retourne l'indice dès qu'un match est trouvé.
    } // Fin de la boucle.

    return -1; // Convention : -1 signifie "non trouvé".
} // Fin de la méthode.
```

#### Approvisionner un produit

📝 **Description** : Ajoute une quantité au stock d’un produit existant.

💡 **Astuce** : Valide l’indice trouvé **et** la quantité (`> 0`) avant de modifier.

```c#
public static bool Approvisionner(Produit[] tab, int nb, string code, int quantite) // Ajoute du stock à un produit.
{ // Début de la méthode.
    int indice = TrouverIndiceProduit(tab, nb, code); // Récupère la position du produit ciblé.

    if (indice == -1 || quantite <= 0) // Vérifie que le produit existe et que la quantité est valide.
        return false; // Échec de l'opération si condition invalide.

    tab[indice].Quantite += quantite; // Incrémente la quantité en stock.
    return true; // Confirme que l'approvisionnement a réussi.
} // Fin de la méthode.
```

#### Compter les produits sous le seuil minimal

📝 **Description** : Compte les produits dont la quantité est inférieure au seuil donné.

💡 **Astuce** : Quand l’énoncé dit « combien », le retour `int` est souvent le bon choix.

```c#
public static int CompterSousSeuil(Produit[] tab, int nb, int seuil) // Compte les produits en bas stock.
{ // Début de la méthode.
    int compteur = 0; // Initialise le nombre de produits sous le seuil.

    for (int i = 0; i < nb; i++) // Parcourt les produits actifs.
    { // Début de la boucle de comptage.
        if (tab[i].Quantite < seuil) // Vérifie si la quantité courante est sous le seuil.
            compteur++; // Incrémente le compteur.
    } // Fin de la boucle.

    return compteur; // Retourne le total de produits sous le seuil.
} // Fin de la méthode.
```

#### Supprimer les produits en rupture (compactage)

📝 **Description** : Retire du tableau les produits avec quantité `0` sans créer un nouveau tableau.

💡 **Astuce** : Technique à deux indices (`lecture`/`ecriture`) = très payante à l’exam.

```c#
public static void SupprimerRuptures(Produit[] tab, ref int nb) // Supprime en place les produits en rupture.
{ // Début de la méthode.
    int ecriture = 0; // Position où recopier les produits conservés.

    for (int lecture = 0; lecture < nb; lecture++) // Parcourt tous les produits actifs.
    { // Début de la boucle de compactage.
        if (tab[lecture].Quantite > 0) // Garde seulement les produits encore en stock.
        { // Début du bloc de copie.
            tab[ecriture] = tab[lecture]; // Recopie le produit conservé vers la gauche.
            ecriture++; // Avance la prochaine position d'écriture.
        } // Fin du bloc de copie.
    } // Fin de la boucle.

    nb = ecriture; // Met à jour le nombre réel d'éléments actifs.
} // Fin de la méthode.
```

#### Retourner plusieurs statistiques avec `out`

📝 **Description** : Calcule en un seul passage le nombre de ruptures et la valeur totale du stock.

💡 **Astuce** : Utilise `out` quand l’énoncé demande plusieurs résultats sans créer de classe de retour.

```c#
public static void StatsInventaire(Produit[] tab, int nb, out int nbRuptures, out double valeurTotale) // Produit 2 résultats via out.
{ // Début de la méthode.
    nbRuptures = 0; // Initialise le nombre de produits en rupture.
    valeurTotale = 0; // Initialise l'accumulateur de valeur totale.

    for (int i = 0; i < nb; i++) // Parcourt les produits actifs.
    { // Début de la boucle de calcul.
        if (tab[i].Quantite == 0) // Vérifie si le produit est en rupture.
            nbRuptures++; // Incrémente le nombre de ruptures.

        valeurTotale += tab[i].Quantite * tab[i].PrixUnitaire; // Ajoute la valeur du stock du produit courant.
    } // Fin de la boucle.
} // Fin de la méthode.
```

## 

---
# ⚠️ Erreurs à éviter
- Oublier override
- Oublier cast dans Equals
- Modifier tableau au lieu de l’objet
- Oublier ref à l’appel
- Ne pas fermer StreamReader
- Mauvais type double.Parse vs int.Parse
- Mauvais test dans boucle
