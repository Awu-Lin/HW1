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

    Vector3 Amount;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialPosition = transform.position; 
        failText.gameObject.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
       
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        Amount = moveDirection * moveSpeed * Time.deltaTime;

        
        if (Input.GetKeyDown(KeyCode.J))
        {
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse); 
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + Amount);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle") 
        {
            Fail();
        }
    }

    private void Fail()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = initialPosition;
        failText.text = "You failed";
        failText.color = Color.red;
        failText.fontSize = 64; 
        failText.gameObject.SetActive(true);
    }
}
