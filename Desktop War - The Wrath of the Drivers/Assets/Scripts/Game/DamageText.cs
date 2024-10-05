using System.Collections;
using TMPro;
using UnityEngine;

public class DamageText : MonoBehaviour
{
    [SerializeField] float xRandomSpawnPositionMin, xRandomSpawnPositionMax, yRandomSpawnPositionMin, yRandomSpawnPositionMax, zRandomSpawnPositionMin, zRandomSpawnPositionMax;


    void Start()
    {
        StartCoroutine(DestroyDamageText());
    }

    private IEnumerator DestroyDamageText()
    {
        yield return new WaitForSeconds(1.59f);
        Destroy(gameObject);
    }


    public void SetupText(int damage, Color color)
    {
        TextMeshProUGUI damageText = transform.Find("Text").GetComponent<TextMeshProUGUI>();

        damageText.text = damage.ToString();
        damageText.color = color;

        float randomSpawnPostionX = Random.Range(xRandomSpawnPositionMin, xRandomSpawnPositionMax);
        float randomSpawnPostionY = Random.Range(yRandomSpawnPositionMin, yRandomSpawnPositionMax);
        float randomSpawnPostionZ = Random.Range(zRandomSpawnPositionMin, zRandomSpawnPositionMax);

        transform.localPosition = new Vector3(randomSpawnPostionX, randomSpawnPostionY, randomSpawnPostionZ);
    }



}
