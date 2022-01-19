using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampaignSquadron : MonoBehaviour
{
    [Header("Lists of normal ways")]
    public List<Squad> easyWays;
    public List<Squad> normalWays;
    public List<Squad> hardWays;

    [Header("List of first ways")]
    public List<Squad> firstEasyWays;
    public List<Squad> firstNormalWays;
    public List<Squad> firstHardWays;

    [Header("Active squadron")]
    [HideInInspector]
    public List<GameObject> activeSquad;

    [Header("Player score")]
    PlayerScore player;
    int score;

    [Header("Drawing system")]
    System.Random random = new System.Random();

    void Awake()
    {
        DrawingSquadron(firstEasyWays);
    }

    void Start()
    {
        player = FindObjectOfType<PlayerScore>();
    }

    void Update()
    {
        score = player.Score;

        CheckingSquad(activeSquad);

        if (activeSquad.Count == 0)
        {
            CheckingWays();
        }
    }

    void CheckingSquad(List<GameObject> activeSquad)
    {
        for (int i = 0; i < activeSquad.Count; i++)
        {
            GameObject enemyObject = activeSquad[i];
            if (enemyObject == null)
            {
                activeSquad.RemoveAt(i);
            }
        }
    }

    void CheckingWays()
    {
        if (score < 500)
            DrawingSquadron(easyWays);

        else if (score >= 500 && score <= 1500)
        {
            if (score >= 500 && score <= 520)
                DrawingSquadron(firstNormalWays);
            else
                DrawingSquadron(normalWays);
        }

        else if (score>=1500)
        {
            if (score >= 1500 && score <= 1520)
                DrawingSquadron(firstHardWays);
            else
                DrawingSquadron(hardWays);
        }
    }

    void DrawingSquadron(List<Squad> squadronToDraw)
    {
        int whichSquad = random.Next(0, squadronToDraw.Count);

        List<GameObject> newSquad = squadronToDraw[whichSquad].enemyWave;

        CreatingSquad(newSquad);
    }

    void CreatingSquad(List<GameObject> squad)
    {
        for (int i = 0; i < squad.Count; i++)
        {
            GameObject newEnemy = Instantiate(squad[i]);
            activeSquad.Add(newEnemy);
        }
    }
}
