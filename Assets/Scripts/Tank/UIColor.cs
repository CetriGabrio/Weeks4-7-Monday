using UnityEngine;
using UnityEngine.UI;
public class UIColor : MonoBehaviour
{
    SpriteRenderer sr;
    //public GameObject tank;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeColor()
    {
        sr.color = Random.ColorHSV();
    }
}
