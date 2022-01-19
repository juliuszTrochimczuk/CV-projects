using UnityEngine;

public class OrbMove : MonoBehaviour
{
    Vector2 Move;

    void FixedUpdate()
    {
        transform.Translate(Move * Time.deltaTime);
    }

    public void NewMove(Vector2 newMove)
    {
        Move = newMove;
    }
}
