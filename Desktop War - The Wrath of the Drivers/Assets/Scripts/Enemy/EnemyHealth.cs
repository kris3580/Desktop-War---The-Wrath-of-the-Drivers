using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] public int currentHealth;
    public int maxHealth;
    [SerializeField] float delayHealthRemovalTimer;
    private float currentDelayHealthRemovalTimer = 0f;
    public bool isSystemActive = true;

    private GameObject damageTextPrefab;
    public Canvas canvas;

    private void Start()
    {
        damageTextPrefab = Resources.Load<GameObject>("DamageText");
        canvas = transform.Find("EnemyCanvas").gameObject.GetComponent<Canvas>();
    }

    private void Update()
    {
        currentDelayHealthRemovalTimer -= Time.deltaTime;
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "PlayerBullet")
        {
            if(other.GetComponent<AutoclickerCursor>() != null)
            {
                Destroy(other.gameObject);
                RemoveHealth(other.GetComponent<AutoclickerCursor>().GetDamage());
            }
            else if (other.GetComponent<SpamMail>() != null)
            {
                RemoveHealth(other.GetComponent<SpamMail>().GetDamage());
            }
            else if (other.GetComponent<WaveEmitterWave>() != null)
            {
                RemoveHealth(other.GetComponent<WaveEmitterWave>().GetDamage());
            }



        }
    }
    

    private void RemoveHealth(int healthToRemove)
    {
        if (currentDelayHealthRemovalTimer <= 0 && isSystemActive)
        {
            currentHealth -= healthToRemove;
            currentDelayHealthRemovalTimer = delayHealthRemovalTimer;

            SpawnDamageText(healthToRemove);

        }

        if (currentHealth <= 0)
        {
            // on death
        }
    }

    private void SpawnDamageText(int healthToRemove)
    {
        GameObject damageText = Instantiate(damageTextPrefab, canvas.transform);
        damageText.GetComponent<DamageText>().SetupText(healthToRemove);
    }
}
