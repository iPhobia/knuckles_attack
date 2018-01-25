using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class EnemySpawnValues
{
    public int waitTime;
    public int enemyCount;
    public int spawnWait;
    public int waveSpawnWait;
    public List<GameObject> spawnPoints = new List<GameObject>();
    public List<GameObject> enemies = new List<GameObject>();
}

public class GameController : MonoBehaviour {

    public EnemySpawnValues spawnValues;
    public Text healthText;
    public Text armourText;
    public Text gameOverText;
    public Text restartText;

    private GameObject[] activeEnemies;
    private PlayerHealthManager healthValues;
    private bool gameOver;
    private bool restart;

    private void Start()
    {
        healthValues = FindObjectOfType<PlayerHealthManager>();
        healthText.text = "Health: " + healthValues.health;
        armourText.text = "Armour: " + healthValues.armour;
        restartText.text = "";
        gameOverText.text = "";
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        
        yield return new WaitForSeconds(spawnValues.waitTime);
        while (true)
        {
            for (int i = 0; i < spawnValues.enemyCount; i++)
            {
                GameObject spawnPoint = spawnValues.spawnPoints[Random.Range(0, spawnValues.spawnPoints.Count)];
                GameObject enemy = spawnValues.enemies[Random.Range(0, spawnValues.enemies.Count)];
                Vector3 spawnCordinates = spawnPoint.transform.position;
                Instantiate(enemy, spawnCordinates, enemy.transform.rotation);
                yield return new WaitForSeconds(spawnValues.spawnWait);
            }

            yield return new WaitForSeconds(spawnValues.waveSpawnWait);

            if (gameOver)
            {
                healthText.text = "";
                armourText.text = "";
                restartText.text = "Press R to restart the game";
                restart = true;
                activeEnemies = GameObject.FindGameObjectsWithTag("Enemy");
                foreach (GameObject objectToDestroy in activeEnemies)
                {
                    Destroy(objectToDestroy);
                }

                break;
            }
        }
    }

    private void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Main");
            }
        }
    }

    public void UpdateValues()
    {
        healthText.text = "Health: " + healthValues.health;
        armourText.text = "Armour: " + healthValues.armour;
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over";
        gameOver = true;
    }
}
