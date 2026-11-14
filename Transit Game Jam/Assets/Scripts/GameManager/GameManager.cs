using UnityEngine;

public class GameManager : MonoBehaviour
{
    CursorLockMode wantedMode;

    void Start()
    {
        // Set wanted mode to whatever is set in the inspector
        SetCursorState();
        Cursor.visible = false;

    }

    // Apply requested cursor state
    void SetCursorState()
    {
        Cursor.lockState = wantedMode;
        // Hide cursor when locking
        Cursor.visible = (CursorLockMode.Locked != wantedMode);
    }

}
