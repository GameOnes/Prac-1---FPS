using UnityEngine;

public class ShieldItem : Item
{
    public Animation m_ItAnimation;
    public AnimationClip m_ItemAnimationClip;
    public PlayerController m_Player;
    public float m_Shield;

    private void Awake()
    {
        SetIdleAnimation();
    }
    public override void Pick()
    {

        m_Player.AddShield(m_Shield, gameObject);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            Pick();
        }
    }
    void SetIdleAnimation()
    {
        m_ItAnimation.Play(m_ItemAnimationClip.name);
        m_ItAnimation.CrossFade(m_ItemAnimationClip.name, 0.1f);

    }
}
