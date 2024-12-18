using UnityEngine;

public class WaveEmitterWave: MonoBehaviour
{

    public Vector3 moveDirection;
    public float speed;
    public float destroyTimer;

    public int baseDamage;
    public int extraDamage;


    private void Start()
    {
        transform.rotation = Quaternion.LookRotation(moveDirection);
    }

    void Update()
    {
        transform.position += moveDirection * Time.deltaTime * speed;
        
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

