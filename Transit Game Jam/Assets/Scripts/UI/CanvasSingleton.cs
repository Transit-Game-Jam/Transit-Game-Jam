using UnityEngine;

public class CanvasSingleton : MonoBehaviour
{
    public static CanvasSingleton Instance;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
