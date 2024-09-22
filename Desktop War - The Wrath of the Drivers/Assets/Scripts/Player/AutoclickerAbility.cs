using UnityEngine;

public class AutoclickerAbility : MonoBehaviour
{

    [SerializeField] float abilityDelay = 0.5f;
    private float timePassed = 0;
    public bool isAbilityActive = true;
    private PlayerTools playerTools;


    private void Start()
    {
        playerTools = GetComponent<PlayerTools>();
    }



    private void Update()
    {
        AutoclickerHandler();
    }

    private void AutoclickerHandler()
    {
        if (!isAbilityActive) return;

        timePassed -= Time.deltaTime;

        if (Input.GetMouseButton(0) && timePassed <= 0)
        {
            timePassed = abilityDelay;

        }
    }




}
