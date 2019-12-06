using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    Vector3 targetPosition;
    float globalPush = 20f;
    Vector3 target;
    
   
    void Start()
    {
       
       
        Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPosition.z = 0f;
        target = position - transform.position;
        GetComponent<Rigidbody2D>().velocity = target * Time.deltaTime * 150f;
        transform.eulerAngles = new Vector3(0, 0, Mathf.Rad2Deg * getAngle()-90);
        
    }

    

    void Update()
    {

        AdjustVelo();

    }
    
    

    private void AdjustVelo()
    {
        float vitX = GetComponent<Rigidbody2D>().velocity.x;
        float vitY = GetComponent<Rigidbody2D>().velocity.y;
        float angleSupp = 0;
        if (vitX < 0)
        {
            angleSupp = Mathf.Deg2Rad * 180;
        }
        float angle= getAngle() + angleSupp;
        float hypo = Mathf.Sqrt((Mathf.Pow(vitX, 2)) + (Mathf.Pow(vitY, 2)));
        float vitManquante = (globalPush - hypo);
        GetComponent<Rigidbody2D>().velocity = new Vector3((vitX + (vitManquante * Mathf.Cos(angle))), (vitY + (vitManquante * Mathf.Sin(angle))));

    }

    private float getAngle()
    {
        float vitX = GetComponent<Rigidbody2D>().velocity.x;
        float vitY = GetComponent<Rigidbody2D>().velocity.y;
        float angle = Mathf.Atan(vitY / vitX);
        return angle;
    }
}
