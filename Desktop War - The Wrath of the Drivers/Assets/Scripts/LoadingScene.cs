using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    // instantiated values when opening the game
    public static string sceneToLoad = "Menu";
    public static float timeToLoad = 3f;

    private void Start()
    {
        StartCoroutine(LoadScene());
    }

    private IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(timeToLoad);

        switch (sceneToLoad)
        {
            case "EXIT GAME!": Application.Quit(); break;
            default: SceneManager.LoadScene(sceneToLoad); break;
        }
    }
}
