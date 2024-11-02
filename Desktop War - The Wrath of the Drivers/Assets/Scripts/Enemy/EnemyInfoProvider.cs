using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyInfoProvider : MonoBehaviour
{
    private static EnemyHealth enemyHealth;

    private static Image healthRedFill;
    private static Image healthBlackFill;
    private static TextMeshProUGUI enemyInfoText;

    private static GameObject enemyDataUI;

    [SerializeField] bool isInitial;

    private void Start()
    {
        if (isInitial)
        {
            enemyDataUI = GameObject.Find("EnemyDataUI");
            healthRedFill = enemyDataUI.transform.Find("HealthRedFill").GetComponent<Image>();
            healthBlackFill = enemyDataUI.transform.Find("HealthBlackFill").GetComponent<Image>();
            enemyInfoText = enemyDataUI.transform.Find("EnemyInfoText").GetComponent<TextMeshProUGUI>();

            enemyDataUI.SetActive(false);
        }

    }

    private void Update()
    {
        if (enemyHealth != null)
        {
            if (enemyHealth.currentHealth <= 0)
            {
                enemyHealth = null;
                return;
            }

            enemyDataUI.SetActive(true);
            float healthPercentage = (float)enemyHealth.currentHealth / enemyHealth.maxHealth;
            healthRedFill.fillAmount = healthPercentage;
            healthBlackFill.fillAmount = 1 - healthPercentage;
            enemyInfoText.text = $"{enemyHealth.name} ({enemyHealth.currentHealth}/{enemyHealth.maxHealth})";
        }
        else
        {
            
            
            enemyDataUI.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerBullet")
        {
            enemyHealth = GetComponent<EnemyHealth>();
        }
    }
}
