using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeepScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txtScore = default;
    [SerializeField] private TextMeshProUGUI txtTemps = default;
    [SerializeField] private TextMeshProUGUI txtWave = default;
    [SerializeField] private TextMeshProUGUI txtName = default;
    UIManager uI = default;
    private bool destroyed = false;
    void Start()
    {
        txtName.SetText(FindObjectOfType<UIManager>().GetName());
        int minute = FindObjectOfType<UIManager>().Getminute();
        int seconde = FindObjectOfType<UIManager>().Getsec();
        txtTemps.SetText(minute + ":" + seconde);
        txtScore.SetText(FindObjectOfType<UIManager>().GetScore().ToString());
        uI = FindObjectOfType<UIManager>();
        txtWave.SetText(FindObjectOfType<UIManager>().GetWave().ToString());
    }

    // Update is called once per frame
    void Update()
    {
        if (!destroyed)
        {
            if (FindObjectOfType<UIManager>().CanDestroy())
            {
                FindObjectOfType<UIManager>().SeekAndDestroy();
                destroyed = true;
            }
        }
    }

    
}
