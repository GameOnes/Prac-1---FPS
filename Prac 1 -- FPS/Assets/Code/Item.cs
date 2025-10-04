using UnityEngine;
public class Item : MonoBehaviour
{

    public virtual void Pick()
    {
        GameObject.Destroy(gameObject);
    }




}



