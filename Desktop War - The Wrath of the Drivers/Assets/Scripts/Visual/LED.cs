using System.Collections;
using UnityEngine;

public class LED : MonoBehaviour
{
    [SerializeField] private GameObject[] ledColors;
    [SerializeField] private float randomTimeX;
    [SerializeField] private float randomTimeY;


    void Start()
    {
        StartCoroutine(LEDAnimation());
    }

    IEnumerator LEDAnimation()
    {
        while (true)
        {
            foreach(var led in ledColors)
        {
                led.SetActive(false);
            }

            ledColors[UnityEngine.Random.Range(0, 3)].SetActive(true);

            yield return new WaitForSeconds(UnityEngine.Random.Range(randomTimeX, randomTimeY));
        }

    }
}
