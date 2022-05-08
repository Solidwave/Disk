using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    // Start is called before the first frame update

    public TextAsset textJson;

    public GameObject commonEnemy;
    public GameObject uncommonEnemy;
    public GameObject rareEnemy;

    GameObject done;

    public float interval = 2f;

    public Vector3 initialPosition;

    private int currentLevelId = 1;

    private bool spawning = true;

    private Level currentLevel;

    private float timer = 5f;

    [System.Serializable]
    public class Level {
        public int id;
        public int common;
        public int uncommon;
        public int rare;
    }

    public class Levels {
        public List<Level> levels;
    }


    public Levels myLevels = new Levels();
    void Start()
    {
        myLevels = JsonUtility.FromJson<Levels>(textJson.text);

        currentLevel = myLevels.levels.Find(item => item.id == currentLevelId);

        initialPosition = new Vector3(transform.position.x , 1f, transform.position.z);

        done = GameObject.FindGameObjectWithTag("done");

    }

    // Update is called once per frame
    void Update()
    {
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

                done.SetActive(true);
            }


            
        }
    }
}
