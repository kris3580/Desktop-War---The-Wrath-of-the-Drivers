using UnityEngine;

public class SpamMail : MonoBehaviour
{

    public bool direction;
    public float speed;
    public float destroyTimer;

    [SerializeField] public int baseDamage;
    public int extraDamage;


    void Update()
    {

        if (direction == true)
        {
            transform.position += Vector3.right * Time.deltaTime * speed;
        }
        else
        {
            transform.position += Vector3.left * Time.deltaTime * speed;
        }

        
        destroyTimer -= Time.deltaTime;

        if (destroyTimer <= 0)
        {
            Destroy(gameObject);
        }
    }

    public int GetDamage()
    {
        int randomPercentageIndex = Random.Range(0, 10);
        int randomPercentage = 0;

        if (0 <= randomPercentageIndex && randomPercentageIndex <= 5) randomPercentage = 25;
        else if (6 <= randomPercentageIndex && randomPercentageIndex <= 9) randomPercentage = 50;
        else if (randomPercentageIndex == 10) randomPercentage = 100;

        int damage = Random.Range(baseDamage + extraDamage, baseDamage + extraDamage + (baseDamage + extraDamage) * randomPercentage / 100);

        return damage;
    }




}
