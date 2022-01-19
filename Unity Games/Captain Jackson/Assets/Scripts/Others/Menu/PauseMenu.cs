using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    AudioManager audioPlayer;
    PlayerScore score;
    PlayerHealth playerhealth;

    private void Awake()
    {
        audioPlayer = FindObjectOfType<AudioManager>();
        playerhealth = FindObjectOfType<PlayerHealth>();
    }

    private void OnEnable()
    {
        CursorVisibility(true);
        audioPlayer.StopAudio("MainMusic");
        Time.timeScale = 0;
    }

    private void OnDisable()
    {
        audioPlayer.PlayAudio("MainMusic");
        Time.timeScale = 1;
        if (!playerhealth.DeadCanvas.activeSelf)
            CursorVisibility(false);
    }

    void CursorVisibility(bool visible)
    {
        if (visible)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void Continue()
    {
        audioPlayer.PlayAudio("ClickButton");
        gameObject.SetActive(false);
    }

    public void Return()
    {
        audioPlayer.PlayAudio("ClickButton"); 
        try
        {
            score = FindObjectOfType<PlayerScore>();
            int PlayerMoney = Mathf.RoundToInt(score.Score / 50);
            PlayerData.Coins += PlayerMoney;
            PlayerData.SaveinData();
        }
        catch
        {
            
        }
        SceneManager.LoadScene("Menu");
    }
}
