using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cursor : MonoBehaviour
{
    [SerializeField] private Texture2D defaultCursor;
    [SerializeField] private Texture2D loadingCursor;

    private float timeUntilDelayToDefaultCursorMethodCouldBeUsed = 7f;
    private float currentTime = 8f;
    private void Update()
    {
        currentTime += Time.deltaTime;
    }

    private void Awake()
    {
        SetCursor("defaultCursor");
        SingletonHandler();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // event
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        string activeSceneName = SceneManager.GetActiveScene().name;

        if (activeSceneName == "Loading")
        {
            SetCursor("loadingCursor");
        }
        else if (activeSceneName == "GameplayTesting" || activeSceneName == "Menu")
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
        if (currentTime > timeUntilDelayToDefaultCursorMethodCouldBeUsed)
        {
            currentTime = 0;
            SetCursor("loadingCursor");
            yield return new WaitForSeconds(UnityEngine.Random.Range(0.01f, 1.2f));
            SetCursor("defaultCursor");
        }

        
    }


    public void SetCursor(string textureName)
    {
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


    // singleton
    public static Cursor instance { get; private set; }
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