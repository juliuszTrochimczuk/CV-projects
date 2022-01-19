using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System.IO;
using Newtonsoft.Json;

public class StartApp : MonoBehaviour
{
    public AudioMixer audioMixer;
    AudioManager audioPlayer;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        bool isFullscreen = false;
        int check = PlayerPrefs.GetInt("isFullscreen", 1);
        if (check == 1)
            isFullscreen = true;
        Screen.SetResolution(PlayerPrefs.GetInt("ScreenWidth", 1400), PlayerPrefs.GetInt("ScreenHeight", 1050), isFullscreen);

        audioMixer.SetFloat("General", Mathf.Log10(PlayerPrefs.GetFloat("GeneralVolume", 1.0f)) * 20);
        audioMixer.SetFloat("SFX", Mathf.Log10(PlayerPrefs.GetFloat("SFXVolume", 1.0f)) * 20);
        audioMixer.SetFloat("Music", Mathf.Log10(PlayerPrefs.GetFloat("MusicVolume", 1.0f)) * 20);


        if (!File.Exists(Application.persistentDataPath + "/" + "Player_Stats.json"))
        {
            File.Create(Application.persistentDataPath + "/" + "Player_Stats.json").Dispose();

            PlayerStats data = new PlayerStats()
            {
                BossKilled = false,
                BestStandard = 0,
                BestEndless = 0,
                BestJack = 0,
                BestOneHeart = 0,
                BestOneShoot = 0,
                BestSlow = 0,
                BestFlip = 0,
                ActiveSkin = 0,
                SkinsUnlocked = new List<bool> { true, false, false, false, false, false, false, false, false, false, false },
                MessageUnlocked = 0,
                Coins = 0,
            };

            string json = JsonConvert.SerializeObject(data);

            File.WriteAllText(Application.persistentDataPath + "/" + "Player_Stats.json", json);
        }

        string saveData = File.ReadAllText(Application.persistentDataPath + "/" + "Player_Stats.json");

        PlayerStats stats = JsonConvert.DeserializeObject<PlayerStats>(saveData);

        PlayerData.BestStandard = stats.BestStandard;
        PlayerData.BestEndless = stats.BestEndless;
        PlayerData.ActiveSkin = stats.ActiveSkin;
        PlayerData.SkinsUnlocked = stats.SkinsUnlocked;
        PlayerData.MessageUnlocked = stats.MessageUnlocked;
        PlayerData.BossKilled = stats.BossKilled;
        PlayerData.Coins = stats.Coins;

        audioPlayer = FindObjectOfType<AudioManager>();
    }
}
