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
       
    }

    void Update()
    {
        Quaternion currentRotation = transform.rotation;
        Quaternion newRotation = Quaternion.Euler(currentRotation.eulerAngles + new Vector3(0f, rotationSpeed, 0f) * Time.deltaTime);
        transform.rotation = newRotation;
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
    }


}
