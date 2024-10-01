using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverScene : MonoBehaviour
{
    [SerializeField] GameObject sadSmiley;
    [SerializeField] GameObject angySmiley;
    [SerializeField] List<GameObject> loseText;
    [SerializeField] TextMeshProUGUI description;
    [SerializeField] TextMeshProUGUI descriptionError;
    [SerializeField] TextMeshProUGUI pressAnyKeyText;

    private float timePassed = 0f;
    [SerializeField] float timeForPressAnyKeyActivation;

    private bool hasAnyKeyBeenPressed = false;
    private bool hasAnyKeyAnimationStarted = false;


    private void Update()
    {
        timePassed += Time.deltaTime;

        if(!hasAnyKeyAnimationStarted && timePassed > timeForPressAnyKeyActivation)
        {
            hasAnyKeyAnimationStarted = true;
            StartCoroutine(PressAnyKeyAnimationSequence());
        }

        if (timePassed > timeForPressAnyKeyActivation && Input.anyKeyDown && !hasAnyKeyBeenPressed)
        {
            hasAnyKeyBeenPressed = true;
            pressAnyKeyText.gameObject.SetActive(false);
            StartCoroutine(SmileyAnimationSequence());
            StartCoroutine(YouLoseAnimationSequence());
            StartCoroutine(DescriptionChangeAnimationSequence());
            StartCoroutine(GoToMenu());
        }
    }

    private IEnumerator PressAnyKeyAnimationSequence()
    {
        while (true)
        {
            pressAnyKeyText.text = "Press any key to continue.";
            yield return new WaitForSeconds(0.5f);

            pressAnyKeyText.text = "Press any key to continue..";
            yield return new WaitForSeconds(0.5f);

            pressAnyKeyText.text = "Press any key to continue...";
            yield return new WaitForSeconds(0.5f);
        }
    }


    private IEnumerator SmileyAnimationSequence()
    {
        yield return new WaitForSeconds(0f);
        sadSmiley.SetActive(false);
        angySmiley.SetActive(true);
    }

    private IEnumerator YouLoseAnimationSequence()
    {
        for (int i = 0; i < loseText.Count; i++)
        {
            loseText[i].SetActive(true);
            yield return new WaitForSeconds(0.03f);
        }
    }

    private IEnumerator DescriptionChangeAnimationSequence()
    {

        yield return new WaitForSeconds(0.1f);
        description.text = "GAME OVER! GAME OVER! GAME OVER! GAME OVER! GAME OVER! GAME OVER! GAME OVER! GAME OVER! ";
        descriptionError.text = "ERROR:TRY_AGAIN_I_DARE_YOU";
    }
    private IEnumerator GoToMenu()
    {
        yield return new WaitForSeconds(0.9f);
        SceneManagement.LoadScene("Menu", 0.2f);
    }

}
