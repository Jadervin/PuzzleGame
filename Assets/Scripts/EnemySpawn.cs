using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawn : MonoBehaviour
{
    public Transform spawnPosition;
    public float minSpawnSec = 5, maxSpawnSec = 30;
    public GameObject enemyPrefab;

    public int MaxEnemies = 10;
    public Transform player;
    public float spawnEverySeconds;
    float secPassed = 0;
    //int lastEnemySpawn = -1;


    // Start is called before the first frame update
    private void Start()
    {
        
        spawnEverySeconds = Random.Range(minSpawnSec, maxSpawnSec);
    }

    // Update is called once per frame
    void Update()
    {
        secPassed += Time.deltaTime;

        if(secPassed>spawnEverySeconds)
        {
            secPassed = 0;
            
            GameObject temp=Instantiate(enemyPrefab, spawnPosition.position, enemyPrefab.transform.rotation);

            
        }
    }
}
