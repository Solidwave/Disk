using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;

public class Controls : MonoBehaviour
{
    // Start is called before the first frame update

    public static bool menuOpen = false;

    public GameObject done;

    public GameObject nextLevelObject;
    void Start()
    {
        Application.targetFrameRate = Screen.currentResolution.refreshRate;

        done.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void resetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") - 1);

        Global.playerHealth = 5;

        Global.moving = false;

        Time.timeScale = 1;
    }

    public void goToMenu()
    {

        SceneManager.LoadScene("Menu");
    }

    public void nextLevel()
    {
        SceneManager.LoadScene("Gameplay");

        Global.playerHealth = 5;

        Global.moving = false;

        Time.timeScale = 1;
    }

    public void pause()
    {

        if (Global.pause)
        {
            Global.pause = false;

            Time.timeScale = 1;

            Debug.Log(nextLevelObject);

            nextLevelObject.SetActive(true);

            done.GetComponent<TMPro.TextMeshProUGUI>().enabled = true;

            done.SetActive(false);
        }
        else
        {
            Global.pause = true;

            Time.timeScale = 0;

            done.SetActive(true);

            done.GetComponent<TMPro.TextMeshProUGUI>().enabled = false;

            nextLevelObject.SetActive(false);
        }
    }
}
