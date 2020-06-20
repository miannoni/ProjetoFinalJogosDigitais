using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float MaxSpeed = 20; // velocidade do jogador
    public float gravity = -9.8f; // valor da gravidade
    public float rotate_speed = 70;
    public float smoothingConstant = 0.5f;
    public float grass_speed = 5;
    float speed;
    float to;
    float grassBoost = 0;
    public LayerMask groundMask;
    CharacterController character;
    Vector3 velocity;
    bool isGrounded;
    private int current_cp = 0;
    private int max_cp;
    private GameObject[] cps;
    public int current_lap = 0;
    public int final_lap = 3;
    public GameObject ui_info;
    public int pos = 1;
    public float total_time;
    public float start_time;
    private float[] times;
    private GameObject[] racers;
    private bool ispause = false;
    public GameObject pausemenu;

    void Start()
    {
        pausemenu.SetActive(false);
        racers = GameObject.FindGameObjectsWithTag("Racer");
        times = new float[racers.Length];
        cps = GameObject.FindGameObjectsWithTag("checkpoint");
        foreach (GameObject cp in cps)
        {
            cp.SendMessage("set_current_cp", current_cp);
        }
        max_cp = cps.Length;
        character = gameObject.GetComponent<CharacterController>();

    }

    void Update()
    {

        if (ispause == false) {
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
            speed = Mathf.SmoothStep((float)velocity.x, (float)to, Time.deltaTime);

            // Rotaciona personagem
            transform.Rotate(0, x * rotate_speed * Time.deltaTime, 0);

            // Move personagem
            Vector3 move = transform.forward * speed;
            character.Move(move);

            // Aplica gravidade no personagem
            velocity.y += gravity * Time.deltaTime;
            character.Move(velocity * Time.deltaTime);
            velocity.x = to;

            ui_info.SendMessage("setinfo", new float[] { speed, pos, current_lap, final_lap, grassBoost });

            if (Input.GetKeyDown(KeyCode.P))
            {
                pauseit();
                
            }
        }


    }

    public void Grass(float grass)
    {
        grassBoost = ((grassBoost + grass)/2)*grass_speed;
    }

    void has_passed(int cp_pass)
    {
        if (cp_pass == current_cp)
        {
            current_cp = (current_cp + 1) % max_cp;

            if ((current_cp == 0) & (current_lap == 0))
            {
                start_time = Time.time;
            } else
            {
                total_time = Time.time - start_time;
                //GameObject.FindGameObjectWithTag("positioner").SendMessage("getmypos", total_time);
                foreach (GameObject racer in racers)
                {
                    racer.SendMessage("amBehind");
                    pos = 1;
                }

            }

            if (current_cp == 0)
            {
                current_lap += 1;
            }

            foreach (GameObject cp in cps)
            {
                cp.SendMessage("set_current_cp", current_cp);
            }
        }

    }

    void is_behind(int yes_no)
    {
        pos += yes_no;
    }

    void contin()
    {
        ispause = false;
        pausemenu.SetActive(false);
    }

    void pauseit()
    {
        ispause = true;
        pausemenu.SetActive(true);

        foreach (GameObject racer in GameObject.FindGameObjectsWithTag("Racer"))
        {
            if (racer != gameObject)
            {
                racer.SendMessage("pauseit");
            }
            
        }
    }
}
