using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 1f;
    public float deathTime = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, deathTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}
