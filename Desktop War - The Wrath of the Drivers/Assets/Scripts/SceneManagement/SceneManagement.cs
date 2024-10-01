using UnityEngine.SceneManagement;

public static class SceneManagement
{
    public static void LoadScene(string sceneToLoad, float timeToLoad)
    {
        LoadingScene.sceneToLoad = sceneToLoad;
        LoadingScene.timeToLoad = timeToLoad;
        SceneManager.LoadScene("Loading");
    }
}
