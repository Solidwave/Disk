using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hearts : MonoBehaviour
{
    // Start is called before the first frame update

    public Sprite heart;
    public List<RawImage> hearts;

    int startHealth;
    
    
    void Start()
    {
        startHealth = Global.playerHealth;

        for (int i = 0; i < hearts.Count; i++)
        {
            if (i>=Global.playerHealth)
            {
                hearts[i].enabled = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Global.playerHealth <= hearts.Count -1)
        {
             hearts[Global.playerHealth].enabled = false;
        }
      

      
    }

    public static void decreaseHeart(int index){
     
    }

}
