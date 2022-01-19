using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTexture : MonoBehaviour
{
    public List<Sprite> SpeedTexture;

    public SpriteRenderer spriteRenderer;

    public GameObject ObjectRenderer;

    void Start()
    {
        spriteRenderer = ObjectRenderer.GetComponent<SpriteRenderer>();
    }

    public void ChangingTexture(int index)
    {
        spriteRenderer.sprite = SpeedTexture[index];
    }
}
