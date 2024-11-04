using TMPro;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float moveSpeed = 5f;
    public static bool isFrozen = false;

    [SerializeField] Vector2 xClamp;
    [SerializeField] Vector2 yClamp;

    [SerializeField] TextMeshProUGUI controlsText;

    void Update()
    {
        MovementHandler();
        MovementStatusTextHandler();
    }

    private void MovementStatusTextHandler()
    {
        if (!isFrozen) controlsText.text = "DRIVER_CONTROLS: OPERATIONAL";
        else controlsText.text = "DRIVER_CONTROLS: DOWN";
    }

    private void MovementHandler()
    {
        if (isFrozen) return;
        
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector3 newPosition = transform.position + new Vector3(moveX, moveY, 0).normalized * moveSpeed * Time.deltaTime;

        newPosition.x = Mathf.Clamp(newPosition.x, xClamp.x, xClamp.y);
        newPosition.y = Mathf.Clamp(newPosition.y, yClamp.x, yClamp.y);

        transform.position = newPosition;
    }


}
