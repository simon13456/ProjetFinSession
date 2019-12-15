using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu
    (menuName="Configuration Vague Ennemi")]
public class ConfigWave : ScriptableObject
{
    [SerializeField] private GameObject _prefabEnemy1 = default;
    

    [SerializeField] private GameObject Chemin1 = default;
    

    [SerializeField] private float _tempsSpawn = 1f;
    [SerializeField] private int _nbrEnemy = 5;
    [SerializeField] private float _vitesseDeplacement =2f;



    public List<Transform> GetWayPoints()
    {
        List<Transform> waypoints = new List<Transform>();
        foreach (Transform point in Chemin1.transform)
        {
            waypoints.Add(point);
        }
        return waypoints;
    }

    public GameObject GetPrefabEnemy() { return _prefabEnemy1; }
    public float GetTempsEntreSpawn() { return _tempsSpawn; }
    public int GetNbrEnemy() { return _nbrEnemy; }
    public float GetVitesse() { return _vitesseDeplacement; }
}
