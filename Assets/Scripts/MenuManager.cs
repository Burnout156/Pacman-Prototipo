﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject panelSplashScreen;
    public GameObject panelMainMenu;
    public GameObject panelSelectLevel;
    public TextMeshProUGUI textScore;

    void Start()
    {
        if(panelMainMenu == null)
        {
            panelMainMenu = GameObject.Find("PanelMenu");
        }

        if (panelSelectLevel == null)
        {
            panelSelectLevel = GameObject.Find("PanelSelectLevel");
        }

        if (panelSplashScreen == null)
        {
            panelSplashScreen = GameObject.Find("PanelSplashScreen");
        }

        if (textScore == null)
        {
            textScore = GameObject.Find("TextScore").GetComponent<TextMeshProUGUI>();
        }

        textScore.text = "Score: " + SaveManager.MainSave.maximunScore;
        panelSplashScreen.SetActive(true);
        panelMainMenu.SetActive(false);
        panelSelectLevel.SetActive(false);
    }

    public void SelectMenu()
    {
        panelSplashScreen.SetActive(false);
        panelMainMenu.SetActive(true);
    }

    public void SelectLevel()
    {
        panelMainMenu.SetActive(false);
        panelSelectLevel.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Level1()
    {
        SceneManager.LoadScene(1);
    }

    public void Level2()
    {
        SceneManager.LoadScene(2);
    }

    public void Menu()
    {
        panelSelectLevel.SetActive(false);
        panelMainMenu.SetActive(true);
    }
}

