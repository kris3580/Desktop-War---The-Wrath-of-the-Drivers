using UnityEngine;

public class SpamAbility : MonoBehaviour
{

    public bool isAbilityActive;
    private PlayerTools playerTools;
    private GameObject spamPrefab;

    [SerializeField] float abilityDelay;
    private float timePassed = 0f;

    [SerializeField] float xSpawnOffset;
    [SerializeField] float spamMailSpeed;
    [SerializeField] float destroyTimer;

    private void Start()
    {
        playerTools = GetComponent<PlayerTools>();
        spamPrefab = Resources.Load<GameObject>("Spam_Mail");
    }


    private void Update()
    {
        SpamAbilityHandler();

    }

    private void SpamAbilityHandler()
    {

        if (!isAbilityActive) return;

        timePassed -= Time.deltaTime;

        if (Input.GetMouseButton(0) && timePassed <= 0)
        {
            timePassed = abilityDelay;
            ShootMail();
        }
    }

    private void ShootMail()
    {
        GameObject objectSpamMail = Instantiate(spamPrefab, playerTools.GetSpamMailSpawnPosition(xSpawnOffset), Quaternion.Euler(-90, 0, 0));
        SpamMail spamMail = objectSpamMail.GetComponent<SpamMail>();
        spamMail.direction = playerTools.GetSpamMailSpawnDirection();
        spamMail.speed = spamMailSpeed;
        spamMail.destroyTimer = destroyTimer;
    }

    



}