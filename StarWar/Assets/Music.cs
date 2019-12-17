using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    private int compteur = 1;
    private void Awake()
    {
        int compteurJeu = FindObjectsOfType<Music>().Length;
        if (compteurJeu > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
   
    void Start()
    {
        muteing();
    }

    
    void Update()
    {
        
    }
    public void muteing()
    {

        if (compteur % 2 == 0)
        {
            GetComponent<AudioSource>().Pause();
            compteur++;

        }
        else
        {
            GetComponent<AudioSource>().Play();
            compteur++;
        }
    }

}
