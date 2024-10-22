using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temporary_EnemySpawnOnButtonPress : MonoBehaviour
{
    [SerializeField] GameObject enemy;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            enemy.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            enemy.SetActive(false);
        }
    }
}
