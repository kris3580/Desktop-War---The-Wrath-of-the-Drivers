using UnityEngine;

public class SFXHandler : MonoBehaviour
{

    [SerializeField] GameObject sfxPrefab;
    [SerializeField] AudioClip[] audioClips;

    public void Play(int sfxIndex, float volumeNormalizationOffset = 0)
    {
        GameObject sfxInstance = Instantiate(sfxPrefab);
        sfxInstance.GetComponent<AudioSource>().clip = audioClips[sfxIndex];
        sfxInstance.GetComponent<SFX>().timeToWaitUntilDestroy = audioClips[sfxIndex].length;
        sfxInstance.GetComponent<AudioSource>().volume = SettingsManager.volume - volumeNormalizationOffset;
        sfxInstance.GetComponent<AudioSource>().Play();
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            Play(13);
        }

        if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
        {
            Play(14);
        }


        if (Input.anyKeyDown)
        {
            Play(11);
        }

        // any key up
        for (int i = (int)KeyCode.Space; i <= (int)KeyCode.Menu; i++)
        {
            KeyCode key = (KeyCode)i;
            if (Input.GetKeyUp(key))
            {
                Play(12);
                break;
            }
        }

    }



    // singleton
    public static SFXHandler Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

}
