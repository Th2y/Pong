using UnityEngine;
using UnityEngine.UI;

public class ChangeVisual : MonoBehaviour
{
    [Header("Colors")]
    [SerializeField] private ColorsData colorsData;
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
        table.color = colorsData.table;
        foreach(Image limit in limits)
        {
            limit.color = colorsData.limits;
        }
        ball.color = colorsData.ball;
        playerR.color = colorsData.playerR;
        playerL.color = colorsData.playerL;

        DefineOptionsColorSelected();
    }

    private void DefineOptionsColorSelected()
    {
        foreach(ButtonColor buttonColor in tableColors)
        {
            buttonColor.DefineBorderActive(buttonColor.GetColor() == colorsData.table);
        }

        foreach (ButtonColor buttonColor in limitsColors)
        {
            buttonColor.DefineBorderActive(buttonColor.GetColor() == colorsData.limits);
        }

        foreach (ButtonColor buttonColor in playerRColors)
        {
            buttonColor.DefineBorderActive(buttonColor.GetColor() == colorsData.playerR);
        }

        foreach (ButtonColor buttonColor in playerLColors)
        {
            buttonColor.DefineBorderActive(buttonColor.GetColor() == colorsData.playerL);
        }

        foreach (ButtonColor buttonColor in ballColors)
        {
            buttonColor.DefineBorderActive(buttonColor.GetColor() == colorsData.ball);
        }
    }

    public void ChangeTableColor(Image image)
    {
        Color color = image.color;
        colorsData.table = color;
        table.color = color;

        foreach (ButtonColor buttonColor in tableColors)
        {
            buttonColor.DefineBorderActive(buttonColor.GetColor() == colorsData.table);
        }
    }

    public void ChangeLimitsColor(Image image)
    {
        Color color = image.color;
        colorsData.limits = color;
        foreach (Image limit in limits)
        {
            limit.color = colorsData.limits;
        }

        foreach (ButtonColor buttonColor in limitsColors)
        {
            buttonColor.DefineBorderActive(buttonColor.GetColor() == colorsData.limits);
        }
    }

    public void ChangePlayerRColor(Image image)
    {
        Color color = image.color;
        colorsData.playerR = color;
        playerR.color = color;

        foreach (ButtonColor buttonColor in playerRColors)
        {
            buttonColor.DefineBorderActive(buttonColor.GetColor() == colorsData.playerR);
        }
    }

    public void ChangePlayerLColor(Image image)
    {
        Color color = image.color;
        colorsData.playerL = color;
        playerL.color = color;

        foreach (ButtonColor buttonColor in playerLColors)
        {
            buttonColor.DefineBorderActive(buttonColor.GetColor() == colorsData.playerL);
        }
    }

    public void ChangeBallColor(Image image)
    {
        Color color = image.color;
        colorsData.ball = color;
        ball.color = color;

        foreach (ButtonColor buttonColor in ballColors)
        {
            buttonColor.DefineBorderActive(buttonColor.GetColor() == colorsData.ball);
        }
    }
}
