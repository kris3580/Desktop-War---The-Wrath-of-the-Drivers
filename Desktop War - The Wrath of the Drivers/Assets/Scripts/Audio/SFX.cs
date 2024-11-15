using UnityEngine;

public class SFX : MonoBehaviour
{
    public float timeToWaitUntilDestroy = 99f;
    private float timePassed = 0f;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        timePassed += Time.unscaledDeltaTime;

        if (timePassed >= timeToWaitUntilDestroy)
        {
            Destroy(gameObject);
        }
    }

}
