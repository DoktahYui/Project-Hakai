using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    private bool isPaused = false;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Game Manager in the scene. Destroying the newest one");
            Destroy(this.gameObject);
            return;
        }
        instance = this;

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)) CursorBehaviour.ToggleCursorState();    
    }
}
