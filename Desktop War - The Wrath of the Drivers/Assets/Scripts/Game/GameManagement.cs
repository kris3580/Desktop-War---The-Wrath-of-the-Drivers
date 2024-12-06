using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagement : MonoBehaviour
{
    [SerializeField] GameObject keysKeyboardImage;
    [SerializeField] GameObject rightClickMouseImage;
    [SerializeField] GameObject leftClickMouseImage;

    DialogueSystem dialogueSystem;
    NavigationHandler navigationHandler;
    SFXHandler sfxHandler;
    ClippyFollow clippyFollow;

    public bool hasGameStartAnimationFinished = false;
    public bool hasGameStarted = false;

    public bool hasDefendingTutorialBeenTriggered = false;
    public bool hasDefendingTutorialStarted = false;

    public bool hasShootingTutorialBeenTriggered = false;
    public bool hasShootingTutorialStarted = false;

    public bool hasPassedTutorialBeenTriggered = false;
    public bool hasPassedTutorialStarted = false;

    public bool isClippyWithYou = false;
    public bool hasMetClippyForTheFirstTime = false;

    public bool hasLeftTheRoomWithClippyTriggered = false;
    public bool hasLeftTheRoomWithClippyStarted = false;

    public bool hasArrivedAtStorageTriggered = false;
    public bool hasArrivedAtStorageStarted = false;

    public bool hasLeftStorageTriggered = false;
    public bool hasLeftStorageStarted = false;

    public bool hasEnteredVideoCardRoomTriggered = false;
    public bool hasEnteredVideoCardRoomStarted = false;

    public bool hasBeatenVideoCard = false;
    public bool hasComputerRestarted = false;

    public bool isClippyWithYouAgain = false;
    public bool hasMetClippyForTheSecondTime = false;

    public bool hasEnteredNetworkCardRoomTriggered = false;
    public bool hasEnteredNetworkCardRoomStarted = false;

    public bool hasBeatenNetworkCard = false;
    public bool haveDoorsBeenUnlocked = false;

    public bool hasArrivedAtStorageAgainTriggered = false;
    public bool hasArrivedAtStorageAgainStarted = false;

    public bool hasEnteredProcessorRoomTriggered = false;
    public bool hasEnteredProcessorRoomStarted = false;

    public bool hasGameEndedTriggered = false;
    public bool hasGameEndedStarted = false;

    public bool isZone2Finished = false;
    public bool isZone3Finished = false;
    public bool isZone4Finished = false;
    public bool isZone6Finished = false;
    public bool isZone7Finished = false;
    public bool isZone8Finished = false;
    public bool isZone9Finished = false;
    public bool isZone10Finished = false;
    public bool isZone11Finished = false;
    public bool isZone12Finished = false;
    public bool isZone13Finished = false;
    public bool isZone14Finished = false;
    public bool isZone15Finished = false;

    [SerializeField] private RawImage biosDoorImage;
    [SerializeField] private RawImage networkCardDirectDoor;
    [SerializeField] private RawImage motherboard2DoorOne;
    [SerializeField] private RawImage motherboard2DoorTwo;
    [SerializeField] private GameObject blackPanel;
    [SerializeField] private GameObject zone1RightNav;
    [SerializeField] private GameObject clippyFirstInteractionTrigger;
    [SerializeField] private GameObject clippySecondInteractionTrigger;
    [SerializeField] private GameObject zone4EnemyGroup;
    [SerializeField] private GameObject zone6EnemyGroup;

    [SerializeField] private GameObject startZone;
    [SerializeField] private List<GameObject> zones;

    [SerializeField] private List<GameObject> zone2EnemyList;
    [SerializeField] public List<GameObject> zone3EnemyList;
    [SerializeField] private List<GameObject> zone4EnemyList;
    [SerializeField] private List<GameObject> zone6EnemyList;
    [SerializeField] private List<GameObject> zone7EnemyList;
    [SerializeField] private List<GameObject> zone8EnemyList;
    [SerializeField] private List<GameObject> zone9EnemyList;
    [SerializeField] private List<GameObject> zone10EnemyList;
    [SerializeField] private List<GameObject> zone11EnemyList;
    [SerializeField] private List<GameObject> zone12EnemyList;
    [SerializeField] private List<GameObject> zone13EnemyList;
    [SerializeField] private List<GameObject> zone14EnemyList;
    [SerializeField] private List<GameObject> zone15EnemyList;


    private void Start()
    {
        dialogueSystem = FindObjectOfType<DialogueSystem>();
        navigationHandler = FindObjectOfType<NavigationHandler>();
        sfxHandler = FindObjectOfType<SFXHandler>();
        clippyFollow = FindObjectOfType<ClippyFollow>();
        Store.coins = 0;


        hasGameStartAnimationFinished = true;
    }

    private void Update()
    {
        BoolTriggeringHandler();
        EnemyListsHandler();
        TriggerDialogue();
    }

    // TRIGGER DIALOGUE WHEN ENTERING ROOM
    private void TriggerDialogue()
    {
        if (navigationHandler.xNav == 2 && navigationHandler.yNav == 4)
        {
            hasDefendingTutorialBeenTriggered = true;
        }

        if (navigationHandler.xNav == 3 && navigationHandler.yNav == 4) 
        { 
            hasShootingTutorialBeenTriggered = true;
        }

        if (navigationHandler.xNav == 3 && navigationHandler.yNav == 2)
        {
            hasLeftTheRoomWithClippyTriggered = true;
        }

        if (navigationHandler.xNav == 3 && navigationHandler.yNav == 1)
        {
            hasArrivedAtStorageTriggered = true;
        }

        if (navigationHandler.xNav == 4 && navigationHandler.yNav == 1)
        {
            hasLeftStorageTriggered = true;
        }

        if (navigationHandler.xNav == 5 && navigationHandler.yNav == 3)
        {
            hasEnteredVideoCardRoomTriggered = true;
        }

        if (navigationHandler.xNav == 4 && navigationHandler.yNav == 3)
        {
            hasEnteredNetworkCardRoomTriggered = true;
        }

        if (navigationHandler.xNav == 3 && navigationHandler.yNav == 1 && hasBeatenNetworkCard)
        {
            hasArrivedAtStorageAgainTriggered = true;
        }

        if (navigationHandler.xNav == 0 && navigationHandler.yNav == 2)
        {
            hasEnteredProcessorRoomTriggered = true;
        }


    }

    // ENEMY CHECKING
    private void EnemyListsHandler()
    {

        // ZONE 2
        if (AreAllElementsNull(zone2EnemyList) && !isZone2Finished)
        {
            zones[0].transform.Find("NavDirectionMarkings").transform.gameObject.SetActive(true);
            isZone2Finished = true;
            navigationHandler.DelayedResetEnterExitBools();
            hasPassedTutorialBeenTriggered = true;
            leftClickMouseImage.SetActive(false);
        }

        // ZONE 4
        if (AreAllElementsNull(zone4EnemyList) && !isZone4Finished)
        {
            zones[2].transform.Find("NavDirectionMarkings").transform.gameObject.SetActive(true);
            isZone4Finished = true;
            navigationHandler.DelayedResetEnterExitBools();
        }

        // ZONE 6
        if (AreAllElementsNull(zone6EnemyList) && !isZone6Finished)
        {
            zones[3].transform.Find("NavDirectionMarkings").transform.gameObject.SetActive(true);
            isZone6Finished = true;
            navigationHandler.DelayedResetEnterExitBools();
        }

        // ZONE 7
        if (AreAllElementsNull(zone7EnemyList) && !isZone7Finished)
        {
            zones[4].transform.Find("NavDirectionMarkings").transform.gameObject.SetActive(true);
            isZone7Finished = true;
            navigationHandler.DelayedResetEnterExitBools();
        }

        // ZONE 8
        if (AreAllElementsNull(zone8EnemyList) && !isZone8Finished)
        {
            zones[5].transform.Find("NavDirectionMarkings").transform.gameObject.SetActive(true);
            isZone8Finished = true;
            navigationHandler.DelayedResetEnterExitBools();
        }

        // ZONE 9
        if (AreAllElementsNull(zone9EnemyList) && !isZone9Finished)
        {
            zones[6].transform.Find("NavDirectionMarkings").transform.gameObject.SetActive(true);
            isZone9Finished = true;
            navigationHandler.DelayedResetEnterExitBools();
            hasBeatenVideoCard = true;
        }

        // ZONE 10
        if (AreAllElementsNull(zone10EnemyList) && !isZone10Finished)
        {
            zones[7].transform.Find("NavDirectionMarkings").transform.gameObject.SetActive(true);
            isZone10Finished = true;
            navigationHandler.DelayedResetEnterExitBools();
            hasBeatenNetworkCard = true;
        }

        // ZONE 11
        if (AreAllElementsNull(zone11EnemyList) && !isZone11Finished)
        {
            zones[8].transform.Find("NavDirectionMarkings").transform.gameObject.SetActive(true);
            isZone11Finished = true;
            navigationHandler.DelayedResetEnterExitBools();
        }

        // ZONE 12
        if (AreAllElementsNull(zone12EnemyList) && !isZone12Finished)
        {
            zones[9].transform.Find("NavDirectionMarkings").transform.gameObject.SetActive(true);
            isZone12Finished = true;
            navigationHandler.DelayedResetEnterExitBools();
        }

        // ZONE 13
        if (AreAllElementsNull(zone13EnemyList) && !isZone13Finished)
        {
            zones[10].transform.Find("NavDirectionMarkings").transform.gameObject.SetActive(true);
            isZone13Finished = true;
            navigationHandler.DelayedResetEnterExitBools();
        }

        // ZONE 14
        if (AreAllElementsNull(zone14EnemyList) && !isZone14Finished)
        {
            zones[11].transform.Find("NavDirectionMarkings").transform.gameObject.SetActive(true);
            isZone14Finished = true;
            navigationHandler.DelayedResetEnterExitBools();
        }

        // ZONE 15
        if (AreAllElementsNull(zone15EnemyList) && !isZone15Finished)
        {
            isZone15Finished = true;
            navigationHandler.DelayedResetEnterExitBools();
            hasGameEndedTriggered = true;
        }


    }

    public bool AreAllElementsNull(List<GameObject> list)
    {
        if (list == null || list.Count == 0) return false;

        foreach (var element in list)
        {
            if (element != null)
            {
                return false;
            }
        }
        return true;
    }

    private void BoolTriggeringHandler()
    {
        // TEST DIALOGUES
        if (Input.GetKeyUp(KeyCode.O))
        {
            StartCoroutine(FullSequence());
        }

        // START GAME
        if (hasGameStartAnimationFinished && !hasGameStarted)
        {
            hasGameStarted = true;
            StartCoroutine(S_WhenFirstSpawned());
        }

        // SHOOT TUTORIAL
        if (hasShootingTutorialBeenTriggered && !hasShootingTutorialStarted)
        {
            hasShootingTutorialStarted = true;
            StartCoroutine(S_WhenSeeingEnemiesForFirstTime());
        }

        // DEFEND TUTORIAL
        if (hasDefendingTutorialBeenTriggered && !hasDefendingTutorialStarted)
        {
            hasDefendingTutorialStarted = true;
            StartCoroutine(S_WhenSeeingImpassableTerrainForFirstTime());
        }


        // AFTER PASSING IMPASSABLE TERRAIN
        if (hasPassedTutorialBeenTriggered && !hasPassedTutorialStarted)
        {
            hasPassedTutorialStarted = true;
            StartCoroutine(S_AfterPassingImpassableTerrain());
        }


        // MEETING CLIPPY FIRST TIME
        if (isClippyWithYou && !hasMetClippyForTheFirstTime)
        {
            hasMetClippyForTheFirstTime = true;
            StartCoroutine(S_FirstTimeInteractionWithNull());
            biosDoorImage.texture = navigationHandler.permittedHighlight;
        }

        // FINISHING A ROOM WITH CLIPPY
        if (hasLeftTheRoomWithClippyTriggered && !hasLeftTheRoomWithClippyStarted)
        {
            hasLeftTheRoomWithClippyStarted = true;
            StartCoroutine(S_AfterFinishingARoomWithClippy());
        }


        // ARRIVING AT STORAGE FIRST TIME
        if (hasArrivedAtStorageTriggered && !hasArrivedAtStorageStarted)
        {
            hasArrivedAtStorageStarted = true;
            StartCoroutine(S_ArrivingAtStorage());
        }

        // AFTER LEAVING STORAGE
        if (hasLeftStorageTriggered && !hasLeftStorageStarted)
        {
            hasLeftStorageStarted = true;
            StartCoroutine(S_AfterLeavingStorage());
        }

        // ENTERING VIDEO CARD ROOM
        if (hasEnteredVideoCardRoomTriggered && !hasEnteredVideoCardRoomStarted)
        {
            hasEnteredVideoCardRoomStarted = true;
            StartCoroutine(S_EnteringVideoCardRoom());
        }

        //BEATING VIDEO CARD
        if (hasBeatenVideoCard && !hasComputerRestarted)
        {
            hasComputerRestarted = true;
            isClippyWithYou = false;
            StartCoroutine(S_AfterBeatingVideoCard());
        }

        //MEETING CLIPPY SECOND TIME
        if (!isClippyWithYou && isClippyWithYouAgain && hasMetClippyForTheFirstTime && !hasMetClippyForTheSecondTime)
        {
            hasMetClippyForTheSecondTime = true;
            isClippyWithYou = true;
            StartCoroutine(S_FindingClippy());
        }

        // ENTERING NETWORK CARD ROOM
        if (hasEnteredNetworkCardRoomTriggered && !hasEnteredNetworkCardRoomStarted)
        {
            hasEnteredNetworkCardRoomStarted = true;
            StartCoroutine(S_ConfrontingNetworkCard());
        }

        //BEATING NETWORK CARD
        if (hasBeatenNetworkCard && !haveDoorsBeenUnlocked)
        {
            haveDoorsBeenUnlocked = true;
            networkCardDirectDoor.texture = navigationHandler.permittedHighlight;
            motherboard2DoorOne.texture = navigationHandler.permittedHighlight;
            motherboard2DoorTwo.texture = navigationHandler.permittedHighlight;
            StartCoroutine(S_AfterBeatingNetworkCard());
        }

        // WHEN ENTERING STORAGE AGAIN
        if (hasArrivedAtStorageAgainTriggered && !hasArrivedAtStorageAgainStarted)
        {
            hasArrivedAtStorageAgainStarted = true;
            StartCoroutine(S_WhenEnteringStorageAgain());
        }

        // ENTERING PROCESSOR ROOM
        if (hasEnteredProcessorRoomTriggered && !hasEnteredProcessorRoomStarted)
        {
            hasEnteredProcessorRoomStarted = true;
            StartCoroutine(S_ConfrontingProcessor());
        }

        // END
        if (hasGameEndedTriggered && !hasGameEndedStarted)
        {
            hasGameEndedStarted = true;
            StartCoroutine(S_End());
        }
    }





    // DIALOGUES

    private string GetPlayerName()
    {
        return PeripheralTypeHandler.selectedPeripheral.ToString();
    }

    private IEnumerator FullSequence()
    {
        yield return StartCoroutine(S_WhenFirstSpawned());
        yield return StartCoroutine(S_WhenSeeingEnemiesForFirstTime());
        yield return StartCoroutine(S_WhenSeeingImpassableTerrainForFirstTime());
        yield return StartCoroutine(S_AfterPassingImpassableTerrain());
        yield return StartCoroutine(S_WhenInteractingWithBIOSDoorAlone());
        yield return StartCoroutine(S_WhenInteractingWithLockedDefault());
        yield return StartCoroutine(S_FirstTimeInteractionWithNull());
        yield return StartCoroutine(S_WhenInteractingWithLockedDoorOneClippy());
        yield return StartCoroutine(S_AfterFinishingARoomWithClippy());
        yield return StartCoroutine(S_ArrivingAtStorage());
        yield return StartCoroutine(S_AfterLeavingStorage());
        yield return StartCoroutine(S_EnteringVideoCardRoom());
        yield return StartCoroutine(S_AfterBeatingVideoCard());
        yield return StartCoroutine(S_FindingClippy());
        yield return StartCoroutine(S_ConfrontingNetworkCard());
        yield return StartCoroutine(S_AfterBeatingNetworkCard());
        yield return StartCoroutine(S_WhenInteractingWithDoorTwo());
        yield return StartCoroutine(S_WhenEnteringStorageAgain());
        yield return StartCoroutine(S_WhenInteractingWithDoorThree());
        yield return StartCoroutine(S_ConfrontingProcessor());
        yield return StartCoroutine(S_End());
    }

    private IEnumerator S_WhenFirstSpawned()
    {
        if (!SettingsManager.isSkipDialogueActive) Movement.isFrozen = true;
        blackPanel.SetActive(true);
        yield return new WaitForSeconds(2.333f);
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine(GetPlayerName(), "Where am I?"));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine(GetPlayerName(), "What happened?"));
        yield return new WaitForSeconds(1);
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine(GetPlayerName(), "I guess I'll have to go to the storage room to find out."));
        keysKeyboardImage.SetActive(true);

    }

    private IEnumerator S_WhenSeeingEnemiesForFirstTime()
    {
        rightClickMouseImage.SetActive(false);
        if (!SettingsManager.isSkipDialogueActive) yield return new WaitForSeconds(1);
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine(GetPlayerName(), "This place is a mess... Thankfully, I still remember how to SHOOT."));
        leftClickMouseImage.SetActive(true);
    }

    private IEnumerator S_WhenSeeingImpassableTerrainForFirstTime()
    {
        keysKeyboardImage.SetActive(false);
        if (!SettingsManager.isSkipDialogueActive) yield return new WaitForSeconds(1);
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine(GetPlayerName(), "Woah, those things weren’t here before!"));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine(GetPlayerName(), "Impassable terrain... Not for me though! At the driver school, they taught me how to DEFEND. "));
        rightClickMouseImage.SetActive(true);
    }

    public void ActivateZone1RightNav()
    {
        zone1RightNav.SetActive(true);
    }


    private IEnumerator S_AfterPassingImpassableTerrain()
    {
        
        if (!SettingsManager.isSkipDialogueActive) yield return new WaitForSeconds(1);
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine(GetPlayerName(), "I have to make my way to the storage before something else happens."));
    }

    public IEnumerator S_WhenInteractingWithBIOSDoorAlone()
    {
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine(GetPlayerName(), "Locked. A strange sound could be heard through the door."));
    }

    public IEnumerator S_WhenInteractingWithLockedDefault()
    {
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine(GetPlayerName(), "Locked."));
    }

    private IEnumerator S_FirstTimeInteractionWithNull()
    {
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("", "*you gently click on... whatever this thing is.*"));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("NULL", "What, what the he- Oh hello there! Thanks for waking me up!"));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine(GetPlayerName(), "H- hi? \nWhat’s the matter with you?!"));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("NULL", "Oh I know what’s the matter alright, that dumbass user for sure installed some malware again."));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("NULL", "I swear this happens like every other day."));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine(GetPlayerName(), "How do you remember all this?"));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("NULL", "I don’t remember all this, but the state of this place gives me a déjà vu. The computer must have restarted."));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine(GetPlayerName(), "We really need to get to the storage room to find out what happened."));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("NULL", "No need, I have a direct line to them! Lemme give them a call."));
        if (!SettingsManager.isSkipDialogueActive) StartCoroutine(sfxHandler.CallingSFX(2));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("", "..."));
        if (!SettingsManager.isSkipDialogueActive) yield return new WaitForSeconds(1);
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("", "..."));
        if (!SettingsManager.isSkipDialogueActive) yield return new WaitForSeconds(1);
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("", "..."));
        if (!SettingsManager.isSkipDialogueActive) StartCoroutine(sfxHandler.CallingSFX(0.5f));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("NULL", "No response. So it’s that bad. Guess we’ll have to walk there on foot."));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine(GetPlayerName(), "Sorry for asking, have you always looked like..."));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("NULL", "Like what?"));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine(GetPlayerName(), "You look like nothing to me. Literally."));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("NULL", "Oh, this? I’m starting to get used to it."));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("NULL", "Looks like this malware somehow managed to delete my textures but not my actual functionality."));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("NULL", "Probably we shouldn’t even be worried at this point."));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine(GetPlayerName(), "You sure?"));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("NULL", "Yes, let’s go already!"));
        zones[1].transform.Find("NavDirectionMarkings").transform.gameObject.SetActive(true);
        isZone3Finished = true;
        navigationHandler.DelayedResetEnterExitBools();
        clippyFirstInteractionTrigger.SetActive(false);
        clippyFollow.SetFollowPlayer();
    }
     
    public IEnumerator S_WhenInteractingWithLockedDoorOneClippy()
    {
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine(GetPlayerName(), "It’s locked."));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("NULL", "Yeah, as it should be. The guy in there is weird."));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine(GetPlayerName(), "What do you mean?"));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("NULL", "Don’t they teach you that stuff at driver school or something? It’s the BIOS! "));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine(GetPlayerName(), "I mean they do teach that stuff, it’s one of the first topics..."));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine(GetPlayerName(), "It’s just... I think I’m losing my mind. I think I’m starting to not remember much about anything."));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("NULL", "Well don’t worry, it means the malware is doing its job."));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine(GetPlayerName(), "So, what about BIOS?"));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("NULL", "Ok, so I got to meet this guy once when he was at his lunch break and he was just standing there."));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("NULL", "So I go up to him and he just keeps talking about how he is always awake even when the computer is turned off."));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("NULL", "Like how is that even possible?"));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine(GetPlayerName(), "Why do I have a feeling that he is probably lying?"));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("NULL", "Noo, not “probably”. It’s “definitely”! He is definitely lying, no one can confirm what he was saying."));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("NULL", "So probably he’s trying to look cool to make up for his boring job."));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine(GetPlayerName(), "Maybe."));
    }

    private IEnumerator S_AfterFinishingARoomWithClippy()
    {
        if (!SettingsManager.isSkipDialogueActive) sfxHandler.Play(10);
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("NULL", "Oh someone is calling."));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("NULL", "It’s the guys from the storage room! Let’s see..."));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("NULL", "Yeah...?"));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("NULL", "Wai- calm down..."));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("NULL", "Uh huh"));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("NULL", "Yes."));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("NULL", "What in the recycle bin?!"));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("NULL", "What do you mean your storage buddy exploded?"));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("NULL", "Anyway."));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("NULL", "Is there something we can do?"));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("NULL", "Oh yeah?"));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("NULL", "No, but i have a driver with me."));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("NULL", "Alright, one more thing-"));
        if (!SettingsManager.isSkipDialogueActive) sfxHandler.Play(8);
        yield return new WaitForSeconds(2);
        if (!SettingsManager.isSkipDialogueActive) StartCoroutine(sfxHandler.CallingSFX(0.5f));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine(GetPlayerName(), " What was that on the phone?"));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("NULL", "Looks like the other guy exploded too."));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine(GetPlayerName(), "What?"));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("NULL", "Sorry. I meant de-fragmented! Get it? "));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine(GetPlayerName(), "Huh?"));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("NULL", "Don’t worry, we just have to get rid of this malware and you will be good."));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("NULL", "Even though the storage room is now dead again at least we should check what’s left there."));
        zone4EnemyGroup.SetActive(true);
    }

    private IEnumerator S_ArrivingAtStorage()
    {
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("NULL", "Here we are. This looks pretty dead. "));
        clippyFollow.MoveToStorage();
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("NULL", "Oh, here are my textures."));
        clippyFollow.TurnNullToClippy();
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine(GetPlayerName(), "Damn."));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("Clippy", "This is pretty sad."));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine(GetPlayerName(), "Why?"));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("Clippy", "I guess this malware mostly locks and destroys stuff that’s important, which is fine."));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine(GetPlayerName(), "Meaning..."));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("", "..."));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("", "..."));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("Clippy", "Have you read the stuff they say about me on the internet? Useless this, annoying that. Like why do I even exist at this point?"));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine(GetPlayerName(), "To help the user?"));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("Clippy", "Yeah, but what if the user is braindead? This guy doesn’t listen to me at all."));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("Clippy", "I told him “Don’t turn off the antivirus ‘cause the software you downloaded from the piracy site told you to.”"));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("Clippy", "I mean I get that, false positives and all. Why not just pay for the software?"));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine(GetPlayerName(), "Hey, a multi-billion dollar corporation made you, you wouldn’t get it."));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("Clippy", "I mean, yeah, but still. This guy makes our job a lot more harder than it needs to be."));
        clippyFollow.MoveNextToStore();
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine(GetPlayerName(), "What’s this thing though?"));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("Clippy", "A store... at the storage. That’s not even funny. Who came up with that?"));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine(GetPlayerName(), "Should we...?"));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("Clippy", "Yeah of course! Double click on it and check what’s up!"));
        clippyFollow.SetFollowPlayer();
    }

    private IEnumerator S_AfterLeavingStorage()
    {
        if (!SettingsManager.isSkipDialogueActive) yield return new WaitForSeconds(0.5f);
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine(GetPlayerName(), "Soo, where are we going now?"));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("Clippy", "Oh yeah, dead guy told me we need to download an antivirus, launch it, and see what’s what."));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("Clippy", "We need to fight our way to the PCI room and pray the guys there are left uninfected by the virus."));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine(GetPlayerName(), "So the plan is to find the network card?"));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("Clippy", "Yes, and then we will have to access the god-forsaken world beyond our realm -  the Internet."));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine(GetPlayerName(), "Is it that bad?"));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("Clippy", "Yes, but also no. It depends on what you look at I guess. Let’s go."));
        zone6EnemyGroup.SetActive(true);
    }

    private IEnumerator S_EnteringVideoCardRoom()
    {
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine(GetPlayerName(), "What’s going on?"));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("Clippy", "Looks like the guys are infected. The goddamn video card is here too! You need to fight it!"));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine(GetPlayerName(), "What, me?"));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("Clippy", "Well no, it’s gonna be me, who can’t even defend himself. Now fight it, or die trying!"));
        zone9EnemyList[0].SetActive(true);

    }

    private IEnumerator S_AfterBeatingVideoCard()
    {
        zones[6].SetActive(false);
        startZone.transform.Find("NavDirectionMarkings").transform.gameObject.SetActive(false);
        startZone.SetActive(true);
        navigationHandler.xNav = 1; navigationHandler.yNav = 4;
        zones[1].transform.Find("NavDirectionMarkings").transform.gameObject.SetActive(false);
        clippySecondInteractionTrigger.SetActive(true);
        if (!SettingsManager.isSkipDialogueActive) yield return new WaitForSeconds(2);
        clippyFollow.GoToSpawnpoint();
        blackPanel.SetActive(false); blackPanel.SetActive(true);
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine(GetPlayerName(), "Huh? I’m here again? "));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine(GetPlayerName(), "Wait... I can remember, I must have beat him..."));
        if (!SettingsManager.isSkipDialogueActive) yield return new WaitForSeconds(0.5f);
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine(GetPlayerName(), "I should search for Clippy."));
        startZone.transform.Find("NavDirectionMarkings").transform.gameObject.SetActive(true);
    }

    private IEnumerator S_FindingClippy()
    {
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("", "*you gently click on... whatever this thing is.*"));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("Clippy", "What, what the he- Oh hello there- Wait. I mean, you did it! "));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine(GetPlayerName(), "Yeah, but we still need to get to the network card."));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("Clippy", "I don’t know if we have much time, this place is in a bigger mess than it was before the restart."));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("Clippy", "Besides, antiviruses aren’t even that good. "));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("Clippy", "They don’t guarantee security. Reinstalling the OS does though. "));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine(GetPlayerName(), "But... that means..."));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("Clippy", "Reinstalling the OS is out of the question though."));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("Clippy", "But yeah. In that case we will be gone, but it’s fine because we exist for the user, and die for the user."));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("Clippy", "And then be reborn again, only to probably go through the same thing all over."));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine(GetPlayerName(), "Sounds kind of depressing. Maybe It’s a good thing that I can't remember everything."));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("Clippy", "Yeah, that’s how most guys on this system get around."));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("Clippy", "If you’re useful, you’re mostly okay."));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("Clippy", "If you’re useless, you’re alone with your thoughts and the thoughts from the previous iterations."));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("", "..."));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine(GetPlayerName(), "I think we should keep going."));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("Clippy", "Let’s go."));
        clippySecondInteractionTrigger.SetActive(false);
        zones[1].transform.Find("NavDirectionMarkings").transform.gameObject.SetActive(true);
        clippyFollow.SetFollowPlayer();
    }

    private IEnumerator S_ConfrontingNetworkCard()
    {
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine(GetPlayerName(), "Looks like the network card is corrupted too."));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("Clippy", "Distract him, I will download the antivirus while you’re at it."));
        clippyFollow.MoveOutOfBounds();
        yield return new WaitForSeconds(1);
        zone10EnemyList[0].SetActive(true);
    }

    private IEnumerator S_AfterBeatingNetworkCard()
    {
        clippyFollow.SetFollowPlayer();
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("Clippy", "Well done! The connection to the Internet is down, but I downloaded the antivirus just in time!"));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine(GetPlayerName(), "Nice! So It’s all over now?"));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("Clippy", "Let’s see..."));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("", "..."));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("", "..."));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("", "..."));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("", "...?"));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("Clippy", "Oh no. There is still a problem."));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("Clippy", "It needs administrator permissions to access some low-level stuff."));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("Clippy", "And knowing the user... I think there is nothing we can do."));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine(GetPlayerName(), "Oh... Well it says something about low-level, why not just go to the processor and launch the antivirus there?"));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("Clippy", "That’s... that’s genius! No need for permission if you already broke the door!"));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("Clippy", "Except we still have a problem..."));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("Clippy", "The processor is definitely corrupted by the virus... and with his processing power against us... "));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("Clippy", "Actually no, we’ll be fine."));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("", "..."));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("Clippy", "I think we should go to the store and prepare for another confrontation."));
    }

    public IEnumerator S_WhenInteractingWithDoorTwo()
    {
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("Clippy", "Don't. The sound card is there. We don't have to fight more than we already have to."));
    }

    private IEnumerator S_WhenEnteringStorageAgain()
    {
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine(GetPlayerName(), "I was wondering... I can’t believe I’m asking this only now, but where is everyone else?"));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("Clippy", "Well the malware prevents a lot of services from being online. "));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("Clippy", "Also when we launch the antivirus properly then everything will be how it used to."));
    }

    public IEnumerator S_WhenInteractingWithDoorThree()
    {
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine(GetPlayerName(), "Another inaccessible room."));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("Clippy", "Well the hard drives are gone and the only thing that’s handling storage now is the RAM."));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("Clippy", "I guess it got locked due to the emergency. Still, we don’t need to go there."));
    }

    private IEnumerator S_ConfrontingProcessor()
    {
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine(GetPlayerName(), "So this is it."));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("Clippy", "I’m starting the antivirus."));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine(GetPlayerName(), "I’m not sure that I can do it..."));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("Clippy", "Come on, driver, we have been in a desktop war for a while, where is your wrath? Let’s do this!"));
        clippyFollow.MoveOutOfBounds();
        OSTHandler.Instance.SetSong(3, 0);
        zone15EnemyList[0].SetActive(true);
    }

    private IEnumerator S_End()
    {
        OSTHandler.Instance.audioSource.Stop();
        clippyFollow.SetFollowPlayer();
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine(GetPlayerName(), "We did it!"));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("Clippy", "Yes we did it..."));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine(GetPlayerName(), "Is there a problem?"));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine("Clippy", "No, it’s just... This isn’t going to last. The user is going to repeat this cycle all over again."));
        yield return StartCoroutine(dialogueSystem.TypeTextRoutine(GetPlayerName(), "I guess we are going to find out after the restart."));

        SceneManagement.LoadScene("Menu", 5f);
    }

}