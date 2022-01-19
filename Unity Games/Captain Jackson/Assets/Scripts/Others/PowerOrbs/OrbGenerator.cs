using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class OrbGenerator : MonoBehaviour
{
    public List<GameObject> PowerOrbs;
    public List<GameObject> ActiveOrbs;

    public GameObject OrbController;

    public List<GameObject> OrbWays;

    System.Random random;

    OrbWays ways;

    OrbController controller;

    bool isJackMode = false;

    int WhichOrb;

    void Start()
    {
        random = new System.Random();

        if (SceneManager.GetActiveScene().name == "JackMode")
            isJackMode = true;
    }

    void Update()
    {
        for (int i=0; i<ActiveOrbs.Count; i++)
        {
            if (ActiveOrbs[i].gameObject == null)
            {
                ActiveOrbs.RemoveAt(i);
            }
        }
    }

    public void Generator(Vector3 spawnPosition)
    {
        if (ActiveOrbs.Count < 4)
        {
            int ChanceForOrb = random.Next(0, 101);
            if (ChanceForOrb >= 65)
            {
                if (!isJackMode)
                {
                    if (ChanceForOrb >= 95)
                        WhichOrb = PowerOrbs.Count - 1;
                    else
                        WhichOrb = random.Next(0, PowerOrbs.Count - 1);
                }
                int WhichWay = random.Next(0, OrbWays.Count);
                ways = OrbWays[WhichWay].GetComponent<OrbWays>();
                GameObject newOrb = Instantiate(OrbController, new Vector2(0.0f, 0.0f), Quaternion.Euler(0.0f, 0.0f, 0.0f));
                ActiveOrbs.Add(newOrb);
                controller = newOrb.GetComponent<OrbController>();
                controller.CreatingOrb(PowerOrbs[WhichOrb], spawnPosition, ways.Way);
                return;
            }
        }
    }
}
