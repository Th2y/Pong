using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeVisual : MonoBehaviour
{
    [Header("Colors")]
    [SerializeField] private ColorsData colorsData;
    [SerializeField] private Image table;
    [SerializeField] private Image[] limits;
    [SerializeField] private Image ball;
    [SerializeField] private Image playerR;
    [SerializeField] private Image playerL;

    private void Awake()
    {
        table.color = colorsData.table;
        foreach(Image limit in limits)
        {
            limit.color = colorsData.limitUp;
        }
        ball.color = colorsData.ball;
        playerR.color = colorsData.playerR;
        playerL.color = colorsData.playerL;
    }
}
