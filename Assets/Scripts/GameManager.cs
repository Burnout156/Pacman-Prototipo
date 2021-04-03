using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject panelLose;
    [SerializeField] private GameObject panelVictory;
    [SerializeField] private GameObject panelTutorial;
    [SerializeField] private List<Enemy> enemies; //aqui é para pegar todos os inimigos do mapa e mudar a rota deles
    [SerializeField] private List<GameObject> coins; //isso é para saber quantas moedas exatas tem no jogo para que
    [SerializeField] private TextMeshProUGUI textCoins;
    [SerializeField] private int coinsCollected; //aqui eu coloquei o total de moedas para tirar a responsabilidade de guardar do jogador 
    [SerializeField] private int totalCoins; //para saber o total de moedas que estão na fase

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; //isso é para tirar do cache a cena atual e recarregá-la, afim de buscar apenas 1 vez todas as referências
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) //aqui serve para buscar a referência toda a vez que a cena for carregada
    {
        SearchReferences();
    }

    public void SearchReferences() //esse método é para ele procurar as referências quando reiniciar o jogo
    {
        Debug.Log("Executado Referencial");

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

        if (textCoins == null)
        {
            textCoins = GameObject.Find("TextCoins").GetComponent<TextMeshProUGUI>();
        }    

        if (coins.Count == 0)
        {
            coins.AddRange(GameObject.FindGameObjectsWithTag("coin"));
        }

        enemies.Clear();
        enemies.AddRange(GameObject.FindObjectsOfType<Enemy>());
        totalCoins = coins.Count;
        panelLose.SetActive(false);
        panelVictory.SetActive(false);
        UpdateTextCoin();
        textCoins.gameObject.SetActive(false);
        Time.timeScale = 0f;
    }    

    public void Play()
    {
        textCoins.gameObject.SetActive(true);
        panelTutorial.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        HidePanels();
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        Time.timeScale = 1f;

        Debug.Log("SceneManager.GetActiveScene().buildIndex + 1: " + SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("SceneManager.sceneCount: " + SceneManager.sceneCount );

        if (SceneManager.GetActiveScene().buildIndex + 1 < SceneManager.sceneCount )
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        else
        {
            Menu();
        }
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void HidePanels()
    {
        textCoins.gameObject.SetActive(true);
        panelVictory.SetActive(false);
        panelLose.SetActive(false);;
    }

    public void ShowPanelLose()
    {
        CheckMaximumScore();
        textCoins.gameObject.SetActive(false);
        panelLose.SetActive(true);
        panelLose.transform.GetChild(3).GetComponentInChildren<TextMeshProUGUI>().text += coinsCollected;
        coinsCollected = 0;
        totalCoins = 0;
        Time.timeScale = 0f;
    }

    public void CheckMaximumScore()
    {
        if(coinsCollected > SaveManager.MainSave.maximunScore)
        {
            SaveManager.MainSave.maximunScore = coinsCollected;
            SaveManager.Save();
        }
    }

    public void UpdateCoin()
    {
        coinsCollected++;
        UpdateTextCoin();
        Pursuit();
        CheckVictory();
    }

    public void CheckVictory()
    {
        Debug.Log("Chegou aqui");
        Debug.Log("coinsCollected: " + coinsCollected);
        Debug.Log("totalCoins: " + totalCoins);

        if (coinsCollected >= totalCoins)
        {
            ShowPanelVictory();
        }
    }

    public void ShowPanelVictory()
    {
        CheckMaximumScore();
        textCoins.gameObject.SetActive(false);
        panelVictory.SetActive(true);
        panelVictory.transform.GetChild(3).GetComponentInChildren<TextMeshProUGUI>().text += coinsCollected;
        coinsCollected = 0;
        totalCoins = 0;
        Time.timeScale = 0f;
    }

    public void Pursuit()
    {
        if(coinsCollected == 70)
        {
            foreach(Enemy enemy in enemies)
            {
                enemy.isPursuiting = true;
            }
        }
    }

    public void UpdateTextCoin()
    {
        textCoins.text = "Coins: " + coinsCollected;
    }
}
