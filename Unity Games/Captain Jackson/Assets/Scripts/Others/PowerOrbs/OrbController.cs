using System.Collections.Generic;
using UnityEngine;

public class OrbController : MonoBehaviour
{
    GameObject Orb;

    List<Transform> Way;

    Vector2 Move;

    public float Speed;
    float ColorDegree = 0.001f;

    OrbDestroying orbDestroyed;
    OrbMove orbMove;

    Color orbColor;

    SpriteRenderer spriteRenderer;

    int IndexWay = 0;

    bool ReadyToGo = false;

    public GameObject Player;
    PlayerHealth health;
    CollectingOrbs collect;

    string OrbTag;

    private void Start()
    {
        try
        {
            Player = GameObject.Find("Player");
        }
        catch
        {
            Destroy(gameObject);
            Destroy(Orb);
        }
        health = Player.GetComponent<PlayerHealth>();
        collect = Player.GetComponent<CollectingOrbs>();
    }

    void Update()
    {
        if (orbDestroyed.Killed)
        {
            collect.Collecting(OrbTag);
            Destroy(gameObject);
            Destroy(Orb);
        }
        else
        {
            if (ReadyToGo)
            {
                if (Vector2.Distance(Orb.transform.position, Way[IndexWay].position) < 0.2f)
                {
                    CreatingMove();
                }
            }
        }
    }
    public void CreatingOrb(GameObject orb, Vector2 Position, List<Transform> newWay)
    {
        Orb = Instantiate(orb, Position, Quaternion.Euler(0.0f, 0.0f, 0.0f));
        OrbTag = Orb.tag;
        orbDestroyed = Orb.GetComponent<OrbDestroying>();
        spriteRenderer = Orb.GetComponent<SpriteRenderer>();
        orbMove = Orb.GetComponent<OrbMove>();
        orbColor = Color.white;

        Way = newWay;
        FirstMove();

        ReadyToGo = true;
    }

    void FirstMove()
    {
        Vector2 VectorMove = Orb.transform.position - Way[IndexWay].position;
        VectorMove *= (-1);
        VectorMove.Normalize();

        Move = VectorMove * Speed;
        orbMove.NewMove(Move);
    }

    void CreatingMove()
    {
        if (IndexWay+1 < Way.Count)
        {
            IndexWay += 1;
            Vector2 VectorMove = Orb.transform.position - Way[IndexWay].position;
            VectorMove *= (-1);
            VectorMove.Normalize();

            Move = VectorMove * Speed;
            orbMove.NewMove(Move);
        }
        else
        {
            Disappearing();
        }
    }

    void Disappearing()
    {
        if (Move.magnitude != 0)
        {
            Move = new Vector2(0.0f, 0.0f);
            orbMove.NewMove(Move);
        }
        else
        {
            if (orbColor.a <= 0)
            {
                Destroy(gameObject);
                Destroy(Orb);
            }
            else
            {
                ColorDegree += 0.001f;
                orbColor.a -= ColorDegree * Time.deltaTime;
                spriteRenderer.color = orbColor;
            }
        }
    }
}
