using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    float timeLeft = 20.0f;

    public Text text;
    public GameObject Set;

    public void settingMenu()
    {
        Set.SetActive(true);
        Time.timeScale = 0f;
    }
   public void SettingMenuBack()
    {
        Set.SetActive(false);
        Time.timeScale = 1f;
    }

    void Update()
    {
       
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            text.text = "" + Mathf.Round(timeLeft);
        }
        else
        {
            //Finish the game
        }
    }
}
