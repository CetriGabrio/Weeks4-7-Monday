using UnityEngine;
using UnityEngine.UI;

//This script handles the player rotation using the rotation slider
public class PlayerRotate : MonoBehaviour
{
    //calling the rotation slider that is in the canvas
    [SerializeField] private Slider rotationSlider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //To handle the rotation I am using the math working I included in my planning
        //I had to revise the formula slightly to tune the behavior between the player rotation and the slider
        //Overall, the functionality is still the same. Player rotates using the slider
        //When the slider value = 0, then the player is tilting to the left
        //When the slider value = 1, then the player is tilting to the right
        //0.5 is perfectly straight
        float s = rotationSlider.value; 

        float angle = -45f * (2f * s - 1f);

        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}

