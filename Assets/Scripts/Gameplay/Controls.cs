using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;

public class Controls : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = Screen.currentResolution.refreshRate;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void resetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        Global.playerHealth = 5;

        Global.moving = false;

        Time.timeScale = 1;
    }

    public void goToMenu () {
        SceneManager.UnloadSceneAsync("Gameplay");

        SceneManager.LoadScene("Menu");
    }
}
