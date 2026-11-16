using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static public GameManager Instance { get; private set; }

    public TextMeshProUGUI timerTxt;
    public TextMeshProUGUI cheddahTxt;
    
    private SceneManager sceneManager;
    [SerializeField] private float elapsedtime = 0f;

    private int playerHealth = 3;


    public float cheddahAmt;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
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
        int mins = Mathf.FloorToInt(elapsedtime / 60);
        int secs = Mathf.FloorToInt(elapsedtime % 60);
        int milliseconds = Mathf.FloorToInt((elapsedtime % 1f) * 100f);
        timerTxt.text = string.Format("{0:00} : {1:00} : {2:00}", mins, secs, milliseconds);
        cheddahTxt.text = "Cheddah: $" + cheddahAmt;

        elapsedtime += Time.deltaTime;

        /*if(elapsedtime <= 0)
        {
            SceneManager.LoadScene(2);
        }*/

        if(playerHealth <= 0)
        {
            SceneManager.LoadScene(2);
        }
    }
}
