using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Store : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    
    [SerializeField] private GameObject iconHighlight;
    [SerializeField] private GameObject iconHighlightBorder;

    private bool hasBeenSelected = false;

    private int doubleClickCount = 0;
    [SerializeField] float doubleClickTimeValidation = 0.5f;
    private float currentTime = 0f;
    private bool hasBeenClickedOnce = false;

    [SerializeField] private GameObject storeWindow;
    [SerializeField] private GameObject desktopIcon;

    [SerializeField] public static bool isInStore = false;


    [SerializeField] GameObject extraSpeedSymbol;

    public static int coins = 150;
    [SerializeField] TextMeshProUGUI coinsText;
    [SerializeField] TextMeshProUGUI storeCoinsText;

    [SerializeField] TextMeshProUGUI[] storePricesText;
    [SerializeField] int[] storePrices;
    [SerializeField] Image[] highlightSquares;
    [SerializeField] bool[] isItemAvailableToBuy;

    private bool isUpgradedPlayerSpeedBought = false;
    private bool isUpgradedShieldDelayBought = false;
    private bool isUpgradedAttackDamageBought = false;
    private bool isUpgradedAttackDelayBought = false;

    private PeripheralTypeHandler peripheralTypeHandler;
    private HealthSystem healthSystem;
    private Memory memory;
    private Movement movement;

    [SerializeField] float upgradedMoveSpeed;

    [SerializeField] float upgradedMouseDefenceTime;
    [SerializeField] float upgradedKeyboardDefenceTime;
    [SerializeField] float upgradedHeadphonesDefenceTime;

    [SerializeField] int extraMouseAttackDamage;
    [SerializeField] int extraKeyboardAttackDamage;
    [SerializeField] int extraHeadphonesAttackDamage;

    [SerializeField] float upgradedMouseAttackDelay;
    [SerializeField] float upgradedKeyboardAttackDelay;
    [SerializeField] float upgradedHeadphonesAttackDelay;


    private void Update()
    {
        DesktopIconDeselectionHandler();
        DoubleClickHandler();
        KeepWindowOnScreen();
    }

    private void Start()
    {
        peripheralTypeHandler = FindObjectOfType<PeripheralTypeHandler>();
        healthSystem = FindObjectOfType<HealthSystem>();
        memory = FindObjectOfType<Memory>();
        movement = FindObjectOfType<Movement>();

        BitflipHandler(0);
        SetupPrices();
        UpdateItemsAvailability();

        storeWindow.SetActive(false);
    }

    private void UpdateItemsAvailability()
    {
        // check if have enough money to buy
        for (int i = 0; i < storePrices.Length; i++)
        {
            if (storePrices[i] <= coins)
            {
                isItemAvailableToBuy[i] = true;
            }
            else
            {
                isItemAvailableToBuy[i] = false;
            }
        }


        if (healthSystem.currentHealth == healthSystem.maxHealth && healthSystem.currentHealth == healthSystem.currentMaxHealth)
        {
            isItemAvailableToBuy[0] = false;
        }


        if (isUpgradedPlayerSpeedBought)
        {
            isItemAvailableToBuy[3] = false;
        }

        if (isUpgradedShieldDelayBought)
        {
            isItemAvailableToBuy[4] = false;
        }

        if (isUpgradedAttackDamageBought)
        {
            isItemAvailableToBuy[5] = false;
        }

        if (isUpgradedAttackDelayBought)
        {
            isItemAvailableToBuy[6] = false;
        }

        // update highlight colors
        for (int i = 0; i < highlightSquares.Length; i++)
        {
            if (isItemAvailableToBuy[i])
            {
                highlightSquares[i].color = Color.white;
            }
            else
            {
                highlightSquares[i].color = Color.red;
            }
        }
    }


    private void SetupPrices()
    {
        for (int i = 0; i < storePricesText.Length; i++)
        {
            storePricesText[i].text = storePrices[i].ToString();
        }
    }


    public void BitflipHandler(int change)
    {
        coins += change;

        coinsText.text = $"DRIVER_AVAILABLE_BITFLIPS: {coins}bfs";
        storeCoinsText.text = coins.ToString();
    }


    public void BuyHealthRestoration()
    {
        if (!isItemAvailableToBuy[0]) return;

        healthSystem.currentHealth = healthSystem.maxHealth = healthSystem.currentMaxHealth;

        BitflipHandler(-storePrices[0]);
        UpdateItemsAvailability();

    }

    public void BuyLevel()
    {
        if (!isItemAvailableToBuy[1]) return;

        memory.LevelHandler(1);

        BitflipHandler(-storePrices[1]);
        UpdateItemsAvailability();
    }

    public void BuyMaxHealth()
    {
        if (!isItemAvailableToBuy[2]) return;

        healthSystem.currentMaxHealth++;
        healthSystem.maxHealth++;
        healthSystem.currentHealth++;

        BitflipHandler(-storePrices[2]);
        UpdateItemsAvailability();
    }

    
    public void BuyPlayerSpeed()
    {
        if (!isItemAvailableToBuy[3]) return;

        movement.moveSpeed += upgradedMoveSpeed;
        peripheralTypeHandler.mouseSpeed += upgradedMoveSpeed;
        peripheralTypeHandler.keyboardSpeed += upgradedMoveSpeed;
        peripheralTypeHandler.headphonesSpeed += upgradedMoveSpeed;



        extraSpeedSymbol.SetActive(true);
        isUpgradedPlayerSpeedBought = true;
        BitflipHandler(-storePrices[3]);
        UpdateItemsAvailability();
    }

    public void BuyImprovedDefenseTime()
    {
        if (!isItemAvailableToBuy[4]) return;

        peripheralTypeHandler.teleportationAbility.abilityDelay = upgradedMouseDefenceTime;
        peripheralTypeHandler.altFInfintyAbility.abilityDelay = upgradedKeyboardDefenceTime;
        peripheralTypeHandler.pFeedbackAbility.abilityDelay = upgradedHeadphonesDefenceTime; 

        isUpgradedShieldDelayBought = true;
        BitflipHandler(-storePrices[4]);
        UpdateItemsAvailability();
    }

    public void BuyExtraAttackDamage()
    {
        if (!isItemAvailableToBuy[5]) return;

        peripheralTypeHandler.autoclickerAbility.damage += extraMouseAttackDamage;
        peripheralTypeHandler.spamAbility.damage += extraKeyboardAttackDamage;
        peripheralTypeHandler.waveEmitterAbility.damage += extraHeadphonesAttackDamage;

        isUpgradedAttackDamageBought = true;
        BitflipHandler(-storePrices[5]);
        UpdateItemsAvailability();
    }

    public void BuyImprovedAttackTime()
    {
        if (!isItemAvailableToBuy[6]) return;

        peripheralTypeHandler.autoclickerAbility.abilityDelay = upgradedMouseAttackDelay;
        peripheralTypeHandler.spamAbility.abilityDelay = upgradedKeyboardAttackDelay;
        peripheralTypeHandler.waveEmitterAbility.abilityDelay = upgradedHeadphonesAttackDelay;

        isUpgradedAttackDelayBought = true;
        BitflipHandler(-storePrices[6]);
        UpdateItemsAvailability();
    }




    private void KeepWindowOnScreen()
    {
        RectTransform rect = storeWindow.GetComponent<RectTransform>();

        rect.localPosition = new Vector3( 
            Mathf.Clamp(rect.localPosition.x ,-6.8f, 4.82f), 
            Mathf.Clamp(rect.localPosition.y, -2.41f, 3.06f), 
            rect.localPosition.z);
    }


    public void CloseStore()
    {
        if (Pause.isPaused) return;

        storeWindow.SetActive(false);
        desktopIcon.SetActive(true);
        isInStore = false;
    }
    private void ShowStore()
    {
        if (Pause.isPaused) return;

        storeWindow.SetActive(true);
        desktopIcon.SetActive(false);
        iconHighlightBorder.SetActive(false);
        isInStore = true;
        StartCoroutine(FindObjectOfType<Cursor>().DelayedReturnToDefaultCursor());
        UpdateItemsAvailability();
        BitflipHandler(0);
    }

    private void DoubleClickHandler()
    {
        if (hasBeenClickedOnce && !Pause.isPaused)
        {
            currentTime += Time.deltaTime;

            if (currentTime > doubleClickTimeValidation)
            {
                hasBeenClickedOnce = false;
                currentTime = 0f;
                doubleClickCount = 0;
            }
        }

        if (doubleClickCount >= 2 && !Pause.isPaused)
        {
            ShowStore();
            hasBeenClickedOnce = false;
            currentTime = 0f;
            doubleClickCount = 0;
        }
    }



    public void OnPointerEnter(PointerEventData eventData)
    {
        if (Pause.isPaused) return;

        iconHighlight.SetActive(true);

        peripheralTypeHandler.AllAbilitiesActivityHandler(false);

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(!hasBeenSelected && !isInStore && !Pause.isPaused)
        {
            iconHighlight.SetActive(false);
            peripheralTypeHandler.AllAbilitiesActivityHandler(true);
        }
        else if (hasBeenSelected && !Pause.isPaused)
        {
            peripheralTypeHandler.AllAbilitiesActivityHandler(true);
        }
        

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (Pause.isPaused) return;

        doubleClickCount++;
        hasBeenClickedOnce |= true;
        Invoke(nameof(DesktopIconSelectionHandler), 0.01f);
    }

    private void DesktopIconSelectionHandler()
    {
        iconHighlightBorder.SetActive(true);
        hasBeenSelected = true;
    }

    private void DesktopIconDeselectionHandler()
    {
        if (Input.GetMouseButtonDown(0) && hasBeenSelected && !Pause.isPaused)
        {
            hasBeenSelected = false ;
            iconHighlight.SetActive(false);
        }
    }
}
