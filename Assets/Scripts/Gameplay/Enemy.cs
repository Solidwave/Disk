using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public int health = 1;

    public float speed = 10f;

    void Start()
    {
        transform.position.Set(transform.position.x, 0.5f, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);

        }

        transform.Translate(0,0, -speed * Time.deltaTime );
    }

}
