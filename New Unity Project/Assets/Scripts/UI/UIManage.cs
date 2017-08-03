using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManage : MonoBehaviour {

    private static UIManage instance;
    public float timeLeft;
    public Text Timer;
    public Text Point;
    public GameObject Set;

    float Mins;
    float Secs;

   public int Score=0;
 

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
 
    public void AddScore(int pluse)
    {
       Score=Score + pluse;
    }

    public void AddTime(int T)
    {
        timeLeft = timeLeft + T;
    }

    void Update()
    {
        Mins = Mathf.FloorToInt(timeLeft / 60f);
        Secs = Mathf.FloorToInt(timeLeft % 60f);
  

        if (timeLeft>0)
        {
          timeLeft -= Time.deltaTime;
    
                Timer.text = "" + Mins + ":" + Secs;
        }

        if(timeLeft==0)
        {
            timeLeft = 0;
        }
    }
}
