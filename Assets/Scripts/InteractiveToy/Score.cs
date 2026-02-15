using UnityEngine;
using TMPro;

//This script handles a very simple scoring system
public class Score : MonoBehaviour
{
    //Calling the spawner
    [SerializeField] private CubesSpawner spawner;

    //Calling the 2 barriers
    [SerializeField] private SpriteRenderer redBarrier; //Red barrier
    [SerializeField] private SpriteRenderer blueBarrier; //Blue barrier

    //Calling the text in the canvas
    [SerializeField] private TMP_Text scoreText;

    //Score is o f integer type as I only what whole numbers
    int score;

    void Update()
    {
        //Checking the score every single frame to check if it needs to be updated
        CheckScore();
    }

    //Here we check the actual score of the game
    void CheckScore()
    {
        if (spawner.currentBlock == null) return;

        //Collision system once again
        //We are obviously calling and using the sprite renderer for the cubes
        //As i explained in the slap script, I am using .intersects to check if the cubes have came in contact with the barriers
        SpriteRenderer blockSR = spawner.currentBlock.GetComponent<SpriteRenderer>();
        FallingCubes cube = spawner.currentBlock.GetComponent<FallingCubes>();

        if (blockSR == null || cube == null) return;

        //The collision with the red barrier 
        if (blockSR.bounds.Intersects(redBarrier.bounds))
        {
            //If the cube is called red
            if (cube.blockType == "red")
            {
                //updates the score by 1
                score++;
                UpdateScore();
            }

            //However, if the block is called bomb
            if (cube.blockType == "bomb")
            {
                //Then remove 1 point from the score
                score--;
                UpdateScore();
            }

            //After colliding, destroy the current block and reset the spawner
            Destroy(spawner.currentBlock);
            spawner.currentBlock = null;
        }

        //The collision with the blue barrier 
        if (blockSR.bounds.Intersects(blueBarrier.bounds))
        {
            //If the cube is called blue
            if (cube.blockType == "blue")
            {
                //updates the score by 1
                score++;
                UpdateScore();
            }

            //However, if the block is called bomb
            if (cube.blockType == "bomb")
            {
                //Then remove 1 point from the score
                score--;
                UpdateScore();
            }

            //After colliding, destroy the current block and reset the spawner
            Destroy(spawner.currentBlock);
            spawner.currentBlock = null;
        }
    }

    //Update the actual text with the right score
    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }
}
