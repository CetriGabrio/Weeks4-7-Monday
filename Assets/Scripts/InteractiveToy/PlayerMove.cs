using UnityEngine;
using UnityEngine.UI;

//This script handles the player movement using the movement slider
public class PlayerMove : MonoBehaviour
{
    //calling the movement slider that is in the canvas
    [SerializeField] private Slider movementSlider;

    //the boundaries for the player movement that i can tune in engine
    [SerializeField] private float xMin = -8f;
    [SerializeField] private float xMax = 8f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //To handle the movement I am using the math working I included in my planning
        //the formula is x = Xmin +Sm (Xmax − Xmin)
        //I explained everything in my planning
        //As a quick refresh, player moves using the slider
        //When the slider value = 0, then the player is on the left
        //When the slider value = 1, then the player is on the right
        //0.5 is at the center of the screen
        float s = movementSlider.value;
        float x = xMin + s * (xMax - xMin);

        Vector3 pos = transform.position;
        pos.x = x;
        transform.position = pos;
    }
}
