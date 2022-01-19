using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinsMenu : MonoBehaviour
{
    [Header("Skins Button Main Menu")]
    public GameObject Button;
    Image SkinImage;
    public List<Sprite> SpriteSkins;

    [Header("Skins Lists")]
    public List<string> Names;
    public List<int> Costs;

    int IndexInList;

    [Header("Camera")]
    public List<Vector2> Positions;
    public float zPosition;
    public Transform Camera;
    public int MoveSpeed;

    [Header("UI elements")]
    public Text NameOfSkin;
    public Text CostOfSkin;
    public Text Money;
    public Text BuyAward;
    public Text Warning;

    [Header("List controling buttons")]
    public GameObject Next;
    public GameObject Previous;

    AudioManager audioPlayer;

    void Start()
    {
        audioPlayer = FindObjectOfType<AudioManager>();

        SkinImage = Button.GetComponent<Image>();
        SkinImage.sprite = SpriteSkins[PlayerData.ActiveSkin];

        IndexInList = PlayerData.ActiveSkin;

        if (PlayerData.SkinsUnlocked.Count < Names.Count)
        {
            for (int i = PlayerData.SkinsUnlocked.Count- 1; i < Names.Count - 1; i++)
            {
                PlayerData.SkinsUnlocked.Add(false);
            }
        }

        NamesSwitching();
        Money.text = PlayerData.Coins.ToString();

        Vector3 position = new Vector3(Positions[IndexInList].x, Positions[IndexInList].y, zPosition);

        Camera.position = position;

        Warning.enabled = false;
    }

    void Update()
    {
        if (Vector2.Distance(Camera.position, Positions[IndexInList]) > 0.2f)
        {
            Vector2 move = Positions[IndexInList] - (Vector2)Camera.position;            
            move.Normalize();
            move *= MoveSpeed;
            Camera.Translate(move * Time.deltaTime);
        }
    }

    public void NextSkin()
    {
        audioPlayer.PlayAudio("ClickButton");
        Warning.enabled = false;
        if (IndexInList < 10)
        {
            Previous.SetActive(true);
            IndexInList += 1;
            if (IndexInList == 10)
            {
                Next.SetActive(false);
            }
            NamesSwitching();
        }
    }

    public void PreviousSkin()
    {
        audioPlayer.PlayAudio("ClickButton");
        Warning.enabled = false;
        if (IndexInList > 0)
        {
            Next.SetActive(true);
            IndexInList -= 1;
            if (IndexInList == 0)
            {
                Previous.SetActive(false);
            }
            NamesSwitching();
        }
    }

    public void BuyingEquiping()
    {
        audioPlayer.PlayAudio("ClickButton");
        if (!PlayerData.SkinsUnlocked[IndexInList])
        {
            if (PlayerData.Coins >= Costs[IndexInList] )
            {
                PlayerData.SkinsUnlocked[IndexInList] = true;
                PlayerData.Coins -= Costs[IndexInList];
                Money.text = PlayerData.Coins.ToString();
                PlayerData.SaveinData();
                NamesSwitching();
            }
            else
            {
                Warning.enabled = true;
            }
        }
        else
        {
            PlayerData.ActiveSkin = IndexInList;
            SkinImage.sprite = SpriteSkins[PlayerData.ActiveSkin];
            PlayerData.SaveinData();
        }
    }

    public void ResetingIndex()
    {
        IndexInList = PlayerData.ActiveSkin;
        NamesSwitching();

        Vector3 position = new Vector3(Positions[IndexInList].x, Positions[IndexInList].y, zPosition);

        Camera.position = position;
    }

    void NamesSwitching()
    {
        NameOfSkin.text = Names[IndexInList];
        if (!PlayerData.SkinsUnlocked[IndexInList])
        {
            CostOfSkin.text = Costs[IndexInList].ToString();
            BuyAward.text = "Buy";
        }
        else
        {
            CostOfSkin.text = "";
            BuyAward.text = "Equip";
        }
    }
}
