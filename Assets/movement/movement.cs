using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float moveSpeed = 1f; 
    private bool isMoving = false; 

    private Jump jumpScript;

    void Start()
    {
        jumpScript = GetComponent<Jump>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isMoving = true;
            jumpScript.StartMoving();  
        }

        if (isMoving)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            var component = GetComponent<Rigidbody2D>();
            component.AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
        }
    }
}
