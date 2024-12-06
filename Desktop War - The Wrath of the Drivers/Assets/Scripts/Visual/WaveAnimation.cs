using UnityEngine;

public class WaveAnimation : MonoBehaviour
{
    [SerializeField] private float frameDuration = 0.1f;
    private int currentFrame = 0;
    private int totalFrames;
    private float timer = 0f; 

    void Start()
    {
        totalFrames = transform.childCount;

        for (int i = 0; i < totalFrames; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == 0);
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= frameDuration)
        {
            transform.GetChild(currentFrame).gameObject.SetActive(false);
            currentFrame = (currentFrame + 1) % totalFrames;
            transform.GetChild(currentFrame).gameObject.SetActive(true);
            timer = 0f;
        }
    }
}