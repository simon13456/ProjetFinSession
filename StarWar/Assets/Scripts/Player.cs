using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _LaserPrefab = default;
    Vector3 targetPosition;
    float _vitesse = 10.0f;
    bool isMoving = false;
    private int _vie = 10;
    private int compteur = 0;
    private bool machineGun = false;
    int cMachine = 0;
    void Start()
    {
        GetComponentInChildren<HealthBar>().NbrVie(_vie);
        
    }

    // Update is called once per frame
    void Update()
    {
        //CodeTroll
        if (Input.GetKeyDown(KeyCode.C))
        {
            cMachine++;
            if (cMachine % 2 == 0)
            {
                machineGun = true;
            }
            else
            {
                machineGun = false;
            }
        }
        if (machineGun)
        {
            Fire();
        }
    //arrete ici


        if (Input.GetKeyDown(KeyCode.Mouse1)||isMoving)
        { 
            Move();
            isMoving = true;
        }
        //Input.GetMouseButtonDown(0)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
    }

    private void Fire()
    {
        Instantiate(_LaserPrefab, transform.position, Quaternion.identity);

        
    }

    private void Move()
    {
        if (Input.GetMouseButtonDown(1))
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.z = 0;           
        }
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * _vitesse);
    }

    public void Damage()
    {
       _vie--;
        if (_vie < 1)
        {
            Destroy(this.gameObject); 
        }
        else
        {
            GetComponentInChildren<HealthBar>().Damage();
        }
        
    }
    public void LifeSteal()
    {
        compteur++;
        if (compteur % 3 == 0)
        {
            if (_vie < 10)
            {
                _vie++;
                GetComponentInChildren<HealthBar>().Heal();
            }
            
        }
        
    }

}
