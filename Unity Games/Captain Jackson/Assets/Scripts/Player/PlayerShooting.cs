using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject BulletPrefab;
    public float ReloadTime;
    float AcutualReloadTime;

    PlayerHealth health;

    public List<Transform> ShootingPoints;

    public int ActiveShootingPoints;

    AudioManager AudioPlayer;

    void Start()
    {
        AudioPlayer = FindObjectOfType<AudioManager>();
        health = gameObject.GetComponent<PlayerHealth>();
    }

    void Update()
    {
        AcutualReloadTime += Time.deltaTime;

        if ((Input.GetKeyDown(KeyCode.Space)) && (AcutualReloadTime >= ReloadTime) && (health.PlayerHP > 0))
        {
            Shooting();
            AcutualReloadTime = 0;
        }
    }

    void Shooting()
    {
        for (int i = 0; i <ActiveShootingPoints; i++)
        {
            AudioPlayer.PlayAudio("PlayerShoot");
            Instantiate(BulletPrefab, ShootingPoints[i].position, ShootingPoints[i].rotation);
        }
    }
}
