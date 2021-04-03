using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocity; // Velocidade que irá ser para mover o jogador
    public GameManager gameManager;
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

        if(gameManager == null)
        {
            gameManager = FindObjectOfType<GameManager>();
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Equals("coin"))
        {
            gameManager.UpdateCoin();
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag.Equals("enemy"))
        {
            gameManager.ShowPanelLose();
        }
    }

}
