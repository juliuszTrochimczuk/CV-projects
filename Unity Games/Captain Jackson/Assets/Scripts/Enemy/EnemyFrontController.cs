using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFrontController : MonoBehaviour
{
    public List<GameObject> Positions;

    Vector2 VectorMove;
    float MoveSpeed = 4.0f;
    float BetweenPlayer = 0.0f;
    float CountDown = 1.0f;

    bool ReadyToFight = false;
    bool RTD = false; // Ready To Detonation;

    OrbGenerator orbGenerator;

    GameObject Player;
    PlayerScore score;

    EnemyTexture texture;
    EnemyHealth health;
    Detonation detonation;
    Rigidbody2D rb;

    public GameObject EnemyPrefab;
    GameObject Enemy;

    void Start()
    {
        Enemy = Instantiate(EnemyPrefab, Positions[0].transform.position, Quaternion.Euler(0.0f, 0.0f, 0.0f));

        texture = Enemy.GetComponent<EnemyTexture>();
        health = Enemy.GetComponent<EnemyHealth>();
        detonation = Enemy.GetComponent<Detonation>();
        rb = Enemy.GetComponent<Rigidbody2D>();

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
            {
                ReadyToFight = true;
                health.ReadyToFight = true;
            }
        }
        else
        {
            AimingToPlayer();
        }

        if (health.Died)
        {
            orbGenerator.Generator(Enemy.transform.position);
            score.IncreaseScore(10);
            Destroy(Enemy);
            Destroy(gameObject);
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

            BetweenPlayer = Vector2.Distance(Enemy.transform.position, Player.transform.position);
        }

        catch
        {
            VectorMove = new Vector2(0.0f, 0.0f);
        }

        if (RTD)
        {
            Detonation();
        }

        else
        {
            if (BetweenPlayer <= 10.0 && BetweenPlayer >= 3.0f)
                ReadyToDetonation();
            else if (BetweenPlayer <= 3.0f)
                Detonation();
            else
                Normal();
        }
    }

    void ReadyToDetonation()
    {
        texture.spriteRenderer.sprite = texture.SpeedTexture[1];
        MoveSpeed = 3.5f;
    }

    void Detonation()
    {
        VectorMove = new Vector2 (0.0f, 0.0f);
        texture.spriteRenderer.sprite = texture.SpeedTexture[2];
        RTD = true;
        CountDown -= Time.deltaTime;
        if (CountDown <= 0.0f)
        {
            detonation.Detonate = true;
            health.DamagingObject();
            Destroy(gameObject);
        }
    }

    void Normal()
    {
        texture.spriteRenderer.sprite = texture.SpeedTexture[0];
        MoveSpeed = 4.0f;
    }

    void Moving(Vector2 vector)
    {
        rb.MovePosition((Vector2)Enemy.transform.position + (vector * MoveSpeed * Time.deltaTime));
    }
}
