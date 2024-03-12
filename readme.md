## I. Les difficultés liées à la validation

### Etat de base du projet :

Multiples code smells et bugs rendant le code peu fiable et maintenable

**Exemples :**

Bloaters :

```csharp
public void tourJoueur()
public void BoucleJeu()
```

Single Responsibility Principle :

```csharp
public class Morpion {
	public void BoucleJeu(){...}
	public void tourJoueur(){...}
	public void tourJoueur2(){...}
	public void affichePlateau(){...}
	public void verifVictoire(){...}
	public void verifEgalite(){...}
	public void finPartie(){...}
}
```

Primitive Obsession & Magic Numbers :

```csharp
var (row, column) = (0, 0);
grille = new char[3, 3];
```

Object-Orientation Abusers :

```csharp
switch (Console.ReadKey(true).Key)
{
    case ConsoleKey.Escape:
        quiterJeu = true;
        Console.Clear();
        break;

    case ConsoleKey.RightArrow:
        if (column >= 2)
        {
            column = 0;
        }
        else
        {
            column = column + 1;
        }
        break;

    case ConsoleKey.LeftArrow:
        if (column <= 0)
        {
            column = 2;
        }
        else
        {
            column = column - 1;
        }
        break;

    case...
    case...
    case...
}
```

Dead Code :

```csharp
//case ConsoleKey.UpArrow:
//    if (row <= 0)
//    {
//        row = 3;
//    }
//    else
//    {
//        row = row - 1;
//    }
//    break;
```

Duplicate code :

```csharp
 public void tourJoueur()
 public void tourJoueur2()
```

## II. Les méthodes de résolution de ces problèmes

**Tests :**
 - Élaboration de tests afin d'identifier les problèmes actuels, les résoudre et les retester par la suite

**Correction du code :**
 - Corriger le code, notamant en corrigeant les code smells identifiés plus haut avec des actions tels que :
     - Scinder les méthodes et classes
     -   Supprimer le code mort
     -   Eviter l'utilisation des primitives si possible
     - ...

**Tests de non régression :**
 - Exécuter des tests afin de s'assurer que nos modifications ont bien résolu les problèmes identifiés et n'en ont pas créer de nouveaux
 - Tester les nouvelles fonctionnalités

## III. Le développement des fonctionnalités manquantes

**Sauvegarde et chargement :**

- Implémentation via une classe en charge de la serialization, en utilisant la serialization json du language C#, une sauvegarde d'une copie de l'état actuel de la classe jeu et de ses differents attributs est effectué a chaque tour avec la possibiliter de pouvoir charger cette sauvegarde au lancement de l'application console

**non implementé pour le moment*

**Jouer contre l'ordinateur :**

- Implémentation via la classe Input qui est en charge des entrées du jeu, une nouvelle méthode est créé dans cette classe afin de pouvoir génerer une entrée pour le joueur 'ordinateur'

**Tests :**

- Ecriture de tests afin de pouvoir tester les fonctionnalités implementés et ceux existants