using TMPro;
using UnityEngine;
using System;
public class DamagePerSecond : MonoBehaviour
{
    private static float totalDamageDealt = 0f;
    private static float elapsedTime = 0f;
    private TextMeshProUGUI dpsText;
    private void Start()
    {
        dpsText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= 1)
        {
            float dps = totalDamageDealt / elapsedTime;
            dpsText.text = $"DRIVER_DAMAGE_PER_SECOND: {Math.Round(dps, 0)}";
            elapsedTime = 0;
            totalDamageDealt = 0;
        }
    }

    public static void AddToDPSCounter(float damage)
    {
        totalDamageDealt += damage;
    }

    public static void ResetDPSCounter()
    {
        totalDamageDealt = 0;
        elapsedTime = 0;
        totalDamageDealt = 0;
    }

}
