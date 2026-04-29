# VS Code Configuration for C# Learning Hub

Ce dossier contient toutes les configurations VS Code optimisées pour l'apprentissage de C# et .NET.

## 📁 Fichiers de configuration

### `extensions.json`
Extensions recommandées pour le développement C#/.NET :
- **C# Dev Kit** - Suite complète pour le développement C#
- **C#** - Support du langage et IntelliSense
- **Test Explorer** - Interface pour exécuter les tests
- **Markdown** - Pour la documentation
- **Error Lens** - Affichage inline des erreurs
- **GitLens** - Contrôle de version avancé

### `settings.json`
Paramètres optimisés incluant :
- **Formatage automatique** à la sauvegarde
- **Règles de 120 caractères** pour C#
- **Organisation automatique des imports**
- **Exclusion des dossiers bin/obj** de la recherche
- **Configuration markdown** pour la documentation
- **Spell checker** anglais/français
- **TODO Tree** personnalisé avec tags LEARN et EXERCISE

### `launch.json`
Configurations de débogage prêtes :
- **Console Launch** - Pour déboguer des exemples
- **Exercise Launch** - Pour déboguer des exercices
- **Current File** - Pour déboguer le fichier actuel
- **Attach** - Pour attacher à un processus existant

### `tasks.json`
Tâches automatisées pour :
- **Build/Clean/Rebuild** - Compilation du projet
- **Test/Test with Coverage** - Exécution des tests
- **Create Projects** - Création rapide de nouveaux projets
- **Format** - Formatage du code
- **Documentation** - Lint markdown
- **Utilities** - Nettoyage, liste des projets

### `csharp.code-snippets`
Snippets de code pour accélérer l'apprentissage :
- **Structures de base** : classes, propriétés, méthodes
- **Contrôle de flux** : if/else, loops, try/catch
- **LINQ** : where, select, query syntax
- **Async/await** : Task, Task<T>
- **Tests unitaires** : xUnit Fact et Theory
- **Fonctionnalités modernes** : records, pattern matching
- **Markers d'apprentissage** : TODO:LEARN, EXERCISE, NOTE

## 🚀 Utilisation rapide

### Raccourcis de snippets courants

| Prefix | Description |
|--------|-------------|
| `cw` | Console.WriteLine() |
| `main` | Main method |
| `class-ctor` | Classe avec constructeur |
| `prop` | Propriété auto-implémentée |
| `method-async` | Méthode asynchrone |
| `foreach` | Boucle foreach |
| `try` | Try-catch block |
| `linq-where` | Clause LINQ Where |
| `test-xunit` | Méthode de test xUnit |
| `record` | Record type |
| `todo-learn` | Marqueur d'apprentissage |

### Exécution des tâches

Appuyez sur **Ctrl+Shift+P** (ou **Cmd+Shift+P** sur Mac) et tapez "Tasks: Run Task" :

- **build** - Compiler tout le workspace
- **test** - Exécuter tous les tests
- **new-console-example** - Créer un nouvel exemple console
- **new-exercise-beginner** - Créer un nouvel exercice débutant
- **clean-all-binobj** - Nettoyer tous les dossiers bin/obj

### Configuration du débogage

1. Ouvrez le fichier que vous voulez déboguer
2. Appuyez sur **F5** ou allez dans le panneau Debug
3. Choisissez la configuration appropriée :
   - **Current File** pour déboguer le fichier actuel
   - **Console Launch** pour un exemple
   - **Exercise Launch** pour un exercice

## 🎓 Fonctionnalités d'apprentissage

### TODO Tree personnalisé

Les tags suivants sont reconnus et colorés :
- `TODO` - Tâches générales (jaune)
- `LEARN` - Points d'apprentissage (bleu)
- `EXERCISE` - Exercices à faire (vert)
- `NOTE` - Notes importantes
- `FIXME` - À corriger
- `HACK` - Solutions temporaires

### Error Lens

Affichage inline des erreurs, warnings et infos pour un feedback immédiat.

### Format on Save

Le code est automatiquement formaté selon les conventions Microsoft C# à chaque sauvegarde.

## 🔧 Personnalisation

### Modifier les règles de formatage

Éditez `settings.json` section `[csharp]` pour ajuster :
- Taille des tabulations
- Longueur maximale des lignes
- Organisation des imports

### Ajouter des snippets personnalisés

Éditez `csharp.code-snippets` pour ajouter vos propres raccourcis de code.

### Créer de nouvelles tâches

Ajoutez des tâches dans `tasks.json` pour automatiser vos workflows d'apprentissage.

## 📚 Ressources

- [VS Code C# Documentation](https://code.visualstudio.com/docs/languages/csharp)
- [C# Dev Kit Guide](https://code.visualstudio.com/docs/csharp/get-started)
- [.NET CLI Reference](https://docs.microsoft.com/en-us/dotnet/core/tools/)

---

**Astuce** : Pour installer toutes les extensions recommandées, ouvrez la palette de commandes et exécutez "Extensions: Show Recommended Extensions".
