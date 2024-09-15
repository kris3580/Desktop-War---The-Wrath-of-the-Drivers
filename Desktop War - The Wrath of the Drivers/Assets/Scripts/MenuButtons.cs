using UnityEngine;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] GameObject mainMenuPanel;
    [SerializeField] GameObject settingsPanel;
    [SerializeField] GameObject creditsPanel;



    //MAIN MENU
    public void ExitGame()
    {
        SceneMangement.LoadScene("EXIT GAME!", 1f);
    }

    public void OpenSettings()
    {
        mainMenuPanel.SetActive(false);

        if(Screen.fullScreen == true) SettingsManager.isFullscreenOn = 1;
        else SettingsManager.isFullscreenOn = 0;

        settingsPanel.SetActive(true);
    }
    public void CloseSettings()
    {
        mainMenuPanel.SetActive(true);
        settingsPanel.SetActive(false);
    }

    public void OpenCredits()
    {
        mainMenuPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }

    public void CloseCredits()
    {
        mainMenuPanel.SetActive(true);
        creditsPanel.SetActive(false);
    }

    public void PrepareGame()
    {

    }


    // SETTINGS

    public void DisplayHandling()
    {

    }

}
