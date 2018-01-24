using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public int waitTime;
    public int enemyCount;
    public int spawnWait;
    public Vector3 spawnValues;
    public GameObject enemy;

    private void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(waitTime);

        for (int i = 0; i < enemyCount; i++)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
            Instantiate(enemy, spawnPosition, enemy.transform.rotation);
            yield return new WaitForSeconds(spawnWait);
        }
    }
}
