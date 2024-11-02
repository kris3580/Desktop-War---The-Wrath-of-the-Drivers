using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseModelKeys : MonoBehaviour
{
    [SerializeField] List<GameObject> keys;
    [SerializeField] Material originalMaterial;
    [SerializeField] Material replacedMaterial;

    private void Update()
    {
        UpdateKeyMaterial(0, 0);
        UpdateKeyMaterial(1, 1);
    }

    private void UpdateKeyMaterial(int keyIndex, int keyCode)
    {
        MeshRenderer renderer = keys[keyIndex].GetComponent<MeshRenderer>();

        Material[] materials = renderer.materials;

        materials[0] = Input.GetMouseButton(keyCode) ? replacedMaterial : originalMaterial;

        renderer.materials = materials;
    }
}