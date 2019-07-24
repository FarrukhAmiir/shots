using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    GameManager Manager;
    public GameObject LevelButton;
    // Start is called before the first frame update
    void Start()
    {
        Manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        for(int i = 0;i<Manager.Levels.Length;i++)
        {
            GameObject level= Instantiate(LevelButton, transform);
            level.name = i.ToString();
            level.transform.GetChild(0).GetComponent<Text>().text = (i+1).ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LevelClick()
    {
        SceneManager.LoadScene(1);
        PlayerPrefs.SetInt("LevelNumber", Int32.Parse(EventSystem.current.currentSelectedGameObject.name));
    }
}
