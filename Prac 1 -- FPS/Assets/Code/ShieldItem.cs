using UnityEngine;

public class ShieldItem : Item
{
    public Animation m_ItAnimation;
    public AnimationClip m_ItemAnimationClip;
    public int m_ShieldCount;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Pick()
    {
        base.Pick();
        GameManager.GetGameManager().GetPlayer().AddShield(m_ShieldCount);
    }

    // Update is called once per frame
    public override bool CanPick()
    {
        if (m_ShieldCount>0)
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
