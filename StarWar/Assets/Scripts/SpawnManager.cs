using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private List<ConfigWave> _configVague;
    private int _vagueDepart = 0;
    private bool _stopSpawning = false;

    IEnumerator Start()
    {

        do
        {
            yield return StartCoroutine(SpawnWaves());
            yield return new WaitForSeconds(3.5f);
        } while (_stopSpawning);
    }
    

    IEnumerator SpawnWaves()
    {
        for(int i = _vagueDepart; i<_configVague.Count; i++)
        {
            ConfigWave vagueActuelle = _configVague[i];
            yield return StartCoroutine(SpawnVagueEnemy(vagueActuelle));
            yield return new WaitForSeconds(2f);
        }
    }



    IEnumerator SpawnVagueEnemy(ConfigWave wave)
    {
        for(int i=0; i<wave.GetNbrEnemy(); i++)
        {
            GameObject newEnemy = Instantiate(wave.GetPrefabEnemy(), wave.GetWayPoints()[0].transform.position, Quaternion.identity);
            newEnemy.GetComponent<EnemyPath>().SetConfigVague(wave);
            yield return new WaitForSeconds(wave.GetTempsEntreSpawn());

        }


    }


    public void stopSpawning()
    {
        _stopSpawning = true;
    }

    public bool ArretJeu()
    {

        return _stopSpawning;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    
    }
   
