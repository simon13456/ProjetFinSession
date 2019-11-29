using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    Vector3 target = new Vector3();
    // Start is called before the first frame update
    void Start()
    {
        Vector3 target = new Vector3(transform.position.x,transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 Position = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
            attaque(Position);
        }
        Move();
}

    private void Move()
    {
        if (Input.GetMouseButtonDown(0))
        {
         Vector3 target = (Input.mousePosition.x / Screen.width * 32 , Input.mousePosition.y / (Screen.width * 10));

        }
        if (transform.position != target)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, 10f * Time.deltaTime);
        }
    }

    public void attaque (Vector3 position)
    {
        
    }
}
