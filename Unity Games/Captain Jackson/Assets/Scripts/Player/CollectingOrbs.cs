using UnityEngine;

public class CollectingOrbs : MonoBehaviour
{
    PlayerHealth health;
    PlayerMove move;
    PlayerShooting shooting;
    PlayerScore score;
    FreedomPower Freedom;

    AudioManager audioManager;

    void Start()
    {
        health = this.GetComponent<PlayerHealth>();
        move = this.GetComponent<PlayerMove>();
        shooting = this.GetComponent<PlayerShooting>();
        score = this.GetComponent<PlayerScore>();
        Freedom = this.GetComponent<FreedomPower>();

        audioManager = FindObjectOfType<AudioManager>();
    }

    public void Collecting(string orbTag)
    {
        if (health.PlayerHP > 0)
        {
            if (orbTag == "FireOrb")
            {
                if (shooting.ActiveShootingPoints < 7)
                {
                    shooting.ActiveShootingPoints += 2;
                    score.IncreaseScore(5);
                }
                else
                    score.IncreaseScore(10);
                audioManager.PlayAudio("PowerUp");
            }

            else if (orbTag == "HeartOrb")
            {
                if (health.PlayerHP != 5)
                {
                    health.GettingHeart();
                    score.IncreaseScore(5);
                }
                else
                    score.IncreaseScore(10);
                audioManager.PlayAudio("PowerUp");
            }

            else if (orbTag == "TimeOrb")
            {
                if (shooting.ReloadTime > 0.4f)
                {
                    shooting.ReloadTime -= 0.2f;
                    score.IncreaseScore(5);
                }
                else
                    score.IncreaseScore(10);
                audioManager.PlayAudio("PowerUp");
            }

            else if (orbTag == "SpeedOrb")
            {
                if (move.activeSpeedLevel < 2)
                {
                    move.SpeedBost();
                    score.IncreaseScore(5);
                }
                else
                    score.IncreaseScore(10);
                audioManager.PlayAudio("PowerUp");
            }

            else if (orbTag == "TurboOrb")
            {
                if (move.timer < 2.0f)
                {
                    move.TurboBoost();
                    score.IncreaseScore(5);
                }
                else
                    score.IncreaseScore(10);
                audioManager.PlayAudio("PowerUp");
            }

            else if (orbTag == "ShieldOrb")
            {
                if (!health.Shield.activeSelf)
                {
                    health.GettingShield();
                    score.IncreaseScore(5);
                }
                else
                    score.IncreaseScore(10);
                audioManager.PlayAudio("PowerUp");
            }

            else if (orbTag == "FreedomOrb")
            {
                if (Freedom.Freedom)
                {
                    score.IncreaseScore(100);
                }
                Freedom.FreedomExtend(5.0f);
                score.IncreaseScore(5);
                audioManager.PlayAudio("PowerUp");
            }
        }
    }
}
