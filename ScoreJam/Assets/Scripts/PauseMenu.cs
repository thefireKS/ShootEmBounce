using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] 
    private Texture2D cursorTex;
    [SerializeField] 
    private GameObject menu;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Cursor.SetCursor(cursorTex, Vector2.zero, CursorMode.Auto);
            Time.timeScale = 0f;
        }
    }
}
