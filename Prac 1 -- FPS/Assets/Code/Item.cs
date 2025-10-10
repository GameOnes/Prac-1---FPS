using UnityEngine;
public abstract class Item : MonoBehaviour 
{

    public virtual void Pick()
    {
        GameObject.Destroy(gameObject);
    }
    public abstract bool CanPick();



    //Abstract: No se pueden instaciar objetos de esta clase, solo estan definidos.
    //Protegido:
}



