using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAttacking : MonoBehaviour
{
    EnemyShooting enemyShooting;
    BossController boss;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            try
            {
                enemyShooting = collision.gameObject.GetComponent<EnemyShooting>();
                enemyShooting.StopShooting();
            }
            catch
            {

            }
        }

        else if (collision.gameObject.CompareTag("Boss"))
        {
            boss = FindObjectOfType<BossController>();
            boss.BossStopShooting();
        }

        else if (collision.gameObject.CompareTag("EnemyBullet") || collision.gameObject.CompareTag("EnemyPowerOrb"))
        {
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            try
            {
                enemyShooting = collision.gameObject.GetComponent<EnemyShooting>();
                enemyShooting.StopShooting();
            }
            catch
            {

            }
        }
    }
}
