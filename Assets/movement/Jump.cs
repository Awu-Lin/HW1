using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jump : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float jumpSpeed = 2f;
    public Vector3 initialPosition;  
    public Text failText;           

    private Vector3 amount;
    private Rigidbody rb;
    private bool isStopped = false;  

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialPosition = transform.position;  
        failText.gameObject.SetActive(false);  
    }

    void Update()
    {
        if (isStopped)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                ResetBall();
            }
            return;  
        }
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        amount = moveDirection * moveSpeed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.J))
        {
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        if (!isStopped)
        {
            rb.MovePosition(rb.position + amount);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            StopBall();
        }
    }

    private void StopBall()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        isStopped = true;  
        failText.text = "You failed";
        failText.color = Color.red;
        failText.fontSize = 64;
        failText.gameObject.SetActive(true);  
    }

    private void ResetBall()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = initialPosition;  
        isStopped = false;  
        failText.gameObject.SetActive(false); 
    }
}
