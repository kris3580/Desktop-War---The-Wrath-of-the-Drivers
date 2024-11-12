using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private float speed = 5f;


    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;

        transform.position += direction * speed * Time.deltaTime;
    }


}
