using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioClip pickAlphabet;
    public AudioClip oneHitAlphabet;
    public AudioClip allHitAlphabet;
    private AudioSource playerSound; 


    private float rotationSpeed = 10f;

    void Start()
    {
        playerSound = GetComponent<AudioSource>(); 
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion currentRotation = transform.rotation;

        // Menambahkan rotasi baru berdasarkan kecepatan rotasi
        Quaternion newRotation = Quaternion.Euler(currentRotation.eulerAngles + new Vector3(0f, rotationSpeed, 0f) * Time.deltaTime);

        // Mengatur rotasi baru ke transform objek
        transform.rotation = newRotation;
        
        // Melakukan transisi posisi
        
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
        playerSound.PlayOneShot(pickAlphabet, 1.0f);
    }


}
