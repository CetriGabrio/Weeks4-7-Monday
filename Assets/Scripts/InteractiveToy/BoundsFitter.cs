using UnityEngine;

//This script handles the bounds at the edge of the screen so they scale with the screen size. 

//I initially made them UI elements to use the Anchor setup, which worked perfectly.
//However, for the scope of this project, I needed the bounds to be GameObjects.
//I was not sure how to recreate the Anchor behavior using code, so I did some research.
//Firstly, I used the official Unity manual and went into the "cameras" section to see if I could find any input.
//https://docs.unity3d.com/Manual/class-Camera.html 
//Overall, what I found that could help is the "cam.orthographicSize".
//This line makes the camera "render objects uniformly, with no sense of perspective." Sounded like what I needed.
//To understand more I did some further research and found this discussion post giving more context regarding the orthographic camera.
//https://discussions.unity.com/t/orthographic-always-better-for-2d/394912
//From what I understood, it eliminates perspective distortion, so it basically allows to display the objects no matter the screen or the resolution (exactly what I needed)
//Apparently it's commonly used for side scrolling games and parallax perspective, but I gave it a try anyway due to its definition.
//I therefore used this concept and it worked just like the Anchor in the UI components.
//We haven't yet covered much about camera works during the semester so I understand this is out of scope.
//However, I wasn't exactly sure on how to solve my issue in other ways. So I identified the problem and came up with a solution.
//In case this is considered out of scope, disabling this script won't affect the overall functionality of the game.

public class BoundsFitter : MonoBehaviour
{
    //The variables for the camera and the 2 bounds
    [SerializeField] private Camera cam;
    [SerializeField] private Transform redBound;
    [SerializeField] private Transform blueBound;

    //The variables for how wide the bounds should be
    [SerializeField] private float boundWorldWidth = 1f;   //Serialize so I can tune them in engine

    //Variable for the last Width and Height of the bounds detected
    int lastW, lastH;

    //I want the bounds to be fixed when the player starts the game, so I put them in Start
    void Start()
    {
        //Using the main camera
        if (cam == null) cam = Camera.main;

        //Call the Camera fix function to fix the bounds to the screen
        CameraFix();
        //Store the current screen resolution
        lastW = Screen.width;
        lastH = Screen.height;
    }

    //I also want to check every frame if the resolution has changed, so I use Update for this
    void Update()
    {
        //Do this process every time the resolution or screen size changes
        if (Screen.width != lastW || Screen.height != lastH)
        {
            lastW = Screen.width;
            lastH = Screen.height;
            CameraFix();
        }
    }

    void CameraFix()
    {
        //Get the camera world position
        float camY = cam.transform.position.y;
        float camX = cam.transform.position.x;

        //Calculate the visible world height and width of the camera
        float halfH = cam.orthographicSize; //This is where the reading I mentioned at the beginning of the script came in handy
        float halfW = halfH * cam.aspect;

        //Calculate the left and right edges of the visible screen in the world space
        float leftX = camX - halfW;  //the left "red" boundary
        float rightX = camX + halfW; //the right "blue"

        //Vertical height of the visible camera
        float height = (halfH * 2f) - (verticalMargin * 2f);

        //Position the bounds at the at edges and center them vertically
        redBound.position = new Vector3(leftX + boundWorldWidth * 0.5f, camY, 0f); //the left "red" boundary
        blueBound.position = new Vector3(rightX - boundWorldWidth * 0.5f, camY, 0f); //the right "blue"

        //Scale the bounds to match the camera height
        redBound.localScale = new Vector3(boundWorldWidth, height, 1f); //the left "red" boundary
        blueBound.localScale = new Vector3(boundWorldWidth, height, 1f); //the right "blue"
    }
}
