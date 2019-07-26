using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject Victory, Mainmenu, LevelMenu,GameFailed;
    public GameObject[] ballz;
    public Text LevelNoText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Click(string name)
    {
        if(name == "Retry")
        {
            SceneManager.LoadScene(1);
            Player.counter = 0;
            StopAllCoroutines();
        }

        else if (name == "Play")
        {
            Mainmenu.SetActive(false);
            LevelMenu.SetActive(true);
        }

        else if (name == "LevelBack")
        {
            Mainmenu.SetActive(true);
            LevelMenu.SetActive(false);
        }

        else if(name == "Home")
        {
            SceneManager.LoadScene(0);
            Player.counter = 0;
        }

        else if(name == "Next")
        {
            SceneManager.LoadScene(1);
            PlayerPrefs.SetInt("LevelNumber", PlayerPrefs.GetInt("LevelNumber") + 1);
            Player.counter = 0;
        }
    }
}
