using UnityEngine;

public class WaveEmitterAbility : MonoBehaviour
{
    [SerializeField] float abilityDelay = 1f;
    private float timePassed = 0;
    public bool isAbilityActive = true;
    private PlayerTools playerTools;

    [SerializeField] float outerValue;
    private GameObject wavePrefab;
    [SerializeField] float waveSpeed;
    [SerializeField] float destroyWaveTimer;

    private void Start()
    {
        playerTools = GetComponent<PlayerTools>();
        wavePrefab = Resources.Load<GameObject>("WaveEmitter_Wave");
    }


    private void Update()
    {
        WaveEmitterHandler();
    }

    private void WaveEmitterHandler()
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
        GameObject objectWave = Instantiate(wavePrefab, transform.position + (playerTools.GetCursorToWorldPlanePosition() - transform.position).normalized * outerValue, Quaternion.identity);
        WaveEmitterWave waveEmitterWave = objectWave.GetComponent<WaveEmitterWave>();
        waveEmitterWave.speed = waveSpeed;
        waveEmitterWave.moveDirection = (playerTools.GetCursorToWorldPlanePosition() - transform.position).normalized;
        waveEmitterWave.destroyTimer = destroyWaveTimer;
    }

}
