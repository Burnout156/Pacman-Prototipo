using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject panelLose;
    public GameObject panelVictory;
    public List<Enemy> enemies; //aqui é para pegar todos os inimigos do mapa e mudar a rota deles
    public TextMeshProUGUI textCoins;
    public int totalCoins; //aqui eu coloquei o total de moedas para tirar a responsabilidade de guardar do jogador 

    void Start()
    {
        if(panelLose == null)
        {
            panelLose = GameObject.Find("PanelLose");
        }

        if(panelVictory == null)
        {
            panelVictory = GameObject.Find("PanelVictory");
        }

        if(textCoins == null)
        {
            textCoins = GameObject.Find("TextCoins").GetComponent<TextMeshProUGUI>();
        }

        enemies.AddRange(GameObject.FindObjectsOfType<Enemy>());
        panelLose.SetActive(false);
        panelVictory.SetActive(false);
        UpdateTextCoin();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void UpdateCoin()
    {
        totalCoins++;
        UpdateTextCoin();
        Pursuit();
    }

    public void Pursuit()
    {
        if(totalCoins == 70)
        {
            foreach(Enemy enemy in enemies)
            {
                enemy.isPursuiting = true;
            }
        }
    }

    public void UpdateTextCoin()
    {
        textCoins.text = "Coins: " + totalCoins;
    }
}
