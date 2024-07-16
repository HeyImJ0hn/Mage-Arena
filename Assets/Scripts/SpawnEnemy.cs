using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {
    public GameManager gm;
    public Transform[] spawnPoints;
    public GameObject[] enemyList;
    // 0 Slime, 1 Goblin, 2 Skeleton, 3 Mage

    public float timeBetweenSpawns = 1f;

    public static int mobsSpawned = 0;
    public static int mobsKilled = 0;

    public bool spawned = false;

    private void Start() {
        mobsSpawned = 0;
        mobsKilled = 0;
    }

    private void Update() {
    }


    public IEnumerator SpawnEnemies(int wave) {
        int mobsToSpawn = wave * 2 + 4;
        
        while (mobsSpawned < mobsToSpawn) {
            yield return new WaitForSeconds(timeBetweenSpawns);
            float rnd = Random.Range(0, 100);
            if (gm.wave > 2 && gm.wave <= 4) {
                if (rnd > 50)
                    Instantiate(enemyList[0], spawnPoints[Random.Range(0, spawnPoints.Length - 1)].position, Quaternion.identity);
                else
                    Instantiate(enemyList[1], spawnPoints[Random.Range(0, spawnPoints.Length - 1)].position, Quaternion.identity);
            } else if (gm.wave > 4 && gm.wave <= 5) {
                if (rnd > 50)
                    Instantiate(enemyList[0], spawnPoints[Random.Range(0, spawnPoints.Length - 1)].position, Quaternion.identity);
                else if (rnd > 20 && rnd <= 50)
                    Instantiate(enemyList[1], spawnPoints[Random.Range(0, spawnPoints.Length - 1)].position, Quaternion.identity);
                else if (rnd <= 20)
                    Instantiate(enemyList[2], spawnPoints[Random.Range(0, spawnPoints.Length - 1)].position, Quaternion.identity);
            } else if (gm.wave > 5) {
                if (rnd > 85)
                    Instantiate(enemyList[0], spawnPoints[Random.Range(0, spawnPoints.Length - 1)].position, Quaternion.identity);
                else if (rnd > 40 && rnd <= 85)
                    Instantiate(enemyList[1], spawnPoints[Random.Range(0, spawnPoints.Length - 1)].position, Quaternion.identity);
                else if (rnd > 5 && rnd <= 40)
                    Instantiate(enemyList[2], spawnPoints[Random.Range(0, spawnPoints.Length - 1)].position, Quaternion.identity);
                else if (rnd <= 5)
                    Instantiate(enemyList[3], spawnPoints[Random.Range(0, spawnPoints.Length - 1)].position, Quaternion.identity);
            } else if (gm.wave > 6) {
                if (rnd > 95)
                    Instantiate(enemyList[0], spawnPoints[Random.Range(0, spawnPoints.Length - 1)].position, Quaternion.identity);
                else if (rnd > 60 && rnd <= 95)
                    Instantiate(enemyList[1], spawnPoints[Random.Range(0, spawnPoints.Length - 1)].position, Quaternion.identity);
                else if (rnd > 10 && rnd <= 60)
                    Instantiate(enemyList[2], spawnPoints[Random.Range(0, spawnPoints.Length - 1)].position, Quaternion.identity);
                else if (rnd <= 10)
                    Instantiate(enemyList[3], spawnPoints[Random.Range(0, spawnPoints.Length - 1)].position, Quaternion.identity);
            } else
                Instantiate(enemyList[0], spawnPoints[Random.Range(0, spawnPoints.Length - 1)].position, Quaternion.identity);
            mobsSpawned++;
        }
        spawned = true;
    }
}