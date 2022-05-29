using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sling : MonoBehaviour
{
    Camera mainCamera;

    public GameObject diskPrefab;

    GameObject disk;

    GameObject anchor;

    GameObject bound;

    Vector2 finalPosition = new Vector2();

    GameObject release;

    Vector3 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        anchor = GameObject.FindGameObjectWithTag("anchor");

        bound = GameObject.FindGameObjectWithTag("bound");

        disk = Instantiate(diskPrefab, anchor.transform.position, Quaternion.identity);

        initialPosition = disk.transform.position;

        release = GameObject.FindGameObjectWithTag("release");

        mainCamera = Camera.main;

        Global.moving = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Global.moving) {
            return;
        }

        if (disk == null)
        {
            disk = GameObject.FindGameObjectWithTag("disk");

            return;
        }
        if (Input.touchCount > 0 && !Global.moving)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                Vector3 position = mainCamera.ScreenToWorldPoint(touch.position);
                 position.y = anchor.transform.position.y;
                if (!bound.GetComponent<BoxCollider>().bounds.Contains(position))
                {
                   return;
                }
                
               

                disk.transform.position = position;
            }

            if (touch.phase == TouchPhase.Ended)
            {
                if (disk.transform.position.z >= anchor.transform.position.z )
                {
                   disk.transform.position = anchor.transform.position;

                   return;
                }

                disk.GetComponent<Rigidbody>().velocity = (anchor.transform.position - disk.transform.position) * 15;

                  disk.GetComponent<Collider>().enabled = true;

                Global.moving = true;

              

            }
        }





    }








}
