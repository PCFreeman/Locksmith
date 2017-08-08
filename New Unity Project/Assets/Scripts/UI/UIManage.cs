using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManage : MonoBehaviour {
    
    public static UIManage instance;


    public float timeLeft;
    public Text Timer;
    public Text Point;
    public GameObject Set;
    public GameObject mGameOverScreen;

    float Mins;
    float Secs;


    public int Score;

    private void Awake()
    {

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

        Time.timeScale = 1f;
        //Start Score
        Score = 0;

        GameObject.Find("Number").GetComponent<Text>().text = Score.ToString();


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
        GameObject.Find("Number").GetComponent<Text>().text = Score.ToString();
    }
    public void AddTime(int T)
    {
        timeLeft = timeLeft + T;
    }

    public void OpenGameOverScreen()
    {
        //GameObject.Find("Canvas").SetActive(false);
        mGameOverScreen.SetActive(true);
        Time.timeScale = 0f;
        GameObject.Find("SettingButton").GetComponent<Button>().enabled = false;
        
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
            OpenGameOverScreen();

            GameObject.Find("FinalScore").GetComponent<Text>().text = "Final Score:   " + Score.ToString();
            GameObject.Find("HighScore").GetComponent<Text>().text = "High Score:   " + Score.ToString();
        }
    }
}
