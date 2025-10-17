using UnityEngine;

public class HitCollider : MonoBehaviour
{
    public int m_Damage;
    public PlayerController m_Player;
    public EnemyController m_Enemy;

    public void Hit()
    {
        m_Enemy.Hit(m_Damage);
     
    }
}
