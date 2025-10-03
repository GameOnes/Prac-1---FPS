using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static private GameManager m_GameController; // siempre debería ser privado porque si no seria accesible desde cualquier clase rompiendo con el patron singleton
    PlayerController m_Player;
    public Transform m_DestroyObjects; // cada vez que recarga una escena destruye todos los objetos hijos dentro de la escena.
    private void Awake()
    {
        //var un indicador para crear variables.
        // un singleton es una clase estatica publica que solo puede tener una instancia
        if(m_GameController == null) // si ya existe una instancia de GameController
        {
            GameObject.Destroy(gameObject); // destruye el objeto actual
            return; // sale del metodo
        }
        m_GameController = this; // si no existe una instancia la crea
        DontDestroyOnLoad(gameObject); // hace que el objeto no se destruya al cargar una nueva escena

    }
    public static GameManager GetGameManager() // se usa un metodo estatico para acceder a la instancia desde otras clases.
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
       if(Input.GetKeyDown(KeyCode.Alpha1)) // tecla 1
       {
            SceneManager.LoadScene("Level1Scene");
       }
       if (Input.GetKeyDown(KeyCode.Alpha2))
       {
            SceneManager.LoadScene("Level2Scene");
       }
    }
    public PlayerController GetPlayer()
    {
        return m_Player;
    }
    public void SetPlayer(PlayerController player)
    {
       m_Player=player;
    }
}



