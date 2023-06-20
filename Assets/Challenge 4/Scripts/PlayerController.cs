using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private float speed = 500;
    private GameObject focalPoint;
    public float volume = 1f;

    private AudioSource playerSound;
    public bool hasPowerup;
    public GameObject powerupIndicator;
    public int powerUpDuration = 5;

    public AudioSource backgroundMusic;
    public AudioClip pickAlphabet;
    public AudioClip oneHitAlphabet;
    public AudioClip allHitAlphabet;

    private float normalStrength = 10; // how hard to hit enemy without powerup
    private float powerupStrength = 25; // how hard to hit enemy with powerup
    private int charCount = 4;
    void Start()
    {
        playerSound = GetComponent<AudioSource>();
        backgroundMusic.volume = volume;
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    void Update()
    {
        // Add force to player in direction of the focal point (and camera)
        float verticalInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * verticalInput * speed * Time.deltaTime); 

        // Set powerup indicator position to beneath player
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.6f, 0);

    }

    // If Player collides with powerup, activate powerup
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
            hasPowerup = true;
            powerupIndicator.SetActive(true);
            StartCoroutine(PowerupCooldown());

        }
    }

    // Coroutine to count down powerup duration
    IEnumerator PowerupCooldown()
    {
        yield return new WaitForSeconds(powerUpDuration);
        hasPowerup = false;
        powerupIndicator.SetActive(false);
    }

    // If Player collides with enemy
    private void OnCollisionEnter(Collision other)
    {

        
        if (other.gameObject.CompareTag("Char"))
        {
            // Rigidbody enemyRigidbody = other.gameObject.GetComponent<Rigidbody>();
            Destroy(other.gameObject);
            charCount--; 
            Debug.Log(charCount);
            playerSound.PlayOneShot(pickAlphabet, 1.0f);
            
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
