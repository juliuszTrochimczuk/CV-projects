using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMenu : MonoBehaviour
{
    float LivingTime;

    void Update()
    {
        LivingTime += Time.deltaTime;
        if (LivingTime >= 0.5f)
        {
            GameObject.FindObjectOfType<AudioManager>().StopAudio("MainMusic");
            SceneManager.LoadScene("Menu");
        }
    }
}
