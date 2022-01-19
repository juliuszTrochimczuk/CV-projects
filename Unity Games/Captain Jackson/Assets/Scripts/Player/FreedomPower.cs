using UnityEngine;

public class FreedomPower : MonoBehaviour
{
    SpriteRenderer sprite;

    [SerializeField]
    Color[] LerpColorPalet;

    public bool Freedom = false;
    float FreedomTimer;

    [SerializeField]
    [Range(0.0f, 1.0f)]
    float LerpTime;

    PlayerHealth health;

    int colorIndex = 0;

    float t = 0.0f;

    void Start()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        health = gameObject.GetComponent<PlayerHealth>();
    }

    void Update()
    {
        if (Freedom)
        {
            FreedomTimer -= Time.deltaTime;
            if (FreedomTimer > 0.0f)
            {
                ColorChanges();
            }

            else
            {
                FreedomTimer = 0.0f;
                sprite.color = new Color(1, 1, 1);
                Freedom = false;
                health.FREEDOM = false;
            }
        }
    }

    void ColorChanges()
    {
        sprite.color = Color.Lerp(sprite.color, LerpColorPalet[colorIndex], LerpTime * Time.deltaTime * 15);

        t = Mathf.Lerp(t, 1.0f, LerpTime * Time.deltaTime * 15);

        if (t > 0.9f)
        {
            t = 0;
            colorIndex++;
            colorIndex = (colorIndex >= LerpColorPalet.Length) ? 0 : colorIndex;
        }
    }

    public void FreedomExtend(float extention)
    {
        if (FreedomTimer <= 0.0f)
        {
            Freedom = true;
            health.FREEDOM = true;
        }
        FreedomTimer += extention;
    }
}
