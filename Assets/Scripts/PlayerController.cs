using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 Scale;

    private CharacterController controller;
    Vector3 direction;
    [SerializeField] private float forwardSpeed=10;
    [SerializeField] private float maxSpeed=50;
    [SerializeField] private float moveSpeed = 2;
    [SerializeField] private float speedFactor=0.5f;
    private float desiredLane = 1;
    [SerializeField] private float laneDistance = 2.5f;
    [SerializeField] private float jumpForce;
    [SerializeField] private float gravity = -10;
    [SerializeField] private Animator myAnimator;
    [SerializeField] private float controllerRadius;

    bool isJumping = false;

    float totalCoins;



    public float life = 1;

    
    bool isCrouched = false;

    static public PlayerController Instance;
    private float animationDuration=2f;
    public float coins;

    private void Awake()
    {
        if(Instance!= null && Instance != this)
        {
            Destroy(Instance);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        Scale = transform.localScale;
        controller = GetComponent<CharacterController>();
        controllerRadius = controller.radius;

    }

    void Update()
    {
        if (!controller.isGrounded)
        {
            direction.y += gravity * Time.deltaTime;
            //moveSpeed = 5f;
            isJumping = true;
        }
        else
        {
            isJumping = false;
        }

        if (Time.time < animationDuration)
        {
            return;
        }
        //Debug.Log(life);

        // Check for life remaining
      /*  if (life <= 0)
        {
            Debug.Log("life in if life==0:" + life);
            PlayerManager.gameOver = true;
        }*/

        //myAnimator.SetBool("isGameStarted", true);


         if (forwardSpeed < maxSpeed)                // player speed will only increase till maxSpeed after which speed becomes constant
         {
               forwardSpeed += speedFactor * Time.deltaTime;  // Increasing player speed with time
         }
        direction.z = forwardSpeed;
        moveSpeed = forwardSpeed;
        

        if(Input.GetKey(KeyCode.UpArrow) && !isCrouched)
        {
            desiredLane = 1;
            PlayerScale();
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && !isCrouched)
        {
            desiredLane--;
            if (desiredLane < 0)
            {
                desiredLane = 0;
            }
        }
        else if(Input.GetKey(KeyCode.RightArrow) && !isCrouched)
        {
            desiredLane++;
            if (desiredLane > 2)
            {
                desiredLane = 2;
            }
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            isCrouched = true;
            transform.localScale = Scale + new Vector3(0, -Scale.y / 2.0f, 0);
            desiredLane = 1;
            controller.radius = controllerRadius / 2.0f;
        }
        else
        {
            isCrouched = false;
            transform.localScale = Scale;
            controller.radius = controllerRadius;
            desiredLane = 1;
        }


        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        //Checking Lanes left = 0 , middle = 1 and right = 2
        if (desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
            PlayerScale();
        }
        else if (desiredLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
            PlayerScale();
        }

        //sDebug.Log(desiredLane);
        transform.position = targetPosition;

        controller.center = controller.center; //fix for the tranform and collider override issue

    }

    //Scaling player
    void PlayerScale()
    {
        transform.localScale = Scale + new Vector3(-Scale.x / 2.0f, Scale.y / 4.0f, 0);
        controller.radius = controllerRadius / 2.0f;
    }


    private void FixedUpdate()
    { 
        controller.Move(direction.normalized*moveSpeed * Time.fixedDeltaTime);
    }

    void OnEnable()
    {
        Coin.CoinCollected += CollectCoin; // subscribing to event "CoinCollected"
    }

    void OnDisable()
    {
        Coin.CoinCollected -= CollectCoin; // unsubscribing to event "CoinCollected"
    }

    void CollectCoin()
    {
        coins++;
        totalCoins = PlayerPrefs.GetFloat("totalCoins") + 1;
        PlayerPrefs.SetFloat("totalCoins", totalCoins);
        Debug.Log("Coin collected! Total coins: " + coins); //function that holds record for how many coins are collected
    }
    //----------------------------------------------------------------- 
    public void Jump()
    {
        direction.y = jumpForce;
        Debug.Log("jump");
        
    }

}
