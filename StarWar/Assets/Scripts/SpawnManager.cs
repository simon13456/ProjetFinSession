using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab = default;
    [SerializeField] private GameObject _enemyPrefab2 = default;
    Vector3 playerPos;
    private bool _stopSpawning = false;
    private int compteur = 0;
    float spawnY = 0;
   
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
            }
            else
            {
                spawnY = 9f;
            }
            Vector3 spawnPosition = new Vector3(Random.Range(-16f, 16f), spawnY, 0f);
            GameObject newEnemy = Instantiate(_enemyPrefab, spawnPosition, Quaternion.identity);
            Vector3 spawnPosition2 = new Vector3(Random.Range(-16f, 16f), Random.Range(-9f,9f), 0f);
            GameObject newEnemy2 = Instantiate(_enemyPrefab2, spawnPosition2, Quaternion.identity);
            yield return new WaitForSeconds(2.0f);
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
