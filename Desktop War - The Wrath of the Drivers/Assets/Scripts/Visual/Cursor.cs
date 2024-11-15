using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cursor : MonoBehaviour
{
    [SerializeField] private Texture2D defaultCursor;
    [SerializeField] private Texture2D loadingCursor;

    private float timeUntilDelayToDefaultCursorMethodCouldBeUsed = 7f;
    private float currentTime = 8f;

    public static Cursor instance { get; private set; }

    private void Update()
    {
        currentTime += Time.unscaledDeltaTime;
    }

    private void Awake()
    {
        SetCursor("defaultCursor");
        SingletonHandler();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (instance == null) return;

        string activeSceneName = SceneManager.GetActiveScene().name;

        if (activeSceneName == "Loading")
        {
            SetCursor("loadingCursor");
        }
        else if (activeSceneName == "Game" || activeSceneName == "Menu")
        {
            StartCoroutine(DelayedReturnToDefaultCursor());
        }
        else
        {
            SetCursor("defaultCursor");
        }
    }

    public IEnumerator DelayedReturnToDefaultCursor()
    {
        if (instance == null) yield break;

        if (currentTime > timeUntilDelayToDefaultCursorMethodCouldBeUsed)
        {
            currentTime = 0;
            SetCursor("loadingCursor");
            yield return new WaitForSeconds(UnityEngine.Random.Range(0.01f, 1.2f));

            if (instance != null)
            {
                SetCursor("defaultCursor");
            }
        }
    }

    public void SetCursor(string textureName)
    {
        if (instance == null) return;

        switch (textureName)
        {
            case "defaultCursor":
                UnityEngine.Cursor.SetCursor(defaultCursor, new Vector2(defaultCursor.width / 2, defaultCursor.height / 2), CursorMode.Auto);
                break;
            case "loadingCursor":
                UnityEngine.Cursor.SetCursor(loadingCursor, new Vector2(loadingCursor.width / 2, loadingCursor.height / 2), CursorMode.Auto);
                break;
            default:
                break;
        }
    }

    private void SingletonHandler()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
