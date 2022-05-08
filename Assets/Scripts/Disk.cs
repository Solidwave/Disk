using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disk : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject anchor;

    public GameObject diskPrefab;

    public int damage = 1;

    bool dying = false;
    void Start()
    {
        anchor = GameObject.FindGameObjectWithTag("anchor");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void destroyMe()
    {   
        
        Instantiate(diskPrefab, anchor.transform.position, Quaternion.identity);

        Destroy(gameObject);

        Global.moving = false;

    }

    void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;


        if (!Global.moving)
        {
            Physics.IgnoreCollision(other.GetComponent<Collider>(), gameObject.GetComponent<Collider>());
            return;
        }

        switch (other.tag)
        {
            case "enemy":
                gameObject.GetComponent<Collider>().enabled = false;
                gameObject.GetComponent<Animator>().SetTrigger("Destroy");
                
                gameObject.GetComponent<Rigidbody>().velocity = gameObject.GetComponent<Rigidbody>().velocity * 0.3f;

                

                other.GetComponent<Enemy>().health -= damage;

                

               

               

                break;
        }
    }

}
