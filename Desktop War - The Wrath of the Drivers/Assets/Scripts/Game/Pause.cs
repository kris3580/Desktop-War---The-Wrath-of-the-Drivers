using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public static bool isPaused = false;

    [SerializeField] GameObject pausePanel;

    [SerializeField] GraphicRaycaster graphicRaycaster;
    [SerializeField] GameObject pauseMenuPanel;
    [SerializeField] GameObject settingsMenuPanel;

    [SerializeField] Toggle skipDialogueToggle;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) PauseSwitch();

        PauseHandler();

    }

    private void PauseHandler()
    {
        if (isPaused)
        {
            graphicRaycaster.enabled = true;
            Time.timeScale = 0f;
            pausePanel.SetActive(true);

        }
        else
        {
            pauseMenuPanel.SetActive(true);
            settingsMenuPanel.SetActive(false);

            graphicRaycaster.enabled = false;
            Time.timeScale = 1f;
            pausePanel.SetActive(false);

        }
    }

    public void PauseSwitch()
    {
        StartCoroutine(FindObjectOfType<Cursor>().DelayedReturnToDefaultCursor());
        isPaused = !isPaused;
    }


    public void ExitGame()
    {
        SFXHandler.Instance.Play(1);
        Time.timeScale = 1;
        isPaused = false;
        SceneManagement.LoadScene("EXIT GAME!", 1f);
    }

    public void GoToMenu()
    {
        SFXHandler.Instance.Play(1);
        Time.timeScale = 1;
        isPaused = false;
        SceneManagement.LoadScene("Menu", 2f);
    }




    public void OpenSettings()
    {
        StartCoroutine(FindObjectOfType<Cursor>().DelayedReturnToDefaultCursor());
        SFXHandler.Instance.Play(1);
        pauseMenuPanel.SetActive(false);
        settingsMenuPanel.SetActive(true);
        skipDialogueToggle.isOn = SettingsManager.isSkipDialogueActive;
    }


    public void CloseSettings()
    {
        SFXHandler.Instance.Play(1);
        pauseMenuPanel.SetActive(true);
        settingsMenuPanel.SetActive(false);

    }

    public void SkipDialogueButtonHandler()
    {
        StartCoroutine(FindObjectOfType<Cursor>().DelayedReturnToDefaultCursor());
        SFXHandler.Instance.Play(1);
        Movement.isFrozen = false;
        SettingsManager.isSkipDialogueActive = !SettingsManager.isSkipDialogueActive;
    }
}
