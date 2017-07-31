using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Firstscreen : MonoBehaviour {

    public GameObject LogininMenu;
    public GameObject Mainmenu;
    public GameObject MenuButton;
    public GameObject EndlessWindow;
    public GameObject TimedWindow;
    public GameObject ChallengeWindow;
    public GameObject ZenWindow;
    public GameObject Setting;

    public void Endless()
        {
        MenuButton.SetActive(false);
        EndlessWindow.SetActive(true);
        }//Those are the button in main menu
    public void Timed()
    {
        MenuButton.SetActive(false);
        TimedWindow.SetActive(true);
    }
    public void Challenge()
    {
        MenuButton.SetActive(false);
        ChallengeWindow.SetActive(true);
    }
    public void Zen()
    {
        MenuButton.SetActive(false);
        ZenWindow.SetActive(true);
    }
    public void CloseButton()
    {
            EndlessWindow.SetActive(false);
            TimedWindow.SetActive(false);
            ChallengeWindow.SetActive(false);
            ZenWindow.SetActive(false);
            MenuButton.SetActive(true);
    }
    public void PlayEndless()
    {
        SceneManager.LoadScene(2);
    }//Those are the "Play" button in text window
    public void PlayTimed()
    {
        SceneManager.LoadScene(3);
    }
    public void PlayChallenge()
    {
        SceneManager.LoadScene(1);
    }
    public void PlayZen()
    {
        SceneManager.LoadScene(4);
    }
    public void SettingMenu()
    {
        MenuButton.SetActive(false);
        Setting.SetActive(true);
    }
    void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            LogininMenu.SetActive(false);
            Mainmenu.SetActive(true);
        }

}

}
// Update is called once per frame
