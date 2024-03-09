namespace PuissanceQuatreTest;

public class PuissanceQuatreTests
{
    [Fact]
    public void TestInitialisationGrille()
    {
        // Arrange
        PuissanceQuatre puissanceQuatre = new PuissanceQuatre();

        // Act
        char[,] grille = puissanceQuatre.grille;

        // Assert
        Assert.NotNull(grille);
        Assert.Equal(4, grille.GetLength(0)); // Vérifie les dimensions de la grille
        Assert.Equal(7, grille.GetLength(1));
        foreach (var cell in grille) Assert.Equal(' ', cell); // Vérifie que chaque cellule est vide
    }

    [Fact]
    public void TestTourDuJoueurParDefaut()
    {
        // Arrange
        PuissanceQuatre puissanceQuatre = new PuissanceQuatre();

        // Act
        bool tourDuJoueur = puissanceQuatre.tourDuJoueur;

        // Assert
        Assert.True(tourDuJoueur); // Vérifie que c'est le tour du joueur 1 par défaut
    }

    [Fact]
    public void TestVerifVictoireJoueur1()
    {
        // Arrange
        PuissanceQuatre puissanceQuatre = new PuissanceQuatre();
        puissanceQuatre.grille = new char[4, 7]
        {
            { 'X', 'X', 'X', 'X', ' ', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ' }
        };

        // Act
        bool victoire = puissanceQuatre.verifVictoire('X');

        // Assert
        Assert.True(victoire); // Vérifie qu'il y a une victoire pour le joueur X
    }

    [Fact]
    public void TestVerifVictoireJoueur2()
    {
        // Arrange
        PuissanceQuatre puissanceQuatre = new PuissanceQuatre();
        puissanceQuatre.grille = new char[4, 7]
        {
            { 'O', 'O', 'O', 'O', ' ', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ' }
        };

        // Act
        bool victoire = puissanceQuatre.verifVictoire('O');

        // Assert
        Assert.True(victoire); // Vérifie qu'il y a une victoire pour le joueur O
    }

    [Fact]
    public void TestVerifEgalite()
    {
        // Arrange
        PuissanceQuatre puissanceQuatre = new PuissanceQuatre();
        puissanceQuatre.grille = new char[4, 7]
        {
            { 'X', 'O', 'X', 'O', 'X', 'O', 'X' },
            { 'X', 'O', 'X', 'O', 'X', 'O', 'X' },
            { 'O', 'X', 'O', 'X', 'O', 'X', 'O' },
            { 'O', 'X', 'O', 'X', 'O', 'X', 'O' }
        };

        // Act
        bool egalite = puissanceQuatre.verifEgalite();

        // Assert
        Assert.True(egalite); // Vérifie qu'il y a une égalité
    }
}