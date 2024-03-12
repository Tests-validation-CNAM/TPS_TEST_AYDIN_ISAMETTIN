using Xunit;

namespace MorpionApp.Tests
{
    public class MorpionTests
    {
        [Fact]
        public void CheckWinByLine_PlayerWins_ReturnsTrue()
        {
            // Arrange
            var morpion = new Morpion();
            var player = new Player(1, "A");
            morpion.grid.GetCell(0, 0).SetOwner(player.GetId());
            morpion.grid.GetCell(0, 1).SetOwner(player.GetId());
            morpion.grid.GetCell(0, 2).SetOwner(player.GetId());

            // Act
            bool result = morpion.CheckWinByLine(player);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void CheckWinByColumn_PlayerWins_ReturnsTrue()
        {
            // Arrange
            var morpion = new Morpion();
            var player = new Player(2, "B");
            morpion.grid.GetCell(0, 0).SetOwner(player.GetId());
            morpion.grid.GetCell(1, 0).SetOwner(player.GetId());
            morpion.grid.GetCell(2, 0).SetOwner(player.GetId());

            // Act
            bool result = morpion.CheckWinByColumn(player);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void CheckWinByDiagonal_PlayerWins_ReturnsTrue()
        {
            // Arrange
            var morpion = new Morpion();
            var player = new Player(1, "A");
            morpion.grid.GetCell(0, 0).SetOwner(player.GetId());
            morpion.grid.GetCell(1, 1).SetOwner(player.GetId());
            morpion.grid.GetCell(2, 2).SetOwner(player.GetId());

            // Act
            bool result = morpion.CheckWinByDiagonal(player);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void CheckEquality_AllCellsOccupied_ReturnsTrue()
        {
            // Arrange
            var morpion = new Morpion();
            for (int i = 0; i < morpion.grid.GetSize(); i++)
            {
                morpion.grid.GetCell(i).SetOwner(1);
            }

            // Act
            bool result = morpion.CheckEquality();

            // Assert
            Assert.True(result);
        }
        
        [Fact]
        public void CheckEquality_SomeCellsOccupied_ReturnsFalse()
        {
            var morpion = new Morpion();
            for (int i = 0; i < morpion.grid.GetSize() - 1; i++)
            {
                morpion.grid.GetCell(i).SetOwner(1);
            }

            bool result = morpion.CheckEquality();

            Assert.False(result);
        }

        [Fact]
        public void CheckEquality_NotAllCellsOccupied_ReturnsFalse()
        {
            // Arrange
            var morpion = new Morpion();

            // Act
            bool result = morpion.CheckEquality();

            // Assert
            Assert.False(result);
        }
        
        [Fact]
        public void CheckEquality_AllCellsOccupiedByDifferentPlayers_ReturnsTrue()
        {
            var morpion = new Morpion();
            for (int i = 0; i < morpion.grid.GetSize(); i++)
            {
                morpion.grid.GetCell(i).SetOwner(i % 2 + 1);
            }

            bool result = morpion.CheckEquality();

            Assert.True(result);
        }

        [Fact]
        public void CheckWinByLine_PlayerDoesNotWin_ReturnsFalse()
        {
            var morpion = new Morpion();
            var player = new Player(1, "A");
            morpion.grid.GetCell(0, 0).SetOwner(player.GetId());
            morpion.grid.GetCell(0, 1).SetOwner(player.GetId());

            bool result = morpion.CheckWinByLine(player);

            Assert.False(result);
        }

        [Fact]
        public void CheckWinByColumn_PlayerDoesNotWin_ReturnsFalse()
        {
            var morpion = new Morpion();
            var player = new Player(2, "B");
            morpion.grid.GetCell(0, 0).SetOwner(player.GetId());
            morpion.grid.GetCell(1, 0).SetOwner(player.GetId());

            bool result = morpion.CheckWinByColumn(player);

            Assert.False(result);
        }

        [Fact]
        public void CheckWinByDiagonal_PlayerDoesNotWin_ReturnsFalse()
        {
            var morpion = new Morpion();
            var player = new Player(1, "A");
            morpion.grid.GetCell(0, 0).SetOwner(player.GetId());
            morpion.grid.GetCell(1, 1).SetOwner(player.GetId());

            bool result = morpion.CheckWinByDiagonal(player);

            Assert.False(result);
        }
        
        [Fact]
        public void CheckWinByLine_PlayerWinsWithDifferentLine_ReturnsTrue()
        {
            var morpion = new Morpion();
            var player = new Player(1, "A");
            morpion.grid.GetCell(1, 0).SetOwner(player.GetId());
            morpion.grid.GetCell(1, 1).SetOwner(player.GetId());
            morpion.grid.GetCell(1, 2).SetOwner(player.GetId());

            bool result = morpion.CheckWinByLine(player);

            Assert.True(result);
        }

        [Fact]
        public void CheckWinByColumn_PlayerWinsWithDifferentColumn_ReturnsTrue()
        {
            var morpion = new Morpion();
            var player = new Player(2, "B");
            morpion.grid.GetCell(0, 1).SetOwner(player.GetId());
            morpion.grid.GetCell(1, 1).SetOwner(player.GetId());
            morpion.grid.GetCell(2, 1).SetOwner(player.GetId());

            bool result = morpion.CheckWinByColumn(player);

            Assert.True(result);
        }

        [Fact]
        public void CheckWinByDiagonal_PlayerWinsWithDifferentDiagonal_ReturnsTrue()
        {
            var morpion = new Morpion();
            var player = new Player(1, "A");
            morpion.grid.GetCell(0, 2).SetOwner(player.GetId());
            morpion.grid.GetCell(1, 1).SetOwner(player.GetId());
            morpion.grid.GetCell(2, 0).SetOwner(player.GetId());

            bool result = morpion.CheckWinByDiagonal(player);

            Assert.True(result);
        }
    }
}
