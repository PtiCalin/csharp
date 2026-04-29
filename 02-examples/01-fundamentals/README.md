# 01 — Fondamentaux : exemples

> 📘 [Theory](../../01-theory/01-fundamentals/README.md) · 🏋️ [Exercises](../../03-exercices/01-fundamentals/README.md)

## Exemple 1 — Hello World classique

```csharp
using System;

namespace Hub.Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // WriteLine = Write + saut de ligne.
            Console.WriteLine("Bonjour, C# !");

            // Affiche les arguments passés en ligne de commande.
            Console.WriteLine($"Reçu {args.Length} argument(s).");
            for (int i = 0; i < args.Length; i++)
                Console.WriteLine($"  args[{i}] = {args[i]}");
        }
    }
}
```

**Compiler & exécuter** depuis le dossier du projet :

```bash
dotnet new console -n HelloWorld
cd HelloWorld
dotnet run -- Charlie 25
```

## Exemple 2 — Top-level statements (C# 9+)

```csharp
// Pas de namespace, pas de class, pas de Main.
// Le compilateur synthétise tout cela.
using System;

Console.WriteLine($"Démarré à {DateTime.Now:HH:mm:ss}");
```

## Exemple 3 — Plusieurs fichiers, même namespace

`Program.cs` :

```csharp
using System;
namespace Hub.Demo
{
    internal class Program
    {
        static void Main()
        {
            Salutations.Bonjour("Charlie");
        }
    }
}
```

`Salutations.cs` :

```csharp
using System;
namespace Hub.Demo
{
    internal static class Salutations
    {
        public static void Bonjour(string nom)
            => Console.WriteLine($"Bonjour, {nom} !");
    }
}
```

🗝️ **À retenir** : tant que les fichiers déclarent le **même namespace**, ils se voient
mutuellement sans `using` supplémentaire.

## 🔗 Voir aussi

- [Theory → 01-fundamentals](../../01-theory/01-fundamentals/README.md)
- Exercice associé : [Exercises → 01-fundamentals](../../03-exercices/01-fundamentals/README.md)
