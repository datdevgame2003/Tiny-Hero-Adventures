using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthManage : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;

    public void SetMaxHealth(int maxHealth)
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
    }

    public void SetHealth(int currentHealth)
    {
        healthSlider.value = currentHealth;
    }
}
