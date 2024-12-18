using Unity.VisualScripting;
using UnityEngine;

public class MenuButtons : MonoBehaviour
{

    [Header("Menu")]
    [SerializeField] GameObject mainMenuPanel;
    [SerializeField] GameObject settingsPanel;
    [SerializeField] GameObject creditsPanel;
    [SerializeField] GameObject logoPanel;
    [SerializeField] GameObject menuTagsTextDecoration;
    [SerializeField] GameObject prepareInstallPanel;

    //MAIN MENU
    public void ExitGame()
    {
        SFXHandler.Instance.Play(1);
        SceneManagement.LoadScene("EXIT GAME!", 1f);
    }


    

    public void SkipDialogueButtonHandler()
    {
        SFXHandler.Instance.Play(1);

        SettingsManager.isSkipDialogueActive = !SettingsManager.isSkipDialogueActive;
    }


    public void OpenSettings()
    {

        StartCoroutine(FindObjectOfType<Cursor>().DelayedReturnToDefaultCursor());
        SFXHandler.Instance.Play(1);
        mainMenuPanel.SetActive(false);

        if(Screen.fullScreen == true) SettingsManager.isFullscreenOn = 1;
        else SettingsManager.isFullscreenOn = 0;

        settingsPanel.SetActive(true);
    }
    public void CloseSettings()
    {
        SFXHandler.Instance.Play(1);
        mainMenuPanel.SetActive(true);
        settingsPanel.SetActive(false);
    }

    public void OpenCredits()
    {
        StartCoroutine(FindObjectOfType<Cursor>().DelayedReturnToDefaultCursor());
        SFXHandler.Instance.Play(1);
        mainMenuPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }

    public void CloseCredits()
    {
        SFXHandler.Instance.Play(1);
        mainMenuPanel.SetActive(true);
        creditsPanel.SetActive(false);
    }

    public void PrepareGame()
    {
        StartCoroutine(FindObjectOfType<Cursor>().DelayedReturnToDefaultCursor());

        SFXHandler.Instance.Play(1);
        SFXHandler.Instance.Play(22);
        logoPanel.SetActive(false);
        menuTagsTextDecoration.SetActive(false);
        mainMenuPanel.SetActive(false);
        prepareInstallPanel.SetActive(true);
        StartCameraAnimation();

    }

    public void ClosePrepareGame()
    {
        SFXHandler.Instance.Play(1);
        SFXHandler.Instance.Play(22);
        logoPanel.SetActive(true);
        menuTagsTextDecoration.SetActive(true);
        mainMenuPanel.SetActive(true);
        prepareInstallPanel.SetActive(false);
        StartCameraAnimation();

    }

    [Header("Camera Animation")]
    [SerializeField] GameObject mainCamera;
    private bool hasCameraAnimationStarted = false;
    private float timer = 0f;
    [SerializeField] float speed = 0.5f;

    private Vector3 positionA;
    private Quaternion rotationA;
    [SerializeField] Vector3 positionB;
    [SerializeField] Quaternion rotationB;

    private Vector3 currentPosition, targetPosition;
    private Quaternion currentRotation, targetRotation;

    private bool isInMainMenu = true;

    private void StartCameraAnimation()
    {
        timer = 0f;
        hasCameraAnimationStarted = true;

        if (isInMainMenu)
        {
            currentPosition = positionA;
            currentRotation = rotationA;
            targetPosition = positionB;
            targetRotation = rotationB;
        }
        else
        {
            currentPosition = positionB;
            currentRotation = rotationB;
            targetPosition = positionA;
            targetRotation = rotationA;
        }

        isInMainMenu = !isInMainMenu;
    }

    public void Install()
    {
        SFXHandler.Instance.Play(0);
        SceneManagement.LoadScene("Game", 6.2f);
    }

    private void Start()
    {
        positionA = mainCamera.transform.position;
        rotationA = mainCamera.transform.rotation;

        Invoke(nameof(OnLoadDeactivateInstallPanel), 0.001f);
    }

    private void OnLoadDeactivateInstallPanel()
    {
        prepareInstallPanel.SetActive(false);
    }


    private void Update()
    {
        CameraAnimationHandler();
        Debug.Log(SettingsManager.isSkipDialogueActive);
    }

    private void CameraAnimationHandler()
    {
        if (hasCameraAnimationStarted)
        {
            timer += Time.deltaTime * speed;

            float clampedTimer = Mathf.Clamp01(timer);

            mainCamera.transform.position = Vector3.Lerp(currentPosition, targetPosition, clampedTimer);
            mainCamera.transform.rotation = Quaternion.Lerp(currentRotation, targetRotation, clampedTimer);

            if (timer >= 1)
            {
                hasCameraAnimationStarted = false;
            }
        }
    }
}
