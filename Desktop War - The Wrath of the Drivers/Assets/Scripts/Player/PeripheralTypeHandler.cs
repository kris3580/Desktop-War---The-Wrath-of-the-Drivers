using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;
public class PeripheralTypeHandler : MonoBehaviour
{
    public static PeripheralType? selectedPeripheral;
    [SerializeField] PeripheralType? currentPeripheral;

    private Movement movement;
    private HealthSystem healthSystem;

    private TeleportationAbility teleportationAbility;
    private AutoclickerAbility autoclickerAbility;
    private AltFInfintyAbility altFInfintyAbility;
    private SpamAbility spamAbility;
    private PFeedbackAbility pFeedbackAbility;
    private WaveEmitterAbility waveEmitterAbility;

    [SerializeField] float mouseSpeed;
    [SerializeField] float keyboardSpeed;
    [SerializeField] float headphonesSpeed;
    [SerializeField] int mouseMaxHealth;
    [SerializeField] int keyboardMaxHealth;
    [SerializeField] int headphonesMaxHealth;

    [SerializeField] GameObject teleportationLineRenderer;

    private bool hasPeripheralBeenInitialized = false;

    [SerializeField] Image healthBarImage;
    [SerializeField] Image specialDelayBarImage;

    [SerializeField] Color mouseHealthBarColor;
    [SerializeField] Color mouseSpecialDelayBarColor;
    [SerializeField] Color keyboardHealthBarColor;
    [SerializeField] Color keyboardSpecialDelayBarColor;
    [SerializeField] Color headphonesHealthBarColor;
    [SerializeField] Color headphonesSpecialDelayBarColor;

    private void Update()
    {
        InputPeripheralSwitch();
        PeripheralSwitchHandler();
        UpdateCanvasPeripheralData();
    }

    private void InputPeripheralSwitch()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentPeripheral = PeripheralType.Mouse;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentPeripheral = PeripheralType.Keyboard;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentPeripheral = PeripheralType.Headphones;
        }
    }

    private void Start()
    {
        OnNullPeripheralHandler();
        currentPeripheral = selectedPeripheral;

        movement = GetComponent<Movement>();
        healthSystem = GetComponent<HealthSystem>();

        teleportationAbility = GetComponent<TeleportationAbility>();
        autoclickerAbility = GetComponent<AutoclickerAbility>();
        altFInfintyAbility = GetComponent<AltFInfintyAbility>();
        spamAbility = GetComponent<SpamAbility>();
        pFeedbackAbility = GetComponent<PFeedbackAbility>();
        waveEmitterAbility = GetComponent<WaveEmitterAbility>();

        PeripheralSwitchHandler();
    }



    void PeripheralSwitchHandler()
    {
        if (currentPeripheral != selectedPeripheral || !hasPeripheralBeenInitialized)
        {
            if (!hasPeripheralBeenInitialized) { hasPeripheralBeenInitialized = true; }

            selectedPeripheral = currentPeripheral;
            currentPeripheral = selectedPeripheral;

            switch (currentPeripheral)
            {
                case PeripheralType.Mouse:
                    teleportationAbility.enabled = true;
                    autoclickerAbility.enabled = true;
                    altFInfintyAbility.enabled = false;
                    spamAbility.enabled = false;
                    pFeedbackAbility.enabled = false;
                    waveEmitterAbility.enabled = false;
                    movement.moveSpeed = mouseSpeed;
                    healthSystem.maxHealth = mouseMaxHealth;
                    teleportationLineRenderer.SetActive(true);
                    healthBarImage.color = mouseHealthBarColor;
                    specialDelayBarImage.color = mouseSpecialDelayBarColor;
                    break;

                case PeripheralType.Keyboard:
                    teleportationAbility.enabled = false;
                    autoclickerAbility.enabled = false;
                    altFInfintyAbility.enabled = true;
                    spamAbility.enabled = true;
                    pFeedbackAbility.enabled = false;
                    waveEmitterAbility.enabled = false;
                    movement.moveSpeed = keyboardSpeed;
                    healthSystem.maxHealth = keyboardMaxHealth;
                    teleportationLineRenderer.SetActive(false);
                    healthBarImage.color = keyboardHealthBarColor;
                    specialDelayBarImage.color = keyboardSpecialDelayBarColor;
                    break;

                case PeripheralType.Headphones:
                    teleportationAbility.enabled = false;
                    autoclickerAbility.enabled = false;
                    altFInfintyAbility.enabled = false;
                    spamAbility.enabled = false;
                    pFeedbackAbility.enabled = true;
                    waveEmitterAbility.enabled = true;
                    movement.moveSpeed = headphonesSpeed;
                    healthSystem.maxHealth = headphonesMaxHealth;
                    teleportationLineRenderer.SetActive(false);
                    healthBarImage.color = headphonesHealthBarColor;
                    specialDelayBarImage.color = headphonesSpecialDelayBarColor;
                    break;
            }
        }
    }

    private static void OnNullPeripheralHandler()
    {
        if (selectedPeripheral == null)
        {
            selectedPeripheral = 0;
        }
    }

    public float GetSpecialAbilityCurrentDelayTime()
    {
        switch (currentPeripheral)
        {
            case PeripheralType.Mouse: return teleportationAbility.timePassed;
            case PeripheralType.Keyboard: return altFInfintyAbility.currentAbilityTimer;
            case PeripheralType.Headphones: return pFeedbackAbility.timePassed;
        }
        return 0;
    }


    public float GetSpecialAbilityDelayTime()
    {
        switch (currentPeripheral)
        {
            case PeripheralType.Mouse: return teleportationAbility.abilityDelay;
            case PeripheralType.Keyboard: return altFInfintyAbility.delayAbilityTimer;
            case PeripheralType.Headphones: return pFeedbackAbility.abilityDelay;
        }
        return 0;
    }




    [SerializeField] TextMeshProUGUI injectionDelayText, protectionDelayText, driverTypeText;

    void UpdateCanvasPeripheralData()
    {
        driverTypeText.text = $"DRIVER_TYPE: {currentPeripheral.ToString().ToUpper()}";
        protectionDelayText.text = $"DRIVER_PROTECTION_DELAY: {Math.Round(Mathf.Clamp(GetSpecialAbilityCurrentDelayTime(), 0, float.MaxValue), 3)}";
        injectionDelayText.text = $"DRIVER_INJECTION_DELAY: {Math.Round(Mathf.Clamp(GetAttackAbilityDelayTime(), 0, float.MaxValue), 3)}";
    }


    public float GetAttackAbilityDelayTime()
    {
        switch (currentPeripheral)
        {
            case PeripheralType.Mouse: return autoclickerAbility.timePassed;
            case PeripheralType.Keyboard: return spamAbility.timePassed;
            case PeripheralType.Headphones: return waveEmitterAbility.timePassed;
        }
        return 0;
    }





}
