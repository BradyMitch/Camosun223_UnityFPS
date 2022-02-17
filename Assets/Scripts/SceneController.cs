using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{

    [SerializeField] private GameObject enemyPrefab;
    private Vector3 spawnPoint = new Vector3(0, 0, 5);

    // multiple enemies
    private int numEnemies = 5;
    private GameObject[] enemies;

    private void Start()
    {
        enemies = new GameObject[numEnemies];
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i <enemies.Length; i++)
        {
            if (enemies[i] == null)
            {
                GameObject spawnableEnemy;

                spawnableEnemy = Instantiate(enemyPrefab) as GameObject;
                spawnableEnemy.transform.position = spawnPoint;
                float angle = Random.Range(0, 360);
                spawnableEnemy.transform.Rotate(0, angle, 0);

                enemies[i] = spawnableEnemy;
            }
        }
    }
}
