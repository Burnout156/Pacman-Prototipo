using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocity = 5; // Velocidade que irá ser para mover o jogador

    private Vector3 direction; //para saber qual direção o jogador quer se mvoer
    private Rigidbody rigidBody;
    [SerializeField] private float horizontal;
    [SerializeField] private float vertical;

    private void Start()
    {
        if(velocity == 0)
        {
            velocity = 5;
        }

        rigidBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");      
        direction = new Vector3(horizontal, 0, vertical);

        Move(direction);
    }

    public void Move(Vector3 moveDirection)
    {
        rigidBody.velocity = (moveDirection * velocity);
    }
  
}
