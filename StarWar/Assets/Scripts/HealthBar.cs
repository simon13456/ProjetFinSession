﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update

   [SerializeField] private GameObject[] _vie = default;
   
    private int compteur;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NbrVie(int nbVie)
    {
        compteur = nbVie - 1;
        
    }
    
    public void Damage()
    {

        _vie[compteur].SetActive(false);
        
        compteur--;

    }

    public void Heal()
    {
        compteur++;
        _vie[compteur].SetActive(true);       
    }

    

}
