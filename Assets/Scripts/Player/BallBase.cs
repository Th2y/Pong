using UnityEngine;

public class BallBase : MonoBehaviour
{
    [SerializeField] private Vector3 speed = new Vector3(1, 1, 0);    

    [Header("Randomization")]
    [SerializeField] private Vector2 randMinSpeed = new Vector2(1, 3);
    [SerializeField] private Vector2 randMaxSpeed = new Vector2(1, 3);

    [Header("Initial values")]
    private Vector3 startPosition;
    private Vector3 startspeed;

    private bool canMove = false;

    private void Start()
    {
        startPosition = transform.position;
        startspeed = speed;
    }

    private void Update()
    {
        if (!canMove) return;

        transform.Translate(speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == TagsController.playerTag)
        {
            OnPlayerColision();
        }
        else
        {
            speed.y *= -1;
        }
    }

    private void OnPlayerColision()
    {
        speed.x *= -1;
        float randX = Random.Range(randMinSpeed.x, randMaxSpeed.x);
        if (speed.x < 0) randX = -randX;
        speed.x = randX;

        float randY = Random.Range(randMinSpeed.y, randMaxSpeed.y);
        speed.y = randY;
    }

    public void ResetPosition()
    {
        transform.position = startPosition;
        if(canMove) speed = startspeed;
        canMove = false;
    }

    public void ChangeCanMove(bool state)
    {
        canMove = state;
    }
}
