using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    private float globalPush = 8f;
    private Player _player = default;
    // Start is called before the first frame update
    void Start()
    {
        _player = FindObjectOfType<Player>();


    }

    // Update is called once per frame
    void Update()
    {
        SeekAndDestroy();
    }

    private void SeekAndDestroy()
    {
        
        Vector3 target = _player.transform.position - transform.position;
        GetComponent<Rigidbody2D>().velocity = target * Time.deltaTime * 20f;
        transform.eulerAngles = new Vector3(0, 0, Mathf.Rad2Deg * getAngle());
        AdjustVelo();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

            _player.Damage();
            _player.Damage();
            Destroy(this.gameObject);
        }
        if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
        if (other.tag == "Enemy")
        {

            other.GetComponent<Enemy>().Damage();
            Destroy(this.gameObject);
        }
        if (other.tag == "Enemy2")
        {

            other.GetComponent<Enemy2>().Damage();
            Destroy(this.gameObject);
        }
        
    }

    private void AdjustVelo()
    {
        float vitX = GetComponent<Rigidbody2D>().velocity.x;
        float vitY = GetComponent<Rigidbody2D>().velocity.y;


        float angle = getAngle();
        float hypo = Mathf.Sqrt((Mathf.Pow(vitX, 2)) + (Mathf.Pow(vitY, 2)));
        float vitManquante = (globalPush - hypo);
        GetComponent<Rigidbody2D>().velocity = new Vector3((vitX + (vitManquante * Mathf.Cos(angle))), (vitY + (vitManquante * Mathf.Sin(angle))));

    }

    private float getAngle()
    {
        float vitX = GetComponent<Rigidbody2D>().velocity.x;
        float vitY = GetComponent<Rigidbody2D>().velocity.y;
        float angle = Mathf.Atan(vitY / vitX);
        float angleSupp = 0;
        if (vitX < 0)
        {
            angleSupp = Mathf.Deg2Rad * 180;
        }
        angle += angleSupp;
        return angle;
    }
}
