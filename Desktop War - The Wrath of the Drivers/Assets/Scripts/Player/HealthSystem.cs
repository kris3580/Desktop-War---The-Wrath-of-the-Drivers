using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class HealthSystem : MonoBehaviour
{

    [SerializeField] public int currentHealth;
    public int maxHealth;
    [SerializeField] float delayHealthRemovalTimer;
    private float currentDelayHealthRemovalTimer = 0f;
    public bool isSystemActive = true;
    public int currentMaxHealth;

    private DialogueSystem dialogueSystem;
    private void Start()
    {
        currentMaxHealth = maxHealth;
        dialogueSystem = FindObjectOfType<DialogueSystem>();
    }

    private void Update()
    {
        currentDelayHealthRemovalTimer -= Time.deltaTime;

        if(currentMaxHealth != maxHealth)
        {
            currentMaxHealth = maxHealth;
            currentHealth = maxHealth;
            UpdateInstability(true);
        }

        UpdateInstability(false);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (dialogueSystem.isInDialogue) return;

        if (other.tag == "Bullet")
        {
            RemoveHealth(other.gameObject);
        }

        if (other.tag == "EnemyTouch")
        {
            RemoveHealth();
        }
    }


    private void RemoveHealth(GameObject bulletToRemove = null)
    {
        if (currentDelayHealthRemovalTimer <= 0 && isSystemActive)
        {
            currentHealth--;
            currentDelayHealthRemovalTimer = delayHealthRemovalTimer;
            if (currentHealth > 0) SFXHandler.Instance.Play(16, 0.5f);
            PlayerAnimations.isGettingHit = true;
            UpdateInstability(true);
            Destroy(bulletToRemove);
        }

        if(currentHealth <= 0)
        {
            SFXHandler.Instance.Play(7);
            OSTHandler.Instance.audioSource.Stop();
            SceneManager.LoadScene("GameOver");
        }
    }


    [SerializeField] TextMeshProUGUI stabilityText;
    private float timePassedForInstability = 0f;
    public float instabilityDefaultTime = 2f;

    private void UpdateInstability(bool updateInstantly)
    {
        timePassedForInstability += Time.deltaTime;

        float percentage = (float)currentHealth / (float)currentMaxHealth * 100f;
        percentage = (float)Math.Floor(percentage);

        int randomNumber = UnityEngine.Random.Range(0, 10);
        
        if (timePassedForInstability > instabilityDefaultTime || updateInstantly)
        {
            timePassedForInstability = 0;

            if (randomNumber == 0)
            {
                stabilityText.text = $"DRIVER_STABILITY: {percentage - 2}%";
            }
            else if (randomNumber >= 7)
            {
                stabilityText.text = $"DRIVER_STABILITY: {percentage - 1}%";
            }
            else
            {
                stabilityText.text = $"DRIVER_STABILITY: {percentage}%";
            }
        }
    }


    public void InvulnerabilityToggleHandler()
    {
        isSystemActive = !isSystemActive;
    }


}
