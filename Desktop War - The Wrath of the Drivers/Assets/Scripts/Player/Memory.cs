using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Memory : MonoBehaviour
{
    public static int memoryCount = 0;

    [SerializeField] TextMeshProUGUI levelText;

    private PeripheralTypeHandler peripheralTypeHandler;

    private void Start()
    {
        peripheralTypeHandler = FindObjectOfType<PeripheralTypeHandler>();

        LevelHandler(1);
    }

    public void LevelHandler(int extra)
    {
        memoryCount += extra;

        peripheralTypeHandler.autoclickerAbility.damage += extra;
        peripheralTypeHandler.spamAbility.damage += extra;
        peripheralTypeHandler.waveEmitterAbility.damage += extra;

        levelText.text = $"DRIVER_MEMORY: {memoryCount}KB";

    }


}
