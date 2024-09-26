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

}
