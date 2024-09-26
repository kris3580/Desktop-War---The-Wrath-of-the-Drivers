using UnityEngine;

public class PlayerTools : MonoBehaviour
{
    [SerializeField] LayerMask layerToHit;

    public Vector3 GetCursorToWorldPlanePosition()
    {
        Vector3 screenPosition = Input.mousePosition;
        Vector3 worldPosition = new Vector3(0, 0, 4.3f);
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);

        if (Physics.Raycast(ray, out RaycastHit hitData, 100, layerToHit))
        {
            worldPosition = hitData.point;
            worldPosition.z = 4.24f;
        }

        return worldPosition;
    }


    public Vector3 GetSpamMailSpawnPosition(float offset)
    {
        Vector3 spawnPostion = transform.position;

        if (GetCursorToWorldPlanePosition().x < transform.position.x)
        {
            spawnPostion.x -= offset;
        }
        else
        {
            spawnPostion.x += offset;
        }
        return spawnPostion;
    }


    public bool GetSpamMailSpawnDirection()
    {
        if (GetCursorToWorldPlanePosition().x < transform.position.x)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

}
