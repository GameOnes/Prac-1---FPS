using UnityEngine;
public abstract class Item : MonoBehaviour 
{

    public virtual void Pick()
    {
        GameObject.Destroy(gameObject);
    }
    public abstract bool CanPick(); // esto obliga a las clases derivadas a implementar este metodo
    //una clase derivada es una clase que hereda de otra clase base.
}



