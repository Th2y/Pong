using UnityEngine;
using TMPro;

public class Points : MonoBehaviour
{
    [Header("Players")]
    [SerializeField] private TextMeshProUGUI playerRText;
    [SerializeField] private TextMeshProUGUI playerLText;
    [SerializeField] private GameData gameData;
    [SerializeField] private TextMeshProUGUI playerWhoWon;

    [Header("Components")]
    [SerializeField] private TMP_InputField pointsToWinInput;
    [SerializeField] private Score score;
    
    private int pointsToWin = 5;
    private int playerRPoints = 0;
    private int playerLPoints = 0;

    public void Init()
    {
        pointsToWin = gameData.PointsToWin;
        pointsToWinInput.text = pointsToWin.ToString();
    }

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
            score.AddEntrie(playerRPoints, playerLPoints, gameData.PlayerRName);
            playerWhoWon.text = gameData.PlayerRName;
            StateMachine.Instance.SwitchState(GameState.END_GAME);
        }
        else if(playerLPoints >= pointsToWin)
        {
            score.AddEntrie(playerRPoints, playerLPoints, gameData.PlayerLName);
            playerWhoWon.text = gameData.PlayerLName;
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

    public void SavePointsToWin()
    {
        pointsToWin = short.Parse(pointsToWinInput.text);

        if (pointsToWin <= 0) pointsToWin = 1;
        gameData.PointsToWin = pointsToWin;
    }
}
