using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public PlayerHealth PlayerHealth;
    public Image fillImage;
    public Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    private void Update()
    {
        if (slider.value <= slider.minValue)
        {
            fillImage.enabled = false;
        }

        if (slider.value > slider.minValue && !fillImage.enabled)
        {
            fillImage.enabled = true;
        }

        float fillValue = PlayerHealth.health / PlayerHealth.maxHealth;
        if (fillValue <= slider.maxValue / 15)
        {
            fillImage.color = Color.yellow;
        }
        else if (fillValue > slider.maxValue / 15)
        {
            fillImage.color = Color.green;
        }
        slider.value = fillValue;
    }
}
