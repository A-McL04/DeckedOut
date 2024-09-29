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
    private bool canSpawn = true;

    [SerializeField]
    private int spawnNum = 0;

    private void Start()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);

        while(canSpawn == true)
        {
            yield return wait;

            int rand = Random.Range(0, enemyPrefab.Length);
            GameObject enemyToSpawn = enemyPrefab[rand];

            Instantiate(enemyToSpawn, transform.position, Quaternion.identity);

            spawnNum++;

            if (spawnNum >= 2)
            {
                canSpawn = false;
            }

        }


    }

    

}
