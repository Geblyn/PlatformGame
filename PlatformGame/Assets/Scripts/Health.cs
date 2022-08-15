using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public HealthBar m_healthBar;
    [SerializeField] private int m_health;
    [SerializeField] private int m_maxHealth;
    
    void Start()
    {
        m_healthBar.SetMaxHealth(m_maxHealth);
        m_health = m_maxHealth;
    }
    
    void Update()
    {
        if(m_health <= 0)
        {
            RestartLevel();
        }
    }

    public void TakeDamage(int damage )
    {
        m_health = m_health - damage;

        m_healthBar.SetHealth(m_health);
    }

    void RestartLevel()
    {
        SceneManager.LoadScene("Level1");
    }
}
