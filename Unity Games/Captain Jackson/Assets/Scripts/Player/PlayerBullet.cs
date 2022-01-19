using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float BulletSpeed;
    
    void FixedUpdate()
    {
        transform.Translate(Vector2.up * BulletSpeed * Time.fixedDeltaTime, Space.Self);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.SendMessage("DamagingObject");
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Edge")
        {
            Destroy(gameObject);
        }

        else if (collision.gameObject.tag == "Boss")
        {
            collision.gameObject.SendMessage("DamageToBoss");
            Destroy(gameObject);
        }
    }
}
