using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyModel model;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Velocity: " + model.velocity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
