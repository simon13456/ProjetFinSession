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
    [SerializeField] private bool infinivie;
    int layerMask = 10;
    bool coupEpee = false;
    int att = 0;
    [SerializeField] private GestionScene gestionScene = default;
    private bool machineGun = false;
    int cMachine = 1;
    int compteurEpee = 0;
   
   /* [SerializeField] AudioSource epee = default;
    [SerializeField] AudioSource bow = default;
    [SerializeField] AudioSource wind = default;*/
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

        
        
       if (Input.GetKeyDown(KeyCode.W) && coupEpee == false)
        {
            
            attaque(2);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            
            attaque(3);
        }
        
        if (Input.GetMouseButtonDown(0) )
        {
            attaque(4);
        }
    }

    private void attaque(int att)
    {
        
        if (att == 2)
        {
            compteurEpee++;
            youSpinMeRightRound();
            if (compteurEpee % 2 == 0)
            {
                coupEpee = true;
            }
            
        }
        else if (att == 3)
        {
            if (EnoughMana(3))
            {
               Force();
            }
            else
            {
                //pas Assez de mana
            }
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
        
        Vector3 Position = Camera.main.ScreenToWorldPoint(Input.mousePosition);  
        Vector3 vec = Position - transform.position;           
        float rot = (Mathf.Atan(vec.y / vec.x));
        float anglesupp = 0;
        if (vec.x < 0)
        {
            anglesupp = Mathf.Deg2Rad * 180;
        }

        rot = Mathf.Rad2Deg*(rot+anglesupp);
        StartCoroutine(fForce(rot));
        SousMana(3);
        
    }


    IEnumerator fForce(float rot)
    {
        
        GameObject _Rforce = Instantiate(_force, transform.position, Quaternion.identity);
        _Rforce.transform.eulerAngles = new Vector3(0, 0, rot-90); ;
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
        for (float i = 0f; i <= 360; i += 15f)
        {
            _Repee.transform.position = transform.position;
            _Repee.transform.eulerAngles = new Vector3(0f, 0f, i + rot);
            yield return new WaitForSeconds(1 * (float)Math.Pow(10, -10000000000000));
        }

        Destroy(_Repee);
        coupEpee = false;
        yield return 0;

    }



    private void Move()
    {
        if (Input.GetMouseButtonDown(1))
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.z = 0;
            targetPosition.x = Mathf.Clamp(targetPosition.x, -16f, 16f);
            targetPosition.y = Mathf.Clamp(targetPosition.y, -9f, 9f);
        }
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * _vitesse);
        
    }

    public void Damage()
    {
        GetComponent<AudioSource>().Play();
        _vie--;
        if (_vie < 1&&!infinivie)
        {
            mort();
            Destroy(this.gameObject); 
        }
        else if (!infinivie)
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
    private bool EnoughMana(int cout)
    {
        if (_mana >= cout)
        {

            return true;
        }
        else
        {
            return false;
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

    private void mort()
    {
        
        FindObjectOfType<SpawnManager>().stopSpawning();
        
        //gestionScene.ChangerScene();
        

    }




}
