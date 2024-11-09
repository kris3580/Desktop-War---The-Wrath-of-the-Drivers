using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;

public class DialogueSystem : MonoBehaviour
{

    [SerializeField] Animator animator;
    [SerializeField] float typingSpeed;
    [SerializeField] TextMeshProUGUI dialogueText;
    [SerializeField] TextMeshProUGUI speakerText;
    [SerializeField] GameObject commentSlashes;
    [SerializeField] GameObject discLogo;

    [SerializeField] PeripheralTypeHandler peripheralTypeHandler;

    private bool toSkipTyping = false;
    private bool isInDialogue = false;
    private void Update()
    {

        if (isInDialogue && Input.GetMouseButtonDown(0) && !toSkipTyping)
        {
            toSkipTyping = true;
        }

    }


    private void TypeText(string speaker, string dialogue)
    {
        StartCoroutine(TTC(speaker, dialogue));
    }


    public IEnumerator TTC(string speaker, string dialogue)
    {
        if (isInDialogue) yield break;

        StartCoroutine(FindObjectOfType<Cursor>().DelayedReturnToDefaultCursor());

        isInDialogue = true;

        peripheralTypeHandler.AllAbilitiesActivityHandler(false);
        Movement.isFrozen = true;
        dialogueText.text = "";
        speakerText.text = speaker;
        commentSlashes.SetActive(true);
        animator.SetBool("isShowing", true);
        animator.SetBool("isHidden", false);
        

        foreach (char letter in dialogue.ToCharArray())
        {
            if (toSkipTyping)
            {
                dialogueText.text = dialogue;
                break;
            }

            dialogueText.text += letter;

            if (speaker == "Clippy" || speaker == "NULL") SFXHandler.Instance.Play(5);
            if (speaker == "Mouse") SFXHandler.Instance.Play(13);
            if (speaker == "Keyboard") SFXHandler.Instance.Play(12);
            if (speaker == "Headphones") SFXHandler.Instance.Play(15, 0.4f);

            yield return new WaitForSeconds(typingSpeed);
        }

        discLogo.SetActive(true);
        discLogo.GetComponent<Animation>().Play();


        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

        dialogueText.text = "";
        speakerText.text = "";
        commentSlashes.SetActive(false);
        animator.SetBool("isShowing", false);
        animator.SetBool("isHidden", true);
        discLogo.SetActive(false);
        peripheralTypeHandler.AllAbilitiesActivityHandler(true);
        Movement.isFrozen = false;

        isInDialogue = false;
        toSkipTyping = false;
    }

}
