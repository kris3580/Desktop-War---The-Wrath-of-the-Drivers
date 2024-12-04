using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OSTHandler : MonoBehaviour
{
    public AudioSource audioSource;
    private bool isTransitioning = false;
    [SerializeField] private List<AudioClip> songs;
    [SerializeField] private float testTransitionTime;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!isTransitioning) audioSource.volume = SettingsManager.volume;


        if (Input.GetKeyDown(KeyCode.Alpha5)) SetSong(0, testTransitionTime);
        if (Input.GetKeyDown(KeyCode.Alpha6)) SetSong(1, testTransitionTime);
        if (Input.GetKeyDown(KeyCode.Alpha7)) SetSong(2, testTransitionTime);
    }


    public void SetSong(int songID, float transitionTime)
    {
        StartCoroutine(TransitionCoroutine(songID, transitionTime));
    }


    private IEnumerator TransitionCoroutine(int songID, float transitionTime)
    {
        float initialVolume = SettingsManager.volume;
        isTransitioning = true;

        for (float t = 0; t < transitionTime; t += Time.deltaTime)
        {
            audioSource.volume = Mathf.Lerp(initialVolume, 0, t / transitionTime);
            yield return null;
        }
        audioSource.volume = 0;

        audioSource.clip = songs[songID];
        audioSource.Play();

        for (float t = 0; t < transitionTime; t += Time.deltaTime)
        {
            audioSource.volume = Mathf.Lerp(0, initialVolume, t / transitionTime);
            yield return null;
        }
        audioSource.volume = initialVolume;
        isTransitioning = false;
    }



    // singleton
    public static OSTHandler Instance { get; private set; }

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
