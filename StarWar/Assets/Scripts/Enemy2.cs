using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    private Player _player = default;
    [SerializeField] private GameObject _ELaserPrefab = default;
    bool allowShoot = false;
    Vector3 playerPos;
   [SerializeField] private int _vie = 1;
    void Start()
    {
        GetComponentInChildren<HealthBar>().NbrVie(_vie);

        _player = FindObjectOfType<Player>();
        StartCoroutine(shootHer());
    }

    IEnumerator shootHer()
    {
        while (!allowShoot)
        {
            Fire();
            yield return new WaitForSeconds(3f);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        Orientation();
        
    }

    private void Fire()
    {
        Instantiate(_ELaserPrefab, transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            
            _player.Damage();
            this.Damage();
        }
        
    }


    public void Damage()
    {
        _vie--;
        
        if (_vie < 1)
        {
            Destroy(this.gameObject);
            _player.LifeSteal();
            _player.AddMana();
        }
        else
        {
            GetComponentInChildren<HealthBar>().Damage();
        }
        
    }



    private void Orientation()
    {
        transform.eulerAngles = new Vector3(0, 0, Mathf.Rad2Deg * getAngle());
    }

    private float getAngle()
    {
        float posX =  _player.transform.position.x - transform.position.x;
        float posY = _player.transform.position.y - transform.position.y;
        float angle = Mathf.Atan(posY / posX);
        float angleSupp = 0;
       /* if (posX > 0)
        {
            angleSupp = Mathf.Deg2Rad * 180;
        }*/
        angle = (angle + angleSupp);
        return angle;

    }
}
