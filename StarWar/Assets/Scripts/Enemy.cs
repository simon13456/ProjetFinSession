using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Player _player = default;
    private int _vie = 1;
    Vector3 playerPos;
    private bool colision = false;
  
    
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

        transform.position = Vector2.MoveTowards(transform.position, playerPos, Time.deltaTime * 5f);
        

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            
            _player.Damage();
            colision = true;
            this.Damage();
            
        }
        
    }
    public void Damage()
    {
        _vie--;

        if (_vie < 1)
        {
            if (!colision)
            {
                _player.LifeSteal();
            }
            Destroy(this.gameObject);
            
            

        }
        else
        {
            GetComponentInChildren<HealthBar>().Damage();
        }

    }


}
