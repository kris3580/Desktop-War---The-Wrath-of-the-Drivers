using Unity.VisualScripting;
using UnityEngine;

public class ClippyFollow : MonoBehaviour
{
    
    [SerializeField] private float distanceToKeep;
    [SerializeField] private float followSpeed;
    [SerializeField] private float offsetFromPlayer;

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject storagePoint;
    [SerializeField] private GameObject outOfBoundsPoint;
    [SerializeField] private GameObject storePoint;

    private GameObject target;
    private Vector3 spawnPoint;
    [SerializeField] private MeshRenderer modelRenderer;


    private void Start()
    {
        spawnPoint = transform.position;
        GoToSpawnpoint();
    }

    private void Update()
    {
        if (target == null) return;

        if (Vector3.Distance(transform.position, target.transform.position) >= distanceToKeep)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, followSpeed * Time.deltaTime);
        }
    }

    public void SetClippyPositionNextToPlayer()
    {
        transform.position = new Vector3(player.transform.position.x - 1, player.transform.position.y - 1, player.transform.position.z); ;
    }

    public void SetFollowPlayer()
    {
        modelRenderer.enabled = true;
        target = player;
    }

    public void MoveToStorage()
    {
        target = storagePoint;
    }

    public void MoveOutOfBounds()
    {
        target = outOfBoundsPoint;
    }

    public void MoveNextToStore()
    {
        target = storePoint;
    }

    public void GoToSpawnpoint()
    {
        modelRenderer.enabled = false;
        target = null;
        transform.position = spawnPoint;
    }




}
