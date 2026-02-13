using UnityEngine;

public class CubesSpawner : MonoBehaviour
{
    public GameObject redCube;
    public GameObject blueCube;
    public GameObject bomb;

    [SerializeField] private float spawnY = 6f;     
    [SerializeField] private float minX = -8f;     
    [SerializeField] private float maxX = 8f;    
    [SerializeField] private float cooldown = 0.5f;

    private float timer;

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            Spawn();
            timer = cooldown;
        }
    }

    private void Spawn()
    {
        float x = Random.Range(minX, maxX);
        Vector3 pos = new Vector3(x, spawnY, 0f);

        int r = Random.Range(0, 3);

        if (r == 0) Instantiate(redCube, pos, Quaternion.identity);
        if (r == 1) Instantiate(blueCube, pos, Quaternion.identity);
        if (r == 2) Instantiate(bomb, pos, Quaternion.identity);
    }

}
