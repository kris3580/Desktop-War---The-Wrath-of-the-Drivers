using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuPeripheralsSelection : MonoBehaviour
{
    
    public static bool hasPeripheralBeenSelected = false;

    private GameObject selectedPeripheralDescriptionPanel;
    private Animator animator;
    private Outline outline;
    [SerializeField] List<Outline> peripheralsOutline;

    private static Button installButton;

    private static TextMeshProUGUI peripheralNameText;
    private static TextMeshProUGUI peripheralDescriptionText;
    private static TextMeshProUGUI abilityName1Text;
    private static TextMeshProUGUI abilityName2Text;
    private static TextMeshProUGUI abilityDescription1Text;
    private static TextMeshProUGUI abilityDescription2Text;
    private static Image abilityImage1;
    private static Image abilityImage2;

    [SerializeField] Sprite headphonesAttackImage;
    [SerializeField] Sprite headphonesDefenceImage;
    [SerializeField] Sprite keyboardAttackImage;
    [SerializeField] Sprite keyboardDefenceImage;
    [SerializeField] Sprite mouseAttackImage;
    [SerializeField] Sprite mouseDefenceImage;

    private string headphonesDescription = "a masterpiece of human engineering";
    private string headphonesAbility1Name = "p_feedback";
    private string headphonesAbility2Name = "wave emitter";
    private string headphonesAbilityDescription1 = "makes a sound so loud it acts as a shield";
    private string headphonesAbilityDescription2 = "used to send malicious information and other stuff";


    private string keyboardDescription = "the right keyboard in the wrong hands could make all the difference in the world";
    private string keyboardAbility1Name = "spam";
    private string keyboardAbility2Name = "alt+f∞";
    private string keyboardAbilityDescription1 = "overwhelms your enemies with walls of text";
    private string keyboardAbilityDescription2 = "powerful shortcut for escaping tough situations";


    private string mouseDescription = "did you know scientists found a way to mind-control mice wirelessly? scary";
    private string mouseAbility1Name = "autoclicker";
    private string mouseAbility2Name = "laser";
    private string mouseAbilityDescription1 = "easily beats minecraft pvp sweats";
    private string mouseAbilityDescription2 = "basically teleportation";


    private void Start()
    {
        DisableAllPeripheralsOutlines();

        animator = GetComponent<Animator>();
        outline = GetComponent<Outline>();
        installButton = GameObject.Find("InstallButton").GetComponent<Button>();
        selectedPeripheralDescriptionPanel = GameObject.Find("SelectedPeripheralDescription");
        
        peripheralNameText = GameObject.Find("PeripheralName").GetComponent<TextMeshProUGUI>();
        peripheralDescriptionText = GameObject.Find("PeripheralDescription").GetComponent<TextMeshProUGUI>();
        abilityName1Text = GameObject.Find("AbilityName1").GetComponent<TextMeshProUGUI>();
        abilityName2Text = GameObject.Find("AbilityName2").GetComponent<TextMeshProUGUI>();
        abilityImage1 = GameObject.Find("AbilityImage1").GetComponent<Image>();
        abilityImage2 = GameObject.Find("AbilityImage2").GetComponent<Image>();
        abilityDescription1Text = GameObject.Find("AbilityDescription1").GetComponent<TextMeshProUGUI>();
        abilityDescription2Text = GameObject.Find("AbilityDescription2").GetComponent<TextMeshProUGUI>();

    }

    void OnMouseOver()
    {
        HoverPeripheralHandler();
    }

    void OnMouseExit()
    {
        ExitHoverPeripheralHandler();
    }

    private void OnMouseUp()
    {
        ClickedPeripheralHandler();
    }



    private void HoverPeripheralHandler()
    {
        animator.SetBool("isHovered", true);
        selectedPeripheralDescriptionPanel.SetActive(true);
        SetPeripheralDescriptions(gameObject.name);

    }

    

    private void ExitHoverPeripheralHandler()
    {
        animator.SetBool("isHovered", false);
        SetPeripheralDescriptions(PeripheralTypeHandler.selectedPeripheral.ToString(), true);
    }

    private void ClickedPeripheralHandler()
    {
        hasPeripheralBeenSelected = true;
        installButton.interactable = true;
        DisableAllPeripheralsOutlines();
        outline.enabled = true;

        switch (gameObject.name)
        {
            case "Headphones": PeripheralTypeHandler.selectedPeripheral = PeripheralType.Headphones; break;
            case "Keyboard": PeripheralTypeHandler.selectedPeripheral = PeripheralType.Keyboard; break;
            case "Mouse": PeripheralTypeHandler.selectedPeripheral = PeripheralType.Mouse; break;
        }
    }

    private void DisableAllPeripheralsOutlines()
    {
        foreach (Outline outline in peripheralsOutline)
        {
            outline.enabled = false;
        }
    }

    public void OnOpeningSelectPeripheralMenuHandler()
    {
        selectedPeripheralDescriptionPanel.SetActive(false);
    }


    public void OnReturnToMenuHandler()
    {
        DisableAllPeripheralsOutlines();
        installButton.interactable = false;
        PeripheralTypeHandler.selectedPeripheral = null;
        selectedPeripheralDescriptionPanel.SetActive(false);
    }

    private void SetPeripheralDescriptions(string whichDescription, bool isOnExit = false)
    {
        if (PeripheralTypeHandler.selectedPeripheral == null && isOnExit)
        {
            selectedPeripheralDescriptionPanel.SetActive(false);
            return;
        }


        switch (whichDescription)
        {
            case "Headphones":

                peripheralNameText.text = "headphones";
                peripheralDescriptionText.text = headphonesDescription;
                abilityName1Text.text = headphonesAbility1Name;
                abilityName2Text.text = headphonesAbility2Name;
                abilityDescription1Text.text = headphonesAbilityDescription1;
                abilityDescription2Text.text = headphonesAbilityDescription2;
                abilityImage1.sprite = headphonesAttackImage;
                abilityImage2.sprite = headphonesDefenceImage;
                break;

            case "Keyboard":

                peripheralNameText.text = "keyboard";
                peripheralDescriptionText.text = keyboardDescription;
                abilityName1Text.text = keyboardAbility1Name;
                abilityName2Text.text = keyboardAbility2Name;
                abilityDescription1Text.text = keyboardAbilityDescription1;
                abilityDescription2Text.text = keyboardAbilityDescription2;
                abilityImage1.sprite = keyboardAttackImage;
                abilityImage2.sprite = keyboardDefenceImage;
                break;

            case "Mouse":

                peripheralNameText.text = "mouse";
                peripheralDescriptionText.text = mouseDescription;
                abilityName1Text.text = mouseAbility1Name;
                abilityName2Text.text = mouseAbility2Name;
                abilityDescription1Text.text = mouseAbilityDescription1;
                abilityDescription2Text.text = mouseAbilityDescription2;
                abilityImage1.sprite = mouseAttackImage;
                abilityImage2.sprite = mouseDefenceImage;
                break;
        }
    }
}
