using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] 
    private Texture2D cursorTex;
    [SerializeField] 
    private GameObject menu;

    private Vector2 hotSpot = new Vector2(17, 17);
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Cursor.SetCursor(cursorTex, hotSpot, CursorMode.Auto);
            Time.timeScale = 0f;
        }
    }
}
