using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKamikadze : MonoBehaviour
{
    public List<GameObject> Positions;

    Vector2 VectorMove;
    float MoveSpeed = 4.0f;

    bool ReadyToFight = false;

    OrbGenerator orbGenerator;

    GameObject Player;
    PlayerScore score;

    EnemyHealth health;
    Rocket kamikadze;
    Rigidbody2D rb;

    public GameObject EnemyPrefab;
    GameObject Enemy;

    void Start()
    {
        Enemy = Instantiate(EnemyPrefab, Positions[0].transform.position, Quaternion.Euler(0.0f, 0.0f, 0.0f));

        health = Enemy.GetComponent<EnemyHealth>();
        kamikadze = Enemy.GetComponent<Rocket>();
        rb = Enemy.GetComponent<Rigidbody2D>();

        health.ReadyToFight = true;

        Player = GameObject.Find("Player");
        score = Player.GetComponent<PlayerScore>();

        orbGenerator = GameObject.Find("PowerOrbGenerator").GetComponent<OrbGenerator>();

        VectorMove = Positions[1].transform.position - Positions[0].transform.position;

        float angle = Mathf.Atan2(VectorMove.y, VectorMove.x) * Mathf.Rad2Deg;
        rb.rotation = angle;

        VectorMove.Normalize();
        VectorMove *= 2;
    }

    void Update()
    {
        if (!ReadyToFight)
        {
            if (Vector2.Distance(Enemy.transform.position, Positions[1].transform.position) < 0.2f)
                ReadyToFight = true;
        }

        else AimingToPlayer();

        if (health.Died)
        {
            orbGenerator.Generator(Enemy.transform.position);
            score.IncreaseScore(10);
            Destroy(gameObject);
            Destroy(Enemy);
        }

        if (kamikadze.Explode)
        {
            Destroy(gameObject);
            health.DamagingObject();
            Destroy(Enemy);
        }
    }

    private void FixedUpdate()
    {
        Moving(VectorMove);
    }


    void AimingToPlayer()
    {
        try
        {
            VectorMove = Player.transform.position - Enemy.transform.position;

            float angle = Mathf.Atan2(VectorMove.y, VectorMove.x) * Mathf.Rad2Deg;
            rb.rotation = angle;

            rb.rotation = angle;

            VectorMove.Normalize();
        }
        catch
        {
            VectorMove = new Vector2(0.0f, 0.0f);
        }
    }

    void Moving(Vector2 vector)
    {
        rb.MovePosition((Vector2)Enemy.transform.position + (vector * MoveSpeed * Time.deltaTime));
    }
}
