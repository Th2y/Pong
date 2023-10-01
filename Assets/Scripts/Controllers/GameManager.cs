using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject panelGame;
    [SerializeField] private GameObject panelWon;
    [SerializeField] private GameObject panelStart;
    [SerializeField] private GameObject panelOptions;
    [SerializeField] private GameObject panelColors;

    [Header("References")]
    [SerializeField] private BallBase ball;
    [SerializeField] private Points points;
    [SerializeField] private Player[] players;

    public static GameManager Instance;

    private GameState actualGameState = GameState.MENU;
    private bool hasWon = false;

    private void Awake()
    {
        Instance = this;
    }

    public void ChangeActualStateToMenu()
    {
        ball.ChangeCanMove(false);
        actualGameState = GameState.MENU;
        ChangePanelActive(actualGameState);
    }

    public void ChangeActualStateToGame()
    {
        ball.ChangeCanMove(true);
        actualGameState = GameState.PLAYING;
        ChangePanelActive(actualGameState);
    }

    public void ChangeActualStateToResetPosition()
    {
        ball.ResetPosition();
        players[0].ResetPosition();
        players[1].ResetPosition();
        actualGameState = GameState.RESET_POSITION;
        ChangePanelActive(actualGameState);
    }

    public void ChangeActualStateToEndGame()
    {
        hasWon = true;
        ball.ChangeCanMove(false);
        actualGameState = GameState.END_GAME;
        ChangePanelActive(actualGameState);
    }

    private void ChangePanelActive(GameState state)
    {
        panelGame.SetActive(state == GameState.PLAYING || state == GameState.RESET_POSITION);
        panelWon.SetActive(state == GameState.END_GAME);
        panelStart.SetActive(state == GameState.MENU);

        if (hasWon)
        {
            hasWon = false;
            points.RestartPoints();
        }
    }

    public void OpenOptions(bool open)
    {
        panelOptions.SetActive(open);
        if (!open)
        {
            panelGame.SetActive(actualGameState == GameState.PLAYING || actualGameState == GameState.RESET_POSITION);
            panelWon.SetActive(actualGameState == GameState.END_GAME);
            panelStart.SetActive(actualGameState == GameState.MENU);
        }
    }

    public void OpenColors(bool open)
    {
        panelColors.SetActive(open);
        panelOptions.SetActive(!open);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
