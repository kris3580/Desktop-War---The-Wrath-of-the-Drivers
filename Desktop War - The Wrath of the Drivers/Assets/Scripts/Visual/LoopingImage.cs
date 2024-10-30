using UnityEngine;
using UnityEngine.UI;

public class LoopingImage : MonoBehaviour
{
    private RawImage image;
    [SerializeField] private float x, y;

    [SerializeField] private bool isUsingUnscaledTime = true;
    private void Start()
    {
        image = GetComponent<RawImage>();
    }

    void Update()
    {
        if (isUsingUnscaledTime)
        {
            image.uvRect = new Rect(image.uvRect.position + new Vector2(x, y) * Time.unscaledDeltaTime, image.uvRect.size);
        }
        else
        {
            image.uvRect = new Rect(image.uvRect.position + new Vector2(x, y) * Time.deltaTime, image.uvRect.size);
        }
       
    }
}
