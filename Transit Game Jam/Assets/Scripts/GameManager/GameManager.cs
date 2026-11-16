using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static public GameManager Instance { get; private set; }

    public TextMeshProUGUI timerTxt;
    public TextMeshProUGUI cheddahTxt;

    [SerializeField] private float elapsedtime = 0f;
    [SerializeField] private string mainCitySceneName = "City Scene";
    [SerializeField] private string playerTag = "Player";

    public float cheddahAmt;

    private Vector3 lastMainCityPlayerPosition;
    private bool hasSavedMainCityPosition;
    private bool isChangingScene;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

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

        string activeSceneName = SceneManager.GetActiveScene().name;

        if (activeSceneName == mainCitySceneName)
        {
            TrackMainCityPlayerPosition();
            return;
        }

        CheckActiveScenePlayerHealthAndReturn();
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

    private void CheckActiveScenePlayerHealthAndReturn()
    {
        if (isChangingScene)
        {
            return;
        }

        PlayerController[] players = GetPlayersInActiveScene();

        for (int i = 0; i < players.Length; i++)
        {
            if (players[i] != null && players[i].playerHealth <= 0f)
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

        if (!Application.CanStreamedLevelBeLoaded(mainCitySceneName))
        {
            Debug.LogError("Scene not found in Build Settings: " + mainCitySceneName);
            isChangingScene = false;
            return;
        }

        if (SceneManager.GetActiveScene().name != mainCitySceneName)
        {
            SceneManager.LoadScene(mainCitySceneName);
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
        Transform playerTransform = FindAnyPlayerTransformInActiveScene();
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

        Transform playerTransform = FindAnyPlayerTransformInActiveScene();
        if (playerTransform == null)
        {
            return;
        }

        playerTransform.position = lastMainCityPlayerPosition;
    }

    private Transform FindAnyPlayerTransformInActiveScene()
    {
        PlayerController[] players = GetPlayersInActiveScene();
        for (int i = 0; i < players.Length; i++)
        {
            if (players[i] != null)
            {
                return players[i].transform;
            }
        }

        return null;
    }

    private PlayerController[] GetPlayersInActiveScene()
    {
        Scene activeScene = SceneManager.GetActiveScene();
        GameObject[] roots = activeScene.GetRootGameObjects();

        System.Collections.Generic.List<PlayerController> result = new System.Collections.Generic.List<PlayerController>();

        for (int i = 0; i < roots.Length; i++)
        {
            PlayerController[] players = roots[i].GetComponentsInChildren<PlayerController>(true);
            for (int j = 0; j < players.Length; j++)
            {
                result.Add(players[j]);
            }
        }

        return result.ToArray();
    }
}