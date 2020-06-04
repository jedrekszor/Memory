using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
   private TextMeshProUGUI score;

   private void Start()
   {
      score = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
      score.text = PlayerPrefs.GetInt("highScore").ToString();
   }

   public void Play()
   {
      SceneManager.LoadScene("Main");
   }

   public void Quit()
   {
      Application.Quit();
   }
   
   public void changeColorBlindMode()
   {
      Settings.ColorBlindMode = !Settings.ColorBlindMode;
   }

   public void changeParkinsonsMode()
   {
      Settings.ParkinsonsMode = !Settings.ParkinsonsMode;
   }

   public void changeMuteMode()
   {
      Settings.MuteMode = !Settings.MuteMode;
   }
}
