using UnityEngine;
using UnityEngine.InputSystem;

public class Pointing : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        Vector3 direction = mousePos - (Vector2)transform.position;

        transform.up = direction;
    }
}
