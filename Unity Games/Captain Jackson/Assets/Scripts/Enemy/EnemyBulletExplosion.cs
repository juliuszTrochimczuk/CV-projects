using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletExplosion : MonoBehaviour
{
    Vector2 BeginingPosition;

    public List<Transform> ExplosionPoints;

    public GameObject BulletPrefab;
    GameObject newBullet;

    AudioManager AudioPlayer;

    EnemyBullet bulletParametrs;
    public float bulletSpeed;

    void Start()
    {
        BeginingPosition = gameObject.transform.position;
        AudioPlayer = FindObjectOfType<AudioManager>();

        newBullet = BulletPrefab;

        bulletParametrs = newBullet.GetComponent<EnemyBullet>();
        bulletParametrs.Speed = bulletSpeed;
    }

    void FixedUpdate()
    {
        if (Vector2.Distance(BeginingPosition, gameObject.transform.position) > 8.0f && gameObject.activeSelf == true)
        {
            Explosion();
        }
    }

    void Explosion()
    {
        for (int i = 0; i < ExplosionPoints.Count; i++)
        {
            Instantiate(newBullet, ExplosionPoints[i].position, ExplosionPoints[i].rotation);
        }
        AudioPlayer.PlayAudio("EnemyOrbExplode");
        Destroy(gameObject);
    }
}
