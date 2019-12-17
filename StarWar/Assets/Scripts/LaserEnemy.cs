using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEnemy : MonoBehaviour
{
    float globalPush = 10f;
    private Player _player = default;
    // Start is called before the first frame update
    void Start()
    {
        if (!FindObjectOfType<SpawnManager>().ArretJeu())
        {
            GetComponent<AudioSource>().Play();
            _player = FindObjectOfType<Player>();
            Vector3 target = _player.transform.position - transform.position;
            GetComponent<Rigidbody2D>().velocity = target * Time.deltaTime * 20f;
            transform.eulerAngles = new Vector3(0, 0, Mathf.Rad2Deg * getAngle() - 90);
            StartCoroutine(seekAndDestroy());
        }
    }

    IEnumerator seekAndDestroy()
    {
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (!FindObjectOfType<SpawnManager>().ArretJeu())
        {
           AdjustVelo();
        }
        else
        {
            Destroy(this.gameObject);
        }
        
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
    private void AdjustVelo()
    {
        float vitX = GetComponent<Rigidbody2D>().velocity.x;
        float vitY = GetComponent<Rigidbody2D>().velocity.y;
        float angleSupp = 0;
        if (vitX < 0)
        {
            angleSupp = Mathf.Deg2Rad * 180;
        }
        float angle = getAngle() + angleSupp;
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
