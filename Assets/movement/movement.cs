using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float moveSpeed = 1f; //speed
    private bool isMoving = false; // not yet move


    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        // press start, then move
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isMoving = true;
        }

        if (isMoving)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            var component = transform.GetComponent<Rigidbody2D>();
            component.AddForce(new Vector2(0,10), ForceMode2D.Impulse);
        }
    }
}
