using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider m_slider;

    public void SetMaxHealth(int m_MaxHealth)
    {
        m_slider.maxValue = m_MaxHealth;
    }

    public void SetHealth(int m_Health) 
    {
        m_slider.value = m_Health;
    }

    
}
