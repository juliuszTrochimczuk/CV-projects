using UnityEngine;
using UnityEngine.UI;

public class DifficultyLevelChose : MonoBehaviour
{
    public Canvas LevelCanvas;
    public Canvas GameCanvas;

    public Button Easy;
    public Button Hard;

    public bool Latwy = false;
    public bool Trudny = false;

    void Start()
    {
        LevelCanvas = LevelCanvas.GetComponent<Canvas>();
        GameCanvas = GameCanvas.GetComponent<Canvas>();

        Easy = Easy.GetComponent<Button>();
        Hard = Hard.GetComponent<Button>();

        LevelCanvas.enabled = true;
        GameCanvas.enabled = false;
    }

    public void EasyPrzycisk()
    {
        LevelCanvas.enabled = false;
        Latwy = true;
        GameCanvas.enabled = true;
    }

    public void HardPrzycisk()
    {
        LevelCanvas.enabled = false;
        Trudny = true;
        GameCanvas.enabled = true;
    }
}
