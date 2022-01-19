using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Button StartButton;
    public Button Quit;

    void Start()
    {
        StartButton = StartButton.GetComponent<Button>();
        Quit = Quit.GetComponent<Button>();
    }

    public void StartPrzycisk()
    {
        SceneManager.LoadScene("GameScene");
    }

   public void QuitPrzycisk()
   {
        Application.Quit();
   }
}
