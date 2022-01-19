using System.Collections.Generic;
using UnityEngine;

public class EnemyShipController : MonoBehaviour
{
    public List<Transform> Points;

    public bool Loop;
    public bool Cycling;
    bool Reverse;
    bool ReadyToFight;

    public GameObject EnemyPrefab;
    public GameObject Enemy;
    GameObject Player;

    int PositionInList;

    public Vector2 EnemyMove;

    EnemyHealth Health;

    EnemyShooting shooting;

    EnemyTexture texture;

    EnemyMove move;

    OrbGenerator orbGenerator;

    public Transform Begining;

    PlayerScore points;

    void Start()
    {
        Enemy = Instantiate(EnemyPrefab, Begining.position, EnemyPrefab.transform.rotation);

        Health = Enemy.GetComponent<EnemyHealth>();

        Player = GameObject.Find("Player");
        points = Player.GetComponent<PlayerScore>();

        shooting = Enemy.GetComponent<EnemyShooting>();

        texture = Enemy.GetComponent<EnemyTexture>();
        texture.ChangingTexture(0);

        move = Enemy.GetComponent<EnemyMove>();

        orbGenerator = GameObject.Find("PowerOrbGenerator").GetComponent<OrbGenerator>();

        Vector2 BetweenPoints = Enemy.transform.position - Points[0].position;
        BetweenPoints.Normalize();

        EnemyMove = BetweenPoints * 2;

        move.ChangingVector(EnemyMove);

        PositionInList = 0;
        Reverse = false;
        ReadyToFight = false;
    }

    void Update()
    {
        if (!ReadyToFight && gameObject.activeSelf)
        {
            OpeningFire();
        }

        if (Health.Died)
        {
            orbGenerator.Generator(Enemy.transform.position);
            points.IncreaseScore(10);
            Destroy(Enemy);
            Destroy(gameObject);
        }

        else
        {
            if (Reverse)
            {
                ReverseMove();
            }

            NormalMove();
        }
    }

    void CreatingMove() 
    {
        Vector2 BetweenPoints = Enemy.transform.position - Points[PositionInList].position;
        BetweenPoints.Normalize();

        move.ChangingVector(BetweenPoints);
    }

    void NormalMove()
    {
        if (Vector2.Distance(Enemy.transform.position, Points[PositionInList].position) < 0.2f)
        {
            if (PositionInList + 1 < Points.Count)
            {
                PositionInList += 1;
                texture.ChangingTexture(1);
                CreatingMove();
            }
            else
            {
                if (Cycling)
                {
                    Reverse = true;
                    PositionInList -= 1;
                    CreatingMove();
                }
                else if (!Loop)
                {
                    texture.ChangingTexture(2);
                    EnemyMove = new Vector2(0, 0);
                    move.ChangingVector(EnemyMove);
                }
                else
                {
                    PositionInList = 0;
                    CreatingMove();
                }
            }
        }
    }

    void ReverseMove()
    {
        if (Vector2.Distance(Enemy.transform.position, Points[PositionInList].position) < 0.2f)
        {
            if (PositionInList - 1 > -1)
            {
                PositionInList -= 1;
                CreatingMove();
            }
            else
            {
                Reverse = false;
            }
        }
    }

    void OpeningFire()
    {
        if (Vector2.Distance(Enemy.transform.position, Points[0].position) < 0.2f)
        {
            ReadyToFight = true;
            shooting.ReadyToFight = ReadyToFight;
            Health.ReadyToFight = ReadyToFight;
        }
    }
}
