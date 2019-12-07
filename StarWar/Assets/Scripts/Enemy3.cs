using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : MonoBehaviour
{
    private Player _player = default;
    [SerializeField] private GameObject _missilePrefab = default;
    bool allowShoot = false;
    Vector3 playerPos;
    [SerializeField] private int _vie = 5;
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
        Move();
        Orientation();

    }

    private void Fire()
    {

        Instantiate(_missilePrefab, transform.position, Quaternion.identity);

    }

    private void Move()
    {
        playerPos = _player.transform.position;

        transform.position = Vector3.MoveTowards(transform.position, playerPos, Time.deltaTime * 1f);


    }
    public void Damage()
    {
        _vie--;

        if (_vie < 1)
        {
            Destroy(this.gameObject);
            _player.LifeSteal();
        }
        else
        {
            GetComponentInChildren<HealthBar>().Damage();
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

            _player.Damage();
            this.Damage();
        }

    }
    private void Orientation()
    {
        transform.eulerAngles = new Vector3(0, 0, Mathf.Rad2Deg * getAngle());
    }

    private float getAngle()
    {
        float posX = _player.transform.position.x - transform.position.x;
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
