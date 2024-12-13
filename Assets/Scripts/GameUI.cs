using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameUI : MonoBehaviour, IGameEndListener
{
    public Button[] buttons;
    public TextMeshProUGUI messageText;
    private GameManager gameManager;

    void Start()
    {
        gameManager = new GameManager(this); // Pass itself as the listener for game end
        InitializeButtons();
    }

    void InitializeButtons()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i;
            buttons[i].onClick.AddListener(() => OnCellClicked(index));
        }
    }

    public void OnCellClicked(int index)
    {
        gameManager.OnCellClicked(index);
        UpdateUI();
    }

    void UpdateUI()
    {
        string[] board = gameManager.GetBoard();
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = board[i]; // Update button text with player symbol
        }
    }

    public void OnGameEnd(string result)
    {
        messageText.text = result; // Display game result
    }

    public void RestartGame()
    {
        gameManager.StartNewGame();
        UpdateUI();
        messageText.text = "";
    }
}
