using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float moveSpeed = 1f;      
    public float jumpSpeed = 2f;     
    public Vector3 initialPosition;   

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialPosition = transform.position;  
        rb.freezeRotation = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector3(moveSpeed, rb.velocity.y, 0); 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            ResetBall();
        }
    }
    private void ResetBall()
    {
        rb.velocity = Vector3.zero;  
        rb.angularVelocity = Vector3.zero;  
        transform.position = initialPosition;  
        rb.velocity = new Vector3(moveSpeed, 0, 0);
    }
}
