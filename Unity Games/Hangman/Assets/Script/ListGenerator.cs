using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListGenerator : MonoBehaviour
{
    public string[] ListaSlowLatwych;
    public string[] ListaSlowTrudnych;
    public List<string> ListaGracza = new List<string>();

    DifficultyLevelChose LevelChose;

    System.Random random = new System.Random();

    public string WybraneSlowo;
    public string ListaGraczaTekst;
    public int DlugoscSlowa;

    public Text DisplayList;

    int Index;

    public bool Gotowy = false;

    void Start()
    {
        DisplayList = DisplayList.GetComponent<Text>();
        LevelChose = this.gameObject.GetComponent<DifficultyLevelChose>();

        Index = random.Next(0, ListaSlowLatwych.Length);
    }

   void Update()
    {
        if (LevelChose.Latwy == true)
        {
            WybraneSlowo = ListaSlowLatwych[Index];
            Debug.Log(WybraneSlowo);
            for (int i = 0; i < WybraneSlowo.Length; i++)
            {
                ListaGracza.Add("x");
            }
            LevelChose.Latwy = false;
            Gotowy = true;
            DlugoscSlowa = WybraneSlowo.Length;
        }
        else if (LevelChose.Trudny == true)
        {
            WybraneSlowo = ListaSlowTrudnych[Index];
            Debug.Log(WybraneSlowo);
            for (int i = 0; i < WybraneSlowo.Length; i++)
            {
                ListaGracza.Add("x");
            }
            LevelChose.Trudny = false;
            Gotowy = true;
            DlugoscSlowa = WybraneSlowo.Length;
        }
        ListaGraczaTekst = string.Join("", ListaGracza);

        DisplayList.text = ListaGraczaTekst;
    }
}