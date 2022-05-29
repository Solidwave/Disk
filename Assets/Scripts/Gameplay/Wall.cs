using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "disk")
        {
            Vector3 velocity = collision.gameObject.GetComponent<Rigidbody>().velocity;


            collision.gameObject.GetComponent<Rigidbody>().velocity = velocity;
        }
    }

}
