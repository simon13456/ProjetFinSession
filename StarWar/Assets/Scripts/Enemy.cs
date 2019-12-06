using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Player _player = default;
    private int _vie = 1;
    Vector3 playerPos;
  
    
    void Start()
    {
        GetComponentInChildren<HealthBar>().NbrVie(_vie);
        _player = FindObjectOfType<Player>();
        
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        playerPos = _player.transform.position;

        transform.position = Vector3.MoveTowards(transform.position, playerPos, Time.deltaTime * 2f);
        

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            
            _player.Damage();
            this.Damage();
        }
        if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            this.Damage();
        }
    }
    private void Damage()
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


}
