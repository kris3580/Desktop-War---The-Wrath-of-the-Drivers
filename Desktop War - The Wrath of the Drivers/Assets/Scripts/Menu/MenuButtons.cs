using Unity.VisualScripting;
using UnityEngine;

public class MenuButtons : MonoBehaviour
{

    [Header("Menu")]
    [SerializeField] GameObject mainMenuPanel;
    [SerializeField] GameObject settingsPanel;
    [SerializeField] GameObject creditsPanel;

    //MAIN MENU
    public void ExitGame()
    {
        SceneMangement.LoadScene("EXIT GAME!", 1f);
    }

    public void OpenSettings()
    {
        mainMenuPanel.SetActive(false);

        if(Screen.fullScreen == true) SettingsManager.isFullscreenOn = 1;
        else SettingsManager.isFullscreenOn = 0;

        settingsPanel.SetActive(true);
    }
    public void CloseSettings()
    {
        mainMenuPanel.SetActive(true);
        settingsPanel.SetActive(false);
    }

    public void OpenCredits()
    {
        mainMenuPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }

    public void CloseCredits()
    {
        mainMenuPanel.SetActive(true);
        creditsPanel.SetActive(false);
    }

    public void PrepareGame()
    {
        StartCameraAnimation();
    }

    public void ClosePrepareGame()
    {
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

    private void Start()
    {
        positionA = mainCamera.transform.position;
        rotationA = mainCamera.transform.rotation;
    }

    private void Update()
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
