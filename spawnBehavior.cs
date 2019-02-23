using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnBehavior : MonoBehaviour
{
    public GameObject enemy;

    public int maxEnemies;
    public int enemiesCount;

    int spawnerCount;
    int currentSpawner;

    public Transform[] spawners;

    // Start is called before the first frame update
    void Start()
    {
        enemiesCount = 0;
        spawnerCount = spawners.Length;
    }

    // Update is called once per frame
    void Update()
    {
        currentSpawner = Random.Range(0, spawnerCount);

        enemiesCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (enemiesCount < maxEnemies)
        {
            Instantiate(enemy, spawners[currentSpawner].position, spawners[currentSpawner].rotation);
        }
    }
}
