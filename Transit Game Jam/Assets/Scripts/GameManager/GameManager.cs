using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static public GameManager Instance { get; private set; }

    public TextMeshProUGUI timerTxt;
    public TextMeshProUGUI cheddahTxt;

    [SerializeField] private float timer = 60f;

    private int cheddahAmt;

    private void Awake()
    {
        Instance = this;
        cheddahAmt = 0;
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

    private void Update()
    {
        timerTxt.text = "00.00.00" + Mathf.Floor(timer * 10 % 10);
        cheddahTxt.text = "Cheddah: " + cheddahAmt;
    }

}
