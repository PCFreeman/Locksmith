using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManage : MonoBehaviour {

    public static UIManage mUiManage = null;

    public float timeLeft;
    public Text Timer;
    public Text Point;
    public GameObject Set;
    public GameObject lose;

    float Mins;
    float Secs;
    public int Score=0;
 
   private void Awake()
    {
        if(mUiManage==null)
        {
           mUiManage = this;
         }
        else if(mUiManage!=this)
        {
            Destroy(gameObject);
        }
    }


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
   public void BacktoMainMenu()
    {
        SceneManager.LoadScene(0);
       
    }
   public void Retry()
    {
        
        SceneManager.LoadScene(2);
     
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
    
                Timer.text = "    " + Mins + ":" + Secs;
        }
        else 
        {
            lose.SetActive(true);
        
        }
    }
}
