using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Moviment")]
    [SerializeField] private Rigidbody2D playerRB;
    [SerializeField] private float speed = 0.1f;

    [Header("Key setup")]
    [SerializeField] private KeyCode keyMoveUp = KeyCode.UpArrow;
    [SerializeField] private KeyCode keyMoveDown = KeyCode.DownArrow;

    private Vector3 startPosition;
    private bool initied = false;

    private void Start()
    {
        startPosition = transform.position;
        initied = true;
    }

    private void Update()
    {
        if (Input.GetKey(keyMoveUp))
        {
            playerRB.MovePosition(transform.position + transform.up * speed);
        }
        else if (Input.GetKey(keyMoveDown))
        {
            playerRB.MovePosition(transform.position + transform.up * -speed);
        }
    }

    public void ResetPosition()
    {
        if (initied) transform.position = startPosition;
    }
}