using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorBehaviour : MonoBehaviour
{
    private static bool enableCursor = false;

    public static void ToggleCursorState()
    {
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.Confined;
            enableCursor = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            enableCursor = false;
        }
    }
}
