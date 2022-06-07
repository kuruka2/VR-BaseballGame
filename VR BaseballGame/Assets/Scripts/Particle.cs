using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name.Contains("Bat"))
        {
            Debug.Log("Particle");
           

        }
    }
    void Boom()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
