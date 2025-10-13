using UnityEngine;

public class MouseLock : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (Input.GetKeyDown("2"))
        {
           Cursor.lockState = CursorLockMode.None;
           Cursor.visible = true;
        }



    }
}
