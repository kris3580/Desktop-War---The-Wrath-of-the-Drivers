using System;
using TMPro;
using UnityEngine;
public class FramesPerSecondText : MonoBehaviour
{
    private TextMeshProUGUI fpsText;
    private void Start()
    {
        fpsText = GetComponent<TextMeshProUGUI>();
    }

    private int frameCount = 0;
    private float dt = 0;
    private float fps = 0f;
    private float updateRate = 4f; 


    void Update()
    {
        frameCount++;
        dt += Time.deltaTime;
        if (dt > 1.0 / updateRate)
        {
            fps = frameCount / dt;
            frameCount = 0;
            dt -= 1.0f / updateRate;
        }

        fpsText.text = $"DRIVER_FRAMES_PER_SECOND: {Math.Round(fps, 2)}";

    }
}
