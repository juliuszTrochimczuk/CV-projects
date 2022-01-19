using UnityEngine;
public class EnemyMove : MonoBehaviour
{
    public Vector2 Way;
    public float speed = 4.0f;
    
    void FixedUpdate()
    {
        transform.Translate(speed * Way * Time.deltaTime);
    }

    public void ChangingVector(Vector2 newVector)
    {
        Way = newVector;
    }
}
