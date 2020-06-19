using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MaxSpeed = 20; // velocidade do jogador
    public float gravity = -9.8f; // valor da gravidade
    public float smoothingConstant = 0.5f;
    float speed;
    float to;
    float grassBoost = 0;
    public LayerMask groundMask;
    CharacterController character;
    Vector3 velocity;
    bool isGrounded;
    void Start()
    {
        character = gameObject.GetComponent<CharacterController>();

    }

    void Update()
    {


        // Verifica se encostando no chão (o centro do objeto deve ser na base)
        isGrounded = Physics.CheckSphere(transform.position, 0.2f, groundMask);

        // Se no chão e descendo, resetar velocidade
        if (isGrounded && velocity.y < 0.0f)
        {
            velocity.y = -1.0f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        to = (z * (MaxSpeed + grassBoost)) * Time.deltaTime;
        speed = Mathf.SmoothStep((float) velocity.x, (float) to, Time.deltaTime);
        //speed = (() - velocity.x * smoothingConstant));
        //print(speed);
        // Rotaciona personagem
        transform.Rotate(0, x * 70 * Time.deltaTime, 0);

        // Move personagem
        Vector3 move = transform.forward * speed;
        character.Move(move);

        // Aplica gravidade no personagem
        velocity.y += gravity * Time.deltaTime;
        character.Move(velocity * Time.deltaTime);
        velocity.x = to;

    }

    public void Grass(float grass)
    {
        grassBoost = grass*grass/3;
    }
}
