using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float volume = 1f;

    private AudioSource playerSound;
    public bool hasPowerup;
    public int powerUpDuration = 5;

    public AudioSource backgroundMusic;
    public AudioClip pickAlphabet;
    public AudioClip oneHitAlphabet;
    public AudioClip allHitAlphabet;

   
    private int charCount = 4;
    void Start()
    {
        playerSound = GetComponent<AudioSource>();
        backgroundMusic.volume = volume; 
    }

    void Update()
    {  
    }

    // If Player collides with powerup, activate powerup
    void OnTriggerEnter(Collider other)
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
    


}
