using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Global : MonoBehaviour
{
   public static bool moving = false;

   public static int playerHealth = 5;

   public static int currentLevel = PlayerPrefs.GetInt("level", 1);

   public static string gameMode ="levels";
   
}
