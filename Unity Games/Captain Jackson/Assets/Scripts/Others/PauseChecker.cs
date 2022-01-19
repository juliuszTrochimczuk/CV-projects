using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseChecker : MonoBehaviour
{
    public GameObject pauseCanvas;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !pauseCanvas.activeSelf)
            pauseCanvas.SetActive(true);
        else if (Input.GetKeyDown(KeyCode.Escape) && pauseCanvas.activeSelf)
            pauseCanvas.SetActive(false);
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause)
            pauseCanvas.SetActive(true);
    }
}
