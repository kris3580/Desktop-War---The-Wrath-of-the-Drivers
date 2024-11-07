using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationHandler : MonoBehaviour
{
    private bool[] enterExitBools = { false, false };

    private int xNav = 1;
    private int yNav = 4;
    private GameObject[,] map;

    [SerializeField] GameObject[] Z;



    private void Update()
    {
        Debug.Log($"{map[yNav, xNav].name} {xNav} {yNav}");
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

    }

    private void OnTriggerEnter(Collider other)
    {
        // exceptions

        if (other.name == "NAV_RIGHT" && xNav == 3 && yNav == 4)
        {
            return;
        }
        else if (other.name == "NAV_RIGHT" && xNav == 5 && yNav == 3)
        {
            return;
        }
        else if (other.name == "NAV_LEFT" && xNav == 2 && yNav == 0)
        {
            return;
        }




        if (!enterExitBools[0] && !enterExitBools[1] && (other.name == "NAV_UP" || other.name == "NAV_DOWN" || other.name == "NAV_LEFT" || other.name == "NAV_RIGHT"))
        {
            map[yNav, xNav].SetActive(false);

            if (other.name == "NAV_UP")
            {
                yNav--;
                transform.position = new Vector3(transform.position.x, 1.994f, transform.position.z);
            }
            else if (other.name == "NAV_DOWN")
            {
                yNav++;
                transform.position = new Vector3(transform.position.x, 6.526f, transform.position.z);
            }
            else if (other.name == "NAV_LEFT")
            {
                xNav--;
                transform.position = new Vector3(4.53f, transform.position.y, transform.position.z);
            }
            else if (other.name == "NAV_RIGHT")
            {
                xNav++;
                transform.position = new Vector3(-4.531f, transform.position.y, transform.position.z);
            }

            map[yNav, xNav].SetActive(true);

            enterExitBools[0] = true;



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


}
