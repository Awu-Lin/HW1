using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float moveSpeed = 3f; 
    private bool isMoving = false; 
    private Rigidbody rb; 

    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isMoving = true;
        }

        if (isMoving)
        {
            rb.velocity = new Vector3(moveSpeed, rb.velocity.y, rb.velocity.z); 
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            rb.AddForce(Vector3.up * 10, ForceMode.Impulse);
        }
    }
}
