using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    [Header("Speed Levels")]
    public List<float> playerSpeed;
    float activeSpeedValue;

    [Header("Skins")]
    public SpriteRenderer spriteRenderer;
    public Skin SkinSprites = new Skin();
    List<Sprite> SpeedSprite;

    [Header("Turbo effect")]
    public List<TurboEffect> turboEffect;
    public List<TurboMouth> mouths;
    public List<ParticleSystem> effects;
    public Slider turboSlider;
    bool effectActive = false;

    [Header("Controlling variables")]
    public int activeSpeedLevel = 0;
    Vector2 move;
    public float timer;
    float turboSpeed;

    AudioManager audioPlayer;

    void Start()
    {
        SpeedSprite = SkinSprites.Skins[PlayerData.ActiveSkin].SpeedSprites;
        spriteRenderer.sprite = SpeedSprite[activeSpeedLevel];

        activeSpeedValue = playerSpeed[0];
        turboSpeed = playerSpeed[0] * 1.5f;

        SettingNewEffect();

        effects[0].Stop();
        effects[1].Stop();

        audioPlayer = FindObjectOfType<AudioManager>();
    }

    void Update()
    {
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && (transform.position.y < 9.1f))
            move.y = 1;
        else if ((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) && (transform.position.y > -9.1f))
            move.y = -1;
        else move.y = 0;

        if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && (transform.position.x < 12.5f))
            move.x = 1;
        else if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && (transform.position.x > -12.5f))
            move.x = -1;
        else move.x = 0;

        if (move.magnitude > 1.0f)
            move.Normalize();
        
        if (move.magnitude == 1.0)
            VectorCalculation();

        transform.Translate(move);
    }

    void VectorCalculation()
    {
        if ((Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) && (timer >= 0.0f))
        {
            if (!effectActive) PlayEffect();
            SpeedValueIncrease(10f);
            timer -= Time.deltaTime;
            turboSlider.value = timer / 2.0f;
        }

        else
        {
            SpeedValueDecrease(5);
            if (effectActive) DestroyEffect();
        }

        move *= Time.deltaTime * activeSpeedValue;
    }

    void SettingNewEffect()
    {
        for (int i = 0; i < 2; i++)
        {
            var main = effects[i].main;

            main.startColor = turboEffect[PlayerData.ActiveSkin].skinColor[activeSpeedLevel];

            effects[i].gameObject.transform.position = mouths[i].mouth[activeSpeedLevel].position;
        }
    }

    void SpeedValueIncrease(float increase)
    {
        if (activeSpeedValue <= turboSpeed)
            activeSpeedValue += (increase * Time.deltaTime * 2);
    }

    void SpeedValueDecrease(float decrease)
    {
        if (activeSpeedValue > playerSpeed[activeSpeedLevel])
            activeSpeedValue -= (decrease * Time.deltaTime);
    }

    void PlayEffect()
    {
        for (int i = 0; i < 2; i++)
            effects[i].Play();
        audioPlayer.PlayAudio("TurboEffect");
        effectActive = true;
    }

    void DestroyEffect()
    {
        for (int i = 0; i < 2; i++)
            effects[i].Stop();
        audioPlayer.StopAudio("TurboEffect");
        effectActive = false;
    }

    public void SpeedBost()
    {
        activeSpeedLevel += 1;
        spriteRenderer.sprite = SpeedSprite[activeSpeedLevel];
        activeSpeedValue = playerSpeed[activeSpeedLevel];
        turboSpeed = playerSpeed[activeSpeedLevel] * 1.5f;
        SettingNewEffect();
    }

    public void TurboBoost()
    {
        if (timer + 1.0 < 2.0)
            timer += 1.0f;
        else if (timer + 1.0f >= 2.0f)
            timer = 2.0f;
        turboSlider.value = timer / 2.0f;
    }
}

[System.Serializable]
public class TurboEffect
{
    public List<Color> skinColor;
}

[System.Serializable]
public class TurboMouth
{
    public List<Transform> mouth;
}