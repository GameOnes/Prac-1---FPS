using UnityEngine;

public class HealthItem : Item
{
    public Animation m_ItAnimation;
    public AnimationClip m_ItemAnimationClip;
    public int m_LifeCount;
    public override void Pick()
    {
        base.Pick();
        GameManager.GetGameManager().GetPlayer().AddLife(m_LifeCount);
    }

    public override bool CanPick()
    {
        if (m_LifeCount > 0)
        {
            SetIdleAnimation();
            return true;
        }
        else return false;
    }

    void SetIdleAnimation()
    {
        m_ItAnimation.CrossFade(m_ItemAnimationClip.name, 0.1f);
    }
}
