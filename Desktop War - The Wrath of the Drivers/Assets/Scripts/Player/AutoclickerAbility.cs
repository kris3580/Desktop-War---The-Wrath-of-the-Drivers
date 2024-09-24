using UnityEngine;

public class AutoclickerAbility : MonoBehaviour
{

    [SerializeField] float abilityDelay = 0.5f;
    private float timePassed = 0;
    public bool isAbilityActive = true;
    private PlayerTools playerTools;

    [SerializeField] float outerValue;
    GameObject cursorPrefab;
    [SerializeField] float cursorSpeed;

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

        if (Input.GetMouseButton(0) && timePassed <= 0)
        {
            timePassed = abilityDelay;
            ShootCursor();
        }
    }


    private void ShootCursor()
    {
        GameObject objectCursor = Instantiate(cursorPrefab, transform.position + (playerTools.GetCursorToWorldPlanePosition() - transform.position).normalized * outerValue, Quaternion.Euler(-90,0,0));
        AutoclickerCursor autoclickerCursor = objectCursor.GetComponent<AutoclickerCursor>();
        autoclickerCursor.speed = cursorSpeed;
        autoclickerCursor.moveDirection = (playerTools.GetCursorToWorldPlanePosition() - transform.position).normalized;

    }


    private void OnDrawGizmos()
    {
        
        if (playerTools != null)
        {
            Gizmos.color = Color.cyan;

            Gizmos.DrawSphere(transform.position, 0.1f);

            Gizmos.DrawSphere(playerTools.GetCursorToWorldPlanePosition(), 0.1f);

            Vector3 outerVector = transform.position + (playerTools.GetCursorToWorldPlanePosition() - transform.position).normalized * outerValue;
            Gizmos.DrawSphere(outerVector, 0.1f);
        }
    }

}
