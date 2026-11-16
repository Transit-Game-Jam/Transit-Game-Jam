using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static public GameManager Instance { get; private set; }

    public TextMeshProUGUI timerTxt;
    public TextMeshProUGUI cheddahTxt;

    [SerializeField] private float elapsedtime = 0f;
    [SerializeField] private string mainCitySceneName = "CityScene";
    [SerializeField] private string playerTag = "Player";

    public float cheddahAmt;

    private Vector3 lastMainCityPlayerPosition;
    private bool hasSavedMainCityPosition;
    private bool isChangingScene;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        cheddahAmt = 0;
        SetCursorState();
        Cursor.visible = false;
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void SetCursorState()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }

    private void Update()
    {
        UpdateUiTimerAndCheddah();
        CheckAnyPlayerHealthAndReturn();

        if (SceneManager.GetActiveScene().name == mainCitySceneName)
        {
            TrackMainCityPlayerPosition();
        }
    }

    private void UpdateUiTimerAndCheddah()
    {
        int mins = Mathf.FloorToInt(elapsedtime / 60);
        int secs = Mathf.FloorToInt(elapsedtime % 60);
        int milliseconds = Mathf.FloorToInt((elapsedtime % 1f) * 100f);

        if (timerTxt != null)
        {
            timerTxt.text = string.Format("{0:00} : {1:00} : {2:00}", mins, secs, milliseconds);
        }

        if (cheddahTxt != null)
        {
            cheddahTxt.text = "Cheddah: $" + cheddahAmt;
        }

        elapsedtime += Time.deltaTime;
    }

    private void CheckAnyPlayerHealthAndReturn()
    {
        if (isChangingScene)
        {
            return;
        }

        PlayerController[] players = GetAllPlayers();

        for (int i = 0; i < players.Length; i++)
        {
            PlayerController player = players[i];
            if (player == null)
            {
                continue;
            }

            if (player.playerHealth <= 0f)
            {
                playerChange();
                return;
            }
        }
    }

    public void playerChange()
    {
        if (isChangingScene)
        {
            return;
        }

        isChangingScene = true;

        if (SceneManager.GetActiveScene().name != mainCitySceneName)
        {
            SceneManager.LoadScene("CityScene");
            return;
        }

        ReturnPlayerToLastMainCityPosition();
        isChangingScene = false;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == mainCitySceneName)
        {
            ReturnPlayerToLastMainCityPosition();
        }

        isChangingScene = false;
    }

    private void TrackMainCityPlayerPosition()
    {
        Transform playerTransform = FindAnyPlayerTransform();
        if (playerTransform == null)
        {
            return;
        }

        lastMainCityPlayerPosition = playerTransform.position;
        hasSavedMainCityPosition = true;
    }

    private void ReturnPlayerToLastMainCityPosition()
    {
        if (!hasSavedMainCityPosition)
        {
            return;
        }

        Transform playerTransform = FindAnyPlayerTransform();
        if (playerTransform == null)
        {
            return;
        }

        playerTransform.position = lastMainCityPlayerPosition;
    }

    private Transform FindAnyPlayerTransform()
    {
        GameObject taggedPlayer = GameObject.FindGameObjectWithTag(playerTag);
        if (taggedPlayer != null)
        {
            return taggedPlayer.transform;
        }

        PlayerController[] players = GetAllPlayers();
        for (int i = 0; i < players.Length; i++)
        {
            if (players[i] != null)
            {
                return players[i].transform;
            }
        }

        return null;
    }

    private PlayerController[] GetAllPlayers()
    {
#if UNITY_2022_2_OR_NEWER
        return FindObjectsByType<PlayerController>(FindObjectsInactive.Include, FindObjectsSortMode.None);
#else
#pragma warning disable CS0618
        return FindObjectsOfType<PlayerController>(true);
#pragma warning restore CS0618
#endif
    }
}