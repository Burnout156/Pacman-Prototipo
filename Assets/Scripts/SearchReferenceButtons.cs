using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SearchReferenceButtons : MonoBehaviour
{
    [SerializeField] private GameObject panelLose;
    [SerializeField] private GameObject panelVictory;
    [SerializeField] private GameObject panelTutorial;
    [SerializeField] private GameManager gameManager;

    void Awake()
    {
        if (panelLose == null)
        {
            panelLose = GameObject.Find("PanelLose");
        }

        if (panelVictory == null)
        {
            panelVictory = GameObject.Find("PanelVictory");
        }

        if (panelTutorial == null)
        {
            panelTutorial = GameObject.Find("PanelTutorial");
        }

        if (gameManager == null)
        {
            gameManager = FindObjectOfType<GameManager>();
        }

        SetFunctions();
    }

    public void SetFunctions()
    {
        panelLose.transform.GetChild(1).GetComponent<Button>().onClick.AddListener(gameManager.Restart);
        panelLose.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(gameManager.Menu);
        panelVictory.transform.GetChild(1).GetComponent<Button>().onClick.AddListener(gameManager.NextLevel);
        panelVictory.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(gameManager.Menu);
        panelTutorial.transform.GetChild(6).GetComponent<Button>().onClick.AddListener(gameManager.Play);
    }
}
