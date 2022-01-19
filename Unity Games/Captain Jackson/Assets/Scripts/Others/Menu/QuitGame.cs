using UnityEngine;

public class QuitGame : MonoBehaviour
{
    float LivingTime;

    void Update()
    {
        LivingTime += Time.deltaTime;
        if (LivingTime >= 0.5f)
            Application.Quit();
    }
}