using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Release : MonoBehaviour
{
    GameObject health;

    
    GameObject gameOver;

    GameObject done;
    // Start is called before the first frame update
    void Start()
    {
        health = GameObject.FindGameObjectWithTag("health");

        gameOver = GameObject.FindGameObjectWithTag("gameover");

        gameOver.SetActive(false);

        done = GameObject.FindGameObjectWithTag("done");

        done.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }


    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "enemy")
        {
            Destroy(other.gameObject);

            Global.playerHealth--;

            Debug.Log(Global.playerHealth);

            if (Global.playerHealth == 0)
            {
                Time.timeScale = 0;

                gameOver.SetActive(true);
            }


        }

    }

    void resetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
