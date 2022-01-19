using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StoryMenu : MonoBehaviour
{
    [Header("Story messages")]
    public List<string> Messages;
    public string NotUnlockedMessage;

    [Header("Display text")]
    public Text Display;

    AudioManager audioManager;

    void Start()
    {
        Display.text = Messages[0];
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void First()
    {
        Display.text = Messages[0];
        audioManager.PlayAudio("ClickButton");
    }

    public void Second()
    {
        if (PlayerData.MessageUnlocked >= 1)
        {
            Display.text = Messages[1];
        }
        else
        {
            Display.text = NotUnlockedMessage;
        }
        audioManager.PlayAudio("ClickButton");
    }

    public void Third()
    {
        if (PlayerData.MessageUnlocked >= 2)
        {
            Display.text = Messages[2];
        }
        else
        {
            Display.text = NotUnlockedMessage;
        }
        audioManager.PlayAudio("ClickButton");
    }

    public void Forth()
    {
        if (PlayerData.MessageUnlocked >= 3)
        {
            Display.text = Messages[3];
        }
        else
        {
            Display.text = NotUnlockedMessage;
        }
        audioManager.PlayAudio("ClickButton");
    }

    public void Fifth()
    {
        if (PlayerData.MessageUnlocked >= 4)
        {
            Display.text = Messages[4];
        }
        else
        {
            Display.text = NotUnlockedMessage;
        }
        audioManager.PlayAudio("ClickButton");
    }

    public void Sixth()
    {
        if (PlayerData.MessageUnlocked >= 5)
        {
            Display.text = Messages[5];
        }
        else
        {
            Display.text = NotUnlockedMessage;
        }
        audioManager.PlayAudio("ClickButton");
    }

    public void Seventh()
    {
        if (PlayerData.MessageUnlocked >= 6)
        {
            Display.text = Messages[6];
        }
        else
        {
            Display.text = NotUnlockedMessage;
        }
        audioManager.PlayAudio("ClickButton");
    }

    public void Eighth()
    {
        if (PlayerData.MessageUnlocked >= 7)
        {
            Display.text = Messages[7];
        }
        else
        {
            Display.text = NotUnlockedMessage;
        }
        audioManager.PlayAudio("ClickButton");
    }

    public void Nineth()
    {
        if (PlayerData.MessageUnlocked >= 8)
        {
            Display.text = Messages[8];
        }
        else
        {
            Display.text = NotUnlockedMessage;
        }
        audioManager.PlayAudio("ClickButton");
    }

    public void Tenth()
    {
        if (PlayerData.MessageUnlocked >= 9)
        {
            Display.text = Messages[9];
        }
        else
        {
            Display.text = NotUnlockedMessage;
        }
        audioManager.PlayAudio("ClickButton");
    }
}
