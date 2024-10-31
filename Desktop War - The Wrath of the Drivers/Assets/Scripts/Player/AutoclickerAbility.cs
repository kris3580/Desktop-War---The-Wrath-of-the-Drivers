using UnityEngine;

public class AutoclickerAbility : MonoBehaviour
{

    [SerializeField] public float abilityDelay = 0.5f;
    public float timePassed = 0;
    public bool isAbilityActive = true;
    private PlayerTools playerTools;

    [SerializeField] float outerValue;
    GameObject cursorPrefab;
    [SerializeField] float cursorSpeed;
    [SerializeField] float destroyCursorTimer;
    [SerializeField] public int damage;

    private void Start()
    {
        playerTools = GetComponent<PlayerTools>();
        cursorPrefab = Resources.Load<GameObject>("Autoclicker_Cursor");
    }

    private void Update()
    {
        AutoclickerHandler();
    }

    private void AutoclickerHandler()
    {
        if (!isAbilityActive) return;

        timePassed -= Time.deltaTime;

        if (Input.GetMouseButton(0) && timePassed <= 0 && !Pause.isPaused)
        {
            timePassed = abilityDelay;
            ShootCursor();
        }
    }


    private void ShootCursor()
    {
        GameObject objectCursor = Instantiate(cursorPrefab, transform.position + (playerTools.GetCursorToWorldPlanePosition() - transform.position).normalized * outerValue, Quaternion.Euler(-90,0,0));
        AutoclickerCursor autoclickerCursor = objectCursor.GetComponent<AutoclickerCursor>();
        autoclickerCursor.baseDamage = damage;
        autoclickerCursor.speed = cursorSpeed;
        autoclickerCursor.moveDirection = (playerTools.GetCursorToWorldPlanePosition() - transform.position).normalized;
        autoclickerCursor.destroyTimer = destroyCursorTimer;
    }
}
