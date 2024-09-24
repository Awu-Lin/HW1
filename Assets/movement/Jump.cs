using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float jumpSpeed = 2f;
    private bool isGround = true;
    Veator3 Amount;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDirection = new Vector3 (input.GetAxis("Horizontal"),0,input.GetAxis("Vertical")).normalized;
        Amount = moveDirection * moveSpeed * Time.deltaTime;

        if (input.GetButtonDown("Jump"))
        {
            if (isGround)
            {
                rb.AddForce(Vector3.up * jumpSpeed);
                isGround = false;
            }
        }
    }

    private void renew()
    {
        rb.MovePosition(rb.position + Amnount);
    }

    private void Collision (Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = true;
        }
    }
}
