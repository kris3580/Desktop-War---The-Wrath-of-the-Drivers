using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void Update()
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

        PeripheralSwitchHandler();
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
                    break;

                case PeripheralType.Headphones:
                    teleportationAbility.enabled = false;
                    autoclickerAbility.enabled = false;
                    altFInfintyAbility.enabled = false;
                    spamAbility.enabled = false;
                    pFeedbackAbility.enabled = true;
                    waveEmitterAbility.enabled = true;
                    movement.moveSpeed = headphonesSpeed;
                    healthSystem.maxHealth = keyboardMaxHealth;
                    teleportationLineRenderer.SetActive(false);
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





}