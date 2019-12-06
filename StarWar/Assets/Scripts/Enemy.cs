using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Player _player = default;
    private float _vie = 1;
    Vector3 playerPos;
  
    
    void Start()
    {
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
            Destroy(this.gameObject);
        }
        if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
    


}
