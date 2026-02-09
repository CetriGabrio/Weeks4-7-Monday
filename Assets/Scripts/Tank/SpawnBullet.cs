using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;
public class SpawnBullet : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject Barrel;

    public AudioClip spawnSound; 
    public AudioSource audioSource;

    // Update is called once per frame
    void Update()
    {
        if(Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 spawnPos = Barrel.transform.position;
            Instantiate(Bullet, spawnPos, Quaternion.identity);
            audioSource.PlayOneShot(spawnSound);
        }
    }

    void Start()
    {

    }
}
