using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public bool isGrounded;

    public CharacterController controller;
    private Vector3 direction;
    public float speed = 8;
    public float jumpForce = 10;
    public float gravity = -20;
    public float climbSpeed = 5;
    public Transform groundCheck;
    public LayerMask groundLayer;

    //mobile controls
    public Joystick joystick;

    //double jump
    public bool doubleJump = true;
    
    //ladder
    public Transform ladderCheck;
    public LayerMask ladderLayer;
    public float climbingX = 0;
    public float climbingY = 0;
    public float climbingZ = 0;
    

    public Animator animator;
    public Transform model;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    

    // Update is called once per frame
    void Update()
    {
        //when player dies
        if (PlayerManager.gameOver)
        {
            //play death animation
            animator.SetTrigger("die");

            //disable script
            this.enabled = false;
        }
        //when player reaches end
        if (LevelEnd.gameWon)
        {
            animator.SetTrigger("win");
            this.enabled = false;
        }

        //PC input
        //float hInput = Input.GetAxis("Horizontal");

        //mobile input
        float hInput = 0;

        if (joystick.Horizontal >= 0.6f)
        {
            hInput = 1;
        } 
        else if (joystick.Horizontal <= -0.6f)
        {
            hInput = -1;
        }
        else{
            hInput = 0;
        }


        direction.x = hInput * speed;



        animator.SetFloat("speed", Mathf.Abs(hInput));

        //PC ladder
        //float vInput = Input.GetAxis("Vertical");
        //mobile ladder
        float vInput = joystick.Vertical;


        //ladder
        bool isClimbing = Physics.CheckSphere(ladderCheck.position, 0f, ladderLayer);

        if (isClimbing)
        {
            //Debug.Log("player can climb");
            gravity = 0;
            animator.SetBool("isClimbing", true);
            direction.y = vInput * climbSpeed;

            Quaternion climbRotation = Quaternion.LookRotation(new Vector3(climbingX, climbingY, climbingZ));
            model.rotation = climbRotation;

            //model.position = new Vector3(0, 1, 0);
        }
        else
        {
            gravity = -20;
            animator.SetBool("isClimbing", false);

            //rotate player to walking direction
            if(hInput != 0)
            {
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(hInput, 0, 0));
            model.rotation = newRotation;
            }
        }

        //jump
        bool isGrounded = Physics.CheckSphere(groundCheck.position, 0.15f, groundLayer);
        
        animator.SetBool("isGrounded", isGrounded);
        direction.y += gravity * Time.deltaTime;

        if (isGrounded && !Input.GetButtonDown("Jump"))
        {
            doubleJump = false;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (doubleJump || isGrounded)
            {
                
                direction.y = jumpForce;
                doubleJump = !doubleJump;
                Debug.Log("jump");
                Debug.Log(System.Convert.ToInt32(isGrounded));
                
            }
        }

        

        if (isGrounded)
        {
            //Debug.Log("ground");
        }


        //if (isGrounded || doubleJump)
        //{
            //Debug.Log("is grounded");
            //doubleJump = true;
            //gravity = -20;
            //if (Input.GetButtonDown("Jump"))
            //{
                //direction.y = jumpForce;
            //}
        //else
        //{
            //Debug.Log("not grounded");
            //if (doubleJump && Input.GetButtonDown("Jump"))
            //{
                //Debug.Log("double jump");
                //direction.y = jumpForce;
                //doubleJump = false;
            //}
        //}

        //while (isGrounded)
        //{
            //gravity = 0;
        //}

        //}


        //if(vInput !=0)
        //{
        //    Quaternion climbRotation = Quaternion.LookRotation(new Vector3(-1, 0, 0));
        //    model.rotation = climbRotation;
        //}


        controller.Move(direction * Time.deltaTime);

        if (transform.position.z != 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
    }

    //mobile jump
    public void JumpButton()
    {
        if (Physics.CheckSphere(groundCheck.position, 0.15f, groundLayer))
        {
            direction.y = jumpForce;
        }
    }


}
