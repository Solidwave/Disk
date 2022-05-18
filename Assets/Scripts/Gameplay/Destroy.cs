using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{   
    public GameObject diskPrefab;

    GameObject anchor;

    // Start is called before the first frame update
    void Start()
    {   
        anchor = GameObject.FindGameObjectWithTag("anchor");

    }

    // Update is called once per frame
    void Update()
    {   
    }


    void OnTriggerEnter(Collider other) {
        
       
       
         if(other.gameObject.tag == "disk") {

            Destroy(other.gameObject);

            Instantiate(diskPrefab, anchor.transform.position, Quaternion.identity);

            Global.moving = false;

        }
    }

    


}
