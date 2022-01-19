using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameModes : MonoBehaviour
{
    [Header("Canvas")]
    public Canvas GameModesCanvas;
    public Canvas SubModeCanvas;

    [Header("Buttons")]
    public Button Standard;
    public Button Endelss;
    public Button SubModes;

    [Header("Score Texts")]
    public Text StandardScoreText;
    public Text EndlessScoreText;

    [Header("Start Game")]
    StartGame start;

    public GameObject StartGame;

    AudioManager audioManager;

    void Start()
    {
        StandardScoreText.text = PlayerData.BestStandard.ToString();
        EndlessScoreText.text = PlayerData.BestEndless.ToString();

        start = StartGame.GetComponent<StartGame>();
        SubModeCanvas.enabled = false;

        audioManager = FindObjectOfType<AudioManager>();
    }

    public void PlayStandard()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        audioManager.PlayAudio("StartGame");
        StartGame.SetActive(true);
        start.MapLoader(1);
    }

    public void PlayEndless()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        audioManager.PlayAudio("StartGame");
        StartGame.SetActive(true);
        start.MapLoader(4);
    }

    public void ShowSubModes()
    {
        audioManager.PlayAudio("ClickButton");
        GameModesCanvas.enabled = false;
        SubModeCanvas.enabled = true;
    }
}
