using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeadMenu : MonoBehaviour
{
    public int PlayerScore;
    public int PlayerMoney;
    public string BestScore;
    string playingMode;

    [Header("Texts")]
    public Text BestScoreTXT;
    public Text PlayerScoreTXT;
    public Text PlayerMoneyTXT;

    public GameObject player;
    PlayerScore score;

    public Canvas DeadCanvas;

    public GameObject RetryGame;
    public GameObject ReturnToMenu;

    AudioManager AudioPlayer;

    void Awake()
    {
        score = player.GetComponent<PlayerScore>();

        PlayerScore = score.Score;

        playingMode = SceneManager.GetActiveScene().name;

        if (playingMode == "Standard")
        {
            BestScore = PlayerData.BestStandard.ToString();
            int MessagePoints = Mathf.RoundToInt(PlayerScore / 500);
            if (PlayerData.MessageUnlocked < MessagePoints)
            {
                int Unlock = MessagePoints - PlayerData.MessageUnlocked;
                PlayerData.MessageUnlocked += Unlock;
            }
        }
        else if (playingMode == "Endless")
            BestScore = PlayerData.BestEndless.ToString();
        else if (playingMode == "JackMode")
            BestScore = PlayerData.BestJack.ToString();
        else if (playingMode == "OneHeartMode")
            BestScore = PlayerData.BestOneHeart.ToString();
        else if (playingMode == "OneShootMode")
            BestScore = PlayerData.BestOneShoot.ToString();
        else if (playingMode == "SlowMode")
            BestScore = PlayerData.BestSlow.ToString();
        else if (playingMode == "FlipMode")
            BestScore = PlayerData.BestFlip.ToString();
    }

    void Start()
    {
        AudioPlayer = FindObjectOfType<AudioManager>();

        PlayerMoney = Mathf.RoundToInt(PlayerScore / 50);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;

        BestScoreTXT.text = BestScore;
        PlayerScoreTXT.text = PlayerScore.ToString();
        PlayerMoneyTXT.text = PlayerMoney.ToString();

        PlayerData.Coins += PlayerMoney;
    }

    void PointsCalculating()
    {
        if (playingMode == "Standard")
        {
            if (PlayerData.BestStandard < PlayerScore)
                PlayerData.BestStandard = PlayerScore;
        }
        else if (playingMode == "Endless")
        {
            if (PlayerData.BestEndless < PlayerScore)
                PlayerData.BestEndless = PlayerScore;
        }
        else if (playingMode == "JackMode")
        {
            if (PlayerData.BestJack < PlayerScore)
                PlayerData.BestJack = PlayerScore;
        }
        else if (playingMode == "OneHeartMode")
        {
            if (PlayerData.BestOneHeart < PlayerScore)
                PlayerData.BestOneHeart = PlayerScore;
        }
        else if (playingMode == "OneShootMode")
        {
            if (PlayerData.BestOneShoot < PlayerScore)
                PlayerData.BestOneShoot = PlayerScore;
        }
        else if (playingMode == "SlowMode")
        {
            if (PlayerData.BestSlow < PlayerScore)
                PlayerData.BestSlow = PlayerScore;
        }
        else if (playingMode == "FlipMode")
        {
            if (PlayerData.BestFlip < PlayerScore)
                PlayerData.BestFlip = PlayerScore;
        }
    }

    public void PlayAgainButton()
    {
        AudioPlayer.PlayAudio("ClickButton");

        PointsCalculating();

        RetryGame.SetActive(true);
        PlayerData.SaveinData();
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void QuitButton()
    {
        AudioPlayer.PlayAudio("ClickButton");

        PointsCalculating();

        ReturnToMenu.SetActive(true);
        PlayerData.SaveinData();
        Time.timeScale = 1;
    }
}
