using UnityEngine;
using UnityEngine.UI;

//This script handles the slap mechanic for the hand
public class Slap : MonoBehaviour
{
    //Calling the spawner and the hand sprite renderer
    [SerializeField] private CubesSpawner spawner;

    //I had to make this line since my player GameObject is a child of another object
    //With this line, I can make sure the collisions are respected, while also keeping the parents relationship working
    [SerializeField] private SpriteRenderer handRenderer;

    //Calling the rotation slider and slap button from the canvas
    [SerializeField] private Slider rotationSlider;
    [SerializeField] private Button slapButton;

    //The variables for the slap
    [SerializeField] private float maxTilt = 45f;
    [SerializeField] private float slapSpeed = 600f;
    float targetAngle;
    float currentAngle;

    //These bool are to make so the slap brings the hand back to the original rotation of 0
    bool slappingToCenter;
    bool returning;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //To call the slap functions I had two ways
        //Either using the OnClick on the button itself, like we did in class
        //Or add a Listener in code. We practiced the first method in class, so I decided to go for the 2nd option here to challenge myself
        slapButton.onClick.AddListener(Slapping);
    }

    // Update is called once per frame
    void Update()
    {
        //If the player is not slapping the slider controls the rotation
        if (!slappingToCenter && !returning)
        {
            currentAngle = SliderToAngle(rotationSlider.value);
        }
        else
        {
            //However, if it is slapping, than rotate toward the target angle, which is the center
            //A note I want to make here is that I discovered how much stuff can be done with the Mathf
            //We have used this function in class multiple times for rotation. However, I needed something more precise so I did some research
            //I found both Mathf.MoveTowards and Mathf.Approximately, which we haven't mentioned inc lass, but are subtopics of Mathf.
            //https://docs.unity3d.com/6000.3/Documentation/ScriptReference/Mathf.MoveTowards.html
            //MoveTowrrds is similar to Lerp, with the difference that value being changed never goes over the target
            //In my case the target is the 0 rotation, And i did not want the hand to go over it
            //https://docs.unity3d.com/6000.3/Documentation/ScriptReference/Mathf.Approximately.html
            //Approximately, as the name hints at, check if two values are "within a small value of each other"
            //In my case, I wanted to check if the current hand angle was close enough to the target angle, and then perform all the collisions
            //We haven't covered these functions in particular but the assignment guidelines say we are allowed to use Mathf.
            //Therefore, I figure I could use them after learning about them.
            currentAngle = Mathf.MoveTowards(currentAngle, targetAngle, slapSpeed * Time.deltaTime);

            if (Mathf.Approximately(currentAngle, targetAngle))
            {
                //After the action has been performed, return
                if (slappingToCenter)
                {
                    CheckCollisions();
                    slappingToCenter = false;
                    returning = true;
                    targetAngle = SliderToAngle(rotationSlider.value);
                }
                //After returning, reset everything to the original positions
                else if (returning)
                {
                    returning = false;
                    rotationSlider.value = 0.5f; //Rotation slider goes back to the center
                    currentAngle = 0f; //Angle goes back to 0
                }
            }
        }

        //Apply the rotation
        transform.rotation = Quaternion.Euler(0f, 0f, currentAngle);
    }

    //The function to actually perform the slap towards the center
    void Slapping()
    {
        if (slappingToCenter || returning) return;

        slappingToCenter = true;
        targetAngle = 0f;
    }

    //Bringing the slider back to the original value of .5 to have no rotation on the player
    float SliderToAngle(float s)
    {
        return -maxTilt * (2f * s - 1f);
    }

    //This is the important bit that handles the collisions between the hand and the cubes
    //I made it in the slap script so that the collisions are only detected when the player is performing the slap

    //Here I am really detecting the collisions between the player hand and the cubes.
    //The one issue I encountered, that I had not planned, was to detect the direction in which the cube flies after being hit
    //My idea was, if I hit the cube with the right side of the hand, it flies to the right, and vice versa
    //However, after trying for a while, I couldn't get this to work as a I wanted.
    //I did some research and found the .bounds in the Unity Documentation
    //https://docs.unity3d.com/6000.3/Documentation/ScriptReference/Renderer-bounds.html
    //It basically finds the boundaries of the rectangle that surrounds a sprite renderer. 
    //From what I understood, it has a similar behavior to the Mesh Renderer.
    //.center instead is the center point of the sprites.
    //https://docs.unity3d.com/6000.3/Documentation/ScriptReference/Bounds-center.html

    //On the same notice, .intersects also allows to check whether two bounds have interacted with each other.
    //https://docs.unity3d.com/6000.3/Documentation/ScriptReference/Bounds.Intersects.html
    //Once again, I did my research to understand the concept, and realized it's a "subtopic" of .bounds
    //This was essential to check the collisions between the hand and the cubes, as well as the cubes and the barriers for the scoring system

    //I am aware we haven't really covered these particular functions in class
    //However, since its native of the sprite renderer (which we covered in class), I had the idea to try it after doing attentive research on it
    void CheckCollisions()
    {
        if (spawner.currentBlock == null) return;

        //Since I can't use colliders, the collision system is using sprites
        //Basically detecting if what has been collided has the current block sprite renderer
        SpriteRenderer blockSR = spawner.currentBlock.GetComponent<SpriteRenderer>();

        //If it is, perform the action
        if (blockSR != null && handRenderer.bounds.Intersects(blockSR.bounds))
        {
            //Debug.Log("Hit Block!"); this was used for testing

            FallingCubes cube = spawner.currentBlock.GetComponent<FallingCubes>();

            if (cube != null)
            {
                //So, how it works, is that to determine which side was hit, I am comparing the center positions of the sprites.
                float handX = handRenderer.bounds.center.x;
                float blockX = blockSR.bounds.center.x;

                //By comparing the X center of the cube and the X center of the hand
                //I can determine whether the cube is left or right of the player
                float dir = (blockX > handX) ? 1f : -1f;

                //And then move it in the intended direction
                cube.velocity = new Vector2(dir * 6f, 0f); 
            }
        }
    }
}

