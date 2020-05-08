using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    public GameObject fruit;
    public Transform[] SpawnPoints;
    public float  minDelay = 0.1f;
    public float maxDelay = 1f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnFruits());
    }

    IEnumerator SpawnFruits()
    {
        while (true)
        {
            float Delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(Delay);

            int spawnIndex = Random.Range(0, SpawnPoints.Length);
            Transform spawner = SpawnPoints[spawnIndex];

           GameObject SpawnedFruit = Instantiate(fruit, spawner.position, spawner.rotation);
            Destroy(SpawnedFruit, 4f);
        }
    }
}
