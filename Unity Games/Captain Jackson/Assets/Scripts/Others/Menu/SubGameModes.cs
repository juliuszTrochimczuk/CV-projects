using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubGameModes : MonoBehaviour
{
    [Header("Texts")]
    public Text BestJack;
    public Text BestOneHeart;
    public Text BestOneShoot;
    public Text BestSlow;
    public Text BestFlip;

    [Header("StartGame")]
    public GameObject StartGame;
    StartGame start;

    [Header("AudioManager")]
    public AudioManager audioManager;

    void Start()
    {
        BestJack.text = PlayerData.BestJack.ToString();
        BestOneHeart.text = PlayerData.BestOneHeart.ToString();
        BestOneShoot.text = PlayerData.BestOneShoot.ToString();
        BestSlow.text = PlayerData.BestSlow.ToString();
        BestFlip.text = PlayerData.BestFlip.ToString();

        start = StartGame.GetComponent<StartGame>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void PlayJackMode()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        audioManager.PlayAudio("StartGame");
        StartGame.SetActive(true);
        start.MapLoader(5);
    }

    public void PlayOneHeartMode()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        audioManager.PlayAudio("StartGame");
        StartGame.SetActive(true);
        start.MapLoader(7);
    }

    public void PlayOneShootMode()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        audioManager.PlayAudio("StartGame");
        StartGame.SetActive(true);
        start.MapLoader(8);
    }

    public void PlaySlowMode()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        audioManager.PlayAudio("StartGame");
        StartGame.SetActive(true);
        start.MapLoader(6);
    }

    public void PlayFlipMode()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        audioManager.PlayAudio("StartGame");
        StartGame.SetActive(true);
        start.MapLoader(9);
    }
}
