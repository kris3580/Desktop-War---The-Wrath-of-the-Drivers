using UnityEngine;

public class PFeedbackAbility : MonoBehaviour
{
    public bool isAbilityActive = true;

    [SerializeField] float abilityDelay;
    private float timePassed = 0f;
    Collider shieldCollider;
    public static bool isShiledCurrentlyInUse = false;

    private float abilityDurationTimer = 0f;
    [SerializeField] float abilityDuration;

    private void Start()
    {
        shieldCollider = GameObject.Find("PositiveFeedbackShield").GetComponent<Collider>();
    }


    private void Update()
    {
        shieldCollider.gameObject.transform.position = transform.position;

        if (!isAbilityActive) return;

        timePassed -= Time.deltaTime;

        if (Input.GetMouseButtonDown(1) && timePassed <= 0)
        {
            isShiledCurrentlyInUse = true;
            timePassed = abilityDelay;
        }

        if (isShiledCurrentlyInUse)
        {
            abilityDurationTimer -= Time.deltaTime;
        }

        if (abilityDurationTimer <= 0)
        {
            isShiledCurrentlyInUse = false;
            abilityDurationTimer = abilityDuration;
        }
    }
}