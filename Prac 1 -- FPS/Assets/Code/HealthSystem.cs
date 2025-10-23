using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [Header("Health")]
    public float m_MaxHealth = 100.0f;
    public float m_CurrentHealth;
    public float m_MaxShield = 100.0f;
    public float m_CurrentShield;
    LifeBarElementUI lifeBar;
    PlayerController player;
    Vector3 m_Health;
    void Awake()
    {
        lifeBar= GetComponent<LifeBarElementUI>();
        player= GetComponent<PlayerController>();
        m_CurrentHealth = m_MaxHealth;
        m_CurrentShield = m_MaxShield;
    }

    void Update()
    {

    }
    public void TakeDamage(float dmg)
    {
        if (m_CurrentShield >= 0)
        {
            m_CurrentHealth = m_CurrentHealth - (dmg * 0.25f);
            m_CurrentShield = m_CurrentShield - (dmg * 0.75f);
            
            if(m_CurrentShield < 0)
            {
                float extradmg = -m_CurrentShield;
                m_CurrentShield = 0;
                m_CurrentHealth -= m_CurrentHealth + extradmg;
            }
           

        }
        else
        {
            m_CurrentHealth = m_CurrentHealth - dmg;
        }
        lifeBar.Show(m_Health, dmg); // no se que coño meter en la ubi ESPADAS AYUDAA
    }
    public void Death()
    {
        Respawn();
    }

}
