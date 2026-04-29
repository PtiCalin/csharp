# 📖 Glossaire C# / .NET

> Renvoi rapide vers les définitions précises des termes employés dans les modules.
> Ordre alphabétique. Termes en **gras** = à connaître impérativement pour l'intra.

---

## A

**Abstract (`abstract`).** Modificateur indiquant qu'une **classe ne peut pas être instanciée** ou qu'une **méthode n'a pas d'implémentation** dans la classe qui la déclare. Une classe contenant une méthode `abstract` doit elle-même être `abstract`. Voir [Polymorphisme](08-oop-polymorphism/README.md).

**Argument.** **Valeur effective** passée à un paramètre lors d'un appel. À distinguer du *paramètre* (variable locale dans la signature). Ex : `Saluer("Charlie")` → `"Charlie"` est l'argument du paramètre `nom`.

**Assemblage (assembly).** Unité de déploiement compilée (`.dll` ou `.exe`). Contient le code IL et les métadonnées.

**Async/await.** Mots-clés pour la programmation asynchrone non-bloquante. Hors scope IFT1179 introductif.

---

## B

**Boxing.** Conversion implicite d'un *type valeur* (`int`, `struct`) vers `object`, qui alloue sur le tas. **Coûteux** : à éviter en boucle critique.

**Bool (`bool`).** Type primitif à deux valeurs : `true` ou `false`. Pas de conversion implicite avec `int`.

**Break (`break`).** Sort immédiatement de la boucle ou du `switch` englobant. Voir [Boucles](05-loops/README.md).

---

## C

**Champ (field).** Variable déclarée **dans** une classe, **hors** d'une méthode. Stocke l'état d'un objet. Idéalement `private` ; exposé via une propriété. À distinguer d'une *propriété*.

**Classe (`class`).** **Plan / blueprint** décrivant un type de référence : ses champs, propriétés, méthodes, constructeurs. Une classe est *instanciée* avec `new` pour produire un *objet*. Voir [Concepts → Classe vs méthode](concepts/class-method-function-procedure.md).

**Const (`const`).** Constante dont la valeur est **fixée à la compilation**. Doit être un type primitif ou `string`. Ex : `const double PI = 3.14159;`.

**Constructeur (constructor).** Méthode spéciale appelée automatiquement par `new` pour initialiser un objet. Même nom que la classe, **pas de type de retour**. Peut être surchargé.

**Continue (`continue`).** Saute à l'**itération suivante** de la boucle, sans exécuter le reste du corps.

---

## D

**Decimal (`decimal`).** Type numérique 128 bits **à précision décimale**. Pour valeurs monétaires. Suffixe `m` : `0.1m`. Pas de conversion implicite avec `double`.

**Délégué (delegate).** *Type* qui pointe vers une méthode (signature compatible). Base des événements et callbacks. Ex : `Action`, `Func<T, TResult>`.

**Double (`double`).** Type flottant 64 bits, **précision binaire** (≈15-16 chiffres significatifs). **Inadapté à l'argent**. Suffixe optionnel `d`.

---

## E

**Encapsulation.** Principe POO : **cacher l'état** d'un objet derrière une interface contrôlée (propriétés, méthodes) pour préserver les invariants. Mécanismes : `private`, propriétés avec validation.

**Enum (`enum`).** Type qui énumère un ensemble fini de valeurs nommées. Ex : `enum Statut { EnAttente, Expedie, Livre }`.

**Événement (event).** Mécanisme par lequel un objet **notifie** ses observateurs qu'**un fait s'est produit**. C'est le **plus proche équivalent C# d'un *trigger* SQL**. Ex : `button.Click += OnClick;`. Voir [Concepts](concepts/class-method-function-procedure.md#triggers-en-c--cest-quoi-vraiment).

**Exception.** Objet représentant une erreur d'exécution. Lancée avec `throw`, capturée avec `try / catch`. Hiérarchie : `Exception → SystemException → ArgumentException → ...`.

---

## F

**Fonction (function).** En C#, ce mot n'est **pas un mot-clé**. Informellement, une « fonction » est une **méthode qui retourne une valeur** (par opposition à une *procédure* qui retourne `void`). Voir [Concepts](concepts/class-method-function-procedure.md).

**For (`for`).** Boucle avec **compteur explicite** : `for (init; condition; pas) { ... }`.

**Foreach (`foreach`).** Itère sur les éléments d'une collection sans manipuler l'indice. Plus sûr que `for` quand on n'a pas besoin de l'indice.

---

## G

**Garbage collector (GC).** Service du runtime qui libère automatiquement la mémoire des objets non référencés. Aucune `delete` manuelle en C#.

**Generic (`<T>`).** Mécanisme de type paramétré : `List<T>`, `Dictionary<K, V>`. Permet la sécurité de type sans `object`.

---

## H

**Héritage.** Relation **« est un »** où une classe `Derivee` hérite des membres d'une classe `Base`. Syntaxe : `class Derivee : Base`. Une seule classe parente en C#.

---

## I

**Immutabilité.** Propriété d'un objet qui **ne peut pas être modifié** après sa création. Souvent obtenue avec des propriétés `{ get; }` initialisées au constructeur, ou avec `record`.

**Instance.** Objet **concret** créé à partir d'une classe via `new`. Ex : `var c = new Colis(...)` → `c` est une instance de `Colis`.

**Interface (`interface`).** Contrat : **liste de membres** (méthodes, propriétés) qu'une classe **promet** d'implémenter. Pas d'état, pas d'implémentation (sauf défauts depuis C# 8). Une classe peut implémenter plusieurs interfaces.

---

## L

**Lambda (`=>`).** Syntaxe abrégée pour une méthode anonyme. Ex : `n => n * 2`, `(a, b) => a + b`.

**LINQ.** *Language Integrated Query* — opérateurs sur les séquences (`Where`, `Select`, `OrderBy`, …). Souvent évité dans les exercices intra IFT1179 pour forcer la pratique des boucles.

---

## M

**Méthode (method).** **Fonction ou procédure définie dans une classe**. C'est la définition formelle C# de ce qu'on appelle parfois informellement « fonction ». Toute « fonction » que tu écris en C# est techniquement une méthode. Voir [Concepts](concepts/class-method-function-procedure.md).

**Modificateur d'accès.** `public` (visible partout), `private` (classe seule), `protected` (classe + dérivées), `internal` (même assembly).

---

## N

**Namespace (`namespace`).** **Boîte logique** qui regroupe des types pour éviter les collisions de noms. Ex : `System.Collections.Generic`.

**New (`new`).** Opérateur qui **crée une instance** d'un type référence et appelle son constructeur.

**Null (`null`).** Référence qui ne pointe vers aucun objet. Accéder à un membre via `null` lève `NullReferenceException`.

**Nullable (`?`).** Suffixe qui rend un type valeur capable d'accepter `null` : `int?`, `DateTime?`. Ou indique l'intention en *Nullable Reference Types* depuis C# 8.

---

## O

**Objet (object).** Instance d'une classe. Aussi : `object` est la classe racine de toute la hiérarchie .NET ; tout type en hérite.

**Override (`override`).** Modificateur qui redéfinit dans une sous-classe une méthode `virtual` ou `abstract` de la classe parent.

**Out (`out`).** Modificateur de paramètre : la méthode **doit assigner** la variable. L'appelant n'a pas besoin de l'initialiser. Ex : `int.TryParse(s, out int n)`.

---

## P

**Paramètre (parameter).** Variable déclarée **dans la signature** d'une méthode. Reçoit la valeur de l'argument au moment de l'appel.

**Polymorphisme.** Capacité d'un objet d'une classe dérivée à être manipulé via une référence du type parent, en invoquant les méthodes redéfinies dans la dérivée. **Mécanisme clé** : `virtual` + `override`.

**Procédure (procedure).** Mot **non utilisé en C#**. Informellement : **méthode qui ne retourne rien** (`void`). Sert à effectuer une action plutôt qu'à calculer une valeur. Voir [Concepts](concepts/class-method-function-procedure.md).

**Propriété (property).** Membre qui **ressemble à un champ** mais utilise des accesseurs `get` / `set`. Permet la **validation** et la **lecture seule**. Ex : `public double Poids { get; private set; }`.

---

## R

**Record (`record`).** Variante de `class` pensée pour l'immutabilité, avec égalité par valeur générée automatiquement. C# 9+.

**Ref (`ref`).** Modificateur de paramètre : la variable doit être **déjà initialisée** par l'appelant ; la méthode peut la modifier. Différent de `out`.

**Référence (type référence).** Type dont les variables stockent une **adresse**, pas la valeur. Classes, tableaux, `string`, délégués. Comparaison par défaut : référence (sauf `string`).

**Return (`return`).** Sort de la méthode, optionnellement avec une valeur (sauf `void`).

---

## S

**Sealed (`sealed`).** Empêche l'héritage d'une classe ou la redéfinition d'une méthode `virtual`.

**Signature.** Identité d'une méthode : nom + types des paramètres (le **type de retour** n'en fait **pas** partie). Deux méthodes ne peuvent partager la même signature dans la même classe.

**Static (`static`).** Membre **lié à la classe**, pas à une instance. Accédé via `MaClasse.Membre`. Ex : `Math.PI`, `Console.WriteLine`.

**String (`string`).** Type référence représentant une chaîne UTF-16. **Immuable** : toute modification crée une nouvelle instance.

**Struct.** Type valeur défini par l'utilisateur. Allocation sur la pile, copie par valeur. Ex : `DateTime`, `int`. À utiliser pour de petites valeurs immuables.

**Surcharge (overload).** Plusieurs méthodes **même nom**, **signatures différentes**. Le compilateur choisit selon les arguments.

**Switch / switch expression.** Aiguillage multi-branches. Voir [Structures de contrôle](04-control-flow/README.md).

---

## T

**Tableau (array).** Collection de taille fixe, indexée à partir de 0. Type référence. Ex : `int[] notes = new int[10];`.

**This (`this`).** Référence à l'instance courante. Sert à désambiguïser un champ d'un paramètre, ou à chaîner des constructeurs : `: this(...)`.

**Throw (`throw`).** Lance une exception. Ex : `throw new ArgumentException("...");`.

**Trigger (déclencheur).** Concept **SQL/base de données**, **pas un mot-clé C#**. Procédure stockée exécutée automatiquement sur un événement de table (INSERT/UPDATE/DELETE). En C#, l'équivalent conceptuel est l'**événement** (`event`). Voir [Concepts](concepts/class-method-function-procedure.md#triggers-en-c--cest-quoi-vraiment).

**TryParse.** Convention de méthode : `bool TryParse(string s, out T result)`. Retourne `false` au lieu de lancer une exception si l'analyse échoue. **Préférée** pour les saisies utilisateur.

---

## U

**Using (`using`).** Deux usages distincts :
1. **Directive en haut de fichier** : `using System;` → importe un namespace.
2. **Bloc / déclaration** : `using var sw = new StreamWriter(...);` → garantit `Dispose()` à la sortie de portée.

---

## V

**Valeur (type valeur).** Type dont les variables stockent **directement** la valeur. Primitifs (`int`, `bool`), `struct`, `enum`. Copie par valeur lors d'affectation.

**Var (`var`).** Inférence de type **statique** par le compilateur à partir de l'initialiseur. Ne change rien au type final ; **pas dynamique**.

**Virtual (`virtual`).** Méthode redéfinissable par les sous-classes via `override`. Sans `virtual`, la méthode est *non-polymorphe* (on parle alors de *masquage* avec `new`).

**Void.** Type de retour signifiant « **rien à retourner** ». Utilisé pour les méthodes-procédures.

---

## 🔗 Voir aussi

- [Concepts → Classe / méthode / fonction / procédure / trigger](concepts/class-method-function-procedure.md)
- [Cheatsheets](cheatsheets/README.md)
- [THEORY.md](THEORY.md) — index des modules
