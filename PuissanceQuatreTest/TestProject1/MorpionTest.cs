using Xunit;
using MorpionApp;

namespace MorpionTest
{
    public class MorpionTests
    {
        [Fact]
        public void TestInitialisationGrille()
        {
            // Arrange
            Morpion morpion = new Morpion();

            // Act
            char[,] grille = morpion.grille;

            // Assert
            Assert.NotNull(grille);
            Assert.Equal(3, grille.GetLength(0)); // Vérifie les dimensions de la grille
            Assert.Equal(3, grille.GetLength(1));
            foreach (var cellule in grille)
            {
                Assert.Equal(' ', cellule); // Vérifie que chaque cellule est vide
            }
        }
        
        [Fact]
        public void TestTourDuJoueurParDefaut()
        {
            // Arrange
            Morpion morpion = new Morpion();

            // Act
            bool tourDuJoueur = morpion.tourDuJoueur;

            // Assert
            Assert.True(tourDuJoueur); // Vérifie que c'est le tour du joueur 1 par défaut
        }
        
        [Fact]
        public void TestVerifVictoireJoueur1()
        {
            // Arrange
            Morpion morpion = new Morpion();
            morpion.grille = new char[3, 3]
            {
                { 'X', 'X', 'X'},
                { ' ', ' ', ' '},
                { ' ', ' ', ' '},
            };

            // Act
            bool victoire = morpion.verifVictoire('X');

            // Assert
            Assert.True(victoire); // Vérifie qu'il y a une victoire pour le joueur X
        }

        [Fact]
        public void TestVerifVictoireJoueur2()
        {
            // Arrange
            Morpion morpion = new Morpion();
            morpion.grille = new char[3, 3]
            {
                { 'O', 'O', 'O'},
                { ' ', ' ', ' '},
                { ' ', ' ', ' '},
            };

            // Act
            bool victoire = morpion.verifVictoire('O');

            // Assert
            Assert.True(victoire); // Vérifie qu'il y a une victoire pour le joueur O
        }

        [Fact]
        public void TestVerifEgalite()
        {
            // Arrange
            Morpion morpion = new Morpion();
            morpion.grille = new char[3, 3]
            {
                { 'X', 'O', 'X'},
                { 'X', 'X', 'O'},
                { 'O', 'X', 'O'},
            };

            // Act
            bool egalite = morpion.verifEgalite();

            // Assert
            Assert.True(egalite); // Vérifie qu'il y a une égalité
        }
    }
}
