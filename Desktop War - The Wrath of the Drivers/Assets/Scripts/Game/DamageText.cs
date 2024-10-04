using System.Collections;
using TMPro;
using UnityEngine;

public class DamageText : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(DestroyDamageText());
    }

    private IEnumerator DestroyDamageText()
    {
        yield return new WaitForSeconds(1.59f);
        Destroy(gameObject);
    }


    public void SetupText(int damage)
    {
        transform.Find("Text").GetComponent<TextMeshProUGUI>().text = damage.ToString();
        float randomSpawnPostionX = Random.Range(-0.4f, 0.6f);
        float randomSpawnPostionY = Random.Range(-0.3f, 0.5f);

        transform.localPosition = new Vector3(randomSpawnPostionX, randomSpawnPostionY, transform.localPosition.z);
    }



}
