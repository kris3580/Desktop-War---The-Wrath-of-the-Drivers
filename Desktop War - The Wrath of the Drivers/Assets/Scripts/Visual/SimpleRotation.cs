using UnityEngine;

public class SimpleRotation : MonoBehaviour
{
    [SerializeField] private float x, y, z;

    [SerializeField] private bool isUsingUnscaledTime = true;

    void Update()
    {
        if (isUsingUnscaledTime)
        {
            transform.Rotate(x * Time.unscaledDeltaTime, y * Time.unscaledDeltaTime, z * Time.unscaledDeltaTime);
        }
        else
        {
            transform.Rotate(x * Time.deltaTime, y * Time.deltaTime, z * Time.deltaTime);
        }

        
    }
}
