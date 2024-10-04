using UnityEngine;

public class AutoclickerCursor : MonoBehaviour
{

    public Vector3 moveDirection;
    public float speed;
    public float destroyTimer;

    [SerializeField] public int baseDamage;
    public int extraDamage;



    void Update()
    {
        transform.position += moveDirection * Time.deltaTime * speed;
        destroyTimer -= Time.deltaTime;

        if (destroyTimer <= 0) 
        {
            Destroy(gameObject);
        } 
    }

    public int GetDamage()
    {
        return 0;
    }

}
