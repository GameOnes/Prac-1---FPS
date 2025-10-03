using System.Collections;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    //con CTrl +.  se puede crear una clase seleccionando el nombre de la clase y presionando esa combinacion de teclas
    public float m_DestroyOnTime = 0.3f;

    private void Start()
    {
        StartCoroutine(DestroyCoroutine());
    }
    IEnumerator DestroyCoroutine()
    {
        //una corutina es un metodo que puede pausar su ejecucion y continuar en el siguiente frame, de forma simple lo deja en espera para realizar la tarea y dp continuar el proceso.
        Debug.Log("start Coroutine");
        yield return new WaitForSeconds(m_DestroyOnTime);
        GameObject.Destroy(gameObject);
    }
}



