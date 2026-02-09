using UnityEngine;
using UnityEngine.UI;

public class Moving : MonoBehaviour
{
    public float speed = 1f;

    public Slider slider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        slider.minValue = 0;
        slider.maxValue = 10;
    }

    // Update is called once per frame
    void Update()
    {
        speed = slider.value;

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        // Move right (D key)
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }

    public void setSpeed(float value)
    {
        speed = value;
    }
}
