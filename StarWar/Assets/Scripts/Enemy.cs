using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Player _player = default;
    private int _vie = 2;
    Vector3 playerPos;
    private float vitesse = 3f;
    private bool colision = false;
    private bool canDash = true;
    private UIManager _UIManager=default;
    
    
    void Start()
    {
        GetComponentInChildren<HealthBar>().NbrVie(_vie);
        _player = FindObjectOfType<Player>();
        _UIManager = FindObjectOfType<UIManager>();
        StartCoroutine(Dash());
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {

        if (!FindObjectOfType<SpawnManager>().ArretJeu())
        {
            playerPos = _player.transform.position;
            float angle = Mathf.Atan(playerPos.y / playerPos.x);
            float dist = Mathf.Sqrt((Mathf.Pow(playerPos.x, 2)) + (Mathf.Pow(playerPos.y, 2)));
            transform.position = Vector2.MoveTowards(transform.position, playerPos, Time.deltaTime * vitesse);
        }
        else
        {

            canDash = false;
        }
      
    }
    IEnumerator Dash()
    {
        while (canDash)
        {
            yield return new WaitForSeconds(2f);
            vitesse = 20f;
            yield return new WaitForSeconds(0.2f);
            vitesse = 3f;
        }
       
    }

   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            
            _player.Damage();
            colision = true;
            this.Damage();
            
        }
        
    }
    public void Damage()
    {
        _vie--;

        if (_vie < 1)
        {
            if (!colision)
            {
                _player.LifeSteal();
                _player.AddMana();
            }
            _UIManager.AddScore(50);
            Destroy(this.gameObject);
                       

        }
        else
        {
            GetComponentInChildren<HealthBar>().Damage();
        }

    }


}
