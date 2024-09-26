using UnityEngine;

public class WaveEmitterAbility : MonoBehaviour
{
    [SerializeField] float abilityDelay = 1f;
    private float timePassed = 0;
    public bool isAbilityActive = true;
    private GameObject wavePrefab;


    private void Start()
    {
        wavePrefab = Resources.Load<GameObject>("WaveEmitter_Wave");
    }


    private void Update()
    {
        if (!isAbilityActive) return;

        timePassed -= Time.deltaTime;

        if (Input.GetMouseButton(0) && timePassed <= 0)
        {
            timePassed = abilityDelay;

            ShootWave();

        }
    }


    private void ShootWave()
    {
        //GameObject waveObject = Instantiate(wavePrefab, GetSpamMailSpawnPosition(xSpawnOffset), Quaternion.Euler(-90, 0, 0));
        //SpamMail spamMail = objectSpamMail.GetComponent<SpamMail>();
        //spamMail.direction = GetSpamMailSpawnDirection();
    }

}
