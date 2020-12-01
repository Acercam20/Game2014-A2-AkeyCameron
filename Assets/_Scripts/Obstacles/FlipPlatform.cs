using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipPlatform : MonoBehaviour
{
    public bool rotated = false;
    public bool inRotation = true;
    public float startDelay = 1.0f;
    public float rotationCycleSpeed = 6.0f; 
    public float rotationSpeed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("RotatePlatform", startDelay, rotationCycleSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        if(inRotation)
        {
            transform.rotation = Quaternion.Euler(Vector3.forward * (transform.eulerAngles.z + rotationSpeed));
            //Debug.Log(transform.eulerAngles.z);
            if(transform.eulerAngles.z >= 179 && rotated == false)
            {
                inRotation = false;
                rotated = true;
            }
            else if (transform.eulerAngles.z <= 1 && rotated == true)
            {
                inRotation = false;
                rotated = false;
            }
        }
    }

    void RotatePlatform()
    {
        inRotation = true;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            Debug.Log("Yubi's stabbed.");
        }
    }
}
