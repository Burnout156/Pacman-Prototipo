using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject panelMainMenu;
    public GameObject panelSelectLevel;

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

        panelSelectLevel.SetActive(false);
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

