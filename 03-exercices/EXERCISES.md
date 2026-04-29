# 🏋️ Exercices — Index

Pratique progressive pour chaque module. Trois niveaux par module :
🟢 **Échauffement** · 🟡 **Application** · 🔴 **Défi**.

## 📑 Modules

| #   | Module                                                | Theory                                             | Examples                                             |
| --- | ----------------------------------------------------- | -------------------------------------------------- | ---------------------------------------------------- |
| 01  | [Fondamentaux](01-fundamentals/README.md)             | [→](../01-theory/01-fundamentals/README.md)        | [→](../02-examples/01-fundamentals/README.md)        |
| 02  | [Types & variables](02-types-and-variables/README.md) | [→](../01-theory/02-types-and-variables/README.md) | [→](../02-examples/02-types-and-variables/README.md) |
| 03  | [E/S & formatage](03-io-and-formatting/README.md)     | [→](../01-theory/03-io-and-formatting/README.md)   | [→](../02-examples/03-io-and-formatting/README.md)   |
| 04  | [Structures de contrôle](04-control-flow/README.md)   | [→](../01-theory/04-control-flow/README.md)        | [→](../02-examples/04-control-flow/README.md)        |
| 05  | [Boucles](05-loops/README.md)                         | [→](../01-theory/05-loops/README.md)               | [→](../02-examples/05-loops/README.md)               |
| 06  | [Méthodes](06-methods/README.md)                      | [→](../01-theory/06-methods/README.md)             | [→](../02-examples/06-methods/README.md)             |
| 07  | [POO — Classes](07-oop-classes/README.md)             | [→](../01-theory/07-oop-classes/README.md)         | [→](../02-examples/07-oop-classes/README.md)         |
| 08  | [POO — Polymorphisme](08-oop-polymorphism/README.md)  | [→](../01-theory/08-oop-polymorphism/README.md)    | [→](../02-examples/08-oop-polymorphism/README.md)    |
| 09  | [Tableaux](09-arrays/README.md)                       | [→](../01-theory/09-arrays/README.md)              | [→](../02-examples/09-arrays/README.md)              |
| 10  | [Recherche & tri](10-search-and-sort/README.md)       | [→](../01-theory/10-search-and-sort/README.md)     | [→](../02-examples/10-search-and-sort/README.md)     |
| 11  | [Fichiers (E/S)](11-file-io/README.md)                | [→](../01-theory/11-file-io/README.md)             | [→](../02-examples/11-file-io/README.md)             |
| 12  | [WinForms](12-winforms/README.md)                     | [→](../01-theory/12-winforms/README.md)            | [→](../02-examples/12-winforms/README.md)            |

## 🎯 Méthode de travail

1. **Lire la théorie** du module avant d'attaquer les exercices.
2. **Tenter l'exercice sans regarder l'exemple** (récupération active).
3. **Comparer** sa solution avec l'exemple correspondant.
4. **Identifier l'écart** et noter la leçon dans ses notes personnelles.
5. **Refaire l'exercice 24-48 h plus tard** (espacement) pour ancrer.

## 🧰 Ressources transversales

- 📖 [Glossaire](../01-theory/GLOSSARY.md) — termes C# / .NET.
- 🧠 [Concepts](../01-theory/concepts/README.md) — fiches qui clarifient les distinctions souvent confondues (classe, méthode, fonction, procédure, trigger…).
- 📋 [Cheatsheets](../01-theory/cheatsheets/README.md) — pense-bêtes condensés à garder ouverts pendant les exercices.

## 🧪 Création de projet pour un exercice

Depuis la racine du dépôt :

```bash
dotnet new console -n MonExo -o 03-exercices/<module>/<exo-slug>/MonExo
```

