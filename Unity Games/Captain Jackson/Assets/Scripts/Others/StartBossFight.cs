using UnityEngine;

public class StartBossFight : MonoBehaviour
{
    public GameObject BossController;
    public GameObject BossCanvas;

    PlayerHealth health;
    PlayerMove move;
    PlayerShooting shooting;

    float BossTimer;

    void Awake()
    {
        BossCanvas.SetActive(false);
        BossController.SetActive(false);
    }

    void Start()
    {
        health = FindObjectOfType<PlayerHealth>();
        move = FindObjectOfType<PlayerMove>();
        shooting = FindObjectOfType<PlayerShooting>();

        shooting.ActiveShootingPoints += 6;
        shooting.ReloadTime -= 0.6f;
        move.SpeedBost();
        move.SpeedBost();
        health.GettingHeart();
        health.GettingHeart();
    }

    void Update()
    {
        BossTimer += Time.deltaTime;
        if (BossTimer >= 1.0f)
        {
            BossController.SetActive(true);
            BossCanvas.SetActive(true);
            Destroy(gameObject);
        }        
    }
}
