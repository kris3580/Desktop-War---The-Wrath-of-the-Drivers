using System.Collections;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public enum PatternType { Line, Circle, FourWaySpiral }
    [SerializeField] PatternType patternType;

    private GameObject bulletPrefab;
    [SerializeField] float fireRate = 1f;
    [SerializeField] int bulletCount = 10;
    [SerializeField] float bulletSpeed = 5f;
    [SerializeField] float spiralAngleStep = 15f;

    private float angleOffset = 0f;     


    private void Start()
    {
        bulletPrefab = Resources.Load<GameObject>("Bullet");
        StartCoroutine(SpawnBullets());
    }

    IEnumerator SpawnBullets()
    {
        while (true)
        {
            switch (patternType)
            {
                case PatternType.Line:
                    SpawnLinePattern();
                    break;
                case PatternType.Circle:
                    SpawnCirclePattern();
                    break;
                case PatternType.FourWaySpiral:
                    SpawnFourWaySpiralPattern();
                    break;
            }
            yield return new WaitForSeconds(1f / fireRate);
        }
    }

    void SpawnLinePattern()
    {
        for (int i = 0; i < bulletCount; i++)
        {
            Vector3 spawnPosition = transform.position + new Vector3(i * 0.5f, 0, 0);
            GameObject bullet = Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);
            bullet.GetComponent<Bullet>().SetDirection(Vector3.right, bulletSpeed);
        }
    }

    void SpawnCirclePattern()
    {
        // Instantiate bullets in a circular pattern
        for (int i = 0; i < bulletCount; i++)
        {
            float angle = i * Mathf.PI * 2f / bulletCount; 
            Vector3 spawnDir = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0); 
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity); 
            bullet.GetComponent<Bullet>().SetDirection(spawnDir, bulletSpeed); 
        }
    }

    void SpawnFourWaySpiralPattern()
    {
        for (int i = 0; i < 4; i++)
        {
            float angle = (i * 90f + angleOffset) * Mathf.Deg2Rad;
            Vector3 spawnDir = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0);
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.GetComponent<Bullet>().SetDirection(spawnDir, bulletSpeed);
        }

        angleOffset += spiralAngleStep;
    }
}
