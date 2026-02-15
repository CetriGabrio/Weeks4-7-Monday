using UnityEngine;

//This is the script for the cubes spawner
public class CubesSpawner : MonoBehaviour
{
    //Variables for all the types of cubes the spawner will have to spawn
    public GameObject redCube;
    public GameObject blueCube;
    public GameObject bomb;

    //This variable instead is to count what cube is currently alive
    //I made this because I want only one cube to be on the screen at a time
    public GameObject currentBlock;

    //Variables for the spawning conditions
    [SerializeField] private float spawnY = 6f; //Spawn position on the Y  
    [SerializeField] private float minX = -8f; //Minimum spawn position on the X   
    [SerializeField] private float maxX = 8f; //Maximum spawn position on the X   
    [SerializeField] private float cooldown = 0.5f; //Spawn cool down

    //Variable for the timer to handle the spawning condition
    private float timer;

    void Update()
    {
        //Code for the timer to spawn cubes on a cool down
        timer -= Time.deltaTime;

        //When the timer reaches 0
        if (timer <= 0f)
        {
            Spawn(); //Spawn whatever GameObject
            timer = cooldown; //Reset the time and wait the cool down time before spawning again
        }
    }

    //Code for the actual spawning of the cubes
    private void Spawn()
    {
        //If a block is already active, do not spawn another one
        if (currentBlock != null) return;

        //Getting the positions to spawn on the x and y axis
        float x = Random.Range(minX, maxX);
        Vector3 pos = new Vector3(x, spawnY, 0f);

        //Since we haven't covered arrays yet, I have to make a manual list with 3 elements
        int r = Random.Range(0, 3);

        //based on what the value of r is, the spawner will spawn a different cube
        if (r == 0) currentBlock = Instantiate(redCube, pos, Quaternion.identity); //the red cube
        if (r == 1) currentBlock = Instantiate(blueCube, pos, Quaternion.identity); //the blue cube
        if (r == 2) currentBlock = Instantiate(bomb, pos, Quaternion.identity); // the bomb
    }
}
