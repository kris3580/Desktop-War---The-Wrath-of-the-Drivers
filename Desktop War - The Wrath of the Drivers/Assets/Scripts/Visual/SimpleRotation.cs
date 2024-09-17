using UnityEngine;

public class SimpleRotation : MonoBehaviour
{

    [SerializeField] private float x, y, z;

    void Update()
    {
        transform.Rotate(x * Time.deltaTime, y * Time.deltaTime, z * Time.deltaTime) ;
    }
}
