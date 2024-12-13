using NUnit.Framework;

[TestFixture]
public class BoardTests
{
    [Test]
    public void Board_ShouldInitializeWithEmptyCells()
    {
        // Arrange & Act
        Board board = new Board();

        // Assert
        for (int i = 0; i < 9; i++)
        {
            Assert.IsTrue(board.IsCellEmpty(i));
        }
    }

    [Test]
    public void Board_ShouldAllowPlayerToMakeMove()
    {
        // Arrange
        Board board = new Board();
        string playerSymbol = "X";
        int cellIndex = 0;

        // Act
        board.SetCell(cellIndex, playerSymbol);

        // Assert
        Assert.AreEqual(board.GetCell(cellIndex), playerSymbol);
    }

    [Test]
    public void Board_ShouldNotAllowOverwritingCell()
    {
        // Arrange
        Board board = new Board();
        string playerSymbol = "X";
        int cellIndex = 0;

        // Act
        board.SetCell(cellIndex, playerSymbol);
        board.SetCell(cellIndex, "O");

        // Assert
        Assert.AreEqual(board.GetCell(cellIndex), playerSymbol);  // Should still be "X"
    }
}
