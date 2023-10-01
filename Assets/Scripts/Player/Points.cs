using UnityEngine;
using TMPro;

public class Points : MonoBehaviour
{
    [SerializeField] private BallBase ball;

    [Header("Players")]
    [SerializeField] private TextMeshProUGUI playerRText;
    [SerializeField] private TextMeshProUGUI playerLText;

    [Header("Variables")]
    [SerializeField] private int pointsToWin = 5;
    private int playerRPoints = 0;
    private int playerLPoints = 0;

    public void IncrementPointsPlayerR()
    {
        playerRPoints++;
        playerRText.text = playerRPoints.ToString();
        DetectIfWon();
    }

    public void IncrementPointsPlayerL()
    {
        playerLPoints++;
        playerLText.text = playerLPoints.ToString();
        DetectIfWon();
    }

    private void DetectIfWon()
    {
        if (playerRPoints >= pointsToWin)
        {
            StateMachine.Instance.SwitchState(GameState.END_GAME);
        }
        else if(playerLPoints >= pointsToWin)
        {
            StateMachine.Instance.SwitchState(GameState.END_GAME);
        }
        else
        {
            StateMachine.Instance.SwitchState(GameState.RESET_POSITION);
        }
    }

    public void RestartPoints()
    {
        playerRPoints = 0;
        playerLPoints = 0;
        playerRText.text = playerRPoints.ToString();
        playerLText.text = playerLPoints.ToString();
    }
}
