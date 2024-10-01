using UnityEngine;

public class WaveEmitterWave: MonoBehaviour
{

    public Vector3 moveDirection;
    public float speed;
    public float destroyTimer;

    private void Start()
    {
        transform.rotation = Quaternion.LookRotation(moveDirection);
        
    }

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

