using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{

    [SerializeField] public int currentHealth;
    public int maxHealth;
    [SerializeField] float delayHealthRemovalTimer;
    private float currentDelayHealthRemovalTimer = 0f;
    public bool isSystemActive = true;
    private int currentMaxHealth;

    private void Start()
    {
        currentMaxHealth = maxHealth;
    }

    private void Update()
    {
        currentDelayHealthRemovalTimer -= Time.deltaTime;

        if(currentMaxHealth != maxHealth)
        {
            currentMaxHealth = maxHealth;
            currentHealth = maxHealth;
            UpdateInstability();
        }

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
            UpdateInstability();
            Destroy(bulletToRemove);
        }

        if(currentHealth <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }


    [SerializeField] TextMeshProUGUI instabilityText;

    private void UpdateInstability()
    {
        float percentage = (float)currentHealth / (float)currentMaxHealth * 100f;
        instabilityText.text = $"DRIVER_INSTABILITY: {percentage}%";

    }


}
