using TMPro;
using UnityEngine;

public class PlayerName : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameData gameData;
    [SerializeField] private TMP_InputField playerRInputName;
    [SerializeField] private TMP_InputField playerLInputName;

    private void Awake()
    {
        playerRInputName.text = gameData.PlayerRName;
        playerLInputName.text = gameData.PlayerLName;
    }

    public void SavePlayerRName()
    {
        gameData.PlayerRName = playerRInputName.text;
    }

    public void SavePlayerLName()
    {
        gameData.PlayerLName = playerLInputName.text;
    }
}
