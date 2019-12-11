using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour
{
    private ConfigWave _configVague;
    private List<Transform> _wayPoints;
    private int _indexPointRepere = 0;
    private bool stopMoving = false;


    void Start()
    {
        _wayPoints = _configVague.GetWayPoints();
        transform.position = _wayPoints[_indexPointRepere].transform.position;



    }

    // Update is called once per frame
    void Update()
    {
        if (!stopMoving)
        {
            Mouvementchemin();
        }
        
    }

    public void SetConfigVague(ConfigWave vagueEncours)
    {
        this._configVague = vagueEncours;
    }

    private void Mouvementchemin()
    {
       
        if(_indexPointRepere < _wayPoints.Count)
        {
            
                Vector3 targetPosition = _wayPoints[_indexPointRepere].transform.position;
                float deplacement = _configVague.GetVitesse() * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, deplacement);
            
            if(transform.position == _wayPoints[_indexPointRepere].transform.position)
            {
                _indexPointRepere++;
            }
            else if (_indexPointRepere == _wayPoints.Count-1)
            {
                stopMoving = true;
            }

        }
        










    }
}
