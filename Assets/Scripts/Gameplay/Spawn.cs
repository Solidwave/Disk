using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class Spawn : MonoBehaviour
{
    // Start is called before the first frame update

    public TextAsset textJson;

    private string path;

    public GameObject commonEnemy;
    public GameObject uncommonEnemy;
    public GameObject rareEnemy;

    public float interval = 2f;

    public Vector3 initialPosition;

    public GameObject done;

    private int currentLevelId;

    private bool spawning = true;

    private Level currentLevel;

    private GameObject levelMessage;

    private GameObject count;

    private float timer = 5f;

    [System.Serializable]
    public class Level {
        public int id;
        public int common;

        public bool completed;
        public int uncommon;
        public int rare;
    }

    public class Levels {
        public List<Level> levels;
    }


    public Levels myLevels = new Levels();

    private bool starting = false;

    private float messageTimer = 0;

    public Levels originalLevels = new Levels();
    void Start()
    {
        myLevels = JsonUtility.FromJson<Levels>(textJson.text);

        originalLevels = JsonUtility.FromJson<Levels>(textJson.text);

        currentLevelId = PlayerPrefs.GetInt("level", 1);

        if (currentLevelId <= 0)
        {
            PlayerPrefs.SetInt("level", 1);

            currentLevelId = 1;
        }

        path = Application.dataPath;
        
        Debug.Log(path);

        currentLevel = myLevels.levels.Find(item => item.id == currentLevelId);

        initialPosition = new Vector3(transform.position.x , 1f, transform.position.z);

        count = GameObject.FindGameObjectWithTag("count");

        levelMessage = GameObject.FindGameObjectWithTag("levelid");

        levelMessage.GetComponent<TMPro.TextMeshProUGUI>().text = "Level "+currentLevelId;

        starting = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (starting)
        {
            if (messageTimer > 3f)
            {
                starting = false;

                levelMessage.SetActive(false);

                return;
            }

            messageTimer += Time.deltaTime;

            count.GetComponent<TMPro.TextMeshProUGUI>().text = ((int)(3f-messageTimer)).ToString();

            return;
        }


        if (timer < interval)
        {
              timer += Time.deltaTime;
        } else
        {
            timer = 0;

            float random = Random.Range(-5f,5f);


            Vector3 position = new Vector3(transform.position.x + random , 1f, transform.position.z);

            if (currentLevel.common > 0)
            {
                Instantiate(commonEnemy, position, Quaternion.identity);

                currentLevel.common--;

                return;
            }

            if (currentLevel.uncommon > 0)
            {
                Instantiate(uncommonEnemy,position, Quaternion.identity);

                currentLevel.uncommon--;

                return;
            }

            if (currentLevel.rare > 0)
            {
                 Instantiate(rareEnemy, position, Quaternion.identity);

                currentLevel.rare--;

                return;
            }

            spawning = false;

            GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");

            if (enemies.Length == 0 && !spawning)
            {
                Time.timeScale = 0;

                originalLevels.levels[currentLevelId].completed = true;

                string newLevels = JsonUtility.ToJson(originalLevels);

                currentLevelId++;

                if (currentLevelId == 6)
                {
                    currentLevelId = 1;
                }

                PlayerPrefs.SetInt("level", currentLevelId);

                File.WriteAllText(Application.dataPath + "/Resources/levels.json", newLevels);
                
                done.SetActive(true);
            }


            
        }
    }
}
