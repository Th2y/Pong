using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Game Data")]

public class GameData : ScriptableObject
{
    [Header("Colors")]
    public Color Table;
    public Color Limits;
    public Color Ball;
    public Color PlayerR;
    public Color PlayerL;

    [Header("Players Names")]
    public string PlayerRName;
    public string PlayerLName;

    [Header("Players Options")]
    public int PointsToWin;
}
