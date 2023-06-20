using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    // Start is called before the first frame update

    private Vector3 startPos;
     private float repeatWidth;
     private float rotationSpeed = 10f;

    void Start()
    {
     
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
}
