using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public List<Transform> ShootingPoints;

    public GameObject BulletPrefab;

    public float ReloadTime;
    float AcutualReloadTime;
    public float bulletSpeed;

    EnemyBullet bulletParametrs;

    public bool ReadyToFight;

    string AudioTitle;

    AudioManager audioPlayer;

    void Start()
    {
        audioPlayer = FindObjectOfType<AudioManager>();

        if (BulletPrefab.name == "Enemy_Bullet")
            AudioTitle = "EnemyShootBullet";
        else if (BulletPrefab.name == "Enemy_Power_Orb")
            AudioTitle = "EnemyShootOrb";
        else if (BulletPrefab.name == "Enemy_Explosion_Orb")
            AudioTitle = "EnemyExplosionOrb";
    }

    void Update()
    {
        AcutualReloadTime += Time.deltaTime;

        if (AcutualReloadTime >= ReloadTime && ReadyToFight)
        {
            Shooting();
        }
    }

    void Shooting()
    {
        for (int i = 0; i < ShootingPoints.Count; i++)
        {
            GameObject newBullet = Instantiate(BulletPrefab, ShootingPoints[i].position, ShootingPoints[i].rotation);

            bulletParametrs = newBullet.GetComponent<EnemyBullet>();
            bulletParametrs.Speed = bulletSpeed;
        }

        audioPlayer.PlayAudio(AudioTitle);
        AcutualReloadTime = 0;
    }

    public void StopShooting()
    {
        ReadyToFight = false;
    }
}
