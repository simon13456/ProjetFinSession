using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private List<ConfigWave> _configVague;
    private int _vagueDepart = 1;
    private bool _stopSpawning = false;

    IEnumerator Start()
    {

        do
        {
            yield return StartCoroutine(SpawnWaves());
            _vagueDepart++;
            yield return new WaitForSeconds(5f);
        } while (!_stopSpawning);
    }
    

    IEnumerator SpawnWaves()
    {
        List<ConfigWave> waveEnemy= new List<ConfigWave>();
        switch (_vagueDepart) 
        
        {
            case 1:
                
                ConfigWave vagueActuelle = _configVague[0];
                ConfigWave vagueActuelle2 = _configVague[1];
                waveEnemy.Add(_configVague[0]);
                waveEnemy.Add(_configVague[1]);
                yield return StartCoroutine(SpawnVagueEnemy(waveEnemy));
                break;
            case 2:
                waveEnemy.Clear();
                ConfigWave vagueActuelle3 = _configVague[2];
                ConfigWave vagueActuelle4 = _configVague[3];
                waveEnemy.Add(_configVague[2]);
                waveEnemy.Add(_configVague[3]);
                yield return StartCoroutine(SpawnVagueEnemy(waveEnemy));
                break;
            case 3:

                break;
            case 4:

                break;
            case 5:

                break;
            case 6:

                break;





        }

    }



    IEnumerator SpawnVagueEnemy(List<ConfigWave> wave)
    {
        for (int j = 0; j < wave.Count; j++)
        {


            for (int i = 0; i < wave[j].GetNbrEnemy(); i++)
            {
                GameObject newEnemy = Instantiate(wave[j].GetPrefabEnemy(), wave[j].GetWayPoints()[0].transform.position, Quaternion.identity);
                newEnemy.GetComponent<EnemyPath>().SetConfigVague(wave[j]);
                yield return new WaitForSeconds(wave[j].GetTempsEntreSpawn());

            }
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
   
