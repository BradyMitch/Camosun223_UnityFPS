using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{

    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject iguanaPrefab;

    private Vector3 spawnPoint = new Vector3(0, 0, 5);
    private Vector3 spawnPointIguana = new Vector3(0, 2.384186f, 18);

    // multiple enemies
    private int numEnemies = 5;
    private GameObject[] enemies;

    private int numIguanas = 7;
    private GameObject[] iguanas;

    private void Start()
    {
        enemies = new GameObject[numEnemies];
        iguanas = new GameObject[numIguanas];

        for (int i = 0; i < iguanas.Length; i++)
        {
            GameObject spawnableIguana;

            spawnableIguana = Instantiate(iguanaPrefab) as GameObject;
            spawnableIguana.transform.position = spawnPointIguana;
            float angle = Random.Range(0, 360);
            spawnableIguana.transform.Rotate(0, angle, 0);

            iguanas[i] = spawnableIguana;
        }
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
