using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    
    
    [SerializeField]
    private float spawnRate = 1f;

    [SerializeField]
    private GameObject[] enemyPrefab;
    

    [SerializeField]
    private bool canSpawnEnemy = true;
   

    [SerializeField]
    private int spawnNum = 0;

    public void Start()
    {
        if (canSpawnEnemy == true)
        {
            StartCoroutine(Spawner());
        }

    }    
        
    

    private IEnumerator Spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);

        while(canSpawnEnemy == true)
        {
            yield return wait;

            int rand = Random.Range(0, enemyPrefab.Length);
            GameObject enemyToSpawn = enemyPrefab[rand];

            Instantiate(enemyToSpawn, transform.position, Quaternion.identity);

            spawnNum++;

            if (spawnNum >= 2)
            {
                canSpawnEnemy = false;
            }


        }


    }

    public void NewWave()
    {
        Debug.Log("NewWave");
        spawnNum = 0;
        canSpawnEnemy = true;
        Start();
    }

}
