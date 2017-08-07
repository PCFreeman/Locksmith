using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManage : MonoBehaviour {

    public static UIManage instance;
    public float timeLeft;
    public Text Timer;
    public Text Point;
    public GameObject Set;

    float Mins;
    float Secs;

    public int Score=0;

    private void Awake()
    {
        //Start Score
        GameObject.Find("Number").GetComponent<Text>().text = Score.ToString();

        //Check if instance already exist
        if (instance == null)
        {
            //if not, set instance to this
            instance = this;
        }
        else if (instance != this) //If instance already exists and it's not this:
        {
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a TouchManager.
            Destroy(gameObject);
        }
        //Sets this to not be destroyed when reloading scene
        //DontDestroyOnLoad(gameObject);
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
 
    public void AddScore(int pluse)
    {
       Score=Score + pluse;
        GameObject.Find("Number").GetComponent<Text>().text = Score.ToString();
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
