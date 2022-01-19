using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeadBossMenu : MonoBehaviour
{
    [Header("Controling GameObjects")]
    public GameObject ReturnToMenu;
    public GameObject PlayAgain;

    [Header("Boss Health text")]
    public Text RemainHealth;

    [Header("Boss Components")]
    public GameObject Boss;
    public Canvas BossCanvas;
    BHealth BossHealth;

    [Header("AudioManager")]
    AudioManager audioManager;

    void Start()
    {
        BossHealth = Boss.GetComponent<BHealth>();

        audioManager = FindObjectOfType<AudioManager>();

        RemainHealth.text = BossHealth.Health.ToString();

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void RetryGame()
    {
        audioManager.PlayAudio("ClickButton");
        PlayAgain.SetActive(true);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void QuitToMenu()
    {
        audioManager.PlayAudio("ClickButton");
        ReturnToMenu.SetActive(true);
    }
}
