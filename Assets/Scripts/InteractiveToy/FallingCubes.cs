using UnityEngine;

//This script handles the movement of the cubes
public class FallingCubes : MonoBehaviour
{
    //Variables for the cubes
    [SerializeField] float fallSpeed = 2f; //Movement speed
    [SerializeField] float destroyY = -3.5f; //Destroy position on the Y

    //This variable is for the velocity at which the cube flies after being hit
    public Vector2 velocity;

    //To avoid using tags, I am giving each block a name using this string variable
    //It is used for the scoring system
    public string blockType;

    void Start()
    {
        
    }

    void Update()
    {
        //Move downward based on the set speed
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);

        //Move in whatever direction at the velocity after being hit
        transform.Translate(velocity * Time.deltaTime);

        //Delete the cubes when it reaches the destroy position
        if (transform.position.y < destroyY)
            Destroy(gameObject);
    }
}
