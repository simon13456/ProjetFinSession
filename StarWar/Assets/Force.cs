using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Force : MonoBehaviour
{
    [SerializeField] AudioClip wind = default;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource.PlayClipAtPoint(wind, Camera.main.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
