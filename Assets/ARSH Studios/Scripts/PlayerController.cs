using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float volume = 0.2f;

    private AudioSource playerSound;
    public bool hasPowerup;
    public int powerUpDuration = 5;
    public float moveSpeed = 5f;


    public AudioSource backgroundMusic;
    public AudioClip pickAlphabet;
    public AudioClip oneHitAlphabet;
    public AudioClip allHitAlphabet;
    private Rigidbody playerRb;
    private float speed = 500;
    private GameObject focalPoint;

    private int charCount = 4;
    void Start()
    {

        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
        playerSound = GetComponent<AudioSource>();
        backgroundMusic.volume = volume; 
    }

    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * verticalInput * speed * Time.deltaTime);
    }

    // If Player collides with powerup, activate powerup

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Char"))
        {
            charCount--;
            Debug.Log(charCount);

            if (charCount != 0)
            {
                playerSound.PlayOneShot(oneHitAlphabet, 1.0f);
            }

            if (charCount == 0)
            {
                playerSound.PlayOneShot(allHitAlphabet, 1.0f);
                Debug.Log("Semua objek 'Char' telah dihancurkan.");
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Char"))
        {
            playerSound.PlayOneShot(pickAlphabet, 1.0f);
            charCount--;
            Debug.Log(charCount);

            if (charCount != 0)
            {
                playerSound.PlayOneShot(oneHitAlphabet, 1.0f);
            }

            if (charCount == 0)
            {
                playerSound.PlayOneShot(allHitAlphabet, 1.0f);
                Debug.Log("Semua objek 'Char' telah dihancurkan.");
            }
        }
    }
    


}
