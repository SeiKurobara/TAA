using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stg12FillStatusBar : MonoBehaviour
{
    public Slider slider;
    public Image fillImage;
    public Gradient gradient;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        slider.value = health;
        fillImage.color = gradient.Evaluate(slider.normalizedValue);
    }

    private void Update()
    {
        
    }
}
