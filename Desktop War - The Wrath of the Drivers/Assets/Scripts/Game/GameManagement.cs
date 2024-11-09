using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagement : MonoBehaviour
{
    DialogueSystem ds;

    public bool isClippyWithYou = false;


    private void Start()
    {
        ds = FindObjectOfType<DialogueSystem>();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            //StartCoroutine(FullSequence());
        }
    }


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
        yield return StartCoroutine(S_WhenInteractingWithLockedDoorOneAlone());
        yield return StartCoroutine(S_FirstTimeInteractionWithNull());
        yield return StartCoroutine(S_WhenInteractingWithLockedDoorOneClippy());
        yield return StartCoroutine(S_AfterFinishingSomeRoomsWithClippy());
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
        yield return StartCoroutine(ds.TTC(GetPlayerName(), "Where am I?"));
        yield return StartCoroutine(ds.TTC(GetPlayerName(), "What happened?"));
        yield return StartCoroutine(ds.TTC(GetPlayerName(), "I guess I'll have to go to the storage to find out."));
    }

    private IEnumerator S_WhenSeeingEnemiesForFirstTime()
    {
        yield return StartCoroutine(ds.TTC(GetPlayerName(), "Woah, those things weren’t here before!"));
        yield return StartCoroutine(ds.TTC(GetPlayerName(), "This place is a mess... Thankfully, I still remember how to SHOOT."));
    }

    private IEnumerator S_WhenSeeingImpassableTerrainForFirstTime()
    {
        yield return StartCoroutine(ds.TTC(GetPlayerName(), "Impassable terrain... Not for me though! At the driver school, they taught me how to DEFEND. "));
    }

    private IEnumerator S_AfterPassingImpassableTerrain()
    {
        yield return StartCoroutine(ds.TTC(GetPlayerName(), "I have to make my way to the storage before something else happens."));
    }

    private IEnumerator S_WhenInteractingWithLockedDoorOneAlone()
    {
        yield return StartCoroutine(ds.TTC(GetPlayerName(), "Locked."));
    }

    private IEnumerator S_FirstTimeInteractionWithNull()
    {
        yield return StartCoroutine(ds.TTC("", "*you gently click on... whatever this thing is.*"));
        yield return StartCoroutine(ds.TTC("NULL", "What, what the he- Oh hello there! Thanks for waking me up!"));
        yield return StartCoroutine(ds.TTC(GetPlayerName(), "H- hi? \nWhat’s the matter with you?!"));
        yield return StartCoroutine(ds.TTC("NULL", "Oh I know what’s the matter alright, that dumbass user for sure installed some malware again."));
        yield return StartCoroutine(ds.TTC("NULL", "I swear this happens like every other day."));
        yield return StartCoroutine(ds.TTC(GetPlayerName(), "How do you remember all this?"));
        yield return StartCoroutine(ds.TTC("NULL", "I don’t remember all this, but the state of this place gives me a déjà vu. The computer must have restarted."));
        yield return StartCoroutine(ds.TTC(GetPlayerName(), "We really need to get to the storage room to find out what happened."));
        yield return StartCoroutine(ds.TTC("NULL", "No need, I have a direct line to them! Lemme give them a call."));
        yield return StartCoroutine(ds.TTC("", "..."));
        yield return StartCoroutine(ds.TTC("", "..."));
        yield return StartCoroutine(ds.TTC("", "..."));
        yield return StartCoroutine(ds.TTC("NULL", "No response. So it’s that bad. Guess we’ll have to walk there on foot."));
        yield return StartCoroutine(ds.TTC(GetPlayerName(), "Sorry for asking, have you always looked like..."));
        yield return StartCoroutine(ds.TTC("NULL", "Like what?"));
        yield return StartCoroutine(ds.TTC("GetPlayerName()", "You look like nothing to me. Literally."));
        yield return StartCoroutine(ds.TTC("NULL", "Oh, this? I’m starting to get used to it."));
        yield return StartCoroutine(ds.TTC("NULL", "Looks like this malware somehow managed to delete my textures but not my actual functionality."));
        yield return StartCoroutine(ds.TTC("NULL", "Probably we shouldn’t even be worried at this point."));
        yield return StartCoroutine(ds.TTC(GetPlayerName(), "You sure?"));
        yield return StartCoroutine(ds.TTC("NULL", "Yes, let’s go already!"));

    }

    private IEnumerator S_WhenInteractingWithLockedDoorOneClippy()
    {
        yield return StartCoroutine(ds.TTC(GetPlayerName(), "It’s locked."));
        yield return StartCoroutine(ds.TTC("NULL", "Yeah, as it should be. The guy in there is weird."));
        yield return StartCoroutine(ds.TTC(GetPlayerName(), "What do you mean?"));
        yield return StartCoroutine(ds.TTC("NULL", "Don’t they teach you that stuff at driver school or something? It’s the BIOS! "));
        yield return StartCoroutine(ds.TTC(GetPlayerName(), "I mean they do teach that stuff, it’s one of the first topics..."));
        yield return StartCoroutine(ds.TTC(GetPlayerName(), "It’s just... I think I’m losing my mind. I think I’m starting to not remember much about anything."));
        yield return StartCoroutine(ds.TTC("NULL", "Well don’t worry, it means the malware is doing its job."));
        yield return StartCoroutine(ds.TTC(GetPlayerName(), "So, what about BIOS?"));
        yield return StartCoroutine(ds.TTC("NULL", "Ok, so I got to meet this guy once when he was at his lunch break and he was just standing there."));
        yield return StartCoroutine(ds.TTC("NULL", "So I go up to him and he just keeps talking about how he is always awake even when the computer is turned off."));
        yield return StartCoroutine(ds.TTC("NULL", "Like how is that even possible?"));
        yield return StartCoroutine(ds.TTC(GetPlayerName(), "Why do I have a feeling that he is probably lying?"));
        yield return StartCoroutine(ds.TTC("NULL", "Noo, not “probably”. It’s “definitely”! He is definitely lying, no one can confirm what he was saying."));
        yield return StartCoroutine(ds.TTC("NULL", "So probably he’s trying to look cool to make up for his boring job."));
        yield return StartCoroutine(ds.TTC(GetPlayerName(), "Maybe."));
    }

    private IEnumerator S_AfterFinishingSomeRoomsWithClippy()
    {
        yield return StartCoroutine(ds.TTC("NULL", "Oh someone is calling."));
        yield return StartCoroutine(ds.TTC("NULL", "It’s the guys from the storage room! Let’s see..."));
        yield return StartCoroutine(ds.TTC("NULL", "Yeah...?"));
        yield return StartCoroutine(ds.TTC("NULL", "Wai- calm down..."));
        yield return StartCoroutine(ds.TTC("NULL", "Uh huh"));
        yield return StartCoroutine(ds.TTC("NULL", "Yes."));
        yield return StartCoroutine(ds.TTC("NULL", "What in the recycle bin?!"));
        yield return StartCoroutine(ds.TTC("NULL", "What do you mean your storage buddy exploded?"));
        yield return StartCoroutine(ds.TTC("NULL", "Anyway."));
        yield return StartCoroutine(ds.TTC("NULL", "Is there something we can do?"));
        yield return StartCoroutine(ds.TTC("NULL", "Oh yeah?"));
        yield return StartCoroutine(ds.TTC("NULL", "No, but i have a driver with me."));
        yield return StartCoroutine(ds.TTC("NULL", "Alright, one more thing-"));
        yield return StartCoroutine(ds.TTC(GetPlayerName(), " What was that on the phone?"));
        yield return StartCoroutine(ds.TTC("NULL", "Looks like the other guy exploded too."));
        yield return StartCoroutine(ds.TTC(GetPlayerName(), "What?"));
        yield return StartCoroutine(ds.TTC("NULL", "Sorry. I meant de-fragmented! Get it? "));
        yield return StartCoroutine(ds.TTC(GetPlayerName(), "Huh?"));
        yield return StartCoroutine(ds.TTC("NULL", "Don’t worry, we just have to get rid of this malware and you will be good."));
        yield return StartCoroutine(ds.TTC("NULL", "Even though the storage room is now dead again at least we should check what’s left there. Come on, let’s go."));
    }

    private IEnumerator S_ArrivingAtStorage()
    {
        yield return StartCoroutine(ds.TTC("NULL", "Here we are. This looks pretty dead. "));
        yield return StartCoroutine(ds.TTC("NULL", "Oh, here are my textures."));
        yield return StartCoroutine(ds.TTC(GetPlayerName(), "Damn."));
        yield return StartCoroutine(ds.TTC("Clippy", "This is pretty sad."));
        yield return StartCoroutine(ds.TTC(GetPlayerName(), "Why?"));
        yield return StartCoroutine(ds.TTC("Clippy", "I guess this malware mostly locks and destroys stuff that’s important, which is fine."));
        yield return StartCoroutine(ds.TTC(GetPlayerName(), "Meaning..."));
        yield return StartCoroutine(ds.TTC("", "..."));
        yield return StartCoroutine(ds.TTC("", "..."));
        yield return StartCoroutine(ds.TTC("Clippy", "Have you read the stuff they say about me on the internet? Useless this, annoying that. Like why do I even exist at this point?"));
        yield return StartCoroutine(ds.TTC(GetPlayerName(), "To help the user?"));
        yield return StartCoroutine(ds.TTC("Clippy", "Yeah, but what if the user is braindead? This guy doesn’t listen to me at all."));
        yield return StartCoroutine(ds.TTC("Clippy", "I told him “Don’t turn off the antivirus ‘cause the software you downloaded from the piracy site told you to.”"));
        yield return StartCoroutine(ds.TTC("Clippy", "I mean I get that, false positives and all. Why not just pay for the software?"));
        yield return StartCoroutine(ds.TTC(GetPlayerName(), "Hey, a multi-billion dollar corporation made you, you wouldn’t get it."));
        yield return StartCoroutine(ds.TTC("Clippy", "I mean, yeah, but still. This guy makes our job a lot more harder than it needs to be."));
        yield return StartCoroutine(ds.TTC(GetPlayerName(), "What’s this thing though?"));
        yield return StartCoroutine(ds.TTC("Clippy", "A store... at the storage. That’s not even funny. Who came up with that?"));
        yield return StartCoroutine(ds.TTC(GetPlayerName(), "Should we...?"));
        yield return StartCoroutine(ds.TTC("Clippy", "Yeah of course! Double click on it and check what’s up!"));
    }

    private IEnumerator S_AfterLeavingStorage()
    {
        yield return StartCoroutine(ds.TTC(GetPlayerName(), "Soo, where are we going now?"));
        yield return StartCoroutine(ds.TTC("Clippy", "Oh yeah, dead guy told me we need to download an antivirus, launch it, and see what’s what."));
        yield return StartCoroutine(ds.TTC("Clippy", "We need to fight our way to the PCI room and pray the guys there are left uninfected by the virus."));
        yield return StartCoroutine(ds.TTC(GetPlayerName(), "So the plan is to find the network card?"));
        yield return StartCoroutine(ds.TTC("Clippy", "Yes, and then we will have to access the god-forsaken world beyond our realm -  the Internet."));
        yield return StartCoroutine(ds.TTC(GetPlayerName(), "Is it that bad?"));
        yield return StartCoroutine(ds.TTC("Clippy", "Yes, but also no. It depends on what you look at I guess. Let’s go."));
    }

    private IEnumerator S_EnteringVideoCardRoom()
    {
        yield return StartCoroutine(ds.TTC(GetPlayerName(), "What’s going on?"));
        yield return StartCoroutine(ds.TTC("Clippy", "Looks like the guys are infected. The goddamn video card is here too! You need to fight it!"));
        yield return StartCoroutine(ds.TTC(GetPlayerName(), "What, me?"));
        yield return StartCoroutine(ds.TTC("Clippy", "Well no, it’s gonna be me, who can’t even defend himself. Now fight it, or die trying!"));
    }

    private IEnumerator S_AfterBeatingVideoCard()
    {
        yield return StartCoroutine(ds.TTC(GetPlayerName(), "Huh? I’m here again? "));
        yield return StartCoroutine(ds.TTC(GetPlayerName(), "Wait... I can remember, I must have beat him..."));
        yield return StartCoroutine(ds.TTC(GetPlayerName(), "I should search for Clippy."));
    }

    private IEnumerator S_FindingClippy()
    {
        yield return StartCoroutine(ds.TTC("", "*you gently click on... whatever this thing is.*"));
        yield return StartCoroutine(ds.TTC("Clippy", "What, what the he- Oh hello there- Wait. I mean, you did it! "));
        yield return StartCoroutine(ds.TTC(GetPlayerName(), "Yeah, but we still need to get to the network card."));
        yield return StartCoroutine(ds.TTC("Clippy", "I don’t know if we have much time, this place is in a bigger mess than it was before the restart."));
        yield return StartCoroutine(ds.TTC("Clippy", "Besides, antiviruses aren’t even that good. "));
        yield return StartCoroutine(ds.TTC("Clippy", "They don’t guarantee security. Reinstalling the OS does though. "));
        yield return StartCoroutine(ds.TTC(GetPlayerName(), "But... that means..."));
        yield return StartCoroutine(ds.TTC("Clippy", "Reinstalling the OS is out of the question though."));
        yield return StartCoroutine(ds.TTC("Clippy", "But yeah. We will be gone, but it’s fine because we exist for the user, and die for the user."));
        yield return StartCoroutine(ds.TTC("Clippy", "And then be reborn again, only to probably go through the same thing all over."));
        yield return StartCoroutine(ds.TTC(GetPlayerName(), "Sounds kind of depressing. Maybe It’s a good thing that I can't remember everything."));
        yield return StartCoroutine(ds.TTC("Clippy", "Yeah, that’s how most guys on this system get around."));
        yield return StartCoroutine(ds.TTC("Clippy", "If you’re useful, you’re mostly okay."));
        yield return StartCoroutine(ds.TTC("Clippy", "If you’re useless, you’re alone with your thoughts and the thoughts from the previous iterations."));
        yield return StartCoroutine(ds.TTC("", "..."));
        yield return StartCoroutine(ds.TTC(GetPlayerName(), "I think we should keep going."));
        yield return StartCoroutine(ds.TTC("Clippy", "Let’s go."));
    }

    private IEnumerator S_ConfrontingNetworkCard()
    {
        yield return StartCoroutine(ds.TTC(GetPlayerName(), "Looks like the network card is corrupted too."));
        yield return StartCoroutine(ds.TTC("Clippy", "Distract him, I will download the antivirus while you’re at it."));
    }

    private IEnumerator S_AfterBeatingNetworkCard()
    {
        yield return StartCoroutine(ds.TTC("Clippy", "Well done! The connection to the Internet is down, but I downloaded the antivirus just in time!"));
        yield return StartCoroutine(ds.TTC(GetPlayerName(), "Nice! So It’s all over now?"));
        yield return StartCoroutine(ds.TTC("Clippy", "Let’s see..."));
        yield return StartCoroutine(ds.TTC("", "..."));
        yield return StartCoroutine(ds.TTC("", "..."));
        yield return StartCoroutine(ds.TTC("", "..."));
        yield return StartCoroutine(ds.TTC("", "...?"));
        yield return StartCoroutine(ds.TTC("Clippy", "Oh no. There is still a problem."));
        yield return StartCoroutine(ds.TTC("Clippy", "It needs administrator permissions to access some low-level stuff."));
        yield return StartCoroutine(ds.TTC("Clippy", "And knowing the user... I think there is nothing we can do."));
        yield return StartCoroutine(ds.TTC(GetPlayerName(), "Oh... Well it says something about low-level, why not just go to the processor and launch the antivirus there?"));
        yield return StartCoroutine(ds.TTC("Clippy", "That’s... that’s genius! No need for permission if you already broke the door!"));
        yield return StartCoroutine(ds.TTC("Clippy", "Except we still have a problem..."));
        yield return StartCoroutine(ds.TTC("Clippy", "The processor is definitely corrupted by the virus... and with his processing power against us... "));
        yield return StartCoroutine(ds.TTC("Clippy", "Actually no, we’ll be fine."));
        yield return StartCoroutine(ds.TTC("", "..."));
        yield return StartCoroutine(ds.TTC("Clippy", "I think we should go to the store and prepare for another confrontation."));
    }

    private IEnumerator S_WhenInteractingWithDoorTwo()
    {
        yield return StartCoroutine(ds.TTC("Clippy", "Don't. The sound card is there. We don't have to fight more than we already have to."));
    }

    private IEnumerator S_WhenEnteringStorageAgain()
    {
        yield return StartCoroutine(ds.TTC(GetPlayerName(), "I was wondering... I can’t believe I’m asking this only now, but where is everyone else?"));
        yield return StartCoroutine(ds.TTC("Clippy", "Well the malware prevents a lot of services from being online. "));
        yield return StartCoroutine(ds.TTC("Clippy", "Also when we launch the antivirus properly then everything will be how it used to."));
    }

    private IEnumerator S_WhenInteractingWithDoorThree()
    {
        yield return StartCoroutine(ds.TTC(GetPlayerName(), "Another inaccessible room."));
        yield return StartCoroutine(ds.TTC("Clippy", "Well the hard drives are gone and the only thing that’s handling storage now is the RAM."));
        yield return StartCoroutine(ds.TTC("Clippy", "I guess it got locked due to the emergency. Still, we don’t need to go there."));
    }

    private IEnumerator S_ConfrontingProcessor()
    {
        yield return StartCoroutine(ds.TTC(GetPlayerName(), "So this is it."));
        yield return StartCoroutine(ds.TTC("Clippy", "I’m starting the antivirus."));
        yield return StartCoroutine(ds.TTC(GetPlayerName(), "I’m not sure that I can do it..."));
        yield return StartCoroutine(ds.TTC("Clippy", "Come on, driver, we have been in a desktop war for a while, where is your wrath? Let’s do this!"));
    }

    private IEnumerator S_End()
    {
        yield return StartCoroutine(ds.TTC(GetPlayerName(), "We did it!"));
        yield return StartCoroutine(ds.TTC("Clippy", "Yes we did it..."));
        yield return StartCoroutine(ds.TTC(GetPlayerName(), "Is there a problem?"));
        yield return StartCoroutine(ds.TTC("Clippy", "No, it’s just... This isn’t going to last. The user is going to repeat this cycle all over again."));
        yield return StartCoroutine(ds.TTC(GetPlayerName(), "I guess we are going to find out after the restart."));
    }

}