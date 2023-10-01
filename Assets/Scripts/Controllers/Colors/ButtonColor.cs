using UnityEngine;
using UnityEngine.UI;

public class ButtonColor : MonoBehaviour
{
    [SerializeField] private GameObject border;

    private Color color => GetComponent<Image>().color;

    public Color GetColor()
    {
        return color;
    }

    public void DefineBorderActive(bool active)
    {
        border.SetActive(active);
    }
}
