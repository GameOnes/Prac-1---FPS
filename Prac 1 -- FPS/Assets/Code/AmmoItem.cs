using UnityEngine;

public class AmmoItem : Item
{
    public Animation m_ItAnimation;
    public AnimationClip m_ItemAnimationClip;
    public int m_AmmoCount;
    public override void Pick()
    {

        if (CanPick())
        {
            base.Pick();
            GameManager.GetGameManager().GetPlayer().AddAmmo(m_AmmoCount);
        }

    }
    public override bool CanPick()
    {
        if (m_AmmoCount == 0)
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



