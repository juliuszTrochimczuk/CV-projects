using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detonation : MonoBehaviour
{
    public List<Transform> ShootingPoints;

    public GameObject BulletPrefab;

    public bool Detonate = false;

    public float bulletSpeed;
    EnemyBullet bulletParametrs;

    private void OnDestroy()
    {
        if (Detonate)
        {
            for (int i = 0; i < ShootingPoints.Count; i++)
            {
                GameObject newBullet = Instantiate(BulletPrefab, ShootingPoints[i].position, ShootingPoints[i].rotation);

                bulletParametrs = newBullet.GetComponent<EnemyBullet>();
                bulletParametrs.Speed = bulletSpeed;
            }
        }
    }
}
