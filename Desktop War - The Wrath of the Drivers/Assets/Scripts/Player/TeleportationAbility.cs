using UnityEngine;

public class TeleportationAbility : MonoBehaviour
{

    [SerializeField] float abilityDelay = 5f;
    private float timePassed = 0;
    public bool isAbilityActive = true;
    private PlayerTools playerTools;
    [SerializeField] LineRenderer lineRenderer;

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

        if (Input.GetMouseButtonDown(1) && timePassed <= 0)
        {
            timePassed = abilityDelay;

            Vector3 newPosition = playerTools.GetCursorToWorldPlanePosition();
            newPosition.z = 4.24f;

            transform.position = newPosition;
        }
    }
    private void TeleportationLineHandler()
    {
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, playerTools.GetCursorToWorldPlanePosition());
    }



   
}
