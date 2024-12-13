using NUnit.Framework;

[TestFixture]
public class PlayerTests
{
    [Test]
    public void Player_ShouldHaveNameAndSymbol()
    {
        // Arrange
        string playerName = "Player X";
        string playerSymbol = "X";

        // Act
        Player player = new Player(playerName, playerSymbol);

        // Assert
        Assert.AreEqual(player.Name, playerName);
        Assert.AreEqual(player.Symbol, playerSymbol);
    }
}
