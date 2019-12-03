using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField]GameObject _eclair;
    [SerializeField] GameObject _force;
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
            Force();
        }
       
    }

    private void Force()
    {
        Vector3 Position = new Vector3(Input.mousePosition.x / Screen.width * 32, Input.mousePosition.y / Screen.height * 18);
        Vector3 vec=Position - transform.position;
        float rot = (float)(Mathf.Rad2Deg * (Math.Tan(vec.x / vec.y)));
        StartCoroutine(fForce(rot));
    }

    IEnumerator fForce(float rot)
    {
        _force.gameObject.transform.Rotate(0f, 0f, rot);
        Instantiate(_force, transform.,Quaternion.identity);
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
