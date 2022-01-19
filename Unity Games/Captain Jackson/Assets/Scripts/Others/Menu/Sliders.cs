using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sliders : MonoBehaviour
{
    Slider slider;

    public Image HandlePlace;

    public List<Sprite> Handles;

    void Start()
    {
        slider = this.GetComponent<Slider>();
    }

    void Update()
    {
        if (slider.value >= 0.66)
        {
            HandlePlace.sprite = Handles[0];
        }

        else if (slider.value >= 0.33 && slider.value < 0.66)
        {
            HandlePlace.sprite = Handles[1];
        }

        else
        {
            HandlePlace.sprite = Handles[2];
        }

    }
}
