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
    private float _vie = 10f;

    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse1)||isMoving)
        { 
            Move();
            isMoving = true;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
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
        if (Input.GetKeyDown(KeyCode.Mouse1))
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
    }

}
