using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndingText : MonoBehaviour
{
    [Header("Text color")]
    public Text comunicat;
    Color textColor;

    public GameObject NextObject;

    public bool LastOne;
    bool isDisapiring = false;

    [Header("Color Degrees")]
    float ApColorDegree = 0.0f;
    float DisColorDegree = 0.0f;

    [Header("Time variables")]
    public float LiveTime;
    float time;

    void Start()
    {
        textColor = comunicat.color;
        Appearing();
    }

    void Update()
    {
        if (!isDisapiring)
        {
            if (comunicat.color.a < 1)
                Appearing();

            else if (comunicat.color.a >= 1)
            {
                time += Time.deltaTime;
                if (time >= LiveTime)
                {
                    isDisapiring = true;
                }
            }
        }
        else
        {
            Disapiring();
            if (comunicat.color.a <= 0 && LastOne)
            {
                SceneManager.LoadScene("Menu");
                Destroy(gameObject);
            }
            else if (comunicat.color.a <= 0 && !LastOne)
            {
                NextObject.SetActive(true);
                Destroy(gameObject);
            }
        }
    }

    void Appearing()
    {
        ApColorDegree += 0.001f;
        textColor.a += ApColorDegree * Time.deltaTime;
        comunicat.color = textColor;
    }

    void Disapiring()
    {
        DisColorDegree += 0.001f;
        textColor.a -= DisColorDegree * Time.deltaTime;
        comunicat.color = textColor;
    }
}
