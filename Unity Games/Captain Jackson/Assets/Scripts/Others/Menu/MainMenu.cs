using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [Header("Canvases")]
    public Canvas FirstMenu;
    public Canvas OptionsCanvas;
    public Canvas GraphicsOptions;
    public Canvas SoundsOptions;
    public Canvas KeybindingsOptions;
    public Canvas GameModeCanvas;
    public Canvas SubGameModeCanvas;
    public Canvas SkinsMenu;
    public Canvas StoryMenu;

    AudioManager AudioPlayer;

    [Header("Skins")]
    public GameObject Skins;

    [Header("GameObjects")]
    public GameObject StartGameObject;
    public GameObject QuitGameObject;
    public GameObject NextSkin;
    public GameObject PreviousSkin;

    StartGame start;

    [Header("GameTitle")]
    public Text GameTittle;

    void Start()
    {
        start = StartGameObject.GetComponent<StartGame>();

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;

        FirstMenu.enabled = true;
        OptionsCanvas.enabled = false;
        GraphicsOptions.enabled = false;
        SoundsOptions.enabled = false;
        KeybindingsOptions.enabled = false;
        GameModeCanvas.enabled = false;
        SubGameModeCanvas.enabled = false;
        SkinsMenu.enabled = false;
        StoryMenu.enabled = false;

        AudioPlayer = FindObjectOfType<AudioManager>();

        Skins.SetActive(false);

        AudioPlayer.StopAudio("MainMusic");
        AudioPlayer.PlayAudio("MenuMusic");
    }

    public void StartGameButton()
    {
        if (!PlayerData.BossKilled)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            AudioPlayer.PlayAudio("StartGame");
            StartGameObject.SetActive(true);
            start.MapLoader(1);
        }
        else
        {
            AudioPlayer.PlayAudio("ClickButton");
            FirstMenu.enabled = false;
            GameModeCanvas.enabled = true;
        }
    }

    public void OptionsButton()
    {
        FirstMenu.enabled = false;
        OptionsCanvas.enabled = true;
        AudioPlayer.PlayAudio("ClickButton");
    }

    public void ExitGameButton()
    {
        AudioPlayer.StopAudio("MenuMusic");
        AudioPlayer.PlayAudio("ClickButton");
        QuitGameObject.SetActive(true);
    }

    public void ReturnButton()
    {
        AudioPlayer.PlayAudio("ClickButton");
        FirstMenu.enabled = true;
        OptionsCanvas.enabled = false;
    }

    public void GraphicsButton()
    {
        AudioPlayer.PlayAudio("ClickButton");
        OptionsCanvas.enabled = false;
        GraphicsOptions.enabled = true;
    }

    public void KeybindingButton()
    {
        AudioPlayer.PlayAudio("ClickButton");
        OptionsCanvas.enabled = false;
        KeybindingsOptions.enabled = true;
    }

    public void SoundButton()
    {
        AudioPlayer.PlayAudio("ClickButton");
        OptionsCanvas.enabled = false;
        SoundsOptions.enabled = true;
    }

    public void FromGraphicsToOptions()
    {
        AudioPlayer.PlayAudio("ClickButton");
        GraphicsOptions.enabled = false;
        OptionsCanvas.enabled = true;
    }

    public void FromSoundToOptions()
    {
        AudioPlayer.PlayAudio("ClickButton");
        SoundsOptions.enabled = false;
        OptionsCanvas.enabled = true;
    }

    public void FromKeybindingToOptions()
    {
        AudioPlayer.PlayAudio("ClickButton");
        KeybindingsOptions.enabled = false;
        OptionsCanvas.enabled = true;
    }

    public void FromGameModesToMainMenu()
    {
        AudioPlayer.PlayAudio("ClickButton");
        GameModeCanvas.enabled = false;
        FirstMenu.enabled = true;
    }
    public void FromSubGameModesToGameModes()
    {
        AudioPlayer.PlayAudio("ClickButton");
        SubGameModeCanvas.enabled = false;
        GameModeCanvas.enabled = true;
    }
    
    public void ShowSkinsMenu()
    {
        AudioPlayer.PlayAudio("ClickButton");
        FirstMenu.enabled = false;
        SkinsMenu.enabled = true;
        Skins.SetActive(true);
        PreviousSkin.SetActive(true);
        NextSkin.SetActive(true);

        if (PlayerData.ActiveSkin == 0)
        {
            PreviousSkin.SetActive(false);
        }
        else if (PlayerData.ActiveSkin == 7)
        {
            NextSkin.SetActive(false);
        }
    }

    public void HideSkinsMenu()
    {
        AudioPlayer.PlayAudio("ClickButton");
        SkinsMenu.enabled = false;
        FirstMenu.enabled = true;
        Skins.SetActive(false);
    }

    public void ShowStoryMenu()
    {
        AudioPlayer.PlayAudio("ClickButton");
        FirstMenu.enabled = false;
        GameTittle.enabled = false;
        StoryMenu.enabled = true;
    }

    public void HideStoryMenu()
    {
        AudioPlayer.PlayAudio("ClickButton");
        FirstMenu.enabled = true;
        GameTittle.enabled = true;
        StoryMenu.enabled = false;
    }
}
