using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int PlayerHP = 3;
    public List<Image> Hearts;

    public GameObject Shield;
    public GameObject DieEffect;
    public GameObject DeadCanvas;
    public GameObject stopAttacking;
    public GameObject turboSlider;

    public bool FREEDOM = false;

    AudioManager AudioPlayer;

    bool audioPlayed = false;

    float LiveTime = 0.0f;

    SpriteRenderer sprite;

    EdgeCollider2D shipColider;
    CircleCollider2D shieldColider;

    void Start()
    {
        shipColider = GetComponent<EdgeCollider2D>();
        shieldColider = GetComponent<CircleCollider2D>();

        DeadCanvas.SetActive(false);

        shieldColider.enabled = false;

        AudioPlayer = FindObjectOfType<AudioManager>();

        sprite = GetComponentInChildren<SpriteRenderer>();

        for (int index=5; index > PlayerHP; index--)
        {
            Hearts[index-1].enabled = false;
        }
    }

    void Update()
    {
        if (PlayerHP <= 0)
        {
            sprite.sprite = null;
            DieEffect.SetActive(true);
            LiveTime += Time.deltaTime;

            if (audioPlayed == false)
            {
                AudioPlayer.PlayAudio("PlayerExplosion");
                audioPlayed = true;
            }

            if (LiveTime >= 1.0f)
            {
                DeadCanvas.SetActive(true);
                Instantiate(stopAttacking);
                turboSlider.SetActive(false);
                Destroy(gameObject);
            }
            
        }
    }

    public void GettingDamage(int damage)
    {
        if (PlayerHP >= 1)
        {
            if (!FREEDOM)
            {
                if (!Shield.activeSelf)
                {
                    AudioPlayer.PlayAudio("PlayerDamage");
                    if (damage == 1)
                    {
                        PlayerHP -= damage;
                        if (PlayerHP < 0)
                            return;
                        Hearts[PlayerHP].enabled = false;
                    }
                    else
                    {
                        for (int i = PlayerHP; i > PlayerHP - damage; i--)
                        {
                            if (i == 0)
                            {
                                break;
                            }
                            Hearts[i-1].enabled = false;
                        }
                        PlayerHP -= damage;
                    }
                }
                else
                {
                    AudioPlayer.PlayAudio("PlayerShieldDamage");
                    Shield.SetActive(false);
                    shipColider.enabled = true;
                    shieldColider.enabled = false;
                }
            }
        }
    }

    public void GettingHeart()
    {
        if (PlayerHP < 5)
            PlayerHP += 1;
        Hearts[PlayerHP-1].enabled = true;
    }

    public void GettingShield()
    {
        Shield.SetActive(true);
        shipColider.enabled = false;
        shieldColider.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            GettingDamage(1);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("EnemyPowerOrb"))
        {
            GettingDamage(2);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Enemy"))
            GettingDamage(1);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
            GettingDamage(1);
        else if (collision.gameObject.CompareTag("Boss"))
            GettingDamage(1);
    }
}
