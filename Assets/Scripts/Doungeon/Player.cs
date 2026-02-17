using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float speed = 2; //how fast the Player moves
    public Vector2 movement; //Player's current speed: will use this to move Player
    Vector2 inputVector; //Current input: will use this to set the animations

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
}
