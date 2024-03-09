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
    }
}
