using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardModelKeys : MonoBehaviour
{
    [SerializeField] List<GameObject> keys;
    [SerializeField] Material originalMaterial;
    [SerializeField] Material replacedMaterial;

    private void Update()
    {
        UpdateKeyMaterial(0, KeyCode.W);
        UpdateKeyMaterial(1, KeyCode.A);
        UpdateKeyMaterial(2, KeyCode.S);
        UpdateKeyMaterial(3, KeyCode.D);
    }

    private void UpdateKeyMaterial(int keyIndex, KeyCode keyCode)
    {
        MeshRenderer renderer = keys[keyIndex].GetComponent<MeshRenderer>();

        Material[] materials = renderer.materials;

        materials[1] = Input.GetKey(keyCode) ? replacedMaterial : originalMaterial;

        renderer.materials = materials;
    }
}