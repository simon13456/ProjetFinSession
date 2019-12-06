using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField]GameObject _eclair;
    [SerializeField] GameObject _force;
    [SerializeField] GameObject _epee;
    int layerMask = 10;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           youSpinMeRightRound();
        }
        
       
    }

    private void youSpinMeRightRound()
    {
        Vector3 Position = new Vector3(Input.mousePosition.x / Screen.width * 32, Input.mousePosition.y / Screen.height * 18);
        Vector3 vec = Position - transform.position;
        float rot = (float)(Mathf.Rad2Deg * (Math.Tan(vec.x / vec.y)));
        StartCoroutine(Spin(rot));
    }

    private void Force()
    {
        Vector3 Position = new Vector3(Input.mousePosition.x / Screen.width * 32, Input.mousePosition.y / Screen.height * 18);
        Vector3 vec=Position - transform.position;
        float rot = (float)(Mathf.Rad2Deg * (Math.Tan(vec.x / vec.y)));
        StartCoroutine(fForce(rot));
    }
    IEnumerator Spin(float rot)
    {
        GameObject _Repee = Instantiate(_epee, transform.position, Quaternion.identity);
        _Repee.transform.Rotate(new Vector3(0f, 0f, rot));
        yield return StartCoroutine(Tour(_Repee));
    }
    IEnumerator Tour(GameObject _Repee)
    {
        /*
        while (transform.position!=new Vector3(_epee.transform.position.x, _epee.transform.position.y, 0f))
        {
            _Repee.transform.RotateAround(new Vector3(0f, 0f, 0f), transform.position, 359f);
        }
        yield return 0;
        */
        yield return 0;
    }
    IEnumerator fForce(float rot)
    {
        GameObject _Rforce =Instantiate(_force, transform.position,Quaternion.identity);
        _Rforce.transform.Rotate(new Vector3(0f, 0f, rot));
        yield return new WaitForSeconds(5f);
    }

    public void eclair()
    {
        Vector3 Position = new Vector3(Input.mousePosition.x / Screen.width * 32, Input.mousePosition.y / Screen.height * 18);
        Collider[] ennemi = Physics.OverlapSphere(Position, 1);
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
}
