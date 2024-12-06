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

    [SerializeField] Color damageTextColor;

    private Memory memory;


    private void Start()
    {
        damageTextPrefab = Resources.Load<GameObject>("DamageText");
        canvas = transform.Find("EnemyCanvas").gameObject.GetComponent<Canvas>();
        maxHealth = currentHealth;
        memory = FindObjectOfType<Memory>();

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
                RemoveHealth(other.GetComponent<AutoclickerCursor>().GetDamage(), true);
            }
            else if (other.GetComponent<SpamMail>() != null)
            {
                RemoveHealth(other.GetComponent<SpamMail>().GetDamage(), false);
            }
            else if (other.GetComponent<WaveEmitterWave>() != null)
            {
                RemoveHealth(other.GetComponent<WaveEmitterWave>().GetDamage(), false);
            }
        }
    }
    

    private void RemoveHealth(int healthToRemove, bool toIgnoreHealthRemovalTimer)
    {
        if ((currentDelayHealthRemovalTimer <= 0 || toIgnoreHealthRemovalTimer) && isSystemActive)
        {
            currentHealth -= healthToRemove;
            currentDelayHealthRemovalTimer = delayHealthRemovalTimer;
            SFXHandler.Instance.Play(6);
            SpawnDamageText(healthToRemove);
            DamagePerSecond.AddToDPSCounter(healthToRemove);

        }

        if (currentHealth <= 0)
        {
            SFXHandler.Instance.Play(18);
            Store.AddCoins(UnityEngine.Random.Range(2, 7));

            if (UnityEngine.Random.Range(0, 10) == 0) memory.AddMemory(1);

            Destroy(gameObject);
            
        }
    }

    private void SpawnDamageText(int healthToRemove)
    {
        GameObject damageText = Instantiate(damageTextPrefab, canvas.transform);
        damageText.GetComponent<DamageText>().SetupText(healthToRemove, damageTextColor);
    }
}
