using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    EnemyHealth ThisEnemy;
    EnemyHealth otherEnemy;
    public bool Explode;

    void Start()
    {
        ThisEnemy = gameObject.GetComponent<EnemyHealth>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            ThisEnemy.DamagingObject();
            otherEnemy = collision.gameObject.GetComponent<EnemyHealth>();
            otherEnemy.DamagingObject();
        }

        else if (collision.gameObject.CompareTag("Player"))
            Explode = true;
    }
}
