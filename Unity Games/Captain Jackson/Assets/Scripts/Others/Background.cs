using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public List<GameObject> BackgroundImg;

    public float Speed;

    int LastImg;

    public float EndPosition;
    public float BeginingPosition;

    void Start()
    {
        LastImg = 0;
    }

    void Update()
    {
        if (BackgroundImg[LastImg].transform.position.y - EndPosition < 0.2f)
        {
            ChangeingImg();
        }
        for (int i=0; i<BackgroundImg.Count; i++)
        {
            BackgroundImg[i].transform.Translate(0, Speed * Time.deltaTime * (-1), 0);
        }
    }

    void ChangeingImg()
    {
        BackgroundImg[LastImg].transform.position = new Vector3(BackgroundImg[LastImg].transform.position.x, BeginingPosition, BackgroundImg[LastImg].transform.position.z);
        if (LastImg+1 == BackgroundImg.Count)
        {
            LastImg = -1;
        }
        LastImg += 1;
    }
}
