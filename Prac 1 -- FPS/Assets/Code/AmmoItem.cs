public class AmmoItem : Item
{

    public int _AmmoCount;
    public override void Pick()
    {
        base.Pick();
        GameManager.GetGameManager().GetPlayer().AddAmmo()
    }
}



