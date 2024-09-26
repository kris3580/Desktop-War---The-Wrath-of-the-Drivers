using UnityEngine;

public class AltFInfintyAbility : MonoBehaviour
{

    public bool isAbilityActive;
    private HealthSystem healthSystem;
    private Movement movement;

    [SerializeField] float changedSpeed;
    [SerializeField] float abilityDuration;
    private float abilityDurationTimer = 0f;

    private float previousSpeed;

    [SerializeField] float delayAbilityTimer;
    float currentAbilityTimer = 0f;
    private bool isAbilityCurrentlyInUse = false;

    private void Start()
    {
        healthSystem = GetComponent<HealthSystem>();
        movement = GetComponent<Movement>();

        previousSpeed = movement.moveSpeed;
    }

    private void Update()
    {
        currentAbilityTimer -= Time.deltaTime;

        if (currentAbilityTimer <= 0 && isAbilityActive && Input.GetMouseButtonDown(1))
        {
            currentAbilityTimer = delayAbilityTimer;
            movement.moveSpeed = changedSpeed;
            healthSystem.isSystemActive = false;
            isAbilityCurrentlyInUse = true;
        }

        if (isAbilityCurrentlyInUse)
        {
            abilityDurationTimer -= Time.deltaTime;
        }

        if (abilityDurationTimer <= 0)
        {
            isAbilityCurrentlyInUse = false;
            movement.moveSpeed = previousSpeed;
            healthSystem.isSystemActive = true;
            abilityDurationTimer = abilityDuration;
        }
    }
}
