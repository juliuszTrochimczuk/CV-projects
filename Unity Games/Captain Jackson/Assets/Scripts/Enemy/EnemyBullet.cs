using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [HideInInspector]
    public float Speed;

    void FixedUpdate()
    {
        transform.Translate(Vector2.down * Time.fixedDeltaTime * Speed, Space.Self);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Edge")
        {
            Destroy(gameObject);
        }
    }
}
