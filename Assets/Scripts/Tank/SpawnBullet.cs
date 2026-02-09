using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;
public class SpawnBullet : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject Barrel;

    public AudioClip spawnSound; 
    public AudioSource audioSource;

    public GameObject spawnPoint;

    // Update is called once per frame
    void Update()
    {
        if(Mouse.current.leftButton.wasPressedThisFrame)
        {
            Instantiate(Bullet, spawnPoint.transform.position, spawnPoint.transform.rotation);
            audioSource.PlayOneShot(spawnSound);
        }
    }

    void Start()
    {

    }
}
