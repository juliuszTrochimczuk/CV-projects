using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphicsMenu : MonoBehaviour
{
    Resolution[] All;

    [Header("Dropdowns")]
    public Dropdown ResolutionDropdown;

    [Header("Toggle")]
    public Toggle Fullscreen;

    void Start()
    {
        All = Screen.resolutions;

        ResolutionDropdown.ClearOptions();

        int currentResolutionIndex = 0;

        List<string> options = new List<string>();
        List<Resolution> resolutions = new List<Resolution>();

        int LastWidth = 0;
        int LastHeight = 0;
        for (int i=0; i < All.Length; i++)
        {
            if (All[i].width != LastWidth && All[i].height != LastHeight)
            {
                string option = All[i].width + " x " + All[i].height;
                options.Add(option);
                resolutions.Add(All[i]);
                if (All[i].width == PlayerPrefs.GetInt("ScreenWidth", 1400) && All[i].height == PlayerPrefs.GetInt("ScreenHeight", 1050))
                    currentResolutionIndex = options.Count - 1;
                LastWidth = All[i].width;
                LastHeight = All[i].height;
            }
        }
        ResolutionDropdown.AddOptions(options);
        ResolutionDropdown.value = currentResolutionIndex;
        ResolutionDropdown.RefreshShownValue();

        All = resolutions.ToArray();
        SetResolution(currentResolutionIndex);
        Fullscreen.isOn = Screen.fullScreen;
    }
    public void SetFullScreen(bool isFullscreen)
    {
        if (isFullscreen)
            PlayerPrefs.SetInt("isFullscreen", 1);
        else
            PlayerPrefs.SetInt("isFullscreen", 0);
        Screen.fullScreen = isFullscreen;
    }

    public void SetResolution(int ResolutionIndex)
    {
        Resolution resolution = All[ResolutionIndex];
        PlayerPrefs.SetInt("ScreenWidth", resolution.width);
        PlayerPrefs.SetInt("ScreenHeight", resolution.height);
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
