# 01 — Fondamentaux : exercices

> 📘 [Theory](../../01-theory/01-fundamentals/README.md) · 📚 [Examples](../../02-examples/01-fundamentals/README.md)

## 🟢 Échauffement — `Bonjour, [Nom]`

**Énoncé.** Crée un projet console qui demande le prénom de l'utilisateur, puis affiche
`Bonjour, <prénom> !`.

```bash
dotnet new console -n Ex01a-Bonjour
```

**Indices.**
- `Console.Write` pour l'invite (sans saut), `Console.ReadLine()` pour la saisie.
- Interpolation `$"Bonjour, {prenom} !"`.

**Critères de réussite.**
- [ ] Le programme compile et s'exécute.
- [ ] L'invite et la salutation sont sur des lignes différentes.
- [ ] `Main` est `static void` avec signature classique.

## 🟡 Application — Compteur d'arguments

**Énoncé.** Affiche le nombre d'arguments reçus en ligne de commande, puis chacun
d'eux préfixé de son indice.

```bash
dotnet run -- alpha bravo charlie
# 3 argument(s) reçus :
#  [0] alpha
#  [1] bravo
#  [2] charlie
```

**Indices.**
- `args.Length` donne le nombre d'arguments.
- Boucle `for (int i = 0; i < args.Length; i++)`.

**Critères.**
- [ ] Affichage correct pour 0, 1 et plusieurs arguments.
- [ ] Indices alignés à droite si > 9 arguments.

## 🔴 Défi — Deux fichiers, un namespace

**Énoncé.** Crée un projet avec deux fichiers `.cs` dans le **même namespace** :
- `Program.cs` : contient `Main` qui appelle `Outils.Inverser("Bonjour")`.
- `Outils.cs` : contient une classe statique `Outils` avec une méthode `Inverser`
  qui retourne la chaîne inversée.

**Indices.**
- `new string(s.Reverse().ToArray())` (LINQ) ou `for` à rebours.
- Pas besoin de `using` supplémentaire si même namespace.

**Critères.**
- [ ] Les deux fichiers déclarent `namespace Hub.Demo` (ou autre, mais identique).
- [ ] `Outils.Inverser("Bonjour")` retourne `"ruojnoB"`.
- [ ] Aucun warning de compilation.

## 🔗 Voir aussi

- [Theory → 01-fundamentals](../../01-theory/01-fundamentals/README.md)
- [Examples → 01-fundamentals](../../02-examples/01-fundamentals/README.md)
