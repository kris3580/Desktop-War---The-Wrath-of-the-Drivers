using UnityEngine;
using UnityEngine.UI;

public class PlayerRadialBars : MonoBehaviour
{
    PeripheralTypeHandler peripheralTypeHandler;
    HealthSystem healthSystem;
    [SerializeField] public Image healthBarImage;
    [SerializeField] public Image specialDelayBarImage;


    private void Start()
    {
        peripheralTypeHandler = GetComponent<PeripheralTypeHandler>();
        healthSystem = GetComponent<HealthSystem>();
    }


    private void Update()
    {
        healthBarImage.fillAmount = (float)healthSystem.currentHealth / (float)healthSystem.maxHealth;

        specialDelayBarImage.fillAmount = 1 - (peripheralTypeHandler.GetSpecialAbilityCurrentDelayTime() / peripheralTypeHandler.GetSpecialAbilityDelayTime());
    }






}
