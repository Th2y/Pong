using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum GameState
{
    START,
    GAME,
    WON
}

public class Points : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject panelGame;
    [SerializeField] private GameObject panelWon;
    [SerializeField] private GameObject panelStart;

    [Header("Players")]
    [SerializeField] private TextMeshProUGUI playerRText;
    [SerializeField] private TextMeshProUGUI playerLText;

    [Header("Variables")]
    [SerializeField] private int pointsToWin = 5;
    private GameState gameState = GameState.START;
    private int playerRPoints = 0;
    private int playerLPoints = 0;

    private void Awake()
    {
        ChangeActualStateToStart();
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
        if (playerRPoints >= 5)
        {
            ChangeActualStateToWon();
        }
        else if(playerLPoints >= 5)
        {
            ChangeActualStateToWon();
        }
    }

    public void ChangeActualStateToStart()
    {
        gameState = GameState.START;
        ChangePanelActive();
    }

    public void ChangeActualStateToGame()
    {
        gameState = GameState.GAME;
        ChangePanelActive();
    }

    public void ChangeActualStateToWon()
    {
        gameState = GameState.WON;
        ChangePanelActive();
    }

    private void ChangePanelActive()
    {
        panelGame.SetActive(gameState == GameState.GAME);
        panelWon.SetActive(gameState == GameState.WON);
        panelStart.SetActive(gameState == GameState.START);

        if (gameState != GameState.GAME)
        {
            RestartPoints();
        }
    }

    private void RestartPoints()
    {
        playerRPoints = 0;
        playerLPoints = 0;
        playerRText.text = playerRPoints.ToString();
        playerLText.text = playerLPoints.ToString();
    }
}
