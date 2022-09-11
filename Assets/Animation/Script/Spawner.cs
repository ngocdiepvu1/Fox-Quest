using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemies;
    public float spawnDelay = 3.0f;
    public float spawnTime = 3.0f;
    private int enemyIndex;
    private Vector3 tempPos;
    public GameObject instance;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", spawnDelay, spawnTime);
    }

    // Update is called once per frame
    void Spawn()
    {
        enemyIndex = Random.Range(0, enemies.Length);

        tempPos = transform.position;
        tempPos.x += transform.position.x * Random.Range(-1.0f,1.0f);
        transform.position = tempPos;

        instance = Instantiate(enemies[enemyIndex], transform.position, transform.rotation);
    }
}
