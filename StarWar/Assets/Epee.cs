using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Epee : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy3")
        {
            
            other.GetComponent<Enemy3>().Damage();
        }
        if (other.tag == "Enemy2")
        {
           
            other.GetComponent<Enemy2>().Damage();
        }
        if (other.tag == "Enemy")
        {
            
            other.GetComponent<Enemy>().Damage();
        }
        if (other.tag == "EnemyLaser" || other.tag == "Missile")
        {
            
            Destroy(other.gameObject);
        }
    }
}
