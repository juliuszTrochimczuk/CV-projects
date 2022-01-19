using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squadron : MonoBehaviour
{
    [Header("List of all squads")]
    public List<Squad> squads;

    [Header("Active squad")]
    [HideInInspector]
    public List<GameObject> activeSquad;

    [Header("Controlling variables")]
    System.Random random = new System.Random();

    void Awake()
    {
        DrawingSquadron();
    }

    void Update()
    {
        CheckingSquad(activeSquad);

        if (activeSquad.Count == 0)
        {
            DrawingSquadron();
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

    void DrawingSquadron()
    {
        int whichSquad = random.Next(0, squads.Count);

        List<GameObject> newSquad = squads[whichSquad].enemyWave;

        CreatingSquad(newSquad);
    }

    void CreatingSquad(List<GameObject> squad)
    {
        for (int i=0; i<squad.Count; i++)
        {
            GameObject newEnemy = Instantiate(squad[i]);
            activeSquad.Add(newEnemy);
        }
    }
}

[System.Serializable]
public class Squad
{
    public List<GameObject> enemyWave;
}
