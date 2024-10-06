using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Shield" && PFeedbackAbility.isShiledCurrentlyInUse) 
        {
            Destroy(gameObject);
        }
    }



    private Vector3 direction;
    private float speed;

    public void SetDirection(Vector3 dir, float spd)
    {
        direction = dir;
        speed = spd;
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        // Optionally, destroy bullet after a certain distance
        if (transform.position.magnitude > 50f)
        {
            Destroy(gameObject);
        }
    }


    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }




}
