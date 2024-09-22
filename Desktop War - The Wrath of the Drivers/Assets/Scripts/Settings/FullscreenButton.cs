using TMPro;
using UnityEngine;

public class FullscreenButton : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI fullscreenButtonText;

    public void FullscreenSwitch()
    {
        if (SettingsManager.isFullscreenOn == 0)
        {
            SettingsManager.isFullscreenOn = 1;
            Screen.SetResolution(Display.main.systemWidth, Display.main.systemHeight, true);
            fullscreenButtonText.text = "true";
        }
        else
        {
            SettingsManager.isFullscreenOn = 0;
            Screen.SetResolution((int)(Display.main.systemWidth / 1.2f), (int)(Display.main.systemHeight / 1.2f), false);
            fullscreenButtonText.text = "false";
        }

        Debug.Log(SettingsManager.isFullscreenOn);

        PlayerPrefs.SetInt("isFullscreenOn", SettingsManager.isFullscreenOn);

    }


    private void Start()
    {
        if (SettingsManager.isFullscreenOn == 0)
        {
            fullscreenButtonText.text = "false";
        }
        else
        {
            fullscreenButtonText.text = "true";
        }
    }


}
