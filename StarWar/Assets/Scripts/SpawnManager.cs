using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private List<ConfigWave> _configVague =default;
    private int _vagueDepart = 0;
    private bool _stopSpawning = false;
    private UIManager _UIManager = default;


    IEnumerator Start()
    {
        _UIManager = FindObjectOfType<UIManager>();
        do
        {
            
            yield return StartCoroutine(SpawnWaves(_vagueDepart));
            _vagueDepart++;
            
            yield return new WaitForSeconds(5f);
        } while (!_stopSpawning);
    }
    

    IEnumerator SpawnWaves(int waveCompteur)
    {
        List<ConfigWave> waveEnemy= new List<ConfigWave>();

        waveEnemy.Clear();
        waveEnemy.Add(_configVague[0]);
        waveEnemy.Add(_configVague[1]);
        waveEnemy.Add(_configVague[2]);
        waveEnemy.Add(_configVague[3]);
        waveEnemy.Add(_configVague[4]);
        waveEnemy.Add(_configVague[5]);
        _UIManager.AddWave();
        yield return StartCoroutine(SpawnVagueEnemy(waveEnemy, waveCompteur));
                
    }



    IEnumerator SpawnVagueEnemy(List<ConfigWave> wave, int waveCompteur)
    {
        bool spawn= true;
        int compteur = 0;

        while (spawn)
        {
            if (compteur < wave.Count)
            {

                for (int i = 0; i < wave[compteur].GetNbrEnemy(); i++)
                {
                    GameObject newEnemy = Instantiate(wave[compteur].GetPrefabEnemy(), wave[compteur].GetWayPoints()[0].transform.position, Quaternion.identity);
                    newEnemy.GetComponent<EnemyPath>().SetConfigVague(wave[compteur]);
                    yield return new WaitForSeconds(wave[compteur].GetTempsEntreSpawn());
                }
            
        
            }
            compteur++;
            if (waveCompteur > 5 && compteur>5)
            {
                compteur = 0;
                waveCompteur -= 5;
            }

            if (compteur >waveCompteur )
            {
                spawn = false;
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
   
