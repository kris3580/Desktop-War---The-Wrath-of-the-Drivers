using UnityEngine;

public class TeleportationAbility : MonoBehaviour
{

    [SerializeField] public float abilityDelay = 5f;
    public float timePassed = 0;
    public bool isAbilityActive = true;
    private PlayerTools playerTools;
    [SerializeField] public LineRenderer lineRenderer;


    private void Start()
    {
        lineRenderer.transform.gameObject.SetActive(true);
        playerTools = GetComponent<PlayerTools>();
    }


    private void Update()
    {
        TeleportationHandler();
        TeleportationLineHandler();

    }

    private void TeleportationHandler()
    {
        if (!isAbilityActive) return;

        timePassed -= Time.deltaTime;

        if (Input.GetMouseButtonDown(1) && timePassed <= 0 && !Pause.isPaused)
        {
            timePassed = abilityDelay;

            Vector3 newPosition = playerTools.GetCursorToWorldPlanePosition();
            
            PlayerAnimations.isDefending = true;
            SFXHandler.Instance.Play(24);
            transform.position = newPosition;
        }
    }
    private void TeleportationLineHandler()
    {

        if (Pause.isPaused || Store.isInStore || Movement.isFrozen)
        {
            lineRenderer.enabled = false;
            return;
        }

        if(timePassed <= 0)
        {
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, playerTools.GetCursorToWorldPlanePosition());
        }
        else
        {
            lineRenderer.enabled = false;
        }
    }
}
