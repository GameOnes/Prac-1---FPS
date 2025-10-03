using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    static private GameController m_GameController; // siempre debería ser privado porque si no seria accesible desde cualquier clase rompiendo con el patron singleton
    public Transform m_DestroyObjects;
    private void Start()
    {
        //var un indicador para crear variables.
        // un singleton es una clase estatica publica que solo puede tener una instancia
        if(m_GameController == null) // si ya existe una instancia de GameController
        {
            GameObject.Destroy(gameObject); // destruye el objeto actual
            return; // sale del metodo
        }
        DontDestroyOnLoad(gameObject);

    }
    public static GameController GetInstance() // se usa un metodo estatico para acceder a la instancia desde otras clases.
                                               // una instancia es un objeto creado a partir de una clase.
    {
        return m_GameController;
    }
    public void ReloadLevel()
    {
        for(int i=0; i < m_DestroyObjects.childCount; i++)
        {
            GameObject.Destroy(m_DestroyObjects.GetChild(i).gameObject);
        }
    }
    private void Update()
    {
       if(Input.GetKeyDown(KeyCode.Alpha1))
       {
            SceneManager.LoadScene("Level1Scene");
       }
       if (Input.GetKeyDown(KeyCode.Alpha2))
       {
            SceneManager.LoadScene("Level2Scene");
       }
    }
}



