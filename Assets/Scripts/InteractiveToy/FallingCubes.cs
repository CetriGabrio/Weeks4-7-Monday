using UnityEngine;

public class FallingCubes : MonoBehaviour
{
    [SerializeField] float fallSpeed = 2f;
    [SerializeField] float destroyY = -3.5f;
    void Start()
    {
        
    }

    void Update()
    {
        // Move downward
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);

        // Delete when below screen
        if (transform.position.y < destroyY)
            Destroy(gameObject);
    }
}
