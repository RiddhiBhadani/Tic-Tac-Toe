
public class GameManager
{
    private Board board;
    private Player playerX;
    private Player playerO;
    private Player currentPlayer;
    private IGameEndListener gameEndListener;

    public GameManager(IGameEndListener listener)
    {
        board = new Board();
        playerX = new Player("Player X", "X");
        playerO = new Player("Player O", "O");
        currentPlayer = playerX;
        gameEndListener = listener;
    }

    public void StartNewGame()
    {
        board = new Board(); // Reset the board
        currentPlayer = playerX;  // Reset to Player X
    }

    public void OnCellClicked(int index)
    {
        if (board.IsCellEmpty(index))
        {
            board.SetCell(index, currentPlayer.Symbol);
            if (board.CheckWin(currentPlayer.Symbol))
            {
                gameEndListener.OnGameEnd($"{currentPlayer.Name} wins!");
            }
            else if (board.IsFull())
            {
                gameEndListener.OnGameEnd("It's a tie!");
            }
            else
            {
                SwitchPlayer();
            }
        }
    }

    private void SwitchPlayer()
    {
        currentPlayer = currentPlayer == playerX ? playerO : playerX;
    }

    public string[] GetBoard() => board.GetBoard();

    public string GetCurrentPlayerName() => currentPlayer.Name;
}
