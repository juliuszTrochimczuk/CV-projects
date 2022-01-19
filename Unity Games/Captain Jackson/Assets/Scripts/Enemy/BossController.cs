using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossController : MonoBehaviour
{
    [Header("Move vectors")]
    public List<Vector2> Positions;
    Vector2 Move;

    [Header("Whole move variables")]
    int MIndex = 0;
    bool RTF = false;

    [Header("Boss Object")]
    public GameObject BossObj;
    GameObject ExplosionShoot;
    GameObject BulletShoot;

    [Header("Components")]
    EnemyShooting Enemy_Bullet;
    EnemyShooting Enemy_Explosive;
    EnemyMove BossMove;
    BHealth BossHealth;
    SpriteRenderer renderer;

    [Header("Boss health bar")]
    public Slider BossHealthSlider;

    [Header("Final Explosion")]
    public GameObject Explosion;
    float Timer;
    bool DestructionPlayed = false;

    AudioManager audioManager;

    

    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();

        ExplosionShoot = BossObj.transform.GetChild(0).gameObject;
        BulletShoot = BossObj.transform.GetChild(2).gameObject;

        Enemy_Bullet = BulletShoot.GetComponent<EnemyShooting>();
        Enemy_Explosive = ExplosionShoot.GetComponent<EnemyShooting>();
        BossHealth = BossObj.GetComponent<BHealth>();
        BossMove = BossObj.GetComponent<EnemyMove>();
        renderer = BossObj.GetComponent<SpriteRenderer>();

        Move = (Vector2)BossObj.transform.position - Positions[0];
        Move.Normalize();
        BossMove.ChangingVector(Move);
    }

    void Update()
    {
        BossHealthSlider.value = BossHealth.Health;

        if (BossHealth.Health <= 0)
        {
            Enemy_Bullet.ReadyToFight = false;
            Enemy_Explosive.ReadyToFight = false;
            renderer.enabled = false;
            Explosion.SetActive(true);
            if (!DestructionPlayed)
            {
                audioManager.PlayAudio("EnemyDestroy");
                DestructionPlayed = true;
            }
            Timer += Time.deltaTime;      
            if (Timer >= 2.0f)
            {
                PlayerData.BossKilled = true;
                PlayerData.SaveinData();
                audioManager.StopAudio("MainMusic");
                SceneManager.LoadScene("EndingScene");
            }
        }

        if (Vector2.Distance(Positions[MIndex], BossObj.transform.position) < 0.2f)
        {
            NewVector();
            if (!RTF)
            {
                RTF = true;
                Enemy_Bullet.ReadyToFight = true;
                Enemy_Explosive.ReadyToFight = true;
            }
        }
    }

    void NewVector()
    {
        MIndex++;
        if (MIndex < Positions.Count)
        {
            Move = (Vector2)BossObj.transform.position - Positions[MIndex];
            Move.Normalize();
            BossMove.ChangingVector(Move);
        }
        else
        {
            MIndex = 0;
            Move = (Vector2)BossObj.transform.position - Positions[MIndex];
            Move.Normalize();
            BossMove.ChangingVector(Move);
        }
    }

    public void BossStopShooting()
    {
        Enemy_Bullet.StopShooting();
        Enemy_Explosive.StopShooting();
    }
}
