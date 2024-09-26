using UnityEngine;

public class AutoclickerCursor : MonoBehaviour
{

    public Vector3 moveDirection;
    public float speed;
    public float destroyTimer;

    void Update()
    {
        transform.position += moveDirection * Time.deltaTime * speed;
        destroyTimer -= Time.deltaTime;

        if (destroyTimer <= 0) 
        {
            Destroy(gameObject);
        } 
    }
}
