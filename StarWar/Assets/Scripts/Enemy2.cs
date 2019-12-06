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
    private float _vie = 2;
    void Start()
    {
        _player = FindObjectOfType<Player>();
        StartCoroutine(shootHer());
    }

    IEnumerator shootHer()
    {
        while (!allowShoot)
        {
            Fire();
            yield return new WaitForSeconds(1.5f);
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
            Destroy(this.gameObject);
        }
        if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }

    private void Orientation()
    {
        transform.eulerAngles = new Vector3(0, 0, Mathf.Rad2Deg * getAngle() - 90);
    }

    private float getAngle()
    {
        float posX =  _player.transform.position.x - transform.position.x;
        float posY = _player.transform.position.y - transform.position.y;
        float angle = Mathf.Atan(posY / posX);
        float angleSupp = 0;
        if (posX > 0)
        {
            angleSupp = Mathf.Deg2Rad * 180;
        }
        angle = (angle + angleSupp);
        return angle;

    }
}
