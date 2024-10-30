using UnityEngine;
using UnityEngine.EventSystems;

public class Store : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    private PeripheralTypeHandler peripheralTypeHandler;
    [SerializeField] private GameObject iconHighlight;
    [SerializeField] private GameObject iconHighlightBorder;

    private bool hasBeenSelected = false;

    private int doubleClickCount = 0;
    [SerializeField] float doubleClickTimeValidation = 0.5f;
    private float currentTime = 0f;
    private bool hasBeenClickedOnce = false;

    [SerializeField] private GameObject storeWindow;
    [SerializeField] private GameObject desktopIcon;

    public static bool isInStore = false;

    private HealthSystem healthSystem;


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


        storeWindow.SetActive(false);
    }

    public void BuyHealthRestoration()
    {
        healthSystem.currentHealth = healthSystem.maxHealth = healthSystem.currentMaxHealth;
    }

    public void BuyLevel()
    {

    }

    public void BuyMaxHealth()
    {

    }

    public void BuyPlayerSpeed()
    {

    }

    public void BuyImprovedDefenseTime()
    {

    }

    private void BuyExtraAttackDamage()
    {

    }

    public void BuyImprovedAttackTime()
    {

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
