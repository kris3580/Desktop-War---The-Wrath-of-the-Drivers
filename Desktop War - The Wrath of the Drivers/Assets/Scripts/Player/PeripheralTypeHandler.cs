using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
public class PeripheralTypeHandler : MonoBehaviour
{
    public static PeripheralType? selectedPeripheral;
    [SerializeField] PeripheralType? currentPeripheral;

    private Movement movement;
    private HealthSystem healthSystem;

    public TeleportationAbility teleportationAbility;
    public AutoclickerAbility autoclickerAbility;
    public AltFInfintyAbility altFInfintyAbility;
    public SpamAbility spamAbility;
    public PFeedbackAbility pFeedbackAbility;
    public WaveEmitterAbility waveEmitterAbility;

    [SerializeField] public float mouseSpeed;
    [SerializeField] public float keyboardSpeed;
    [SerializeField] public float headphonesSpeed;
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

    private static Image abilityImage1;
    private static Image abilityImage2;

    [SerializeField] Sprite headphonesAttackImage;
    [SerializeField] Sprite headphonesDefenceImage;
    [SerializeField] Sprite keyboardAttackImage;
    [SerializeField] Sprite keyboardDefenceImage;
    [SerializeField] Sprite mouseAttackImage;
    [SerializeField] Sprite mouseDefenceImage;

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

        abilityImage1 = GameObject.Find("AttackIcon").GetComponent<Image>();
        abilityImage2 = GameObject.Find("DefenseIcon").GetComponent<Image>();
        PeripheralSwitchHandler();
    }


    public void AllAbilitiesActivityHandler(bool stateToSwitchTo)
    {
        teleportationAbility.isAbilityActive = stateToSwitchTo;
        autoclickerAbility.isAbilityActive = stateToSwitchTo;
        altFInfintyAbility.isAbilityActive = stateToSwitchTo; 
        spamAbility.isAbilityActive = stateToSwitchTo; 
        pFeedbackAbility.isAbilityActive = stateToSwitchTo; 
        waveEmitterAbility.isAbilityActive = stateToSwitchTo; 

        PlayerRadialBars playerRadialBars = FindObjectOfType<PlayerRadialBars>();
        playerRadialBars.healthBarImage.enabled = stateToSwitchTo;
        playerRadialBars.specialDelayBarImage.enabled = stateToSwitchTo;
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
                    abilityImage1.sprite = mouseAttackImage;
                    abilityImage2.sprite = mouseDefenceImage;


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
                    abilityImage1.sprite = keyboardAttackImage;
                    abilityImage2.sprite = keyboardDefenceImage;


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
                    abilityImage1.sprite = headphonesAttackImage;
                    abilityImage2.sprite = headphonesDefenceImage;


                    break;
            }

            DamagePerSecond.ResetDPSCounter();

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
            case PeripheralType.Keyboard: return altFInfintyAbility.abilityDelay;
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

    public float GetAttackAbilityDamage()
    {
        switch (currentPeripheral)
        {
            case PeripheralType.Mouse: return autoclickerAbility.damage;
            case PeripheralType.Keyboard: return spamAbility.damage;
            case PeripheralType.Headphones: return waveEmitterAbility.damage;
        }
        return 0;
    }

    public float GetAttackAbilityDelay()
    {
        switch (currentPeripheral)
        {
            case PeripheralType.Mouse: return autoclickerAbility.abilityDelay;
            case PeripheralType.Keyboard: return spamAbility.abilityDelay;
            case PeripheralType.Headphones: return waveEmitterAbility.abilityDelay;
        }
        return 0;
    }

}
