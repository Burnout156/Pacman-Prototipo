using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public EnemyModel model;
    public List<GameObject> checkPoints; //aqui é para achar os pontos que o inimigo poderá ir
    public NavMeshAgent navMesh;
    public Player player; //aqui é para pegar o jogador como referencia para ser perseguido a partir de um determinado ponto do jogo
    public List<int> indexCheckPoints; //aqui é para definir quais indexs aleatórios ele vai pegar para buscar no vetor de checkpoints
    public int indexNow;
    public bool isPursuiting; //ele verifica se está perseguindo o jogador

    void Start()
    {
        player = FindObjectOfType<Player>();
        navMesh = GetComponent<NavMeshAgent>();
        checkPoints.AddRange(GameObject.FindGameObjectsWithTag("checkpoint"));
        SetPathsRandom();
        navMesh.speed = model.velocityMax;
        navMesh.SetDestination(checkPoints[indexCheckPoints[indexNow]].transform.position);
    }

    public void SetPathsRandom() //isso é para definir em ordem quais pontos o inimigo vai, sendo de forma aleatória para não ficar fácil
    {
        for(int contador = 0; contador < checkPoints.Count - 1;)
        {
            int randomNumber = Random.Range(0, checkPoints.Count - 1);

            if(!indexCheckPoints.Contains(randomNumber))
            {
                indexCheckPoints.Add(randomNumber);
                contador++;
            }
        }
    }

    public void GoToNextCheckPoint() //aqui é para ele ir ao próximo ponto, caso ele chegue ao ponto anterior
    {
        var distance = Vector3.Distance(checkPoints[indexCheckPoints[indexNow]].transform.position, transform.position);

        if (distance < 0.5f)
        {
            if (indexNow + 1 >= checkPoints.Count - 1)
            {
                indexNow = 0;
                navMesh.destination = (checkPoints[indexCheckPoints[indexNow]].transform.position);
            }

            else
            {
                indexNow++;
                navMesh.destination = (checkPoints[indexCheckPoints[indexNow]].transform.position);
            }
        }
    }

    private void FixedUpdate()
    {
        if (!isPursuiting)
        {
            GoToNextCheckPoint();
        }

        else
        {
            navMesh.destination = player.transform.position;
        }
    }
}
