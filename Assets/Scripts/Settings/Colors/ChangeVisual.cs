using UnityEngine;
using UnityEngine.UI;

public class ChangeVisual : MonoBehaviour
{
    [Header("Colors")]
    [SerializeField] private GameData gameData;
    [SerializeField] private Image table;
    [SerializeField] private Image[] limits;
    [SerializeField] private Image playerR;
    [SerializeField] private Image playerL;
    [SerializeField] private Image ball;

    [Header("Options")]
    [SerializeField] private ButtonColor[] tableColors;
    [SerializeField] private ButtonColor[] limitsColors;
    [SerializeField] private ButtonColor[] playerRColors;
    [SerializeField] private ButtonColor[] playerLColors;
    [SerializeField] private ButtonColor[] ballColors;

    private void Awake()
    {
        table.color = gameData.Table;
        foreach(Image limit in limits)
        {
            limit.color = gameData.Limits;
        }
        ball.color = gameData.Ball;
        playerR.color = gameData.PlayerR;
        playerL.color = gameData.PlayerL;

        DefineOptionsColorSelected();
    }

    private void DefineOptionsColorSelected()
    {
        foreach(ButtonColor buttonColor in tableColors)
        {
            buttonColor.DefineBorderActive(buttonColor.GetColor() == gameData.Table);
        }

        foreach (ButtonColor buttonColor in limitsColors)
        {
            buttonColor.DefineBorderActive(buttonColor.GetColor() == gameData.Limits);
        }

        foreach (ButtonColor buttonColor in playerRColors)
        {
            buttonColor.DefineBorderActive(buttonColor.GetColor() == gameData.PlayerR);
        }

        foreach (ButtonColor buttonColor in playerLColors)
        {
            buttonColor.DefineBorderActive(buttonColor.GetColor() == gameData.PlayerL);
        }

        foreach (ButtonColor buttonColor in ballColors)
        {
            buttonColor.DefineBorderActive(buttonColor.GetColor() == gameData.Ball);
        }
    }

    public void ChangeTableColor(Image image)
    {
        Color color = image.color;
        gameData.Table = color;
        table.color = color;

        foreach (ButtonColor buttonColor in tableColors)
        {
            buttonColor.DefineBorderActive(buttonColor.GetColor() == gameData.Table);
        }
    }

    public void ChangeLimitsColor(Image image)
    {
        Color color = image.color;
        gameData.Limits = color;
        foreach (Image limit in limits)
        {
            limit.color = gameData.Limits;
        }

        foreach (ButtonColor buttonColor in limitsColors)
        {
            buttonColor.DefineBorderActive(buttonColor.GetColor() == gameData.Limits);
        }
    }

    public void ChangePlayerRColor(Image image)
    {
        Color color = image.color;
        gameData.PlayerR = color;
        playerR.color = color;

        foreach (ButtonColor buttonColor in playerRColors)
        {
            buttonColor.DefineBorderActive(buttonColor.GetColor() == gameData.PlayerR);
        }
    }

    public void ChangePlayerLColor(Image image)
    {
        Color color = image.color;
        gameData.PlayerL = color;
        playerL.color = color;

        foreach (ButtonColor buttonColor in playerLColors)
        {
            buttonColor.DefineBorderActive(buttonColor.GetColor() == gameData.PlayerL);
        }
    }

    public void ChangeBallColor(Image image)
    {
        Color color = image.color;
        gameData.Ball = color;
        ball.color = color;

        foreach (ButtonColor buttonColor in ballColors)
        {
            buttonColor.DefineBorderActive(buttonColor.GetColor() == gameData.Ball);
        }
    }
}
