using Xunit;

namespace MorpionApp.Tests
{
    public class Puissance4Tests
    {
        [Fact]
        public void CheckWinByLine_PlayerWins_ReturnsTrue()
        {
            // Arrange
            var puissance4 = new Puissance4();
            var player = new Player(1, "A");
            puissance4.grid.GetCell(0, 0).SetOwner(player.GetId());
            puissance4.grid.GetCell(0, 1).SetOwner(player.GetId());
            puissance4.grid.GetCell(0, 2).SetOwner(player.GetId());
            puissance4.grid.GetCell(0, 3).SetOwner(player.GetId());
            
            // Act
            bool result = puissance4.CheckWinByLine(player);
            
            // Assert
            Assert.True(result);
        }

        [Fact]
        public void CheckWinByColumn_PlayerWins_ReturnsTrue()
        {
            // Arrange
            var puissance4 = new Puissance4();
            var player = new Player(2, "B");
            puissance4.grid.GetCell(0, 0).SetOwner(player.GetId());
            puissance4.grid.GetCell(1, 0).SetOwner(player.GetId());
            puissance4.grid.GetCell(2, 0).SetOwner(player.GetId());
            puissance4.grid.GetCell(3, 0).SetOwner(player.GetId());
            
            // Act
            bool result = puissance4.CheckWinByColumn(player);
            
            // Assert
            Assert.True(result);
        }

        [Fact]
        public void CheckWinByDiagonal_PlayerWins_ReturnsTrue()
        {
            // Arrange
            var puissance4 = new Puissance4();
            var player = new Player(1, "A");
            puissance4.grid.GetCell(0, 0).SetOwner(player.GetId());
            puissance4.grid.GetCell(1, 1).SetOwner(player.GetId());
            puissance4.grid.GetCell(2, 2).SetOwner(player.GetId());
            puissance4.grid.GetCell(3, 3).SetOwner(player.GetId());
            
            // Act
            bool result = puissance4.CheckWinByDiagonal(player);
            
            // Assert
            Assert.True(result);
        }

        [Fact]
        public void CheckEquality_AllCellsOccupied_ReturnsTrue()
        {
            // Arrange
            var puissance4 = new Puissance4();
            for (int i = 0; i < puissance4.grid.GetSize(); i++)
            {
                puissance4.grid.GetCell(i).SetOwner(1);
            }
            
            // Act
            bool result = puissance4.CheckEquality();
            
            // Assert
            Assert.True(result);
        }
        
        [Fact]
        public void CheckEquality_SomeCellsOccupied_ReturnsFalse()
        {
            // Arrange
            var puissance4 = new Puissance4();
            for (int i = 0; i < puissance4.grid.GetSize() - 1; i++)
            {
                puissance4.grid.GetCell(i).SetOwner(1);
            }
            
            // Act
            bool result = puissance4.CheckEquality();
            
            // Assert
            Assert.False(result);
        }

        [Fact]
        public void CheckEquality_NotAllCellsOccupied_ReturnsFalse()
        {
            // Arrange
            var puissance4 = new Puissance4();

            // Act
            bool result = puissance4.CheckEquality();

            // Assert
            Assert.False(result);
        }
        
        [Fact]
        public void CheckEquality_AllCellsOccupiedByDifferentPlayers_ReturnsTrue()
        {
            // Arrange
            var puissance4 = new Puissance4();
            for (int i = 0; i < puissance4.grid.GetSize(); i++)
            {
                puissance4.grid.GetCell(i).SetOwner(i % 2 + 1);
            }

            // Act
            bool result = puissance4.CheckEquality();

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void CheckWinByLine_PlayerDoesNotWin_ReturnsFalse()
        {
            // Arrange
            var puissance4 = new Puissance4();
            var player = new Player(1, "A");
            puissance4.grid.GetCell(0, 0).SetOwner(player.GetId());
            puissance4.grid.GetCell(0, 1).SetOwner(player.GetId());
            puissance4.grid.GetCell(0, 2).SetOwner(player.GetId());

            // Act
            bool result = puissance4.CheckWinByLine(player);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void CheckWinByColumn_PlayerDoesNotWin_ReturnsFalse()
        {
            // Arrange
            var puissance4 = new Puissance4();
            var player = new Player(2, "B");
            puissance4.grid.GetCell(0, 0).SetOwner(player.GetId());
            puissance4.grid.GetCell(1, 0).SetOwner(player.GetId());
            puissance4.grid.GetCell(2, 0).SetOwner(player.GetId());

            // Act
            bool result = puissance4.CheckWinByColumn(player);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void CheckWinByDiagonal_PlayerDoesNotWin_ReturnsFalse()
        {
            // Arrange
            var puissance4 = new Puissance4();
            var player = new Player(1, "A");
            puissance4.grid.GetCell(0, 0).SetOwner(player.GetId());
            puissance4.grid.GetCell(1, 1).SetOwner(player.GetId());
            puissance4.grid.GetCell(2, 2).SetOwner(player.GetId());

            // Act
            bool result = puissance4.CheckWinByDiagonal(player);

            // Assert
            Assert.False(result);
        }
        
        [Fact]
        public void CheckWinByLine_PlayerWinsWithDifferentLine_ReturnsTrue()
        {
            // Arrange
            var puissance4 = new Puissance4();
            var player = new Player(1, "A");
            puissance4.grid.GetCell(3, 0).SetOwner(player.GetId());
            puissance4.grid.GetCell(3, 1).SetOwner(player.GetId());
            puissance4.grid.GetCell(3, 2).SetOwner(player.GetId());
            puissance4.grid.GetCell(3, 3).SetOwner(player.GetId());

            // Act
            bool result = puissance4.CheckWinByLine(player);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void CheckWinByColumn_PlayerWinsWithDifferentColumn_ReturnsTrue()
        {
            // Arrange
            var puissance4 = new Puissance4();
            var player = new Player(2, "B");
            puissance4.grid.GetCell(0, 6).SetOwner(player.GetId());
            puissance4.grid.GetCell(1, 6).SetOwner(player.GetId());
            puissance4.grid.GetCell(2, 6).SetOwner(player.GetId());
            puissance4.grid.GetCell(3, 6).SetOwner(player.GetId());

            // Act
            bool result = puissance4.CheckWinByColumn(player);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void CheckWinByDiagonal_PlayerWinsWithDifferentDiagonal_ReturnsTrue()
        {
            // Arrange
            var puissance4 = new Puissance4();
            var player = new Player(1, "A");
            puissance4.grid.GetCell(3, 0).SetOwner(player.GetId());
            puissance4.grid.GetCell(2, 1).SetOwner(player.GetId());
            puissance4.grid.GetCell(1, 2).SetOwner(player.GetId());
            puissance4.grid.GetCell(0, 3).SetOwner(player.GetId());

            // Act
            bool result = puissance4.CheckWinByDiagonal(player);

            // Assert
            Assert.True(result);
        }
    }
}
