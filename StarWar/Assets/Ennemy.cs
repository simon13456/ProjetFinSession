using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : MonoBehaviour
{
    private player _player = default;

    Vector3 playerPos;


    void Start()
    {
        _player = FindObjectOfType<player>();

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
}
