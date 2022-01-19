using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScore : MonoBehaviour
{
    [Header("Score variables")]
    public int Score;
    int _oldScore;
    bool gettingScore = false;

    float timeBetween;

    public Text ScoreText;
    public Canvas ScoreCanvas;

    [Header("Audio manager")]
    AudioManager audioPlayer;

    private void Start()
    {
        audioPlayer = FindObjectOfType<AudioManager>();
    }

    void Update()
    {
        if (gettingScore)
        {
            timeBetween += Time.deltaTime * 2;
            if (timeBetween >= 0.15f)
            {
                AddingEffect();
                if (_oldScore == Score)
                    gettingScore = false;
            }
        }
    }

    public void IncreaseScore(int increase)
    {
        Score += increase;
        gettingScore = true;
    }

    void AddingEffect()
    {
        _oldScore++;
        ScoreText.text = _oldScore.ToString();
        audioPlayer.PlayAudio("ScoreUp");
        timeBetween = 0.0f;
    }

    private void OnDestroy()
    {
        ScoreCanvas.enabled = false;
    }
}
