using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float jumpSpeed = 2f;
    private bool isGround = true;
    Vector3 Amount;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        Amount = moveDirection * moveSpeed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.J))
        {
            if (isGround)
            {
                rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse); 
                isGround = false; 
            }
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + Amount);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = true; 
        }
    }
}
