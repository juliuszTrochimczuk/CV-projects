using UnityEngine;
using UnityEngine.SceneManagement;

public class BossMapLoader : MonoBehaviour
{
    PlayerScore score;
    public GameObject Player;

    void Start()
    {
        score = Player.GetComponent<PlayerScore>();
    }

    void Update()
    {
        if (score.Score >= 5000)
        {
            PlayerData.BestStandard = score.Score;
            PlayerData.Coins += Mathf.RoundToInt(score.Score / 50);
            SceneManager.LoadScene("BossFight");
            PlayerData.SaveinData();
        }
    }
}
