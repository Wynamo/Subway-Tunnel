using UnityEngine;

public class HideAndLockCursor : MonoBehaviour
{
    void Start()
    {
        // Hide and lock the cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}