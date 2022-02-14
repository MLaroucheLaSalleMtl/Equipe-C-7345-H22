using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManaBar : MonoBehaviour
{
    public PlayerMana PlayerMana;
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

        float fillValue = PlayerMana.mana / PlayerMana.maxMana;
        if (fillValue <= slider.maxValue / 15)
        {
            fillImage.color = Color.yellow;
        }
        else if (fillValue > slider.maxValue / 15)
        {
            fillImage.color = Color.blue;
        }
        slider.value = fillValue;
    }
}
