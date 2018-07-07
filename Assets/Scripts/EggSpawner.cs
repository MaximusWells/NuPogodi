using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggSpawner : MonoBehaviour {

    public GameObject egg;
    public GameObject[] spawnObjects = new GameObject[4];
    public GameObject goldenEgg;
    private float repeatRate;
    private int needToSpawn;

    private float incomingEgg = 0.0f;
    private float spawnRate = 1.5f;

    private void Start()
    {
        repeatRate = Mathf.Clamp(repeatRate, 1f, 90f); ;
        StartCoroutine(SpawnLifeEggRepeat(goldenEgg));
    }

    void Update()
    {
        needToSpawn = Random.Range(1, 10);
        if (incomingEgg < Time.time)
        {
            SpawnArr(spawnObjects);
            incomingEgg = Time.time + spawnRate;
            spawnRate *= 0.98f;
            spawnRate = Mathf.Clamp(spawnRate, 0.3f, 99f);
        }
    }

    public void SpawnArr(GameObject[] objectsToSpawn)
    {
        float spawnAt = Random.Range(-MainControlls.maxWidth, MainControlls.maxWidth);
        Vector2 spawnPos = new Vector2(spawnAt, transform.position.y);
        Instantiate(objectsToSpawn[Random.Range(0, objectsToSpawn.Length)], spawnPos, Quaternion.identity);
    }

    private IEnumerator SpawnLifeEggRepeat(GameObject objectToSpawn)
    {
        while (true)
        {
            SpawnSingle(objectToSpawn);
            yield return new WaitForSeconds(repeatRate);
        }
    }

    private void SpawnSingle(GameObject objectToSpawn)
    {
        if (needToSpawn == 1)
        {
            float spawnAt = Random.Range(-MainControlls.maxWidth, MainControlls.maxWidth);
            Vector2 spawnPos = new Vector2(spawnAt, transform.position.y);
            Instantiate(objectToSpawn, spawnPos, Quaternion.identity);
        }
    }
}
