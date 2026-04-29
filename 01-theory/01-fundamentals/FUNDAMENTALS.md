# 01 — Fondamentaux : projet, `Main`, namespaces

> Théorie · [Examples](../../02-examples/01-fundamentals/README.md) · [Exercises](../../03-exercices/01-fundamentals/README.md)

## L1 — Intuition

Un programme C# est un **livre** : la couverture est le projet (`.csproj`), les chapitres
sont les fichiers `.cs`, le sommaire est le `namespace`, et la première phrase lue
est la méthode `Main`.

## L2 — Définition formelle

| Élément | Rôle |
|---------|------|
| **Solution (`.sln`)** | Conteneur de plusieurs projets liés |
| **Projet (`.csproj`)** | Unité de compilation, déclare SDK, version cible, dépendances |
| **Assembly** | Sortie compilée (`.dll` ou `.exe`) |
| **`namespace`** | Espace logique pour grouper et désambiguïser des types |
| **`using`** | Importe un namespace pour éviter les noms qualifiés complets |
| **Point d'entrée** | Méthode `Main` (signature `static void Main(string[] args)`) ou *top-level statements* (C# 9+) |

### Cycle de vie

```
.cs → compilateur Roslyn → IL (Intermediate Language) → .dll/.exe
                                          ↓
                                    runtime CoreCLR
                                          ↓
                                  exécution machine
```

## L3 — Exemple commenté

```csharp
// Importe l'espace de noms System pour utiliser Console sans préfixe.
using System;

// Déclare un namespace : tout type ci-dessous vit dans Hub.Demo.
namespace Hub.Demo
{
    // Classe statique : sert seulement de conteneur pour Main.
    internal class Program
    {
        // Point d'entrée. static = appartient à la classe, pas à un objet.
        // string[] args = arguments passés en ligne de commande.
        static void Main(string[] args)
        {
            Console.WriteLine("Bonjour, C#!");
        }
    }
}
```

### Variante moderne (top-level statements, C# 9+)

```csharp
using System;
Console.WriteLine("Bonjour, C#!");
```

Le compilateur génère implicitement `Program.Main`. Pédagogiquement, **conserver la
forme explicite** au cours IFT1179 pour rester aligné avec les exemples du cours.

## L4 — Cas limites & pièges

- ⚠️ **Confusion `static`/instance** : `Main` doit être `static`, sinon l'exécutable ne
  démarre pas (le runtime ne peut pas instancier `Program`).
- ⚠️ **Plusieurs `Main`** : si plusieurs projets contiennent un `Main`, préciser
  `<StartupObject>` dans le `.csproj`.
- ⚠️ **`using System;` implicite** : depuis .NET 6, les *implicit usings* importent
  automatiquement `System`, `System.Linq`, etc. Visible via
  `<ImplicitUsings>enable</ImplicitUsings>`.
- ⚠️ **`namespace` vs dossier** : le compilateur n'oblige pas la correspondance, mais
  la convention l'exige (`Hub.Demo.Models` → `Demo/Models/`).

## ✅ Vérifiez votre compréhension

1. Pourquoi `Main` doit-elle être `static` ? Que se passerait-il si elle ne l'était pas ?
2. Dans une solution avec deux projets `.csproj`, où sont stockées les dépendances NuGet ?
3. Vous voyez `error CS0017: Program has more than one entry point defined`. Quelle
   est la cause probable et comment la résoudre ?

## 🔗 Voir aussi

- [Examples → 01-fundamentals](../../02-examples/01-fundamentals/README.md)
- [Exercises → 01-fundamentals](../../03-exercices/01-fundamentals/README.md)
- Notes IFT1179 : `05-references/course-materials/UDEM_H26_IFT1179/notes/2026-01-14_Introductions et Généralités.md`
