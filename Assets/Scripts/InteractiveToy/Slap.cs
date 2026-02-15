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

    //These bools are to make so the slap brings the hand back to the original rotation of 0
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
        return maxTilt * (2f * s - 1f);
    }

    //This is the important bit that handles the collisions between the hand and the cubes
    //I made it in the slap script so that the collisions are only detected when the player is performing the slap
    void CheckCollisions()
    {
        if (spawner.currentBlock == null) return;

        //Since I can't use colliders, the collision system is using sprites
        //Basically detecting if what has been collided has the current block sprite renderer
        SpriteRenderer blockSR = spawner.currentBlock.GetComponent<SpriteRenderer>();

        //IF it is, perform the action
        if (blockSR != null && handRenderer.bounds.Intersects(blockSR.bounds))
        {
            Debug.Log("Hit Block!");
        }
    }


}

