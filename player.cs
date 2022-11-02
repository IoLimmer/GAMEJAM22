using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -18f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private bool isGrounded;

    Vector3 velocity;

    //Bug variables
    public string Xaxis = "Horizontal";
    public string Yaxis = "Vertical";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //checking for ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Moving the player
        float x = Input.GetAxis(Xaxis);
        float z = Input.GetAxis(Yaxis);

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        //Jumping 
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }


        // Gravity application
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }


    void Bug1()
    {
        //fuck with visuals
        //make hitboxes visible
    }
    void Bug2()
    {
        gun gun = GetComponent<gun>();
        gun.impactForce = 0f;
        //can walk through walls
    }

    void Bug3()
    {
        //bugs become stock images of insects
    }

    void Bug4()
    {
        gun gun = GetComponent<gun>();
        gun.damage += 10f;
        gun.accuracy += Random.Range(-10, 10);
        //Beam is less accurate 
        //Beam is more powerful
    }

    void Bug5()
    {
        if(Xaxis == "Horizontal")
        {
            Xaxis = "Vertical";
            Yaxis = "Horizontal";
        }
        else
        {
            Xaxis = "Horizontal";
            Yaxis = "Vertical";
        }

        speed += 5f;
    }

    void Bug6()
    {
        //carameldansen starts playing ominously in the background
    }

    void Bug7()
    {
        //fuck with mouse sensitivity
        Mouselook mouse = GetComponent<Mouselook>();
        mouse.mouseSensitivity += Random.Range(-200, 200);

        //X-ray vision?


    }

    void Bug8()
    {
        //bugs move x2 speed
    }
}
