using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;

public class PlayerData : MonoBehaviour
{
    public static bool BossKilled;

    public static int BestStandard;
    public static int BestEndless;
    public static int BestJack;
    public static int BestOneHeart;
    public static int BestOneShoot;
    public static int BestSlow;
    public static int BestFlip;

    public static List<bool> SkinsUnlocked;
    public static int ActiveSkin;

    public static int MessageUnlocked;

    public static int Coins;

    public static void SaveinData()
    {
        PlayerStats data = new PlayerStats()
        {
            BossKilled = BossKilled,
            BestStandard = BestStandard,
            BestEndless = BestEndless,
            BestJack = BestJack,
            BestOneHeart = BestOneHeart,
            BestOneShoot = BestOneShoot,
            BestSlow = BestSlow,
            BestFlip = BestFlip,
            ActiveSkin = ActiveSkin,
            SkinsUnlocked = SkinsUnlocked,
            MessageUnlocked = MessageUnlocked,
            Coins = Coins,
        };

        string json = JsonConvert.SerializeObject(data);

        File.WriteAllText(Application.persistentDataPath + "/" + "Player_Stats.json", json);
    }

    private void OnApplicationQuit()
    {
        PlayerData.SaveinData();
    }
}
