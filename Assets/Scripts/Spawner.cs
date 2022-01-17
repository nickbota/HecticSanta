using UnityEngine;
using DG.Tweening;
using System.Collections;

public class Spawner : MonoBehaviour
{
    [Header("Spawn Objects")]
    [SerializeField] private GameObject gift;
    [SerializeField] private GameObject heart;
    [SerializeField] private GameObject bomb;

    [Header("Parameters")]
    [SerializeField] private float acceleration;
    [SerializeField] private float maxDelay;
    [SerializeField] private float minDelay;
    [SerializeField] private float edgeSpawnPosition;
    private float delay;
    private bool stopSpawning;

    private void Awake()
    {
        delay = maxDelay;
    }

    private void OnEnable()
    {
        StartCoroutine(Subscribe());
    }
    private void OnDisable()
    {
        GameEvents.instance.OnGameStart -= Spawn;
        GameEvents.instance.OnGameOver -= StopSpawn;
    }
    private IEnumerator Subscribe()
    {
        yield return new WaitUntil(() => GameEvents.instance != null);
        GameEvents.instance.OnGameStart += Spawn;
        GameEvents.instance.OnGameOver += StopSpawn;
    }

    private void Spawn()
    {
        if (stopSpawning) return;

        delay -= acceleration;
        delay = Mathf.Clamp(delay, minDelay, maxDelay);

        float posX = Random.Range(-edgeSpawnPosition, edgeSpawnPosition);
        Vector3 spawnPosition = new Vector3(posX, transform.position.y, transform.position.z);
        GameObject spawnedGift = Instantiate(gift, spawnPosition, Quaternion.identity, transform);
        spawnedGift.transform.DOMoveY(0, delay);

        Invoke(nameof(Spawn), delay);
    }
    private void StopSpawn()
    {
        stopSpawning = true;
    }
}