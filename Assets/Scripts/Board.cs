public class Board
{
    private string[] board;
    private const int size = 3;  // 3x3 grid

    public Board()
    {
        board = new string[size * size];  // Initialize 3x3 grid with empty strings
    }

    public bool IsCellEmpty(int index) => string.IsNullOrEmpty(board[index]);

    public void SetCell(int index, string symbol)
    {
        if (IsCellEmpty(index))
        {
            board[index] = symbol;
        }
    }

    public string GetCell(int index) => board[index];

    public string[] GetBoard() => board;
    public bool IsFull()
    {
        foreach (var cell in board)
        {
            if (string.IsNullOrEmpty(cell)) return false;
        }
        return true;
    }

    public bool CheckWin(string symbol)
    {
        // Check rows, columns, and diagonals
        for (int i = 0; i < size; i++)
        {
            // Check rows
            if (board[i * size] == symbol && board[i * size + 1] == symbol && board[i * size + 2] == symbol)
                return true;

            // Check columns
            if (board[i] == symbol && board[i + size] == symbol && board[i + 2 * size] == symbol)
                return true;
        }

        // Check diagonals
        if (board[0] == symbol && board[4] == symbol && board[8] == symbol)
            return true;

        if (board[2] == symbol && board[4] == symbol && board[6] == symbol)
            return true;

        return false;
    }
}
