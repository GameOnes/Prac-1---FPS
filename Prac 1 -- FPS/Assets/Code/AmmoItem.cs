using UnityEngine;

public class AmmoItem : Item
{
    public Animation m_ItAnimation;
    public AnimationClip m_ItemAnimationClip;
    public PlayerController m_Player;
    public int m_AmmoCount;

    private void Awake()
    {
        m_Player = GameManager.GetGameManager().GetPlayer();
    }
    public override void Pick()
    {

        if (CanPick())
        {
            GameManager.GetGameManager().GetPlayer().AddAmmo(m_AmmoCount); // añade municion al jugador
            base.Pick(); // llama al metodo Pick de la clase base (Item)
        }

    }
    public override bool CanPick()
    {
        if (m_Player.m_MaxAmmoCount < m_Player.m_AmmoCount) // si la municion del jugador es menor que la municion maxima
        {
            Debug.Log("Pickeame" + m_AmmoCount); 
            SetIdleAnimation();
            return true;
        }
        else return false;
    }
    void SetIdleAnimation()
    {
        m_ItAnimation.Play(m_ItemAnimationClip.name);
        m_ItAnimation.CrossFade(m_ItemAnimationClip.name, 0.1f);
    }
}



