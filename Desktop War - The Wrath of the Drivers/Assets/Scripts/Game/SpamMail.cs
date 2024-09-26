using UnityEngine;
using UnityEngine.EventSystems;

public class SpamMail : MonoBehaviour
{

    public bool direction;
    public float speed;
    public float destroyTimer;

    void Update()
    {

        if (direction == true)
        {
            transform.position += Vector3.right * Time.deltaTime * speed;
        }
        else
        {
            transform.position += Vector3.left * Time.deltaTime * speed;
        }

        
        destroyTimer -= Time.deltaTime;

        if (destroyTimer <= 0)
        {
            Destroy(gameObject);
        }
    }






}
