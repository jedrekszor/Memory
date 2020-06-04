using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
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
