using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Animator animatorController;

    public float speed = 2; //how fast the Player moves
    public Vector2 movement; //Player's current speed: will use this to move Player
    Vector2 inputVector; //Current input: will use this to set the animations

    public float maxHealth = 10; //max HP
    public float health = 10; //current HP. If it's 0 she's dead
    public bool isDead = false;
    public UnityEvent<float> SetupHealthbar; //pass max health. Use to set value & max value, show slider
    public UnityEvent<float> UpdateHealthbar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isDead = false;
        health = maxHealth;
        SetupHealthbar.Invoke(maxHealth);
        animatorController = GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        transform.position += (Vector3)movement;
    }

    void GetInput()
    {
        //Get input as a Vector2 where 0 is no input, 1 is input
        inputVector = Vector2.zero;

        if (Keyboard.current.leftArrowKey.isPressed || Keyboard.current.aKey.isPressed)
        {
            //move left
            inputVector.x -= 1;
        }
        if (Keyboard.current.rightArrowKey.isPressed || Keyboard.current.dKey.isPressed)
        {
            //move right
            inputVector.x += 1;
        }
        if (Keyboard.current.upArrowKey.isPressed || Keyboard.current.wKey.isPressed)
        {
            //move up
            inputVector.y += 1;
        }
        if (Keyboard.current.downArrowKey.isPressed || Keyboard.current.sKey.isPressed)
        {
            //move down
            inputVector.y -= 1;
        }

        //multiply input by speed and Time
        movement = inputVector * speed * Time.deltaTime;
    }

    public void TakeDamage(float damage)
    {
        //don't take damage if we're already dead
        if (isDead) return;

        //take damage
        health -= damage;
        UpdateHealthbar.Invoke(health);
        animatorController.SetTrigger("takeDamage");
    }
}
