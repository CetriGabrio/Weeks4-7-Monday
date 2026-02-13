using UnityEngine;

//This is the script for the cubes spawner
public class CubesSpawner : MonoBehaviour
{
    //Variables for all the types of cubes the spawner will have to spawn
    public GameObject redCube;
    public GameObject blueCube;
    public GameObject bomb;

    //Variables for the spawning conditions
    [SerializeField] private float spawnY = 6f; //Spawn position on the Y  
    [SerializeField] private float minX = -8f; //Minimum spawn positon on the X   
    [SerializeField] private float maxX = 8f; //Maximum spawn position on the X   
    [SerializeField] private float cooldown = 0.5f; //Spawn Cooldown

    //Variable for the timer to handle the spawning condition
    private float timer;

    void Update()
    {
        //Code for the timr to spawn cubes on a cooldown
        timer -= Time.deltaTime;

        //When the timer reaches 0
        if (timer <= 0f)
        {
            Spawn(); //Spawn whatever GameObject
            timer = cooldown; //Reset the time and wait the cooldown time before spawning again
        }
    }

    //Code for the actual spawning of the cubes
    private void Spawn()
    {
        //Collect the range of positions on the X set before with the variables and the chosen position on the Y
        float x = Random.Range(minX, maxX);
        Vector3 pos = new Vector3(x, spawnY, 0f);

        //Setting up a random spawn conditions to pick from 3 different possibilities
        //Since arrays are not yet avalable, I did it manually.
        //Just set up a range of 3 options
        int r = Random.Range(0, 3);

        //And spawn the cube that matches the correct option
        if (r == 0) Instantiate(redCube, pos, Quaternion.identity);
        if (r == 1) Instantiate(blueCube, pos, Quaternion.identity);
        if (r == 2) Instantiate(bomb, pos, Quaternion.identity);
    }

}
