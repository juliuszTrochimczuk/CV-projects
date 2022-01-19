using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingAnimation : MonoBehaviour
{
    [Header("Sprite render Color")]
    public GameObject Jack;
    public GameObject Alien;
    SpriteRenderer JackRender;
    SpriteRenderer AlienRender;
    Color JackColor;
    Color AlienColor;


    float Timer = 0.0f;
    float ColorDegree = 0.0f;

    public GameObject NextObject;

    private void Start()
    {
        JackRender = Jack.GetComponent<SpriteRenderer>();
        AlienRender = Alien.GetComponent<SpriteRenderer>();

        JackColor = JackRender.color;
        AlienColor = AlienRender.color;
    }
   
    void Update()
    {
        Timer += Time.deltaTime;
        if (Timer >= 3.6f)
        {
            Disapiring();
        }
    }

    void Disapiring()
    {
        if (JackColor.a <= 0)
        {

            Destroy(Jack);
            Destroy(Alien);
            NextObject.SetActive(true);
            Destroy(gameObject);
        }
        else
        {
            ColorDegree += 0.001f;
            JackColor.a -= ColorDegree * Time.deltaTime;
            AlienColor.a -= ColorDegree * Time.deltaTime;
            JackRender.color = JackColor;
            AlienRender.color = AlienColor;
        }
    }
}
