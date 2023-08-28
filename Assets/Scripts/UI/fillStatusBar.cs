using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fillStatusBar : MonoBehaviour
{
    public stg11HealthManager healthManager;
    public Image fillImage;
    private Slider HealthBar;
    // Start is called before the first frame update
    void Awake()
    {
        HealthBar = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (HealthBar.value <= HealthBar.minValue)
        {
            fillImage.enabled = true;
        }

        if (HealthBar.value > HealthBar.minValue && fillImage.enabled)
        {
            fillImage.enabled = true;
        }

        float fillValue = healthManager.currentHealth / healthManager.maxHealth;
        if (fillValue <= HealthBar.maxValue / 3)
        {
            fillImage.color = Color.green;
        }
        else if (fillValue > HealthBar.maxValue / 3)
        {
            fillImage.color = Color.green;
        }

        HealthBar.value = fillValue;
    }
}
