using UnityEngine;

//This script handles the tutorial spawning with the button
public class Tutorial : MonoBehaviour
{
    //The variables to call the tutorial prefab and canvas
    [SerializeField] private GameObject tutorialPrefab;
    [SerializeField] private Transform canvas;
    private GameObject tutorialBox;

    //As I mentioned in the Slap script, there are 2 ways to call an action with a button
    //Through code or the OnClick function
    //In this case, I used the  OnCLick function on the button itself
    //By doing so, I practiced both methods
    public void SpawnTutorial()
    {
        //If the tutorial box is not on the screen, then spawn it on button click
        if (tutorialBox == null)
        {
            tutorialBox = Instantiate(tutorialPrefab, canvas);
            Time.timeScale = 0f; //Pause the game play in the background
        }
        //If the tutorial box is already on the screen then destroy it on the next button click
        else
        {
            Destroy(tutorialBox);
            tutorialBox = null;
            Time.timeScale = 1f; //Resume the game play
        }
    }
}
