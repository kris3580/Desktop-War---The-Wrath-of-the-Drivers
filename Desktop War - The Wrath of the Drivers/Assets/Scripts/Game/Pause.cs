using UnityEngine;

public class Pause : MonoBehaviour
{
    public static bool isPaused = false;

    [SerializeField] GameObject pausePanel;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }

        if (isPaused)
        {
            Time.timeScale = 0f;
            pausePanel.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            pausePanel.SetActive(false);
        }

    }
}
