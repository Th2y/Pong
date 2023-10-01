using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject panelGame;
    [SerializeField] private GameObject panelWon;
    [SerializeField] private GameObject panelStart;

    [Header("References")]
    [SerializeField] private BallBase ball;
    [SerializeField] private Points points;
    [SerializeField] private Player[] players;

    public static GameManager Instance;

    private bool hasWon = false;

    private void Awake()
    {
        Instance = this;
    }

    public void ChangeActualStateToMenu()
    {
        ball.ChangeCanMove(false);
        ChangePanelActive(GameState.MENU);
    }

    public void ChangeActualStateToGame()
    {
        ball.ChangeCanMove(true);
        ChangePanelActive(GameState.PLAYING);
    }

    public void ChangeActualStateToResetPosition()
    {
        ball.ResetPosition();
        players[0].ResetPosition();
        players[1].ResetPosition();
        ChangePanelActive(GameState.RESET_POSITION);
    }

    public void ChangeActualStateToEndGame()
    {
        hasWon = true;
        ball.ChangeCanMove(false);
        ChangePanelActive(GameState.END_GAME);
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
}
