using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] List<Vector3> targetPositions;
    [SerializeField] List<bool> hasMovementTargetPositionStarted;
    [SerializeField] List<bool> hasMovementTargetPositionReached;

    private float timer = 0f;
    private Vector3 startingPosition;
    [SerializeField] float speed;


    private void Start()
    {
        startingPosition = transform.position;
        StartCoroutine(EnemyMovementSequence());
    }

    private void Update()
    {
        

        if (hasMovementTargetPositionStarted[0] && !hasMovementTargetPositionReached[0])
            timer += Time.deltaTime * speed;
        {
            transform.position = Vector3.Lerp(startingPosition, targetPositions[0], timer);

            if (timer >= 1) hasMovementTargetPositionReached[0] = true;
        }

    }

    private IEnumerator EnemyMovementSequence()
    {
        yield return new WaitForSeconds(9f);
        hasMovementTargetPositionStarted[0] = true;

    }
}
