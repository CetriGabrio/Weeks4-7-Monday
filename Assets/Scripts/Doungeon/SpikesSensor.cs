using UnityEngine;

public class SpikesSensor : MonoBehaviour
{
    public SpriteRenderer hazard;
    public bool isInHazard = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(hazard.bounds.Contains(transform.position) == true)
        {
            if(isInHazard == true)
            {

            }
            else
            {
                isInHazard = true;
                Debug.Log("Spikes");
            }
        }
        else
        {
            if(isInHazard == true)
            {
                isInHazard = false;
                Debug.Log("No Spikes");
            }
            else
            {

            }
        }
    }
}
