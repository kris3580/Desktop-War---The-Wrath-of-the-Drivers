using UnityEngine;

public class HealthSystem : MonoBehaviour
{

    [SerializeField] int currentHealth;
    [SerializeField] int maxHealth;
    [SerializeField] float delayHealthRemovalTimer;
    private float currentDelayHealthRemovalTimer = 0f;
    public bool isSystemActive = true;

    private void Update()
    {
        currentDelayHealthRemovalTimer -= Time.deltaTime;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            RemoveHealth(other.gameObject);
            Debug.Log(currentHealth);
        }

    }


    private void RemoveHealth(GameObject bulletToRemove)
    {
        if (currentDelayHealthRemovalTimer <= 0 && isSystemActive)
        {
            currentHealth--;
            currentDelayHealthRemovalTimer = delayHealthRemovalTimer;
            Destroy(bulletToRemove);
        }
    }

}
