using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{

    [SerializeField] GameObject playerModelsObject;
    [SerializeField] float leanRotationValue;

    [SerializeField] float defensiveRotationDuration;

    public static bool isDefending;

    public static bool isGettingHit;
    [SerializeField] List<Material> playerModelsMaterials;
    [SerializeField] List<GameObject> playerModels;

    [SerializeField] Material onHitMaterial;
    [SerializeField] float onHitSwitchColorsTime;
    [SerializeField] int onHitSwitchColorsTimes;


    private Vector3 rotation;
    private void Update()
    {
        LeanHandler();
        DefenseSpinHandler();
        HitHandler();
    }



    private void HitHandler()
    {
        if (isGettingHit)
        {
            isGettingHit = false;

            StartCoroutine(OnHitAnimation());

        }
    }

    IEnumerator OnHitAnimation()
    {
        for (int i = 0; i < onHitSwitchColorsTimes; i++)
        {
            OnHitSwitchMaterials(true);
            yield return new WaitForSeconds(onHitSwitchColorsTime);
            OnHitSwitchMaterials(false);
            yield return new WaitForSeconds(onHitSwitchColorsTime);
        }

        
    }



    private void OnHitSwitchMaterials(bool toSwitchToRed)
    {

        MeshRenderer renderer;
        Material[] materials;

        if (toSwitchToRed)
        {

            for (int i = 0; i < playerModels.Count; i++)
            {
                renderer = playerModels[i].GetComponent<MeshRenderer>();

                materials = renderer.materials;


                for (int j = 0; j < materials.Length; j++)
                {
                    materials[j] = onHitMaterial;
                }

                renderer.materials = materials;
            }
        }
        else
        {
            renderer = playerModels[0].GetComponent<MeshRenderer>();

            materials = renderer.materials;

            materials[0] = playerModelsMaterials[0];
            materials[1] = playerModelsMaterials[1];
            materials[2] = playerModelsMaterials[2];

            renderer.materials = materials;



            renderer = playerModels[1].GetComponent<MeshRenderer>();

            materials = renderer.materials;

            materials[0] = playerModelsMaterials[3];
            materials[1] = playerModelsMaterials[4];
            materials[2] = playerModelsMaterials[5];

            renderer.materials = materials;




            renderer = playerModels[2].GetComponent<MeshRenderer>();

            materials = renderer.materials;

            materials[0] = playerModelsMaterials[6];
            materials[1] = playerModelsMaterials[7];
            materials[2] = playerModelsMaterials[8];

            renderer.materials = materials;
        }

    }












    float currentDefenseRotationTime = 0;
    private void DefenseSpinHandler()
    {
        if (!isDefending) return;

        currentDefenseRotationTime += Time.deltaTime;
        
        float angle = Mathf.Lerp(0, 360, currentDefenseRotationTime / defensiveRotationDuration);

        rotation = playerModelsObject.transform.localEulerAngles;
        rotation.z = angle;
        playerModelsObject.transform.localEulerAngles = rotation;

        if (currentDefenseRotationTime >= defensiveRotationDuration)
        {
            currentDefenseRotationTime = 0f;
            isDefending = false;
        }

    }


    private void LeanHandler()
    {
        rotation = playerModelsObject.transform.localEulerAngles;

        if (Input.GetKey(KeyCode.D))
        {
            rotation.y = leanRotationValue;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rotation.y = -leanRotationValue;
        }
        else
        {
            rotation.y = 0;
        }

        playerModelsObject.transform.localEulerAngles = rotation;
    }
}
