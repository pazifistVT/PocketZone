using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyConrol : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] int spawnRadius = 4;
    GameObject[] enemies;
    MonsterControl[] monsterControls;

    void Start()
    {
        enemies = new GameObject[10];
        monsterControls = new MonsterControl[10];
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i] = Instantiate(enemyPrefab);
            monsterControls[i] = enemies[i].GetComponent<MonsterControl>();
            enemies[i].SetActive(false);
        }

        SpawnEnemy();
    }

    public void SpawnEnemy()
    {
        for (int i = 0; i < 3; i++)
        {
            enemies[i].SetActive(true);
            Vector3 pos = new Vector3(Random.Range(-spawnRadius, spawnRadius), Random.Range(-spawnRadius, spawnRadius), 0);
            monsterControls[i].SpawnMonster(pos);
        }
    }
}
