using UnityEngine;

public class RandomColor : MonoBehaviour
{

    SpriteRenderer sr;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Randomizer()
    {
        sr.material.color = Random.ColorHSV();
    }
}
