using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static public GameManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        // Set wanted mode to whatever is set in the inspector
        SetCursorState();
        Cursor.visible = false;

    }

    // Apply requested cursor state
    void SetCursorState()
    {
        Cursor.lockState = CursorLockMode.Locked;
        // Hide cursor when locking
        Cursor.visible = true;
    }
    
    

}
