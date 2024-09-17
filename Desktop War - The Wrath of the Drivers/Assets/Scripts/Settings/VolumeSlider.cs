using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    Slider volumeSlider;

    private void Start()
    {
        volumeSlider = GetComponent<Slider>();
        volumeSlider.value = SettingsManager.volume;
    }

    void Update()
    {
        SettingsManager.volume = volumeSlider.value;
        PlayerPrefs.SetFloat("volume", SettingsManager.volume);
    }
}

