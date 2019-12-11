using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _LaserPrefab = default;
    Vector3 targetPosition;
    float _vitesse = 10.0f;
    bool isMoving = false;
    private int _vie = 10;
    private int _mana = 12;
    private int compteur = 0;

    //simon
    [SerializeField] GameObject _eclair = default;
    [SerializeField] GameObject _force = default;
    [SerializeField] GameObject _epee = default;
    int layerMask = 10;
    bool coupEpee = false;
    int att = 0;

    void Start()
    {
        GetComponentInChildren<HealthBar>().NbrVie(_vie);
        GetComponentInChildren<ManaBar>().NbrMana(_mana);
    }

    // Update is called once per frame
    void Update()
    {       


        if (Input.GetKeyDown(KeyCode.Mouse1)||isMoving)
        { 
            Move();
            isMoving = true;
        }

        
        /*if (Input.GetMouseButtonDown(0))
        {
            Fire();
            SousMana(1);
        }*/

        //simon
        if (Input.GetKeyDown(KeyCode.Q))
        {
            att = 1;
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            att = 2;
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            att = 3;
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            att = 4;
        }
        if (Input.GetMouseButtonDown(0) && coupEpee == false)
        {
            attaque(att);
        }
    }

    private void attaque(int att)
    {
        if (att == 1)
        {
            eclair();
        }
        else if (att == 2)
        {
            youSpinMeRightRound();
            coupEpee = true;
        }
        else if (att == 3)
        {
            Force();
        }
        else if (att == 4)
        {
            Fire();
        }
    }

    private void Fire()
    {
        Instantiate(_LaserPrefab, transform.position, Quaternion.identity);    
    }

    private void Force()
    {
        Vector3 Position = new Vector3(Input.mousePosition.x / Screen.width * 32, Input.mousePosition.y / Screen.height * 18);
        Vector3 vec = Position - transform.position;
        float rot = (float)(Mathf.Rad2Deg * (Math.Tan(vec.x / vec.y)));
        if (vec.x < 0 & vec.y >= 0)
        {
            rot += 90;
        }
        else if (vec.x >= 0 && vec.y < 0)
        {
            rot += 270;
        }
        else if (vec.x < 0 && vec.y < 0)
        {
            rot += 180;
        }
        StartCoroutine(fForce(rot));
    }


    IEnumerator fForce(float rot)
    {
        GameObject _Rforce = Instantiate(_force, transform.position, Quaternion.identity);
        _Rforce.transform.Rotate(new Vector3(0f, 0f, rot));
        for (float i = 0f; i <= 0.3; i += 0.01f)
        {
            _Rforce.transform.localScale += new Vector3(i / 2, i, 0f);
            yield return new WaitForSeconds(1 * (float)Math.Pow(10, -1000));
        }
        Destroy(_Rforce);
    }

    private void youSpinMeRightRound()
    {
        Vector3 Position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 vec = Position - transform.position;
        float rot = (float)(Mathf.Rad2Deg * (Math.Tan(vec.x / vec.y)));
        if (vec.x < 0 & vec.y >= 0)
        {
            rot += 90;
        }
        else if (vec.x >= 0 && vec.y < 0)
        {
            rot += 270;
        }
        else if (vec.x < 0 && vec.y < 0)
        {
            rot += 180;
        }
        StartCoroutine(Spin(rot));
    }

    IEnumerator Spin(float rot)
    {
        GameObject _Repee = Instantiate(_epee, transform.position, Quaternion.identity);
        _Repee.transform.Rotate(new Vector3(0f, 0f, rot));

        for (float i = 0f; i <= 360; i += 10f)
        {
            _Repee.transform.eulerAngles = new Vector3(0f, 0f, i + rot);
            yield return new WaitForSeconds(1 * (float)Math.Pow(10, -1000));
        }

        Destroy(_Repee);
        coupEpee = false;
        yield return 0;

    }
    public void eclair()
    {
        Vector3 Position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Collider[] ennemi = Physics.OverlapSphere(Position, 1, layerMask);
        _eclair.gameObject.transform.GetChild(0).gameObject.transform.position = this.transform.position;
        if (false)
        {
            _eclair.gameObject.transform.GetChild(1).gameObject.transform.position = Position;
            Instantiate(_eclair, transform.position, Quaternion.identity);
        }
        else
        {
            _eclair.gameObject.transform.GetChild(1).gameObject.transform.position = ennemi[0].transform.position;
            Instantiate(_eclair, default, Quaternion.identity);
        }
    }

    private void Move()
    {
        if (Input.GetMouseButtonDown(1))
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.z = 0;           
        }
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * _vitesse);
    }

    public void Damage()
    {
       _vie--;
        if (_vie < 1)
        {
            Destroy(this.gameObject); 
        }
        else
        {
            GetComponentInChildren<HealthBar>().Damage();
        }
        
    }
    public void LifeSteal()
    {
        compteur++;
        if (compteur % 3 == 0)
        {
            if (_vie < 10)
            {
                _vie++;
                GetComponentInChildren<HealthBar>().Heal();
            }            
        }      
    }
    private void SousMana(int cout)
    {
        
        if (_mana >= cout)
        {
            //return un true
            _mana -= cout;
            for (int i=0; i < cout; i++)
           {
                GetComponentInChildren<ManaBar>().GerardLaflaque();
            }
        }
        else
        {
            //return un false
        }

    }
    public void AddMana()
    {
        if (_mana < 12)
        {
            _mana++;
            GetComponentInChildren<ManaBar>().ajoutMana();
        }
    }




}
