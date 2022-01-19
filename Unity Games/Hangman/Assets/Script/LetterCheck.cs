using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LetterCheck : MonoBehaviour
{
    public InputField Literka;
    public Button PrzyciskSprawdzania;

    public Canvas KoniecGryCanvas;
    public Text Komunikat;
    public Button Wyjscie;
    public Button GrajJeszczeRaz;

    private bool Sprawdzanie = false;

    public string WpisanaLiterka;
    public char Sprawdzajka;

    ListGenerator listGenerator;

    public GameObject[] Wisielec;

    private int IloscProb = 0;
    private int IloscRazy = 14;
    private char ZmiennaPomocnicza;
    private int ZmiennaPomocnicza2;

    public string Wygrana;
    public string Przegrana;

    void Start()
    {
        listGenerator = this.gameObject.GetComponent<ListGenerator>();
        Literka = Literka.GetComponent<InputField>();
        PrzyciskSprawdzania = PrzyciskSprawdzania.GetComponent<Button>();
        KoniecGryCanvas = KoniecGryCanvas.GetComponent<Canvas>();
        Komunikat = Komunikat.GetComponent<Text>();
        Wyjscie = Wyjscie.GetComponent<Button>();
        GrajJeszczeRaz = GrajJeszczeRaz.GetComponent<Button>();

        for (int i=0; i<14; i++)
        {
            Wisielec[i].SetActive(false);
        }

        KoniecGryCanvas.enabled = false;
    }
    
    void Update()
    {
        WpisanaLiterka = Literka.text;

        if (IloscProb != IloscRazy)
        {
            if (Sprawdzanie == true)
            {
                Gra();
            }
        }
    }

    public void EnterButton()
    {
        if (WpisanaLiterka.Length != 1)
        {
            Literka.text = "";
        }
        else
        {         
            Sprawdzajka = WpisanaLiterka[0]; 
            Sprawdzanie = true;
        }
    }

    public void Gra()
    {
        for (int i = 0; i < listGenerator.WybraneSlowo.Length; i++)
        {
            ZmiennaPomocnicza = listGenerator.WybraneSlowo[i];

            if (Sprawdzajka == ZmiennaPomocnicza)
            {
                listGenerator.ListaGracza[i] = WpisanaLiterka;
                listGenerator.DlugoscSlowa = listGenerator.DlugoscSlowa - 1;
            }
            else
            {
                ZmiennaPomocnicza2 = ZmiennaPomocnicza2 + 1;
                continue;
            }
        }
        if (ZmiennaPomocnicza2 == listGenerator.WybraneSlowo.Length)
        {
            IloscProb = IloscProb + 1;
            for (int z = 0; z < IloscProb; z++)
            {
                Wisielec[z].SetActive(true);
            }
        }
        ZmiennaPomocnicza2 = 0;
        Sprawdzanie = false;
        Literka.text = "";
        if (listGenerator.DlugoscSlowa == 0 || IloscProb == IloscRazy)
        {
            KoniecGry();
        }
    }

    public void KoniecGry()
    {
        KoniecGryCanvas.enabled = true;

        if (IloscProb == IloscRazy)
        {
            Komunikat.text = Przegrana;
        }
        else
        {
            Komunikat.text = Wygrana;
        }
    }

    public void QuitPrzycisk()
    {
        Application.Quit();
    }

    public void GrajJesczeRazPrzycisk()
    {
        SceneManager.LoadScene("GameScene");
    }
}
