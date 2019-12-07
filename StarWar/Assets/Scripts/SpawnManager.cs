using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab = default;
    [SerializeField] private GameObject _enemyPrefab2 = default;
    [SerializeField] private GameObject _enemyPrefab3 = default;
    Vector3 playerPos;
    private bool _stopSpawning = false;
    private int compteur = 0;
    private float spawnY = 0;
    private float spawnX = 0f;
   
    void Start()
    {
        StartSpawning();
    }
    public void StartSpawning()
    {
        StartCoroutine(SpawnEnemy());

    }

    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(5.0f);
        while (!_stopSpawning)
        {
            compteur++;
            if (compteur % 2 == 0)
            {
                spawnY = -9f;
                spawnX = -15f;
            }
            else
            {
                spawnY = 9f;
                spawnX = 15f;
            }
            if (compteur % 3 == 0)
            {
                Vector3 spawnPosition3 = new Vector3(spawnX, Random.Range(-8.5f, 8.5f), 0f);
                GameObject newEnemy3 = Instantiate(_enemyPrefab3, spawnPosition3, Quaternion.identity);
            }
            Vector3 spawnPosition = new Vector3(Random.Range(-16f, 16f), spawnY, 0f);
            GameObject newEnemy = Instantiate(_enemyPrefab, spawnPosition, Quaternion.identity);
            Vector3 spawnPosition2 = new Vector3(Random.Range(-15f, 15f), Random.Range(-8.5f,8.5f), 0f);
            GameObject newEnemy2 = Instantiate(_enemyPrefab2, spawnPosition2, Quaternion.identity);
            yield return new WaitForSeconds(3f);
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
