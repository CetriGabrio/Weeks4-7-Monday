using UnityEngine;
using UnityEngine.Events;

public class SpikesSensor : MonoBehaviour
{
    public SpriteRenderer hazard;
    public bool isInHazard = false;
    public UnityEvent OnSpikesDetection;
    public UnityEvent OnSpikesUndetection;

    public UnityEvent<float> OnExitRandomNumber;

    public UnityEvent<float> OnSpikesDamage;
    public float spikeDamage = 1f;


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
                //Debug.Log("Spikes");
                OnSpikesDetection.Invoke();
                OnSpikesDamage.Invoke(spikeDamage);
            }
        }
        else
        {
            if(isInHazard == true)
            {
                isInHazard = false;
                //Debug.Log("No Spikes");
                OnSpikesUndetection.Invoke();
                //OnExitRandomNumber.Invoke(Random.Range(0, 10));
            }
            else
            {

            }
        }
    }

    public void ShowNumberInConsole(float number)
    {
        Debug.Log(number);
    }
}
