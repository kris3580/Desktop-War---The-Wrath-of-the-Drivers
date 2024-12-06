using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NavigationHandler : MonoBehaviour
{
    private bool[] enterExitBools = { false, false };

    public int xNav = 1;
    public int yNav = 4;
    private GameObject[,] map;

    [SerializeField] GameObject[] Z;

    GameManagement gameManagement;
    DialogueSystem dialogueSystem;
    ClippyFollow clippyFollow;

    [SerializeField] public Texture permittedHighlight;
    [SerializeField] public Texture forbiddenHighlight;


    private void Update()
    {
        //Debug.Log($"{map[yNav, xNav].name} {xNav} {yNav}");
    }

    private void Start()
    {
        map = new GameObject[5, 6]
        {
            { null,   null,   Z[12],  null,   null,   null,  },
            { null,   null,   Z[11],  Z[5],   Z[6],   Z[7],  },
            { Z[15],  Z[14],  Z[13],  Z[4],   null,   Z[8],  },
            { null,   null,   null,   Z[3],   Z[10],  Z[9],  },
            { null,   Z[0],   Z[1],   Z[2],   null,   null,  }  
        };

        gameManagement = FindObjectOfType<GameManagement>();
        dialogueSystem = FindObjectOfType<DialogueSystem>();
        clippyFollow = FindObjectOfType<ClippyFollow>();
    }

    private void ResetEnterExitBools()
    {
        enterExitBools[0] = false;
        enterExitBools[1] = false;
    }

    public void DelayedResetEnterExitBools()
    {
        Invoke(nameof(ResetEnterExitBools), 1f);
    }



    private void OnTriggerEnter(Collider other)
    {
        if (dialogueSystem.isInDialogue) return;



        // TRIGGER DIALOGUES

        if (other.name == "AfterDefendingTrigger")
        {
            gameManagement.ActivateZone1RightNav();
            return;
        }

        if (other.name == "ClippyFirstInteractionTrigger" && gameManagement.AreAllElementsNull(gameManagement.zone3EnemyList) && !gameManagement.isZone3Finished)
        {
            gameManagement.isClippyWithYou = true;
        }

        if (other.name == "ClippySecondInteractionTrigger")
        {
            gameManagement.isClippyWithYouAgain = true;
        }





            // doors that are locked forever

        if (other.name == "NAV_RIGHT" && xNav == 3 && yNav == 4)
        {
            other.transform.parent.GetComponent<RawImage>().texture = forbiddenHighlight;
            if (gameManagement.isClippyWithYou)
            {
                StartCoroutine(gameManagement.S_WhenInteractingWithLockedDoorOneClippy());
            }
            else
            {
                StartCoroutine(gameManagement.S_WhenInteractingWithBIOSDoorAlone());
            }
            return;
        }
        else if (other.name == "NAV_RIGHT" && xNav == 5 && yNav == 3)
        {
            other.transform.parent.GetComponent<RawImage>().texture = forbiddenHighlight;

            StartCoroutine(gameManagement.S_WhenInteractingWithDoorTwo());

            return;
        }
        else if (other.name == "NAV_LEFT" && xNav == 2 && yNav == 0)
        {
            other.transform.parent.GetComponent<RawImage>().texture = forbiddenHighlight;

            StartCoroutine(gameManagement.S_WhenInteractingWithDoorThree());

            return;
        }

        // doors that will unlock eventually
        if (other.name == "NAV_RIGHT" && xNav == 3 && yNav == 3 && !gameManagement.hasBeatenNetworkCard)
        {
            other.transform.parent.GetComponent<RawImage>().texture = forbiddenHighlight;

            StartCoroutine(gameManagement.S_WhenInteractingWithLockedDefault());

            return;
        }


        if (other.name == "NAV_LEFT" && xNav == 3 && yNav == 2 && !gameManagement.hasBeatenNetworkCard)
        {
            other.transform.parent.GetComponent<RawImage>().texture = forbiddenHighlight;

            StartCoroutine(gameManagement.S_WhenInteractingWithLockedDefault());

            return;
        }


        if (other.name == "NAV_LEFT" && xNav == 3 && yNav == 1 && !gameManagement.hasBeatenNetworkCard)
        {
            other.transform.parent.GetComponent<RawImage>().texture = forbiddenHighlight;

            StartCoroutine(gameManagement.S_WhenInteractingWithLockedDefault());

            return;
        }


        // usual cases
        if (!enterExitBools[0] && !enterExitBools[1] && (other.name == "NAV_UP" || other.name == "NAV_DOWN" || other.name == "NAV_LEFT" || other.name == "NAV_RIGHT"))
        {
            map[yNav, xNav].SetActive(false);

            if (other.name == "NAV_UP")
            {
                yNav--;
                transform.position = new Vector3(transform.position.x, 1.994f, transform.position.z);
                clippyFollow.SetClippyPositionNextToPlayer();
            }
            else if (other.name == "NAV_DOWN")
            {
                yNav++;
                transform.position = new Vector3(transform.position.x, 6.526f, transform.position.z);
                clippyFollow.SetClippyPositionNextToPlayer();
            }
            else if (other.name == "NAV_LEFT")
            {
                xNav--;
                transform.position = new Vector3(4.53f, transform.position.y, transform.position.z);
                clippyFollow.SetClippyPositionNextToPlayer();
            }
            else if (other.name == "NAV_RIGHT")
            {
                xNav++;
                transform.position = new Vector3(-4.531f, transform.position.y, transform.position.z);
                clippyFollow.SetClippyPositionNextToPlayer();
            }

            map[yNav, xNav].SetActive(true);

            enterExitBools[0] = true;

            DestroyAllBullets();

        }
        else if (enterExitBools[0] && !enterExitBools[1] && (other.name == "NAV_UP" || other.name == "NAV_DOWN" || other.name == "NAV_LEFT" || other.name == "NAV_RIGHT"))
        {
            enterExitBools[1] = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {

        if (enterExitBools[0] && enterExitBools[1] && (other.name == "NAV_UP" || other.name == "NAV_DOWN" || other.name == "NAV_LEFT" || other.name == "NAV_RIGHT"))
        {
            enterExitBools[0] = false;
            enterExitBools[1] = false;
        }
    }

    private void DestroyAllBullets()
    {
        List<string> tagsToDestroy = new List<string>
        {
            "Bullet", "PlayerBullet"
        };

        List<GameObject> objectsToDestroy = new List<GameObject>();

        foreach (string tag in tagsToDestroy)
        {
            GameObject[] foundObjects = GameObject.FindGameObjectsWithTag(tag);
            objectsToDestroy.AddRange(foundObjects);
        }

        foreach (GameObject obj in objectsToDestroy)
        {
            Destroy(obj);
        }
    }






}
