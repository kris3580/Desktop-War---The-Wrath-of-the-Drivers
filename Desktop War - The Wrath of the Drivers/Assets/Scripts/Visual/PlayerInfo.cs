using TMPro;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI stabilityText;
    [SerializeField] TextMeshProUGUI RAMText;
    [SerializeField] TextMeshProUGUI bitflipsText;
    [SerializeField] TextMeshProUGUI attackText;
    [SerializeField] TextMeshProUGUI defenceText;

    PeripheralTypeHandler peripheralTypeHandler;
    HealthSystem healthSystem;

    private void Start()
    {
        peripheralTypeHandler = FindObjectOfType<PeripheralTypeHandler>();
        healthSystem = FindObjectOfType<HealthSystem>();
    }




    private void Update()
    {
        stabilityText.text = $"{healthSystem.currentHealth}/{healthSystem.maxHealth};";
        RAMText.text = $"{Memory.memoryCount}KB;";
        bitflipsText.text = $"{Store.coins};";
        attackText.text = $"{peripheralTypeHandler.GetAttackAbilityDamage()}dmg/{peripheralTypeHandler.GetAttackAbilityDelay()}s;";
        defenceText.text = $"1/{peripheralTypeHandler.GetSpecialAbilityDelayTime()}s;";
    }


}
