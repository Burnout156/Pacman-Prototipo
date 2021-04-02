using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public EnemyModel model;
    public List<GameObject> checkPoints; //aqui é para achar os pontos que o inimigo poderá ir
    public GameObject[] arrayCheckPoints;
    public NavMeshAgent navMesh;
    public Player player;
    public List<int> indexCheckPoints;
    public int indexNow;

    void Start()
    {
        player = FindObjectOfType<Player>();
        navMesh = GetComponent<NavMeshAgent>();
        checkPoints.AddRange(GameObject.FindGameObjectsWithTag("checkpoint"));
        SetPathsRandom();
        navMesh.SetDestination(checkPoints[indexCheckPoints[indexNow]].transform.position);
    }

    public void SetPathsRandom()
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

        arrayCheckPoints = new GameObject[checkPoints.Count];

        for (int contador2 = 0; contador2 < checkPoints.Count - 1; contador2++)
        {
            arrayCheckPoints[contador2] = checkPoints[contador2];
        }
    }

    private void FixedUpdate()
    {
        var distance = Vector3.Distance(checkPoints[indexCheckPoints[indexNow]].transform.position, transform.position);

        if(distance < 0.5f)
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

}
