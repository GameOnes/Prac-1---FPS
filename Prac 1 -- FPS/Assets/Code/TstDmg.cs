using UnityEngine;

public class TstDmg : MonoBehaviour
{

    public float dmg = 30;

    private void OnTriggerEnter(Collider other)
    {
        TryRealDmg(other);
    }
    private void TryRealDmg(Collider col)
    {

        if (col == null) return;

        var pc = col.GetComponentInParent<PlayerController>();
        if (pc != null)
        {
            pc.GetDamage(dmg);
        }
    }
}
