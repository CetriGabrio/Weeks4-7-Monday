using UnityEngine;
using UnityEngine.UI;

//This script handles the player rotation using the rotation slider
//P.S. I have added this script to a GameObject and made the player its child to make the center of rotation, like we practiced in class
public class PlayerRotate : MonoBehaviour
{
    //calling the rotation slider that is in the canvas
    [SerializeField] private Slider rotationSlider;

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

