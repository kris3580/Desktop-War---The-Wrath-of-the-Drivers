using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public static float volume = 1f;
    public static int isFullscreenOn = 1;

    private void Start()
    {
        SetSettings();
    }

    private void SetSettings()
    {
        volume = PlayerPrefs.GetFloat("volume");
        isFullscreenOn = PlayerPrefs.GetInt("isFullscreenOn");

        if (isFullscreenOn == 0)
        {
            Screen.SetResolution((int)(Display.main.systemWidth / 1.2f), (int)(Display.main.systemHeight / 1.2f), false);
        }
        else
        {
            Screen.SetResolution(Display.main.systemWidth, Display.main.systemHeight, true);
        }

    }

}
