using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryGame : MonoBehaviour
{
    float LivingTime;

    void Update()
    {
        LivingTime += Time.deltaTime;
        if (LivingTime >= 0.5f)
        {
            Scene activeScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(activeScene.name);
        }
    }
}
