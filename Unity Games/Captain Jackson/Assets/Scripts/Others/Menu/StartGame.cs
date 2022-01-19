using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    float LivingTime;
    AudioManager audioPlayer;
    int MapIndex = 0;
    bool musicPlayed = false;

    private void Awake()
    {
        audioPlayer = FindObjectOfType<AudioManager>();
    }

    void Update()
    {
        if (!musicPlayed)
        {
            audioPlayer.StopAudio("MenuMusic");
            musicPlayed = true;
        }

        LivingTime += Time.deltaTime;

        if (LivingTime >= 1.7f)
        {
            audioPlayer.PlayAudio("MainMusic");
            SceneManager.LoadScene(MapIndex);
        }
    }

    public void MapLoader(int newMapIndex)
    {
        MapIndex = newMapIndex;
    }
}
