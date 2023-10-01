using UnityEngine;

public enum Sides
{
    LEFT,
    RIGHT
}

public class TriggerPoint : MonoBehaviour
{
    [SerializeField] private Sides side;
    [SerializeField] private Points points;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == TagsController.ballTag)
        {
            CountPoint();
        }
    }

    private void CountPoint()
    {
        if(side == Sides.LEFT)
        {
            points.IncrementPointsPlayerR();
        }
        else
        {
            points.IncrementPointsPlayerL();
        }
    }
}
